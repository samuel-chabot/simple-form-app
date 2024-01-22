using Microsoft.AspNetCore.Mvc;
using SimpleFormApp.Models;
using SimpleFormApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleFormApp.Controllers;
[Route("[controller]")]
[ApiController]
public class RequestFormController : ControllerBase
{
    private readonly IRequestFormService _requestFormService;

    public RequestFormController(IRequestFormService requestFormService)
    {
        _requestFormService = requestFormService;
    }

    // GET: <RequestFormController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RequestForm>>> Get(CancellationToken cancellationToken)
    {
        return Ok(await _requestFormService.GetAll(cancellationToken));
    }

    // GET <RequestFormController>/<id>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<RequestForm>> Get(Guid id, CancellationToken cancellationToken)
    {
        var res = await _requestFormService.Get(id, cancellationToken);
        return res == null ? NotFound() : Ok(res);
    }

    // POST <RequestFormController>
    [HttpPost]
    public async Task<ActionResult<RequestForm>> Post([FromBody] CreateRequestForm value, CancellationToken cancellationToken)
    {
        return await _requestFormService.Create(value, cancellationToken);
    }

    // PUT <RequestFormController>/<id>
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<RequestForm>> Put(Guid id, [FromBody] UpdateRequestForm value, CancellationToken cancellationToken)
    {
        value.Id = id;
        return await _requestFormService.Update(value, cancellationToken);
    }

    // DELETE <RequestFormController>/<id>
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var res = await _requestFormService.Delete(id, cancellationToken);
        return !res ? NotFound() : NoContent();
    }
}
