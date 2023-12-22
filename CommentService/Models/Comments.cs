using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models_Comments
{

	public class Comment
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[StringLength(100)]
		public int CommentId { get; set; }

		[StringLength(300)]
		public string comment { get; set; }

		[ForeignKey("posts")]
		public int postid { get; set; }

	}
}