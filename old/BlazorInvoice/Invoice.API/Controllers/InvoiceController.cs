using Invoice.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Invoice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public InvoiceController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        //        [HttpGet]
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetInvoices(int id)
        {
            if (id > 0)
                return Ok(await appDbContext.Invoices.FindAsync(id));
            else
                return Ok(await appDbContext.Invoices.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> CreateInvoice(Invoice.Models.Invoice invoice)
        {
            try
            {
                if (invoice == null)
                    return BadRequest();
//                if (ModelState.IsValid) //   Not required 
                {
                    await appDbContext.Invoices.AddAsync(invoice);
                    await appDbContext.SaveChangesAsync();
                    return CreatedAtAction(nameof(GetInvoices), new { id = invoice.UniqueId });
                }
            }
            catch { }
            return Ok();
         }
    }
}
