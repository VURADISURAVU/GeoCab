using GeoCab.DAL.Repositories;

namespace GeoCab.DAL.Entities
{
	public class Tool : BaseModel
	{
		public string Type { get; set; }
		public string Name { get; set; }
		public int InventoryName { get; set; }
		
	}
}