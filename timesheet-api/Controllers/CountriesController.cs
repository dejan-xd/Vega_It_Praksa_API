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
    public class CountriesController : ControllerBase
    {

        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountriesController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CountryDTO>> GetAllCountries()
        {
            var country = await _countryService.Get();
            var mapperCountry = _mapper.Map<CountryDTO[]>(country);

            return mapperCountry;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDTO>> GetCountry(int id)
        {
            var country = await _countryService.Get(id);
            var mapperCountry = _mapper.Map<CountryDTO>(country);

            return mapperCountry;
        }

        [HttpPost]
        public async Task<ActionResult<CountryDTO>> PostCountry(CountryDTO countryDto)
        {
            var mapperCountry = _mapper.Map<Country>(countryDto);
            var newCountry = await _countryService.Create(mapperCountry);

            return CreatedAtAction(nameof(GetCountry), new { id = newCountry.CountryId }, newCountry);
        }

        [HttpPut]
        public async Task<ActionResult> PutCountry(int id, CountryDTO countryDto)
        {
            if (id != countryDto.CountryId)
            {
                return BadRequest();
            }

            var mapperCountry = _mapper.Map<Country>(countryDto);

            await _countryService.Update(mapperCountry);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCountry(int id)
        {
            var countryToDelete = await _countryService.Get(id);
            if (countryToDelete == null)
                return NotFound();

            await _countryService.Delete(countryToDelete.CountryId);
            return NoContent();
        }
    }
}
