using AutoMapper;
using LOGIC.Interfaces.Services;
using LOGIC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WEB_API.ApiModels;

namespace WEB_API.ApiControllers
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

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateLeeruitkomst(CreateLeeruitkomstRequest request)
        {
            var result = await _leeruitkomstService.CreateLeeruitkomst(_mapper.Map<Leeruitkomst>(request));
            return result.Success == true ? Ok(_mapper.Map<LeeruitkomstResponse>(result.ResultSet)) : StatusCode(500, result.Message);
        }

        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> ReadLeeruitkomst(int id)
        {
            var result = await _leeruitkomstService.ReadLeeruitkomst(id);
            return result.Success == true ? Ok(_mapper.Map<LeeruitkomstResponse>(result.ResultSet)) : StatusCode(500, result.Message);
        }

        [HttpPut]
        [Route("{id?}")]
        public async Task<IActionResult> UpdateLeeruitkomst(int id, UpdateLeeruitkomstRequest request)
        {
            var result = await _leeruitkomstService.UpdateLeeruitkomst(id, _mapper.Map<Leeruitkomst>(request));
            return result.Success == true ? Ok(_mapper.Map<LeeruitkomstResponse>(result.ResultSet)) : NoContent();
        }

        [HttpDelete]
        [Route("{id?}")]
        public async Task<IActionResult> DeleteLeeruitkomst(int id)
        {
            var result = await _leeruitkomstService.DeleteLeeruitkomst(id);
            return result.Success == true ? Ok(result.Message) : StatusCode(500, result.Message);
        }
    }
}
