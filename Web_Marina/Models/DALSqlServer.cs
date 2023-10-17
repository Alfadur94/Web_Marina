using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;

namespace Web_Marina.Models

{
	public class DALSqlServer : IDataAccessable
	{
		readonly SqlConnection connection;

		public DALSqlServer(string connectionString)
		{
			connection = new SqlConnection(connectionString);
		}
		
		public int CreateBoot(Boot boot)
		{
			SqlCommand InsertCmd = new SqlCommand("INSERT INTO Boot (Name, Laenge, Motorleistung, IsSegler, Tiefgang, Baujahr, Bild) VALUES (@Name, @Laenge, @Motorleistung, @IsSegler, @Tiefgang, @Baujahr, @Bild)", connection);
			InsertCmd.Parameters.AddWithValue("@Name", boot.Name);
			InsertCmd.Parameters.AddWithValue("@Laenge", boot.Laenge);
			InsertCmd.Parameters.AddWithValue("@Motorleistung", boot.Motorleistung);
			InsertCmd.Parameters.AddWithValue("@IsSegler", boot.IsSegler);
			InsertCmd.Parameters.AddWithValue("@Tiefgang", boot.Tiefgang);
			InsertCmd.Parameters.AddWithValue("@Baujahr", boot.Baujahr);
			InsertCmd.Parameters.AddWithValue("@Bildname", boot.Bild);
			connection.Open();
			int result = InsertCmd.ExecuteNonQuery();
			connection.Close();
			return result;
		}

		public void DeleteBoot(int id)
		{
			SqlCommand DeleteCmd = new SqlCommand("DELETE FROM Boot WHERE SID = @SID", connection);
			DeleteCmd.Parameters.AddWithValue("@SID", id);
			connection.Open();
			DeleteCmd.ExecuteNonQuery();
			connection.Close();
		}

		public List<Boot> GetAllBoote()
		{
			List<Boot> boote = new List<Boot>();
			SqlCommand SelectCmd = new SqlCommand("SELECT * FROM Boot", connection);
			connection.Open();
			SqlDataReader reader = SelectCmd.ExecuteReader();
			while (reader.Read())
			{
				Boot boot = new Boot();
				boot.SID = reader.GetInt32(0);
				boot.Name = reader.GetString(1);
				boot.Laenge = reader.GetDouble(2);
				if (!reader.IsDBNull(3))
				{
					boot.Motorleistung = reader.GetInt32(3);
				}
				boot.IsSegler = reader.GetBoolean(4);
				boot.Tiefgang = reader.GetDouble(5);
				if (!reader.IsDBNull(6))
				{
					boot.Baujahr = reader.GetString(6);
				}
				if (!reader.IsDBNull(7))
				{
					boot.Bild = reader.GetString(7);
				}
				boote.Add(boot);
			}
			connection.Close();
			return boote;
		}

		public Boot GetBootById(int id)
		{
			SqlCommand SelectBySIDCmd = new SqlCommand("SELECT * FROM Boot WHERE SID = @SID", connection);
			SelectBySIDCmd.Parameters.AddWithValue("@SID", id);
			connection.Open();
			SqlDataReader reader = SelectBySIDCmd.ExecuteReader();
			Boot boot = new Boot();
			while (reader.Read())
			{
				boot.SID = reader.GetInt32(0);
				boot.Name = reader.GetString(1);
				boot.Laenge = reader.GetDouble(2);
				if (!reader.IsDBNull(3))
				{
					boot.Motorleistung = reader.GetInt32(3);
				}
				boot.IsSegler = reader.GetBoolean(4);
				boot.Tiefgang = reader.GetDouble(5);
				if (!reader.IsDBNull(6))
				{
					boot.Baujahr = reader.GetString(6);
				}
				if (!reader.IsDBNull(7))
				{
					boot.Bild = reader.GetString(7);
				}
			}
			connection.Close();
			return boot;
		}

		public void UpdateBoot(Boot boot)
		{
			SqlCommand UpdateCmd = new SqlCommand("UPDATE Boot SET Name = @Name, Laenge = @Laenge, Motorleistung = @Motorleistung, IsSegler = @IsSegler, Tiefgang = @Tiefgang, Baujahr = @Baujahr, Bild = @Bild WHERE SID = @SID", connection);
			UpdateCmd.Parameters.AddWithValue("@SID", boot.SID);
			UpdateCmd.Parameters.AddWithValue("@Name", boot.Name);
			UpdateCmd.Parameters.AddWithValue("@Laenge", boot.Laenge);
			UpdateCmd.Parameters.AddWithValue("@Motorleistung", boot.Motorleistung);
			UpdateCmd.Parameters.AddWithValue("@IsSegler", boot.IsSegler);
			UpdateCmd.Parameters.AddWithValue("@Tiefgang", boot.Tiefgang);
			UpdateCmd.Parameters.AddWithValue("@Baujahr", boot.Baujahr);
			UpdateCmd.Parameters.AddWithValue("@Bildname", boot.Bild);
			connection.Open();
			UpdateCmd.ExecuteNonQuery();
			connection.Close();			
		}
	}
}

