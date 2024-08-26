using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Seb.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [DisplayName("Kategori Adı")]
        public string CategoryName { get; set; }
        [DisplayName("Sipariş Sayısı")]
        [Range(1, 100, ErrorMessage = "Sipariş Sayısı 1-100 arasında olmalıdır.")]
        public int DisplayOrder { get; set; }
    }
}
