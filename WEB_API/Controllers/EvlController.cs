
using LOGIC.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvlController : ControllerBase
    {
        private IEvlService _EvlService;

        public EvlController(IEvlService evl_Service)
        {
            _EvlService = evl_Service;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetEvls()
        {
            var result = await _EvlService.GetEvls();
            return result.Success == true ? Ok(result) : StatusCode(500, result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetEvlById(int id)
        {
            var result = await _EvlService.GetEvlById(id);
            return result.Success == true ? Ok(result) : StatusCode(500, result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddEvl(CreateEvlSchema evl)
        {
            var result = await _EvlService.AddEvl(evl.Code, evl.Naam, evl.Beroepstaken, evl.Eindkwalificaties, evl.Beschrijving, evl.Studiepunten);
            return result.Success == true ? Ok(result) : StatusCode(500, result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateEvl(UpdateEvlSchema evl)
        {
            var result = await _EvlService.UpdateEvl(evl.Id, evl.Code, evl.Naam, evl.Beroepstaken, evl.Eindkwalificaties, evl.Beschrijving, evl.Studiepunten);
            return result.Success == true ? Ok(result) : StatusCode(500, result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteEvl(int id)
        {
            var result = await _EvlService.DeleteEvl(id);
            return result.Success == true ? Ok(result) : StatusCode(500, result);
        }

        /*[HttpPost]
        [Route("[action]")]
        //deze actie bij LeeruitkomstService of EvlService uitvragen?
        public async Task<IActionResult> AddLeeruitkomstToEvl(int evlId, LeeruitkomstCreateApiModel leeruitkomst)
        {
            var result = await _leeruitkomst_Service.AddLeeruitkomstToEvl(evlId, leeruitkomst.Naam, leeruitkomst.Beschrijving);
            return result.success == true ? Ok(result) : StatusCode(500, result);
        }*/
    }
}
