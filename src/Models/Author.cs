using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using News.Models.Base;

namespace News.Models
{
    [Table(("Author"))]
    public class Author : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorDisplayName { get; set; }
        public string AuthorEmail { get; set; }
        public bool? AuthorAccountStatus { get; set; }
        [Display(Name = "Profile Pic")]
        public string AuthorProfile { get; set; }
     }
}