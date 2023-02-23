using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Models
{
    public class SearchOfferViewModel
    {
        [Required]
        public string? id { get; set; }
    }
}
