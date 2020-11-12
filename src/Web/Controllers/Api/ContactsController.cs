using ApplicationCore.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Web.Features.ContactFeatures.Commands;
using Web.Features.ContactFeatures.Queries;
using Web.Models;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly IMediator _mediator;
        public ContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/contacts
        // GET api/contacts?pagesize=3&pagenumber=1
        [HttpGet(Name = nameof(GetContactsAsync))]
        public async Task<ActionResult<IEnumerable<ContactDto>>> GetContactsAsync([FromQuery] PagingOptions pagingOptions, CancellationToken ct)
        {
            var contacts = await _mediator.Send(new GetAllContactsQuery(pagingOptions), ct); 
            return Ok(contacts);
        }


        [HttpGet("{id}", Name = nameof(GetContactAsync))]
        public async Task<ActionResult<ContactDto>> GetContactAsync(int id, CancellationToken ct)
        {
            var contact = await _mediator.Send(new GetContactByIdQuery(id), ct);

            if (contact == null) return NotFound();

            return Ok(contact);
        }


        [HttpPost]
        public async Task<ActionResult> CreateContactAsync([FromBody] ContactFormModel model, CancellationToken ct)
        {
            return Ok(await _mediator.Send(new CreateContactCommand(model), ct));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactAsync(int id, CancellationToken ct)
        {
            if (id == default) return BadRequest();
            return Ok(await _mediator.Send(new DeleteContactCommand(id), ct));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContactAsync(int id, ContactFormModel model, CancellationToken ct)
        {
            if (id != model.Id) return BadRequest();

            await _mediator.Send(new UpdateContactCommand(model), ct);

            return NoContent();
        }
    }
}
