using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APICrudServer.DATA;
using Microsoft.EntityFrameworkCore;

namespace APICrudServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApiDataContext _context;

        public CustomerController(ApiDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>>GetCustomer()
        {
            return Ok(await _context.Customers.ToListAsync());
            
        }

        [HttpGet("{id}")]

        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if(customer== null)
            {
                return NotFound();
            }
            return customer;
        }
        [HttpPost]
        public async Task<ActionResult<Customer>>Create(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult>Update(int id, Customer customer)
        {
            if( id!=customer.Id )
                return BadRequest();
            
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var customer=await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound("In correct customer id");
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();  
            return Ok();
        }
    }
}
