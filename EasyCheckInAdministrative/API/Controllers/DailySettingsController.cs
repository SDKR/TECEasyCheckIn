using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using API.dto;
using Core.DataInterfaces;
using Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    //[Authorize]
    public class DailySettingsController : ControllerBase
    {
        private readonly ILogger<DailySettingsController> _logger;
        private readonly IDailySettingsRepository _dailySettingsRepository;
        private readonly IMapper _mapper;

        public DailySettingsController(ILogger<DailySettingsController> logger,
                                       IDailySettingsRepository dailySettingsRepository,
                                       IMapper mapper)
        {
            _logger = logger;
            _dailySettingsRepository = dailySettingsRepository;
            _mapper = mapper;
        }

        [HttpGet("defaults/{departmentName}", Name = "GetAllDefaultDailySettings")]
        public async Task<IActionResult> GetAllForDepartment([FromRoute] string departmentName)
        {
            var allDailySettings = await _dailySettingsRepository.GetAllDefaultAsync(departmentName);

            return Ok(allDailySettings);
        }

        [HttpGet("forWeek/{departmentName}", Name = "GetAllDailySettingsForWeek")]
        public async Task<IActionResult> GetAllForDepartmentForSelectedWeek([FromRoute] string departmentName, [FromQuery] string[] selectedDays)
        {
            DateTime[] selectedWeek = Array.ConvertAll(selectedDays, sd =>
            {
                DateTime d = Convert.ToDateTime(sd);
                return d;
            });
            var allDailySettings = await _dailySettingsRepository.GetAllForSelectedWeekAsync(departmentName, selectedWeek);

            return Ok(allDailySettings);
        }

        [HttpGet("{id}", Name = "GetDailySetting")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id)
        {
            var oneDailySetting = await _dailySettingsRepository.GetFirstByExpressionAsync(x => x.Id == id);

            if (oneDailySetting == null)
            {
                return NotFound();
            }

            return Ok(oneDailySetting);
        }

        [HttpPost(Name = "CreateDailySetting")]
        public async Task<IActionResult> CreateOne([FromBody] DailySettingsDto dailySetting)
        {
            var dailySettingToAdd = _mapper.Map<DailySettings>(dailySetting);
            dailySettingToAdd.Id = Guid.NewGuid();
            _dailySettingsRepository.Create(dailySettingToAdd);

            if (!await _dailySettingsRepository.SaveAsync())
            {
                _logger.LogError("Failed to create daily setting");
            }

            return Ok(dailySettingToAdd);
        }

        [HttpPut("{id}", Name = "UpdateDailySetting")]
        public async Task<IActionResult> UpdateOne([FromBody] DailySettingsDto dailySettings, [FromRoute] Guid id)
        {
            DailySettings dailySettingToReturn;
            var dailySettingFromDb = await _dailySettingsRepository.GetFirstByExpressionAsync(x => x.Id == id);

            if (dailySettingFromDb == null)
            {
                dailySettingToReturn = _mapper.Map<DailySettings>(dailySettings);
                dailySettingToReturn.Id = Guid.NewGuid();
                _dailySettingsRepository.Create(dailySettingToReturn);
            } else
            {
                dailySettingToReturn = _mapper.Map(dailySettings, dailySettingFromDb);
                _dailySettingsRepository.Update(dailySettingToReturn);
            }

            if (!await _dailySettingsRepository.SaveAsync())
            {
                _logger.LogError("Failed to update daily settings");
            }

            return Ok(dailySettingToReturn);
        }

        [HttpPut(Name = "UpdateDailySettingList")]
        public async Task<IActionResult> UpdateList([FromBody] List<DailySettingsDto> dailySettings)
        {
            List<DailySettings> dailySettingsToReturn = new List<DailySettings>(dailySettings.Count);
            foreach (var setting in dailySettings)
            {
                // TODO: check if defaultdailysetting is same as dailysetting being created,
                //       care if dailySetting already exists with other settings,
                //       use GetAllDefaultAsync
                
                var dailySettingFromDb = await _dailySettingsRepository.GetFirstByExpressionAsync(x => x.Id == setting.Id);
                if (dailySettingFromDb == null)
                {
                    var dailySettingToAdd = _mapper.Map<DailySettings>(setting);
                    dailySettingToAdd.Id = Guid.NewGuid();
                    _dailySettingsRepository.Create(dailySettingToAdd);
                    dailySettingsToReturn.Add(dailySettingToAdd);
                }
                else
                {
                    var dailySettingToUpdate = _mapper.Map(setting, dailySettingFromDb);
                    _dailySettingsRepository.Update(dailySettingToUpdate);
                    dailySettingsToReturn.Add(dailySettingToUpdate);
                }
            }

            if (!await _dailySettingsRepository.SaveAsync())
            {
                _logger.LogError("Failed to update daily settings");
            }

            return Ok(dailySettingsToReturn);
        }

        [HttpDelete("{id}", Name = "DeleteDailySetting")]
        public async Task<IActionResult> DeleteOne([FromRoute] Guid id)
        {
            var oneDailySetting = await _dailySettingsRepository.GetFirstByExpressionAsync(x => x.Id == id);

            if (oneDailySetting == null)
            {
                return NotFound();
            }

            _dailySettingsRepository.Delete(oneDailySetting);

            if (!await _dailySettingsRepository.SaveAsync())
            {
                _logger.LogError("Failed to delete daily setting");
            }

            return Ok(oneDailySetting);
        }
    }
}