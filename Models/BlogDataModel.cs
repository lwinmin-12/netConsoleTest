using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace netConsoleTest.Models
{
    [Table("Blog")]
    public class BlogDataModel
    {
        [Key]
        // [Column("BLogId")]
        public int Blog_Id {get; set;}
        public string? Blog_Title {get; set;}
        public string? Blog_Author{get; set;}
        public string? Blog_Content{get; set;}
    }
} 