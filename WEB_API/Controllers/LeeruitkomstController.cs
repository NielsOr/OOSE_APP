using AutoMapper;
using LOGIC.Interfaces;
using LOGIC.Interfaces.Services;
using LOGIC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WEB_API.Schemas.Leeruitkomst;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeeruitkomstController : ControllerBase
    {
        private readonly ILeeruitkomstService _leeruitkomstService;
        private readonly IMapper _mapper;

        public LeeruitkomstController(ILeeruitkomstService leeruitkomstService, IMapper mapper)
        {
            _leeruitkomstService = leeruitkomstService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetLeeruitkomstById(int id)
        {
            var result = await _leeruitkomstService.GetLeeruitkomstById(id);
            return result.Success == true ? Ok(_mapper.Map<LeeruitkomstResponse>(result.ResultSet)) : StatusCode(500, result.Message);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetLeeruitkomstenByEvlId(int evlId)
        {
            var result = await _leeruitkomstService.GetLeeruitkomstenByEvlId(evlId);
            return result.Success == true ? Ok(_mapper.Map<List<LeeruitkomstResponse>>(result.ResultSet)) : StatusCode(500, result.Message);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddLeeruitkomst(CreateLeeruitkomstSchema schema)
        {
            var result = await _leeruitkomstService.AddLeeruitkomst(_mapper.Map<Leeruitkomst>(schema));
            return result.Success == true ? Ok(_mapper.Map<LeeruitkomstResponse>(result.ResultSet)) : StatusCode(500, result.Message);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateLeeruitkomst(UpdateLeeruitkomstSchema schema)
        {
            var result = await _leeruitkomstService.UpdateLeeruitkomst(_mapper.Map<Leeruitkomst>(schema));
            return result.Success == true ? Ok(_mapper.Map<LeeruitkomstResponse>(result.ResultSet)) : StatusCode(500, result.Message);
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteLeeruitkomst(int id)
        {
            var result = await _leeruitkomstService.DeleteLeeruitkomst(id);
            return result.Success == true ? Ok(result.Message) : StatusCode(500, result.Message);
        }
    }
}
