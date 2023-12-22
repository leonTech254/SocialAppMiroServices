using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models_Comments;
using Newtonsoft.Json;
using Comments.Repository;
using JwTNameService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models_Comments;
using System.Net.Http.Headers;
using Models.PostModels;

namespace CommentSerives_namesapace
{
	public class CommentsService
	{
		private readonly Jwt _jwt;
		private readonly DBConn _dbConn;
		private  HttpClient _httpClient;

		public CommentsService(Jwt jwt, DBConn dBConn)
		{
			_jwt = jwt;
			_dbConn = dBConn;
			_httpClient = new HttpClient();
		}

		public async Task<bool> AddComment(Comment comment, string token, string postId)
		{
			Console.WriteLine("hello wotdbds");
			try
			{

				Console.WriteLine("hello try catch");
				//string apiUrl=$"https://localhost:7284/api/v1/post/get/postid/{postId}";
				string apiUrl=$"https://localhost:7284/api/v1/post/get/postid/{postId}";

				HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

				if (response.IsSuccessStatusCode)
				{
					Console.WriteLine("If Stauts True");
					string postJson = await response.Content.ReadAsStringAsync();

					PostsModel post = JsonConvert.DeserializeObject<PostsModel>(postJson);
					comment.CommentId=Guid.NewGuid().ToString().Substring(0,6).Replace("-","");
					comment.postid = int.Parse(postId);
					_dbConn.comments.Add(comment);
					await _dbConn.SaveChangesAsync();
					return true;
				}
				else
				{
					Console.WriteLine("Write Jsfnf");
					Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
					return false;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception: {ex.Message}");
				return false;
			}
		}


		public ActionResult GetAlComments()
		{
			var comments = _dbConn.comments;

			return new OkObjectResult(comments);
		}
	}
}
