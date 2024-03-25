using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using urunTakip.DataAccessLayer;

namespace urunTakip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult BookList()
        {
            using (var c = new Context())
            {
                var values = c.Products.ToList();
                return Ok(values);
            }
        }

        [HttpPost]
        public IActionResult BookAdd(Product product)
        {
            using (var c = new Context())
            {
                c.Add(product);
                c.SaveChanges();
                return Ok(product);
            }
        }

        [HttpGet("{id}")]
        public IActionResult ProductGet(int id)
        {

            using var c = new Context();
            var product = c.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }

        }


        [HttpDelete("{id}")]
        public IActionResult ProductDelete(int id)
        {
            using (var c = new Context())
            {
                var product = c.Products.Find(id);
                if (product == null)
                {
                    return NotFound(); 
                }

                c.Products.Remove(product);
                c.SaveChanges(); 

                return NoContent(); 
            }
        }

        [HttpPut("{id}")]
        public IActionResult ProductUpdate(Product product)
        {
            using var c=new Context();
            var urun = c.Find<Product>(product.Id);
            if (urun==null)
            {
                return NotFound();
            }

            else
            {
                urun.Name = product.Name;
                c.Update(urun);
                c.SaveChanges();
                return Ok();
            }


        }

    }
}
