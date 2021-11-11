using System;
using System.Data.OleDb;

namespace TesteInclusao
{
	public static class Cadastro1
	{
		public static int CadastrarPessoa(Pessoa pessoa)
		{
			string conexaoAccess = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Arquivos\Database.mdb";
			OleDbConnection conexaodb = new OleDbConnection(conexaoAccess);
			conexaodb.Open();
			try
			{
				string query = $"INSERT INTO PESSOA(NOME, CPF, IDENDERECO, IDTELEFONE) VALUES ('{pessoa.Nome}', '{pessoa.Cpf}', {pessoa.Endereco.Id}, {pessoa.Telefone.Id})";
				OleDbCommand cmd = new OleDbCommand(query, conexaodb);
				cmd.ExecuteNonQuery();

				cmd.CommandText = @"select @@identity";
				int idRetono = Int32.Parse(cmd.ExecuteScalar().ToString());

				Console.WriteLine("Pessoa cadastrado com sucesso!");
				return idRetono;
			}
			catch (Exception exception)
			{
				Console.WriteLine($"Erro ao cadastrar a pessoa:{exception.Message}, verifique!");
				return 0;
			}
			finally
			{
				conexaodb.Close();
				conexaodb.Dispose();
			}
		}

		public static int CadastrarEndereco(Endereco endereco)
		{
			string conexaoAccess = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Arquivos\Database.mdb";
			OleDbConnection conexaodb = new OleDbConnection(conexaoAccess);
			conexaodb.Open();
			try
			{
				string query = $"INSERT INTO ENDERECO (LOGRADOURO, NUMEROCASA, CEP, BAIRRO, CIDADE, ESTADO) VALUES ('{endereco.Logradouro}', {endereco.NumeroCasa}, {endereco.Cep}, '{endereco.Bairro}', '{endereco.Cidade}', '{endereco.Estado}');";
				OleDbCommand cmd = new OleDbCommand(query, conexaodb);
				cmd.ExecuteNonQuery();

				cmd.CommandText = @"select @@identity";
				int idRetono = Int32.Parse(cmd.ExecuteScalar().ToString());

				Console.WriteLine("Endereço cadastrado com sucesso!");
				return idRetono;
			}
			catch (Exception exception)
			{
				Console.WriteLine($"Erro ao cadastrar o endereço:{exception.Message}, verifique!");
				return 0;
			}
			finally
			{
				conexaodb.Close();
				conexaodb.Dispose();
			}
		}

		public static int CadastrarTelefone(Telefone telefone)
		{
			string conexaoAccess = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Arquivos\Database.mdb";
			OleDbConnection conexaodb = new OleDbConnection(conexaoAccess);
			conexaodb.Open();
			try
			{
				string query = $"INSERT INTO TELEFONE(NUMEROTELEFONE, DDD, TIPO) VALUES ({telefone.NumeroTelefone}, {telefone.Ddd}, '{telefone.Tipo}')";
				OleDbCommand cmd = new OleDbCommand(query, conexaodb);
				cmd.ExecuteNonQuery();

				cmd.CommandText = @"select @@identity";
				int idRetono = Int32.Parse(cmd.ExecuteScalar().ToString());

				Console.WriteLine("Telefone cadastrado com sucesso!");
				return idRetono;
			}
			catch (Exception exception)
			{
				Console.WriteLine($"Erro ao cadastrar o telefone:{exception.Message}, verifique!");
				return 0;
			}
			finally
			{
				conexaodb.Close();
				conexaodb.Dispose();
			}
		}
	}
}
