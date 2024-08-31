using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiFirst.Data;
using WebApiFirst.Entities;

namespace WebApiFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ECommerceController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public ECommerceController(ProductDbContext context)
        {
            _context = context;
        }

        #region Products

        // GET: api/ecommerce/products
        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/ecommerce/products/1
        [HttpGet("products/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST: api/ecommerce/products
        [HttpPost("products")]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            product.Id = 0;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // PUT: api/ecommerce/products/1
        [HttpPut("products/{id}")]
        public async Task<IActionResult> PutProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest("Product ID mismatch.");
            }

            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Discount = product.Discount;

            _context.Entry(existingProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent(); 
        }

        // DELETE: api/ecommerce/products/1
        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Customers

        // GET: api/ecommerce/customers
        [HttpGet("customers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/ecommerce/customers/1
        [HttpGet("customers/{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // POST: api/ecommerce/customers
        [HttpPost("customers")]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            customer.Id = 0;

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        // PUT: api/ecommerce/customers/1
        [HttpPut("customers/{id}")]
        public async Task<IActionResult> PutCustomer(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest("Customer ID mismatch.");
            }

            var existingCustomer = await _context.Customers.FindAsync(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            existingCustomer.Name = customer.Name;

            _context.Entry(existingCustomer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent(); 
        }

        // DELETE: api/ecommerce/customers/1
        [HttpDelete("customers/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Orders

        // GET: api/ecommerce/orders
        [HttpGet("orders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders.Include(o => o.Product).Include(o => o.Customer).ToListAsync();
        }

        // GET: api/ecommerce/orders/1
        [HttpGet("orders/{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Product)
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // POST: api/ecommerce/orders
        [HttpPost("orders")]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        // PUT: api/ecommerce/orders/1
        [HttpPut("orders/{id}")]
        public async Task<IActionResult> PutOrder(int id, [FromBody] Order order)
        {
            if (id != order.Id)
            {
                return BadRequest("Order ID mismatch.");
            }

            var existingOrder = await _context.Orders.FindAsync(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            existingOrder.ProductId = order.ProductId; 
            existingOrder.CustomerId = order.CustomerId;
            existingOrder.OrderDate = order.OrderDate; 

            _context.Entry(existingOrder).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent(); 
        }

        // DELETE: api/ecommerce/orders/1
        [HttpDelete("orders/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        // Helper methods
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
