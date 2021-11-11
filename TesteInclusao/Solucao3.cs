using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;

namespace TesteInclusao
{
	public class Solucao3
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
				Telefones = new List<Telefone>
				{
					new Telefone()
					{
						NumeroTelefone = 998285478,
						Ddd = 14,
						Tipo = "Celular"
					},
					new Telefone()
					{
						NumeroTelefone = 998285478,
						Ddd = 14,
						Tipo = "Celular"
					},
					new Telefone()
					{
						NumeroTelefone = 996751245,
						Ddd = 14,
						Tipo = "Celular"
					}
				}
			};
			/*linq
			var teste = pessoa.Telefones.Where(tel => tel.NumeroTelefone == 996751245)
										.Select(t => t.NumeroTelefone)
										.FirstOrDefault();
			*/


			using (OleDbConnection conexaodb = new OleDbConnection(conexaoAccess))
			{
				try
				{
					conexaodb.Open();

					pessoa.Endereco.Id = Cadastro3.CadastrarEndereco(pessoa.Endereco, conexaodb);

					pessoa.Id = Cadastro3.CadastrarPessoa(pessoa, conexaodb);

					foreach (Telefone tel in pessoa.Telefones)
					{
						Cadastro3.CadastrarTelefone(tel, pessoa.Id, conexaodb);
					}
					/* Com linq
					pessoa.Telefones.ForEach(tel =>
					{
						Cadastro3.CadastrarTelefone(tel, pessoa.Id, conexaodb);
					});*/

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
}
