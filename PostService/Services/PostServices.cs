using EmailService.Repository;
using JwTNameService;
using Microsoft.AspNetCore.Mvc;
using Models.PostModels;

namespace PostServices_namespace
{
	public class PostServices
	{
		private readonly DBConn _dBConn;
		private readonly Jwt _jwt;
		public PostServices(DBConn dBConn,Jwt jwt) {
		_dBConn = dBConn;
			_jwt=jwt;
		}

		internal bool AddPost(PostsModel postsModel,String token)
		{
			String user_id = _jwt.GetUserIdFromToken(token);
			String postId=Guid.NewGuid().ToString().Substring(0,6).Replace("-","");
			postsModel.DateTime = DateTime.Now;
			postsModel.postid = postId;
			postsModel.userId = user_id;
			_dBConn.posts.Add(postsModel);
			try
			{
				_dBConn.SaveChanges();
				return true;
			}catch(Exception e)
			{
				return false;
			}
			
		}

		internal ActionResult GetAllPosts()
		{
			List<PostsModel> posts= _dBConn.posts.ToList();
			if(posts!=null)
			{
				return new OkObjectResult(posts);
			}else
			{
				return new OkObjectResult(null);
			}
		}
		internal ActionResult GetPostById(int id)
		{
			List<PostsModel> posts = _dBConn.posts.ToList();
			PostsModel post=posts.Find(e=>e.Id==id);

			if (post != null)
			{
				
				return new OkObjectResult(new {result=post });
			}
			else
			{
				return new NotFoundResult();
			}
		}

	}

}