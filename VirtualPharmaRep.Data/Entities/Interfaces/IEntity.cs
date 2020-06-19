namespace VirtualPharmaRep.Data.Entities.Interfaces
{
	public interface IEntity
	{
		/// <summary>
		/// Entity ID
		/// </summary>
		int Id { get; set; }
		public string CreatedBy { get; set; }
    }
}