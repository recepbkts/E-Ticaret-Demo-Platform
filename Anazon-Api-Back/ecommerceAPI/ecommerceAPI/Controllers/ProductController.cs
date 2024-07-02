using ecommerceAPI.Helpers;
using ecommerceAPI.Models;
using ecommerceAPI.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace ecommerceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]

        public IActionResult Create([FromBody] ProductCreateModel model)
        {
            try
            {
                if(!ValidationHelper.IsProductCreateModelVlaid(model))
                    return BadRequest(new {message="pleas complete all fields correctly!"});


                using var context = new AnazonDbContext();
                var newProduct = new Product
                {
                    CategoryId = model.CategoryId,
                    ProductName = model.ProductName,
                    UnitPrice = model.UnitPrice,
                    UnitsInStock = model.UnitsInStock,
                    UnitsOnOrder = model.UnitsOnOrder,
                    Discontinued = model.Discontinued,
                    ReorderLevel = model.ReorderLevel,
                    SupplierId = model.SupplierId,
                    QuantityPerUnit = model.QuantityPerUnit,
                };
                context.Products.Add(newProduct);
                context.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "The Server has encountered an unexpected Error"
                });
            }
        }

        [HttpGet]
        [Route("[action]")]

        public IActionResult List()
        {
            try
            {
                using var context = new AnazonDbContext();
                var products = context.Products.Select(p => new
                {

                    p.ProductId,
                    p.ProductName,
                    p.UnitPrice,
                    p.UnitsInStock,
                    p.QuantityPerUnit,
                    p.Discontinued,
                    p.ReorderLevel,
                    p.UnitsOnOrder,

                }).ToList();
                return Ok(products);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "The Server has encountered an unexpected Error"
                });
            }
        }

        [HttpPost]
        [Route("[action]")]

        public IActionResult Edit([FromBody] ProductEditModel model) 
        {
            try
            {
                using var context = new AnazonDbContext();
                var product = context.Products.Find(model.ProductId);

                if(product == null) {return NotFound(new {Message="Product was not found"});}
                product.CategoryId = model.CategoryId;
                product.ProductName = model.ProductName;
                product.UnitPrice = model.UnitPrice;
                product.QuantityPerUnit = model.QuantityPerUnit;
                product.Discontinued = model.Discontinued;
                product.ReorderLevel = model.ReorderLevel;
                product.SupplierId = model.SupplierId;
                product.UnitsInStock = model.UnitsInStock;
                product.UnitsOnOrder = model.UnitsOnOrder;

                context.SaveChanges();
                return Ok(product);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "The Server has encountered an unexpected Error"
                });
            }
        }


        [HttpGet]
        [Route("[action]")]

        public IActionResult Details(int productID)
        {
            try
            {
                using var context = new AnazonDbContext();
                var product = context.Products.Find(productID);

                if (product == null) return NotFound(new { message = "Peoduct was not found" });

                return Ok(new
                {
                    product.ProductId,
                    product.ProductName,
                    product.UnitPrice,
                    product.QuantityPerUnit,
                    product.Discontinued,
                    product.ReorderLevel,
                    product.UnitsOnOrder,
                    product.UnitsInStock,

                });
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "The Server has encountered an unexpected Error"
                });
            }
        }
    }
}
