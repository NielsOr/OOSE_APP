using AutoMapper;
using LOGIC.Interfaces.Services;
using LOGIC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WEB_API.ApiModels;

namespace WEB_API.ApiControllers
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

        //201 (Created), ‘Location’ header with link to the new resource containing new ID
        //200 (OK)
        //204 (No Content)
        //TEST
        //TEST2
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateEvl(EvlRequest request)
        {
            var result = await _evlService.CreateEvl(_mapper.Map<Evl>(request));
            return result.Success == true ? Ok(_mapper.Map<EvlResponse>(result.ResultSet)) : StatusCode(500, result.Message);
        }

        //200 (OK)
        //404 (NOT FOUND)
        //400 (BAD REQUEST)
        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> ReadEvl(int id)
        {
            var result = await _evlService.ReadEvl(id);
            return result.Success == true ? Ok(_mapper.Map<EvlResponse>(result.ResultSet)) : StatusCode(500, result.Message);
        }

        //200 (OK)
        //204 (No Content) 
        [HttpPut]
        [Route("{id?}")]
        public async Task<IActionResult> UpdateEvl(int id, EvlRequest request)
        {
            var result = await _evlService.UpdateEvl(id, _mapper.Map<Evl>(request));
            return result.Success == true ? Ok(_mapper.Map<EvlResponse>(result.ResultSet)) : StatusCode(500, result.Message);
        }

        //code 200 (OK)
        //404 (NOT FOUND)
        [HttpDelete]
        [Route("{id?}")]
        public async Task<IActionResult> DeleteEvl(int id)
        {
            var result = await _evlService.DeleteEvl(id);
            return result.Success == true ? Ok(result.Message) : StatusCode(500, result.Message);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> ReadAll()
        {
            var result = await _evlService.ReadAllEvls();
            return result.Success == true ? Ok(_mapper.Map<List<EvlResponse>>(result.ResultSet)) : StatusCode(500, result.Message);
        }

        [HttpPost]
        [Route("{id}/revisie")]
        public async Task<IActionResult> CreateRevisie(int id)
        {
            var result = await _evlService.CreateRevisie(id);
            return result.Success == true ? Ok(result.ResultSet) : StatusCode(500, result.Message);
        }

        [HttpGet]
        [Route("{id}/revisie")]
        public async Task<IActionResult> GetRevisiesByEvlId(int id)
        {
            var result = await _evlService.GetRevisiesByEvlId(id);
            return result.Success == true ? Ok(result.ResultSet) : StatusCode(500, result.Message);
        }

        /*        [HttpGet("{id}/Rubrics/{contentType}")]
                public async Task<IActionResult> DownloadRubrics(int id, int contentType)
                {
                    var result = await _tentamineringService.DownloadRubrics(id, contentType);
                    return result.Success == true ? File(result.ResultSet.Content, result.ResultSet.ContentType, result.ResultSet.FileName) : StatusCode(500, result.Message);
                }*/

    }
}
