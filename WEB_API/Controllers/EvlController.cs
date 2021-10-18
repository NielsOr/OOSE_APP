using LOGIC.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WEB_API.Schemas.Evl;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvlController : ControllerBase
    {
        private readonly IEvlService _evlService;

        public EvlController(IEvlService evlService)
        {
            _evlService = evlService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetEvls()
        {
            var result = await _evlService.GetEvls();
            return result.Success == true ? Ok(result) : StatusCode(500, result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetEvlById(int id)
        {
            var result = await _evlService.GetEvlById(id);
            return result.Success == true ? Ok(result) : StatusCode(500, result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddEvl(CreateEvlSchema evl)
        {
            var result = await _evlService.AddEvl(evl.Code, evl.Naam, evl.Beroepstaken, evl.Eindkwalificaties, evl.Beschrijving, evl.Studiepunten);
            return result.Success == true ? Ok(result) : StatusCode(500, result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateEvl(UpdateEvlSchema evl)
        {
            var result = await _evlService.UpdateEvl(evl.Id, evl.Code, evl.Naam, evl.Beroepstaken, evl.Eindkwalificaties, evl.Beschrijving, evl.Studiepunten);
            return result.Success == true ? Ok(result) : StatusCode(500, result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteEvl(int id)
        {
            var result = await _evlService.DeleteEvl(id);
            return result.Success == true ? Ok(result) : StatusCode(500, result);
        }

        /*[HttpPost]
        [Route("[action]")]
        //deze actie bij LeeruitkomstService of EvlService uitvragen?
        public async Task<IActionResult> AddLeeruitkomstToEvl(int evlId, LeeruitkomstCreateApiModel leeruitkomst)
        {
            var result = await _leeruitkomstService.AddLeeruitkomstToEvl(evlId, leeruitkomst.Naam, leeruitkomst.Beschrijving);
            return result.success == true ? Ok(result) : StatusCode(500, result);
        }*/
    }
}
