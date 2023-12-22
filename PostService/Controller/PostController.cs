using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.PostModels;
using PostServices_namespace;

namespace PostService_Namespace
{
	[Route("/api/v1/post/")]
	[ApiController]
	public class PostController :ControllerBase
	{
		private readonly  PostServices _postService;

		public PostController(PostServices postService)
		{
			_postService = postService;
		}
		[HttpPost("add/")]
		[Authorize]
		public ActionResult addPost([FromBody] PostsModel postsModel)
		{
			string jwtToken = HttpContext.Request.Headers["Authorization"];
			if (jwtToken != null)
			{
				String token = jwtToken.ToString().Replace("Bearer ", "");
				var isPosted=_postService.AddPost(postsModel, token);
				if(isPosted)
				{
					return Ok("Added Post successfully");
				}else
				{
					return BadRequest("Problem Added the post Try again later");
				}
			}
			else
			{
				return NotFound();
			}
			return null;

		}


		[HttpGet("get/")]
		public ActionResult getAllPost()
		{
			var response=_postService.GetAllPosts();
			return Ok(response);
		}

		[HttpGet("get/postid/{id}")]
		public ActionResult GetPostById(int id)
		{
			try
			{
				var response = _postService.GetPostById(id);

				if (response == null)
				{
					return NotFound();
				}

				return Ok(response);
			}
			catch (Exception ex)
			{
				// Log the exception or handle it as needed
				return StatusCode(500, $"Internal Server Error: {ex.Message}");
			}
		}
	}


}
	 
