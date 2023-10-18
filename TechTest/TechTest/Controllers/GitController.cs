using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechTest.Queries;
using TechTest.Validators;

namespace TechTest.Controllers;

[ApiController]
[Route("api/v1/")]
public class GitController : ControllerBase
{
    private readonly ISender _sender;
    private readonly RequiredStringValidator _requiredStringValidator = new();

    public GitController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{owner}/{repo}/contributors")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetContributors(string owner, string repo)
    {
        // NOTE: If I had the benefit of knowing Mediatr better, I would have implemented a validation behaviour
        if((await _requiredStringValidator.ValidateAsync(owner)).Errors.Any()
           || (await _requiredStringValidator.ValidateAsync(repo)).Errors.Any())
            return BadRequest("A valid owner and repository are required to use this endpoint");

        var contributors = await _sender.Send(new GetContributorsQuery(owner, repo));
        if (contributors == null) return NotFound("That repository and owner combination does not return any records");
        return Ok(contributors);
    }
}