using System.Collections.Generic;

namespace TesteInclusao
{
	public class Pessoa
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Cpf { get; set; }

		public Endereco Endereco { get; set; }
		public Telefone Telefone { get; set; }

		public List<Telefone> Telefones { get; set; }
	}
}
