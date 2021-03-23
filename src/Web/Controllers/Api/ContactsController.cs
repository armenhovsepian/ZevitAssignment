using Application.Features.ContactFeatures.Commands;
using Application.Features.ContactFeatures.Queries;
using AutoMapper;
using Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ContactsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // GET api/contacts
        // GET api/contacts?pagesize=3&pagenumber=1
        [HttpGet(Name = nameof(GetContactsAsync))]
        public async Task<ActionResult<IEnumerable<ContactDto>>> GetContactsAsync([FromQuery] PagingOptions pagingOptions, CancellationToken ct)
        {
            var contacts = await _mediator.Send(new GetAllContactsQuery(pagingOptions.Skip, pagingOptions.Take), ct);
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
            return Ok(await _mediator.Send(new CreateContactCommand(_mapper.Map<ContactDto>(model)), ct));
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

            await _mediator.Send(new UpdateContactCommand(_mapper.Map<ContactDto>(model)), ct);

            return NoContent();
        }
    }
}
