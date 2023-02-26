using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CODEFIRST.Models
{
    public class MembershipCategory
    {
        [Key]
        public MembershipCategoryEnum Membership_Category_Id { get; set; }
        [Required]
        public string Membership_Category_Name { get; set; }

        
    }
    public enum MembershipCategoryEnum
    {
        Silver = 1,
        Gold = 2,
        Platinum = 3,
        Daimond = 4
    }
}
