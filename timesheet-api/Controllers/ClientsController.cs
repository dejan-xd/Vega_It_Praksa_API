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
    public class ClientsController : ControllerBase
    {

        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientsController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ClientDTO>> GetAllClients()
        {
            var client = await _clientService.Get();
            var mapperClient = _mapper.Map<ClientDTO[]>(client);

            return mapperClient;
            //return await _clientService.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> GetClient(int id)
        {
            var client = await _clientService.Get(id);
            var mapperClient = _mapper.Map<ClientDTO>(client);

            return mapperClient;
            //return await _clientService.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<ClientDTO>> PostClient(ClientDTO clientDto)
        {
            var mapperClient = _mapper.Map<Client>(clientDto);
            var newClient = await _clientService.Create(mapperClient);

            return CreatedAtAction(nameof(GetClient), new { id = newClient.ClientId }, newClient);
        }

        [HttpPut]
        public async Task<ActionResult> PutClient(int id, ClientDTO clientDto)
        {
            if (id != clientDto.ClientId)
            {
                return BadRequest();
            }

            var mapperClient = _mapper.Map<Client>(clientDto);

            await _clientService.Update(mapperClient);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteClient(int id)
        {
            var clientToDelete = await _clientService.Get(id);
            if (clientToDelete == null)
                return NotFound();

            await _clientService.Delete(clientToDelete.ClientId);
            return NoContent();
        }
    }
}
