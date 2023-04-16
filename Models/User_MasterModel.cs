using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models
{
    public class User_MasterModel
    {
        public int UserID { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string? UserName { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
