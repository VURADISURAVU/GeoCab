
namespace GeoCab.DAL.Entities
{
	public class Tool : BaseModel
	{
		public string Type { get; set; }
		public string Name { get; set; }
		public int InventoryName { get; set; }
		public bool IsUsing { get; set; }

		public virtual Employee Employee { get; set; }
	}
}