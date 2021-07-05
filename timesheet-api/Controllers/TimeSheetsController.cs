using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VegaITPraksa.DTO;
using VegaITPraksa.Models;
using VegaITPraksa.Services;

namespace VegaITPraksa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSheetsController : ControllerBase
    {

        private readonly ITimeSheetService _timeSheetService;
        private readonly IMapper _mapper;

        public TimeSheetsController(ITimeSheetService timeSheetService, IMapper mapper)
        {
            _timeSheetService = timeSheetService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TimeSheetDTO>> GetAllTimeSheets()
        {
            var timeSheet = await _timeSheetService.Get();
            var mapperTimeSheet = _mapper.Map<TimeSheetDTO[]>(timeSheet);
            return mapperTimeSheet;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TimeSheetDTO>> GetTimeSheet(int id)
        {
            var timeSheet = await _timeSheetService.Get(id);
            var mapperTimeSheet = _mapper.Map<TimeSheetDTO>(timeSheet);
            return mapperTimeSheet;
        }

        [HttpPost]
        public async Task<ActionResult<TimeSheetDTO>> PostTimeSheet(TimeSheetDTO timeSheetDto)
        {
            var mapperTimeSheet = _mapper.Map<TimeSheet>(timeSheetDto);
            var newTimeSheet = await _timeSheetService.Create(mapperTimeSheet);

            return CreatedAtAction(nameof(GetTimeSheet), new { id = newTimeSheet.TimeSheetId }, newTimeSheet);
        }

        [HttpPut]
        public async Task<ActionResult> PutTimeSheet(int id, TimeSheetDTO timeSheetDto)
        {
            if (id != timeSheetDto.TimeSheetId)
            {
                return BadRequest();
            }

            var mapperTimeSheet = _mapper.Map<TimeSheet>(timeSheetDto);

            await _timeSheetService.Update(mapperTimeSheet);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTimeSheet(int id)
        {
            var timeSheetToDelete = await _timeSheetService.Get(id);
            if (timeSheetToDelete == null)
                return NotFound();

            await _timeSheetService.Delete(timeSheetToDelete.TimeSheetId);
            return NoContent();
        }
    }
}
