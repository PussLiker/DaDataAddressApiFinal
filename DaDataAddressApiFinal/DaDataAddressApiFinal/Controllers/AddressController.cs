using AutoMapper;
using DaDataAddressApiFinal.Clients;
using DaDataAddressApiFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace DaDataAddressApiFinal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly ICleanAddressClient _client;
        private readonly IMapper _mapper;

        public AddressController(ICleanAddressClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string query)
        {
            var cleaned = await _client.CleanAddressAsync(query);
            var mapped = _mapper.Map<AddressResponse>(cleaned);
            return Ok(mapped);
        }
    }
}
