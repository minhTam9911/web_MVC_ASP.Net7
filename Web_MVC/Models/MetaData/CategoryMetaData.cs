using System.ComponentModel.DataAnnotations;
using Web_MVC.Models;
namespace Web_MVC.Models.MetaData;


[MetadataType(typeof(CategoryMetaData))]
public partial class Category
{

}

public class CategoryMetaData
{
	[Required]
	[MaxLength(255)]
	public string Name { get; set; }

}

