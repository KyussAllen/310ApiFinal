using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiPleaseWork.Models;
using ApiPleaseWork.Server.Data;

namespace ApiPleaseWork.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInfoController : ControllerBase
    {
        private readonly ApiPleaseWorkServerContext _context;

        public CustomerInfoController(ApiPleaseWorkServerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerInformation>>> GetCustomerInformation()
        {
            return await _context.CustomerInformation.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerInformation>> GetCustomerInformation(int id)
        {
            var customerInformation = await _context.CustomerInformation.FindAsync(id);

            if (customerInformation == null)
            {
                return NotFound();
            }

            return customerInformation;
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerInformation(int id, CustomerInformation customerInformation)
        {
            if (id != customerInformation.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customerInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerInformationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

   
        [HttpPost]
        public async Task<ActionResult<CustomerInformation>> PostCustomerInformation(CustomerInformation customerInformation)
        {
            _context.CustomerInformation.Add(customerInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerInformation", new { id = customerInformation.CustomerId }, customerInformation);
        }

     
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerInformation(int id)
        {
            var customerInformation = await _context.CustomerInformation.FindAsync(id);
            if (customerInformation == null)
            {
                return NotFound();
            }

            _context.CustomerInformation.Remove(customerInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerInformationExists(int id)
        {
            return _context.CustomerInformation.Any(e => e.CustomerId == id);
        }
    }
}
