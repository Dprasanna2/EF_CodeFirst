using System.ComponentModel.DataAnnotations;

namespace CODEFIRST.Models
{
    public class PersonDetail
    {
        [Key]
        public int Person_Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailId { get; set; }

        
    }
}
