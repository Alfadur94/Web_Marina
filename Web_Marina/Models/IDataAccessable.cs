namespace Web_Marina.Models
{
	public interface IDataAccessable
	{
		int CreateBoot(Boot boot);
		Boot GetBootById(int id);
		List<Boot> GetAllBoote();
		void UpdateBoot(Boot boot);
		void DeleteBoot(int id);
	}
}
