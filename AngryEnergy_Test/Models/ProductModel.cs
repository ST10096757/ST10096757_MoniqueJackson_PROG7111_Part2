using AngryEnergy_Test.Data.Migrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngryEnergy_Test.Models
{
	public class ProductModel
	{
		
		[Key]
		public Guid Id { get; set; }

		[ForeignKey("UserModel")]
		public string UserID { get; set; }

		[ForeignKey("FarmerModel")]
		public Guid FarmerId { get; set; }

		public string Name { get; set; }
		public string Category { get; set; }
		public DateTime? ProductionDate { get; set; }

		// Navigation property
		public virtual UserModel UserModel { get; set; }

		public FarmerModel FarmerModel { get; set; }

	}
}
