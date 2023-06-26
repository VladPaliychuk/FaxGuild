using CleanArchitecture.Application.Features.Comment.Commands.CreateComment;
using CleanArchitecture.Application.Features.Comment.Commands.DeleteComment;
using CleanArchitecture.Application.Features.Comment.Commands.UpdateComment;
using CleanArchitecture.Application.Features.Comment.Queries.GetAllComments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllComments")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllCommentsQuery()));
        }

        [HttpPost("Create Comment")]
        public async Task<IActionResult> CreateCommentAsync([FromBody] CreateCommentCommand request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _mediator.Send(request);

            return Ok();
        }

        [HttpPut("Update Comment")]
        public async Task<IActionResult> UpdateCommentAsync(int id, [FromBody] UpdateCommentCommand request)
        {
            request.Id = id;
            bool succes = await _mediator.Send(request);

            if (succes)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("Delete Command")]
        public async Task<IActionResult> DeleteCommentAsync(int id)
        {
            var request = new DeleteCommentCommand { Id = id };
            var result = await _mediator.Send(request);

            if (result > 0)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
