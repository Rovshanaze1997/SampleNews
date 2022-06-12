using System;
using System.ComponentModel.DataAnnotations;
using News.Models.Base;
using News.Models.Data.Enums;

namespace News.Models
{
    public class News : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public Categories Categories { get; set; }
         public DateTime DatePosted { get; set; }
         public string Description { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        [Display(Name = "Picture")]
        public string PicUrl { get; set; }
 
    }
}