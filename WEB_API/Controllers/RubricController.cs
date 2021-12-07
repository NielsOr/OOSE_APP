using AutoMapper;
using LOGIC.Interfaces.Services;
using LOGIC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WEB_API.Contracts.Rubric;
using WEB_API.Contracts.RubricCriterium;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RubricController : ControllerBase
    {
        private readonly IRubricService _rubricService;
        private readonly IMapper _mapper;

        public RubricController(IRubricService rubricService, IMapper mapper)
        {
            _rubricService = rubricService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateRubric(CreateRubricRequest request)
        {
            var result = await _rubricService.CreateRubric(_mapper.Map<Rubric>(request));
            return result.Success == true ? base.Ok(_mapper.Map<RubricResponse>(result.ResultSet)) : base.StatusCode(500, result.Message);
        }

        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> ReadRubric(int id)
        {
            var result = await _rubricService.ReadRubric(id);
            return result.Success == true ? Ok(_mapper.Map<RubricResponse>(result.ResultSet)) : StatusCode(500, result.Message);
        }

        [HttpPut]
        [Route("{id?}")]
        public async Task<IActionResult> UpdateRubric(int id, UpdateRubricRequest request)
        {
            var result = await _rubricService.UpdateRubric(id, _mapper.Map<Rubric>(request));
            return result.Success == true ? base.Ok(_mapper.Map<RubricResponse>(result.ResultSet)) : base.StatusCode(500, result.Message);
        }

        [HttpDelete]
        [Route("{id?}")]
        public async Task<IActionResult> DeleteRubric(int id)
        {
            var result = await _rubricService.DeleteRubric(id);
            return result.Success == true ? Ok(result.Message) : StatusCode(500, result.Message);
        }

/*        [HttpPost]
        [Route("{id?}/Criterium")]
        public async Task<IActionResult> AddRubricCriterium(int id, RubricCriteriumContract request)
        {
            var result = await _rubricService.AddRubricCriterium(id, _mapper.Map<RubricCriterium>(request));
            return result.Success == true ? base.Ok(_mapper.Map<RubricResponse>(result.ResultSet)) : base.StatusCode(500, result.Message);
        }

        [HttpDelete]
        [Route("{id?}/Criterium/{criteriumId?}")]
        public async Task<IActionResult> RemoveRubricCriterium(int id, int criteriumId)
        {
            var result = await _rubricService.RemoveRubricCriterium(id, criteriumId);
            return result.Success == true ? Ok(_mapper.Map<RubricResponse>(result.ResultSet)) : StatusCode(500, result.Message);
        }*/

    }
}
