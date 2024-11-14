using CNLTHD.DTO;
using CNLTHD.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CNLTHD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpDelete]
        [Route("/delete/{supplierId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute]int supplierId)
        {
            var result = await _supplierService.DeleteAsync(supplierId);
            if (!result) return BadRequest("Not Found or being referenced!");
            return NoContent();
        }

        [HttpGet]
        [Route("/get-all")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
           var result =  await _supplierService.GetAllAsync();
            if (result.Count() <= 0 || result == null) return BadRequest("Supplier list empty!");
            return Ok(result);
        }


        [HttpGet]
        [Route("/get-by-id/{supplierId}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int supplierId)
        {
            var result = await _supplierService.GetAsync(supplierId);
            if(result == null) return BadRequest("Supplier does not exist!");
            return Ok(result);
        }

        [HttpPost]
        [Route("/create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateSupplierDTO request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _supplierService.CreateAsync(request);
            if (result == null) return BadRequest("Created fail!");
            return CreatedAtAction(nameof(GetById), new { supplierId = result.SupplierId }, result);
        }

        [HttpPut]
        [Route("/update/{supplierId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute]int supplierId, [FromBody] UpdateSupplierDTO request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _supplierService.UpdateAsync(supplierId,request);
            if( result == null) return BadRequest("Updated Fail!");
            return Ok(result);
        }
    }
}
