using LivaSoftExam.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace LivaSoftExam.Controllers;

[ApiController]
[Route("api/comments")]
public class CommentController : ControllerBase
{
    private readonly IStringOperations _stringOperations;
    public CommentController(IStringOperations stringOperations)
    {
        _stringOperations = stringOperations;

    }
    [HttpPost]
    [Route("clean-comment")]
    public IActionResult CleanComments([FromBody] string[] str)
    {
        var service = _stringOperations.CleanComments(str);
        if (service is not null) return Ok(service.Split("@").Where(e => e != string.Empty).ToArray());

        return BadRequest();
    }
    [HttpPost]
    [Route("find-difference")]
    public IActionResult FindDifference(string firstArgs, string secondArgs)
    {
        var service = _stringOperations.FindDifferenceString(firstArgs, secondArgs);
        if (service is not null) return Ok(service);

        return BadRequest();

    }

}
