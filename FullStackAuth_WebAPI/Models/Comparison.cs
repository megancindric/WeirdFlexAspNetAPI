using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.Models
{
    public class Comparison
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal WeightInPounds { get; set; }

        [Required]
        public ComparisonCategory Category { get; set; }

    }

    public enum ComparisonCategory
    {
        Animal,
        Food,
        Item
    }
}
