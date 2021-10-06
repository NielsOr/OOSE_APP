using LOGIC.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeeruitkomstController : ControllerBase
    {
        private ILeeruitkomst_Service _leeruitkomst_Service;

        public LeeruitkomstController (ILeeruitkomst_Service leeruitkomst_Service)
        {
            _leeruitkomst_Service = leeruitkomst_Service;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetLeeruitkomstById(int id)
        {
            var result = await _leeruitkomst_Service.GetLeeruitkomstById(id);
            return result.success == true ? Ok(result) : StatusCode(500, result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddLeeruitkomst(CreateLeeruitkomstSchema leeruitkomst)
        {
            var result = await _leeruitkomst_Service.AddLeeruitkomst(leeruitkomst.EvlId, leeruitkomst.Naam, leeruitkomst.Beschrijving);
            return result.success == true ? Ok(result) : StatusCode(500, result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateLeeruitkomst(UpdateLeeruitkomstSchema leeruitkomst)
        {
            var result = await _leeruitkomst_Service.UpdateLeeruitkomst(leeruitkomst.Id, leeruitkomst.Naam, leeruitkomst.Beschrijving);
            return result.success == true ? Ok(result) : StatusCode(500, result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteLeeruitkomst(int id)
        {
            var result = await _leeruitkomst_Service.DeleteLeeruitkomst(id);
            return result.success == true ? Ok(result) : StatusCode(500, result);
        }

    }
}
