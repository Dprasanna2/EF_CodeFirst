using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CODEFIRST.Models
{
    public class Membership
    {
        [Key]
        [Required]
        public int Membership_Id { get; set; }
        [Required]
        public decimal Account_Balance { get; set; }

        [Display(Name = "PersonDetail")]
        [Required]
      //  [Index("IX_Membership_PersonId_MembershipCategoryId", IsClustered = true)]
       
        public virtual int Person_Id { get; set; }

        [ForeignKey("Person_Id")]
        public virtual PersonDetail PersonDetail { get; set; }


        [Display(Name = "Membership_Category_Name")]
        public virtual MembershipCategoryEnum Membership_Category_Id { get; set; }

      //  [Index("IX_Membership_PersonId_MembershipCategoryId", IsClustered = true)]
        [ForeignKey("Membership_Category_Id")]
        public virtual MembershipCategory  MembershipCategory { get; set; }

    }
}
