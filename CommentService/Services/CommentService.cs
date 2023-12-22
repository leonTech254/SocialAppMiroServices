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

namespace CommentSerives_namesapace
{
	public class CommentsService
	{
		private readonly Jwt _jwt;
		private readonly DBConn _dbConn;
		private readonly HttpClient _httpClient;

		public CommentsService(Jwt jwt, DBConn dBConn, HttpClient httpClient)
		{
			_jwt = jwt;
			_dbConn = dBConn;
			_httpClient = httpClient;
		}

		internal async Task<bool> AddComment(Comment comment, string token, string postId)
		{
			try
			{
				string apiUrl = $"https://localhost:7284/api/v1/post//get/postid/{postId}"; 
				
				string commentJson = JsonConvert.SerializeObject(comment);

				var content = new StringContent(commentJson, Encoding.UTF8, "application/json");

				
				/*_httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");*/

				
				HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);

			
				if (response.IsSuccessStatusCode)
				{
					// If the comment was successfully added to the external API, you can also save it to your local database
					_dbConn.comments.Add(comment);
					await _dbConn.SaveChangesAsync();

					return true;
				}
				else
				{
					// Handle the case where adding the comment to the external API failed
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

		internal ActionResult GetAlComments()
		{
			var comments = _dbConn.comments;

			return new OkObjectResult(comments);
		}
	}
}
