using LOGIC.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeeruitkomstController : ControllerBase
    {
        private ILeeruitkomstService _leeruitkomstService;

        public LeeruitkomstController(ILeeruitkomstService leeruitkomstService)
        {
            _leeruitkomstService = leeruitkomstService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetLeeruitkomstById(int id)
        {
            var result = await _leeruitkomstService.GetLeeruitkomstById(id);
            return result.Success == true ? Ok(result) : StatusCode(500, result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddLeeruitkomst(CreateLeeruitkomstSchema leeruitkomst)
        {
            var result = await _leeruitkomstService.AddLeeruitkomst(leeruitkomst.EvlId, leeruitkomst.Naam, leeruitkomst.Beschrijving);
            return result.Success == true ? Ok(result) : StatusCode(500, result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateLeeruitkomst(UpdateLeeruitkomstSchema leeruitkomst)
        {
            var result = await _leeruitkomstService.UpdateLeeruitkomst(leeruitkomst.Id, leeruitkomst.Naam, leeruitkomst.Beschrijving);
            return result.Success == true ? Ok(result) : StatusCode(500, result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteLeeruitkomst(int id)
        {
            var result = await _leeruitkomstService.DeleteLeeruitkomst(id);
            return result.Success == true ? Ok(result) : StatusCode(500, result);
        }
    }
}
