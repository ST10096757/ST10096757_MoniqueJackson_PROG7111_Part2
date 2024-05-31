using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngryEnergy_Test.Models
{
    public class FarmerModel
    {
        [Key]
        public Guid ID { get; set; }

        [ForeignKey("UserModel")]
        public string UserID { get; set; }

        [PersonalData]
        public string Address { get; set; }

        [PersonalData]
        public string FarmType { get; set; }

        // Navigation property
        public virtual UserModel UserModel { get; set; }
    }
}
