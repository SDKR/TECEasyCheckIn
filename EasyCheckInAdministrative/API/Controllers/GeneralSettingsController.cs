using System;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
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
    public class GeneralSettingsController : ControllerBase
    {
        private readonly ILogger<GeneralSettingsController> _logger;
        private readonly IGeneralSettingsRepository _generalSettingsRepository;
        private readonly IMapper _mapper;

        public GeneralSettingsController(ILogger<GeneralSettingsController> logger,
                                         IGeneralSettingsRepository generalSettingsRepository,
                                         IMapper mapper)
        {
            _logger = logger;
            _generalSettingsRepository = generalSettingsRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllGeneralSettings")]
        public async Task<IActionResult> GetAll()
        {
            var allGeneralSettings = await _generalSettingsRepository.GetAllAsync();

            return Ok(allGeneralSettings);
        }

        [HttpGet("{id}", Name = "GetGeneralSetting")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var oneGeneralSetting = await _generalSettingsRepository.GetFirstByExpressionAsync(x => x.Id == id);

            if (oneGeneralSetting == null)
            {
                return NotFound();
            }

            return Ok(oneGeneralSetting);
        }

        [HttpDelete("{id}", Name = "GetGeneralSetting")]
        public async Task<IActionResult> DeleteOne(Guid id)
        {
            var oneGeneralSetting = await _generalSettingsRepository.GetFirstByExpressionAsync(x => x.Id == id);

            if (oneGeneralSetting == null)
            {
                return NotFound();
            }

            _generalSettingsRepository.Delete(oneGeneralSetting);

            if (!await _generalSettingsRepository.SaveAsync())
            {
                _logger.LogError("Failed to delete general setting");
            }

            return Ok(oneGeneralSetting);
        }

        [HttpPost(Name = "CreateGeneralSetting")]
        public async Task<IActionResult> CreateOne([FromBody] GeneralSettingsDto generalSetting)
        {
            var generalSettingToAdd = _mapper.Map<GeneralSettings>(generalSetting);
            generalSettingToAdd.Id = Guid.NewGuid();
            _generalSettingsRepository.Create(generalSettingToAdd);

            if (!await _generalSettingsRepository.SaveAsync())
            {
                _logger.LogError("Failed to create general setting");
            }

            return Ok(generalSettingToAdd);
        }

        [HttpPut("{id}", Name = "UpdateGeneralSetting")]
        public async Task<IActionResult> UpdateOne([FromBody] GeneralSettingsDto generalSettings, [FromRoute] Guid id)
        {
            var generalSettingFromDb = await _generalSettingsRepository.GetFirstByExpressionAsync(x => x.Id == id);

            if (generalSettingFromDb == null)
            {
                return NotFound();
            }

            var bod = _mapper.Map(generalSettings, generalSettingFromDb);
            _generalSettingsRepository.Update(generalSettingFromDb);

            if (!await _generalSettingsRepository.SaveAsync())
            {
                _logger.LogError("Failed to update general setting");
            }

            return Ok(generalSettingFromDb);
        }
    }
}