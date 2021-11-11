using System;
using System.Data.OleDb;

namespace TesteInclusao
{
	public class Cadastro2
	{
		public static int CadastrarPessoa(Pessoa pessoa, OleDbConnection conexaodb)
		{
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
				throw new Exception($" no cadastro da pessoa: {exception.Message}");
			}
		}

		public static int CadastrarEndereco(Endereco endereco, OleDbConnection conexaodb)
		{
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
				throw new Exception($" no cadastro do endereço: {exception.Message}");
			}
		}

		public static int CadastrarTelefone(Telefone telefone, OleDbConnection conexaodb)
		{
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
				throw new Exception($" no cadastro do telefone: {exception.Message}");
			}
		}
	}
}
