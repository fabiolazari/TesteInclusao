using System;
using System.Data.OleDb;

namespace TesteInclusao
{
	public static class Solucao2
	{
		private static string conexaoAccess = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Arquivos\Database.mdb";

		public static void Executa()
		{
			Pessoa pessoa = new Pessoa()
			{
				Nome = "Fulano de Tal",
				Cpf = "11111111111",
				Endereco = new Endereco()
				{
					Logradouro = "Rua Joaquim M. de Figueiredo",
					NumeroCasa = 1455,
					Cep = 17034290,
					Bairro = "Distrito Industrial",
					Cidade = "Bauru",
					Estado = "SP"
				},
				Telefone = new Telefone()
				{
					NumeroTelefone = 997963272,
					Ddd = 14,
					Tipo = "Celular"
				}
			};
			/*
			using (OleDbConnection conexaodb = new OleDbConnection(conexaoAccess))
			{
				conexaodb.Open();
				pessoa.Endereco.Id = Cadastro2.CadastrarEndereco(pessoa.Endereco, conexaodb);
				//if

				pessoa.Telefone.Id = Cadastro2.CadastrarTelefone(pessoa.Telefone, conexaodb);
				//if

				bool retorno = Cadastro2.CadastrarPessoa(pessoa, conexaodb);
			}
			*/
			OleDbConnection conexaodb = new OleDbConnection(conexaoAccess);
			
			try
			{
				conexaodb.Open();

				pessoa.Endereco.Id = Cadastro2.CadastrarEndereco(pessoa.Endereco, conexaodb);
				//if

				pessoa.Telefone.Id = Cadastro2.CadastrarTelefone(pessoa.Telefone, conexaodb);
				//if

				pessoa.Id = Cadastro2.CadastrarPessoa(pessoa, conexaodb);
			}
			catch (Exception exception)
			{
				Console.WriteLine($"Erro: {exception.Message}");
			}
			finally
			{
				conexaodb.Close();
				conexaodb.Dispose();
			}
		}
	}
}
