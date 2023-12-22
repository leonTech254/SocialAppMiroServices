using CommentSerives_namesapace;
using Microsoft.AspNetCore.Mvc;
using Models_Comments;

namespace CommentController_nameSpace
{
	[Route("/api/v1/Comments/")]
	[ApiController]
	public class CommentController:ControllerBase
	{
		private readonly CommentsService _commentsService;
	public CommentController(CommentsService commentsService)
	{
			_commentsService=commentsService;
	}

		[HttpPost("add/comment/post/{id}")]
		public  async Task<ActionResult> AddComment([FromBody] Comment comments,String id)
		{
			string jwtToken = HttpContext.Request.Headers["Authorization"];
			if (jwtToken != null)
			{
				String token = jwtToken.ToString().Replace("Bearer ", "");
				var isPosted = await _commentsService.AddComment(comments, token,id);
				;
				if (isPosted)
				{
					return Ok("Comment Added  successfully");
				}
				else
				{
					return BadRequest("Problem Added the Comment Try again later");
				}
			}
			else
			{
				return NotFound();
			}
			return null;

		}
		[HttpGet("get/")]
		public ActionResult? GetAllComments()
		{
			var response=_commentsService.GetAlComments();
			return Ok(response);

		}

	}

}