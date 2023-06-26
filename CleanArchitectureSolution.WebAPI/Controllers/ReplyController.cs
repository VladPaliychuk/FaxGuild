using CleanArchitecture.Application.Features.Reply.CreateComment;
using CleanArchitecture.Application.Features.Reply.DeleteReply;
using CleanArchitecture.Application.Features.Reply.UpdateReply;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ReplyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReplyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create Reply")]
        public async Task<IActionResult> CreateReplyAsync([FromBody] CreateReplyCommand request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _mediator.Send(request);

            return Ok();
        }

        [HttpPut("Update Reply")]
        public async Task<IActionResult> UpdateReplyAsync(int id, [FromBody] UpdateReplyCommand request)
        {
            request.Id = id;
            bool succes = await _mediator.Send(request);

            if (succes)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("Delete Reply")]
        public async Task<IActionResult> DeleteReplyAsync(int id)
        {
            var request = new DeleteReplyCommand { Id = id };
            var result = await _mediator.Send(request);

            if (result > 0)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
