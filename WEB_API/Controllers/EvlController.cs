using AutoMapper;
using LOGIC.Interfaces;
using LOGIC.Interfaces.Services;
using LOGIC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WEB_API.Schemas.Evl;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvlController : ControllerBase
    {
        private readonly IEvlService _evlService;
        private readonly IMapper _mapper;

        public EvlController(IEvlService evlService, IMapper mapper)
        {
            _evlService = evlService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetEvls()
        {
            var result = await _evlService.GetEvls();
            return result.Success == true ? Ok(_mapper.Map<List<BasicEvlResponse>>(result.ResultSet)) : StatusCode(500, result.Message);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetEvlById(int id)
        {
            var result = await _evlService.GetEvlById(id);
            return result.Success == true ? Ok(_mapper.Map<EvlResponse>(result.ResultSet)) : StatusCode(500, result.Message);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddEvl(CreateEvlSchema schema)
        {
            var result = await _evlService.AddEvl(_mapper.Map<Evl>(schema));
            return result.Success == true ? Ok(_mapper.Map<EvlResponse>(result.ResultSet)) : StatusCode(500, result.Message);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateEvl(UpdateEvlSchema schema)
        {
            var result = await _evlService.UpdateEvl(_mapper.Map<Evl>(schema));
            return result.Success == true ? Ok(_mapper.Map<EvlResponse>(result.ResultSet)) : StatusCode(500, result.Message);
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteEvl(int id)
        {
            var result = await _evlService.DeleteEvl(id);
            return result.Success == true ? Ok(result.Message) : StatusCode(500, result.Message);
        }

    }
}
