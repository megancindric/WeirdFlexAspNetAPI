using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.Models
{
    public class Lift
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string LiftName { get; set; }

        [Required]
        public decimal WeightInPounds { get; set; }

        [Required]
        public DateTime DateRecorded { get; set; }

        [ForeignKey("User")]
        [BindNever]
        public string UserId { get; set; }

        [BindNever]
        public virtual User User { get; set; }
    }
}
