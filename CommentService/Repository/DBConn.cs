using Microsoft.EntityFrameworkCore;
using Models_Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comments.Repository
{
	public class DBConn : DbContext
	{
		public DBConn(DbContextOptions<DBConn> options) : base(options)
		{

		}
		public DbSet<Comment> comments { get; set; }
	}
}
