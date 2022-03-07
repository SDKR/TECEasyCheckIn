using Core.DataInterfaces;
using Core.Model;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DailySettingsRepository : RepositoryBase<DailySettings>, IDailySettingsRepository
    {
        public DailySettingsRepository(ECADbContext context) : base(context)
        {

        }

        // default settings are set to these days
        private DateTime[] defaultDays = new DateTime[] {
                new DateTime(0001, 1, 1),
                new DateTime(0001, 1, 2),
                new DateTime(0001, 1, 3),
                new DateTime(0001, 1, 4),
                new DateTime(0001, 1, 5)
            };

        public async Task<IEnumerable<DailySettings>> GetAllDefaultAsync(string departmentName)
        {    
            return await _context.DailySettings.Where(ds => ds.Department.Name == departmentName && defaultDays.Contains(ds.Date))
                            .OrderBy(ds => ds.Date).ToListAsync();
        }

        public async Task<IEnumerable<DailySettings>> GetAllForSelectedWeekAsync(string departmentName, DateTime[] selectedWeek)
        {
            return await _context.DailySettings.Where(ds => ds.Department.Name == departmentName && selectedWeek.Contains(ds.Date))
                            .OrderBy(ds => ds.Date).ToListAsync();
        }

        public IEnumerable<DailySettings> CreateDefaultsForDepartment(Guid departmentId)
        {
            List<DailySettings> dailySettingsToCreate = new List<DailySettings>(defaultDays.Length);
            foreach (var date in defaultDays)
            {
                dailySettingsToCreate.Add(new DailySettings()
                {
                    Id = Guid.NewGuid(),
                    Date = date,
                    LastestCheckInTimeStamp = new DateTimeOffset(date.Year, date.Month, date.Day, 7, 30, 0, new TimeSpan(+2, 0, 0)),
                    EarliestCheckOutTimeStamp = new DateTimeOffset(date.Year, date.Month, date.Day, 15, 0, 0, new TimeSpan(+2, 0, 0)),
                    DepartmentId = departmentId
                });
            }
            _context.DailySettings.AddRange(dailySettingsToCreate);

            return dailySettingsToCreate;
        }


        public async Task<DailySettings> CreateSettingsForToday(Guid departmentId, DateTime date)
        {
            DateTime dayOfWeek = new DateTime();
            foreach (var day in defaultDays)
            {
                if (day.DayOfWeek == date.DayOfWeek)
                {
                    dayOfWeek = day;
                }
            }
            var setting = await _context.DailySettings.Where(ds => ds.DepartmentId == departmentId && ds.Date == dayOfWeek.Date).FirstOrDefaultAsync();
            if (setting == null)
            {
                return null;
            }
            DailySettings settingToAdd = new DailySettings()
            {

                Id = Guid.NewGuid(),
                Date = date,
                // Add check in and out times from setting times, but use date parameter for the date of the setting.
                LastestCheckInTimeStamp = date + setting.LastestCheckInTimeStamp.TimeOfDay,
                EarliestCheckOutTimeStamp = date + setting.EarliestCheckOutTimeStamp.TimeOfDay,
                DepartmentId = departmentId
            };

            return settingToAdd;

        }
    }
}