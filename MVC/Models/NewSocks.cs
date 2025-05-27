using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    //Indexy
    [Index(nameof(Brand))]
    [Index(nameof(Price))]
    public class NewSocks
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Brand { get; set; }

        public SockSize Size { get; set; }

        public decimal Price { get; set; }

        [Range(0, 100, ErrorMessage = "Mimo rozsah")]
        public int OnStock { get; set; }
    }
}
