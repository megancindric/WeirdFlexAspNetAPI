using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.Models
{
    public class Flex
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool IsFavorite { get; set; }

        [ForeignKey("Lift")]
        [Required]
        public int LiftId { get; set; }

        [BindNever]
        public virtual Lift Lift { get; set; }

        [ForeignKey("Comparison")]
        [Required]
        public int ComparisonId { get; set; }

        [BindNever]
        public virtual Comparison Comparison { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
