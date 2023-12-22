using Microsoft.EntityFrameworkCore;
using Models.PostModels;
using Models_Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Repository
{
	public class DBConn : DbContext
	{
		public DBConn(DbContextOptions<DBConn> options) : base(options)
		{

		}
		public DbSet<PostsModel> posts { get; set; }
		public DbSet<Comment> comments { get; set; }
	}
}
