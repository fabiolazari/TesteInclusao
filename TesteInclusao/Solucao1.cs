
namespace TesteInclusao
{
	public static class Solucao1
	{
		public static void Executa()
		{
			Endereco endereco = new Endereco()
			{
				Logradouro = "Rua Joaquim M. de Figueiredo",
				NumeroCasa = 1455,
				Cep = 17034290,
				Bairro = "Distrito Industrial",
				Cidade = "Bauru",
				Estado = "SP"
			};

			endereco.Id = Cadastro1.CadastrarEndereco(endereco);
			//if

			Telefone telefone = new Telefone()
			{
				NumeroTelefone = 997963272,
				Ddd = 14,
				Tipo = "Celular"
			};


			telefone.Id = Cadastro1.CadastrarTelefone(telefone);
			//if

			Pessoa pessoa = new Pessoa()
			{
				Nome = "Fulano de Tal",
				Cpf = "11111111111",
				Endereco = endereco,
				Telefone = telefone
			};

			pessoa.Id = Cadastro1.CadastrarPessoa(pessoa);
		}
	}
}
