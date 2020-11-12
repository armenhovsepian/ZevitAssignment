using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Web.Features.ContactFeatures.Commands;
using Web.Features.ContactFeatures.Queries;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index([FromQuery] PagingOptions pagingOptions, CancellationToken ct)
        {
            pagingOptions.PageNumber = 1;
            pagingOptions.PageSize = 100;
            var contacts = await _mediator.Send(new GetAllContactsQuery(pagingOptions), ct);
            return View(contacts);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactFormModel model, CancellationToken ct)
        {
            if (!ModelState.IsValid) return View(model);

            await _mediator.Send(new CreateContactCommand(model), ct);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id, CancellationToken ct)
        {
            var contact = await _mediator.Send(new GetContactByIdQuery(id), ct);

            if (contact == null) return NotFound();

            var contactModel = _mapper.Map<ContactFormModel>(contact);

            return View(contactModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit( ContactFormModel model, CancellationToken ct)
        {
            if (!ModelState.IsValid) return View(model);

            await _mediator.Send(new UpdateContactCommand(model), ct);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id, CancellationToken ct)
        {
            var contact = await _mediator.Send(new GetContactByIdQuery(id), ct);
            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            if (id == default) return BadRequest();
            await _mediator.Send(new DeleteContactCommand(id), ct);
            return RedirectToAction(nameof(Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
