using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost("addsale")]
        public IActionResult AddSale(Sale sale)
        {
            var result = _saleService.Add(sale);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("addsalewithbarcode")]
        public IActionResult AddSaleWithBarcode(Sale sale,string barcodeNumber)
        {
            var result = _saleService.AddSaleWithBarcode(sale,barcodeNumber);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _saleService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("deletesale")]
        public IActionResult DeleteSale(Sale sale)
        {
            var result = _saleService.Delete(sale);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
       

    }
}
