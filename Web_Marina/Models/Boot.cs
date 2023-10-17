namespace Web_Marina.Models
{
	public class Boot
	{
		public int SID { get; set; }
		public string Name { get; set; }
		public double Laenge { get; set; }
		public int? Motorleistung { get; set; }
		public bool IsSegler { get; set; }
		public double Tiefgang { get; set; }
		public string? Baujahr { get; set; }
		public string? Bild { get; set; }
	}
}
