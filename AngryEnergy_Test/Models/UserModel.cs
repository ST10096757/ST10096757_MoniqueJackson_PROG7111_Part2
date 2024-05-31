using Microsoft.AspNetCore.Identity;

namespace AngryEnergy_Test.Models
{
	public class UserModel : IdentityUser
	{
		//PersonalDate = informs ASP.NET Identity that these properties contain personal data
		//and might be used for GDPR* compliance features.
		//*General Data Protection Regulation.
		[PersonalData]
		public string FirstName { get; set; }

		[PersonalData]
		public string LastName { get; set; }

		[PersonalData]
		public string Contact { get; set; }

        // Navigation property
        public virtual FarmerModel FarmerModel { get; set; }

    }
}
