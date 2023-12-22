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
			postsModel.userId = user_id;
			_dBConn.Add(postsModel);
			try
			{
				_dBConn.SaveChanges();
				return true;
			}catch(Exception e)
			{
				return false;
			}
			
		}


	}

}