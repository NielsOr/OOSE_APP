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
    public class TentamineringController : ControllerBase
    {
        private readonly ITentamineringService _tentamineringService;
        private readonly IMapper _mapper;

        public TentamineringController(ITentamineringService tentamineringService, IMapper mapper)
        {
            _tentamineringService = tentamineringService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateTentaminering(CreateTentamineringRequest request)
        {
            var result = await _tentamineringService.CreateTentaminering(_mapper.Map<Tentaminering>(request));
            return result.Success == true ? Ok(_mapper.Map<TentamineringResponse>(result.ResultSet)) : StatusCode(500, result.Message);
        }

        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> ReadTentaminering(int id)
        {
            var result = await _tentamineringService.ReadTentaminering(id);
            return result.Success == true ? Ok(_mapper.Map<TentamineringResponse>(result.ResultSet)) : StatusCode(500, result.Message);
        }

        [HttpPut]
        [Route("{id?}")]
        public async Task<IActionResult> UpdateTentaminering(int id, UpdateTentamineringRequest request)
        {
            var result = await _tentamineringService.UpdateTentaminering(id, _mapper.Map<Tentaminering>(request));
            return result.Success == true ? Ok(_mapper.Map<TentamineringResponse>(result.ResultSet)) : StatusCode(500, result.Message);
        }

        [HttpDelete]
        [Route("{id?}")]
        public async Task<IActionResult> DeleteTentaminering(int id)
        {
            var result = await _tentamineringService.DeleteTentaminering(id);
            return result.Success == true ? Ok(result.Message) : StatusCode(500, result.Message);
        }

        /*        [HttpGet("{id}/Rubrics/{contentType}")]
                public async Task<IActionResult> DownloadRubrics(int id, int contentType)
                {
                    var result = await _tentamineringService.DownloadRubrics(id, contentType);
                    return result.Success == true ? File(result.ResultSet.Content, result.ResultSet.ContentType, result.ResultSet.FileName) : StatusCode(500, result.Message);
                }*/
    }
}
