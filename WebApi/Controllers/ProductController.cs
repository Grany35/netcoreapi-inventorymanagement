using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("addproduct")]
        public IActionResult AddProduct(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("deleteproduct")]
        public IActionResult DeleteProduct(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("listproduct")]
        public IActionResult ListProduct()
        {
            var result = _productService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbybarcode")]
        public IActionResult GetByBarcode(string barcodeNumber)
        {
            var result = _productService.GetByBarcodeNumber(barcodeNumber);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _productService.GetByCategory(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
