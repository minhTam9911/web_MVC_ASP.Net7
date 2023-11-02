

using System.ComponentModel.DataAnnotations;

namespace Web_MVC.Models.MetaData;


internal sealed class DiscountMetaData
{
	[Required]
	public double Precent { get; set; }

	[Required(ErrorMessage ="The field is required")]
	public string? Description { get; set; }

	[Required]
	public DateTime StartTime { get; set; }

	[Required]
	public DateTime EndTime { get; set; }
}

[MetadataType(typeof(DiscountMetaData))]
public partial class Discount
{

}