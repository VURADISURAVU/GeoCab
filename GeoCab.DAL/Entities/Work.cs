namespace GeoCab.DAL.Entities
{
	public class Work : BaseModel
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public float Cost { get; set; }
		
		public long UserId { get; set; }
		public virtual User User { get; set; }
	}
}