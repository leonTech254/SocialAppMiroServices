using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.PostModels
{

	public class PostsModel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[StringLength(100)]
		public String userId {get; set;}
		[StringLength(100)]
		public String postid { get; set; }
		[StringLength(300)]
		public string post { get; set; }
		public DateTime DateTime { get; set; }
	}

}