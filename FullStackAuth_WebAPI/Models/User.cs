using Microsoft.AspNetCore.Identity;

namespace FullStackAuth_WebAPI.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        //public WeightDisplay WeightDisplayUnit { get; set; }
    }

    //public enum WeightDisplay
    //{
    //    Pounds,
    //    Kilograms
    //}
}
