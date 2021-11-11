
namespace TesteInclusao
{
	public class Telefone
	{
		//[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public long NumeroTelefone { get; set; }
		public int Ddd { get; set; }
		public string Tipo { get; set; }

		public int IdPessoa { get; set; }
	}
}
