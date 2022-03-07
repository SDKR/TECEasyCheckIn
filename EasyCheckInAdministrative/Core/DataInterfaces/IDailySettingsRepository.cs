using Core.DataInterfaces.Base;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.DataInterfaces
{
    public interface IDailySettingsRepository : IRepository<DailySettings>
    {
        Task<IEnumerable<DailySettings>> GetAllDefaultAsync(string departmentName);
        Task<IEnumerable<DailySettings>> GetAllForSelectedWeekAsync(string departmentName, DateTime[] selectedWeek);
        IEnumerable<DailySettings> CreateDefaultsForDepartment(Guid departmentId);
        Task<DailySettings> CreateSettingsForToday(Guid departmentId, DateTime date);
    }
}
