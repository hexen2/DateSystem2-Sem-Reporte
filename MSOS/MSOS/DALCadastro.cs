using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data;

namespace MSOS
{
    class DALCadastro
    {
        private Conexao objConexao;

        public DALCadastro(Conexao conexao)
        {
            objConexao = conexao;
        }


        //Base de Dados Clientes Fisica e Juridica. E tambem Cep---------------------------------------------------------------------------------------------------------------------------
        public void Incluir(Pessoa cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            //transacao = objConexao.ObjetoConexao.BeginTransaction("");


            cmd.CommandText = "EXEC PessoaInserir @IdTipoPessoa,@Situacao,@Nome,@Telefone,@Telefone2,@FaxTelefone,@TelexTelefone," +
                              " @Email,@Observacao,@Tipo,@CpMunicipio,@Municipio,@Pais,@DesPais; select @@IDENTITY;";
            cmd.Parameters.AddWithValue("@IdTipoPessoa", cliente.IdPessoaTipo);
            cmd.Parameters.AddWithValue("@Situacao", cliente.Situacao);
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);

            if (cliente.Telefone2 == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Telefone2", cliente.Telefone2).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Telefone2", cliente.Telefone2);
            }
            if (cliente.FaxTelefone == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@FaxTelefone", cliente.FaxTelefone).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@FaxTelefone", cliente.FaxTelefone);
            }
            if (cliente.TelexTelefone == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@TelexTelefone", cliente.TelexTelefone).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@TelexTelefone", cliente.TelexTelefone);
            }
            cmd.Parameters.AddWithValue("@Email", cliente.Email);

            if (cliente.Observacao == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Observacao", cliente.Observacao).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Observacao", cliente.Observacao);
            }
            if (cliente.Tipo == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Tipo", cliente.Tipo).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Tipo", cliente.Tipo);
            }
            if (cliente.CpMunicipio == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@CpMunicipio", cliente.CpMunicipio).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@CpMunicipio", cliente.CpMunicipio);
            }
            if (cliente.Municipio == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Municipio", cliente.Municipio).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Municipio", cliente.Municipio);
            }
            if (cliente.Pais == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Pais", cliente.Pais).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Pais", cliente.Pais);
            }
            if (cliente.DesPais == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@DesPais", cliente.DesPais).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@DesPais", cliente.DesPais);
            }

            objConexao.Conectar();

            cliente.idPessoa = Convert.ToInt32(cmd.ExecuteScalar());
        }
        public void IncluirCliente(Clientes Cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            cmd.CommandText = "EXEC PessoaClienteInserir @IdCliente, @Ms ; ";

            cmd.Parameters.AddWithValue("@IdCliente", Cliente.idPessoa);
            //cmd.Parameters.AddWithValue("@IdPessoaTipo", Fisica.IdPessoaTipo);
            cmd.Parameters.AddWithValue("@Ms", Cliente.IdMs);
       
            objConexao.Conectar();

            cmd.ExecuteScalar();
        }
        public void IncluirPessoaFIsica(PessoaFisica Fisica)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;
            //transacao = objConexao.ObjetoConexao.BeginTransaction("SampleTransaction");
            /*
            cmd.CommandText = "INSERT INTO [dbo].[P_Fisica] (ID_PESSOA_FISICA,ID_PESSOA_TIPO,SEXO,CPF,RG,DATA_NASCIMENTO,CELULAR,CELULAR2) VALUES(@idPessoaFisica,@IdPessoaTipo,@Sexo,@Cpf," +
            "@Rg,@dataNacimento,@Celular,@Celular2);select @@IDENTITY;";
            */
            cmd.CommandText = "EXEC PessoaFisicaInserir @idPessoaFisica,@Nome1,@Sexo,@Cpf,@Rg,@dataNacimento,@Celular,@Celular2;";
            
            cmd.Parameters.AddWithValue("@idPessoaFisica", Fisica.idPessoaFisica);
            //cmd.Parameters.AddWithValue("@IdPessoaTipo", Fisica.IdPessoaTipo);
            cmd.Parameters.AddWithValue("@Sexo", Fisica.Sexo);
            cmd.Parameters.AddWithValue("@Cpf", Fisica.Cpf);
            cmd.Parameters.AddWithValue("@Rg", Fisica.Rg);
            cmd.Parameters.AddWithValue("@dataNacimento", Fisica.dataNacimento);
            cmd.Parameters.AddWithValue("@Celular", Fisica.Celular);

            if (Fisica.Nome == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Nome1", Fisica.Nome).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Nome1", Fisica.Nome);
            }

            if (Fisica.Celular2 == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Celular2", Fisica.Celular2).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Celular2", Fisica.Celular2);
            }

            objConexao.Conectar();

            cmd.ExecuteScalar();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = objConexao.ObjetoConexao;

            cmd1.CommandText = "UPDATE [dbo].[P_Pessoa] SET[ID_PESSOA_TIPO] = 1 WHERE ID_PESSOA = @idPessoaFisica; ";
            cmd1.Parameters.AddWithValue("@idPessoaFisica", Fisica.idPessoaFisica);
 

            cmd1.ExecuteScalar();

        }
        public void IncluirPessoaJuridica(PessoaJuridica Juridica)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;
            //transacao = objConexao.ObjetoConexao.BeginTransaction("SampleTransaction");
            cmd.CommandText = "EXEC PessoaJuridicaInserir @idPessoaJuridica,@RazaoSocial,@Cnpj,@NomeContato, @InscricaoStadual;";
            cmd.Parameters.AddWithValue("@idPessoaJuridica", Juridica.idPessoaJuridica);
            cmd.Parameters.AddWithValue("@RazaoSocial", Juridica.RazaoSocial);
            cmd.Parameters.AddWithValue("@Cnpj", Juridica.Cnpj);
            cmd.Parameters.AddWithValue("@NomeContato", Juridica.NomeContato);
            cmd.Parameters.AddWithValue("@InscricaoStadual", Juridica.InscricaoStadual);

            objConexao.Conectar();

            cmd.ExecuteScalar();


        }


        public void IncluirCep(Cep cep)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            /*
            cmd.CommandText = "INSERT INTO [dbo].[P_Cep]([ID_CEP],[CEP],[TIPO_LOGRADOURO],[ENDERECO],[NUMERO],[COMPLEMENTO],[BAIRRO],[CIDADE],[SIGLA_CIDADE])"
            + " VALUES(@IdCep,@Cep,@TipoLogradouro,@Endereco,@Numero,@Complemento,@Bairro,@Cidade,@SiglaCidade);select @@IDENTITY;";
            */
            cmd.CommandText = "exec PessoaCepInserir @IdCep,@Cep,@TipoLogradouro,@Endereco,@Numero,@Complemento,@Bairro,@Cidade,@SiglaCidade;select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@IdCep", cep.idCep);
            cmd.Parameters.AddWithValue("@Cep", cep.Cepc);
            cmd.Parameters.AddWithValue("@TipoLogradouro", cep.TipoLogradouro);
            cmd.Parameters.AddWithValue("@Endereco", cep.Endereco);
            cmd.Parameters.AddWithValue("Numero", cep.Numero);

            if (cep.Complemento == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Complemento", cep.Complemento).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Complemento", cep.Complemento);
            }
            cmd.Parameters.AddWithValue("@Bairro", cep.Bairro);
            cmd.Parameters.AddWithValue("@Cidade", cep.Cidade);
            cmd.Parameters.AddWithValue("@SiglaCidade", cep.SiglaCidade);

            objConexao.Conectar();
            cmd.ExecuteScalar();
        }

        //Alterar Informação de Cadastra Fisica e Juridica------------------------------------------------------------------------------------------------------------------------------------

        public void Alterar(Pessoa cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            cmd.CommandText = "EXEC PessoaUpdate @idPessoa,@Situacao,@Nome,@Telefone,@Telefone2,@FaxTelefone,@TelexTelefone,@Email," +
            "@Observacao,@Tipo,@CpMunicipio,@Municipio,@Pais,@DesPais;";
            cmd.Parameters.AddWithValue("@idPessoa", cliente.idPessoa);
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);

            if (cliente.Telefone2 == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Telefone2", cliente.Telefone2).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Telefone2", cliente.Telefone2);
            }
            if (cliente.FaxTelefone == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@FaxTelefone", cliente.FaxTelefone).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@FaxTelefone", cliente.FaxTelefone);
            }
            if (cliente.TelexTelefone == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@TelexTelefone", cliente.TelexTelefone).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@TelexTelefone", cliente.TelexTelefone);
            }

            cmd.Parameters.AddWithValue("@Situacao", cliente.Situacao);
            cmd.Parameters.AddWithValue("@Email", cliente.Email);

            if (cliente.Observacao == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Observacao", cliente.Observacao).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Observacao", cliente.Observacao);
            }
            if (cliente.Tipo == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Tipo", cliente.Tipo).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Tipo", cliente.Tipo);
            }
            if (cliente.CpMunicipio == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@CpMunicipio", cliente.CpMunicipio).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@CpMunicipio", cliente.CpMunicipio);
            }
            if (cliente.Municipio == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Municipio", cliente.Municipio).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Municipio", cliente.Municipio);
            }
            if (cliente.Pais == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Pais", cliente.Pais).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Pais", cliente.Pais);
            }
            if (cliente.DesPais == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@DesPais", cliente.DesPais).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@DesPais", cliente.DesPais);
            }

            objConexao.Conectar();

            cmd.ExecuteNonQuery();

            objConexao.Desconectar();
        }

        public void AlterarClienteFIsica(PessoaFisica Fisica)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            cmd.CommandText = "EXEC PessoaFisicaUpdate @idPessoaFisica,@Celular,@Celular2; ";
            cmd.Parameters.AddWithValue("@idPessoaFisica", Fisica.idPessoaFisica);
            if (Fisica.Celular == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Celular", Fisica.Celular).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Celular", Fisica.Celular);
            }
            if (Fisica.Celular2 == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Celular2", Fisica.Celular2).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Celular2", Fisica.Celular2);
            }
            objConexao.Conectar();
            cmd.ExecuteNonQuery();
            objConexao.Desconectar();

        }
        public void AlterarClienteJuridica(PessoaJuridica Juridica)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            cmd.CommandText = "EXEC PessoaJuridicaUpdate @idPessoaJuridica,@NomeContato; ";

            cmd.Parameters.AddWithValue("@idPessoaJuridica", Juridica.idPessoaJuridica);
            cmd.Parameters.AddWithValue("@NomeContato", Juridica.NomeContato);

            objConexao.Conectar();
            cmd.ExecuteNonQuery();
            objConexao.Desconectar();


        }

        //Excluir Informação de Cadastra Fisica e Juridica

        public void ExcluirClienteFisico(int IdCliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            cmd.CommandText = "DELETE FROM [dbo].[P_Cliente] WHERE ID_CLIENTE_PESSOA = @idPessoa;";
            cmd.Parameters.AddWithValue("@idPessoa", IdCliente);

            objConexao.Conectar();
            cmd.ExecuteNonQuery();
            objConexao.Desconectar();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = objConexao.ObjetoConexao;

            cmd1.CommandText = "DELETE FROM [dbo].[P_Fisica] WHERE ID_PESSOA_FISICA = @idPessoa;";

            cmd1.Parameters.AddWithValue("@idPessoa", IdCliente);

            objConexao.Conectar();
            cmd1.ExecuteNonQuery();
            objConexao.Desconectar();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = objConexao.ObjetoConexao;

            cmd2.CommandText = "DELETE FROM [dbo].[P_Pessoa] WHERE ID_PESSOA = @idPessoa;";

            cmd2.Parameters.AddWithValue("@idPessoa", IdCliente);

            objConexao.Conectar();
            cmd2.ExecuteNonQuery();
        }
        public void ExcluirClienteJuridica(int Juridica)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            cmd.CommandText = "DELETE FROM [dbo].[P_Cliente] WHERE ID_CLIENTE_PESSOA = @idPessoa;";
            cmd.Parameters.AddWithValue("@idPessoa", Juridica);

            objConexao.Conectar();
            cmd.ExecuteNonQuery();
            objConexao.Desconectar();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = objConexao.ObjetoConexao;

            cmd1.CommandText = "DELETE FROM [dbo].[P_Juridica] WHERE ID_PESSOA_JURIDICA = @idPessoa;";

            cmd1.Parameters.AddWithValue("@idPessoa", Juridica);

            objConexao.Conectar();
            cmd1.ExecuteNonQuery();
            objConexao.Desconectar();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = objConexao.ObjetoConexao;

            cmd2.CommandText = "DELETE FROM [dbo].[P_Pessoa] WHERE ID_PESSOA = @idPessoa;";

            cmd2.Parameters.AddWithValue("@idPessoa", Juridica);

            objConexao.Conectar();
            cmd2.ExecuteNonQuery();
        }




        


        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Base de Dados Fornecedor Fisica e Juridica. E tambem Cep
        public void IncluirF(Fornecedor Fornecedor)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            cmd.CommandText = "EXEC PessoaFornecedorInserir @IdFornecedorPessoa, @NomeContato,CargoContato ; ";

            cmd.Parameters.AddWithValue("@IdFornecedorPessoa", Fornecedor.idFornecedor);
            //cmd.Parameters.AddWithValue("@IdPessoaTipo", Fisica.IdPessoaTipo);
            cmd.Parameters.AddWithValue("@NomeContato", Fornecedor.NomeContato);
            cmd.Parameters.AddWithValue("@CargoContato", Fornecedor.CargoContato);

            objConexao.Conectar();

            cmd.ExecuteScalar();
        }

        public void IncluirPessoaFIsica(FornecedorFisica Fisica)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;
            //transacao = objConexao.ObjetoConexao.BeginTransaction("SampleTransaction");
            /*
            cmd.CommandText = "INSERT INTO [dbo].[P_Fisica] (ID_PESSOA_FISICA,ID_PESSOA_TIPO,SEXO,CPF,RG,DATA_NASCIMENTO,CELULAR,CELULAR2) VALUES(@idPessoaFisica,@IdPessoaTipo,@Sexo,@Cpf," +
            "@Rg,@dataNacimento,@Celular,@Celular2);select @@IDENTITY;";
            */
            cmd.CommandText = "EXEC PessoaFisicaInserir @idPessoaFisica,@Nome1,@Sexo,@Cpf,@Rg,@dataNacimento,@Celular,@Celular2;";

            cmd.Parameters.AddWithValue("@idPessoaFisica", Fisica.idFornecedorFisica);
            //cmd.Parameters.AddWithValue("@IdPessoaTipo", Fisica.IdPessoaTipo);
            cmd.Parameters.AddWithValue("@Sexo", Fisica.Sexo);
            cmd.Parameters.AddWithValue("@Cpf", Fisica.Cpf);
            cmd.Parameters.AddWithValue("@Rg", Fisica.Rg);
            cmd.Parameters.AddWithValue("@dataNacimento", Fisica.dataNacimento);
            cmd.Parameters.AddWithValue("@Celular", Fisica.Celular);

            if (Fisica.Nome == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Nome1", Fisica.Nome).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Nome1", Fisica.Nome);
            }

            if (Fisica.Celular2 == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Celular2", Fisica.Celular2).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Celular2", Fisica.Celular2);
            }

            objConexao.Conectar();

            cmd.ExecuteScalar();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = objConexao.ObjetoConexao;

            cmd1.CommandText = "UPDATE [dbo].[P_Pessoa] SET[ID_PESSOA_TIPO] = 1 WHERE ID_PESSOA = @idPessoaFisica; ";
            cmd1.Parameters.AddWithValue("@idPessoaFisica", Fisica.idFornecedorFisica);


            cmd1.ExecuteScalar();

        }
        public void IncluirPessoaJuridica(FornecedorJuridica Juridica)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;
            //transacao = objConexao.ObjetoConexao.BeginTransaction("SampleTransaction");
            cmd.CommandText = "EXEC PessoaJuridicaInserir @idPessoaJuridica,@RazaoSocial,@Cnpj,@NomeContato, @InscricaoStadual;";
            cmd.Parameters.AddWithValue("@idPessoaJuridica", Juridica.idFornecedorJuridica);
            cmd.Parameters.AddWithValue("@RazaoSocial", Juridica.RazaoSocial);
            cmd.Parameters.AddWithValue("@Cnpj", Juridica.Cnpj);
            cmd.Parameters.AddWithValue("@NomeContato", Juridica.NomeContato);
            cmd.Parameters.AddWithValue("@InscricaoStadual", Juridica.InscricaoStadual);

            objConexao.Conectar();

            cmd.ExecuteScalar();


        }

        public void AlterarFornecedorFIsica(FornecedorFisica Fisica)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            cmd.CommandText = "EXEC PessoaFisicaUpdate @idPessoaFisica,@Celular,@Celular2; ";
            cmd.Parameters.AddWithValue("@idPessoaFisica", Fisica.idFornecedorFisica);
            if (Fisica.Celular == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Celular", Fisica.Celular).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Celular", Fisica.Celular);
            }
            if (Fisica.Celular2 == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Celular2", Fisica.Celular2).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Celular2", Fisica.Celular2);
            }
            objConexao.Conectar();
            cmd.ExecuteNonQuery();
            objConexao.Desconectar();

        }
        public void AlterarFornecedorJuridica(FornecedorJuridica Juridica)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            cmd.CommandText = "EXEC PessoaJuridicaUpdate @idPessoaJuridica,@NomeContato; ";

            cmd.Parameters.AddWithValue("@idPessoaJuridica", Juridica.idFornecedorJuridica);
            cmd.Parameters.AddWithValue("@NomeContato", Juridica.NomeContato);

            objConexao.Conectar();
            cmd.ExecuteNonQuery();
            objConexao.Desconectar();


        }

        //Alterar Informação de Cadastra Fornecedor Fisica e Juridica------------------------------------------------------------------------------------------------------------------------------------

        public void AlterarF(Fornecedor cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;
            cmd.CommandText = "EXEC FornecedorUpdate @idPessoa,@NomeContato,@CargoContato " +
            cmd.Parameters.AddWithValue("@idPessoa", cliente.idFornecedor);
            if (cliente.NomeContato == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@NomeContato", cliente.NomeContato).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@NomeContato", cliente.NomeContato);
            }
            if (cliente.CargoContato == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@CargoContato", cliente.CargoContato).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@CargoContato", cliente.CargoContato);
            }


            objConexao.Conectar();

            cmd.ExecuteNonQuery();

            objConexao.Desconectar();
            
        }
        public void ExcluirFornecedorFisico(int Fisica)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            cmd.CommandText = "DELETE FROM [dbo].[P_Cliente] WHERE ID_CLIENTE_PESSOA = @idPessoa;";
            cmd.Parameters.AddWithValue("@idPessoa", Fisica);

            objConexao.Conectar();
            cmd.ExecuteNonQuery();
            objConexao.Desconectar();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = objConexao.ObjetoConexao;

            cmd1.CommandText = "DELETE FROM [dbo].[P_Fisica] WHERE ID_PESSOA_FISICA = @idPessoa;";

            cmd1.Parameters.AddWithValue("@idPessoa", Fisica);

            objConexao.Conectar();
            cmd1.ExecuteNonQuery();
            objConexao.Desconectar();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = objConexao.ObjetoConexao;

            cmd2.CommandText = "DELETE FROM [dbo].[P_Pessoa] WHERE ID_PESSOA = @idPessoa;";

            cmd2.Parameters.AddWithValue("@idPessoa", Fisica);

            objConexao.Conectar();
            cmd2.ExecuteNonQuery();
        }
        public void ExcluirFornecedorJuridica(int Juridica)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            cmd.CommandText = "DELETE FROM [dbo].[P_Cliente] WHERE ID_CLIENTE_PESSOA = @idPessoa;";
            cmd.Parameters.AddWithValue("@idPessoa", Juridica);

            objConexao.Conectar();
            cmd.ExecuteNonQuery();
            objConexao.Desconectar();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = objConexao.ObjetoConexao;

            cmd1.CommandText = "DELETE FROM [dbo].[P_Juridica] WHERE ID_PESSOA_JURIDICA = @idPessoa;";

            cmd1.Parameters.AddWithValue("@idPessoa", Juridica);

            objConexao.Conectar();
            cmd1.ExecuteNonQuery();
            objConexao.Desconectar();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = objConexao.ObjetoConexao;

            cmd2.CommandText = "DELETE FROM [dbo].[P_Pessoa] WHERE ID_PESSOA = @idPessoa;";

            cmd2.Parameters.AddWithValue("@idPessoa", Juridica);

            objConexao.Conectar();
            cmd2.ExecuteNonQuery();
        }





        //Base de Dados Funcionario. E tambem Cep---------------------------------------------------------------------------------------------------------------------------
        public void IncluirFuncionario(Funcionario cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            //transacao = objConexao.ObjetoConexao.BeginTransaction("");

            cmd.CommandText = "EXEC FuncionarioInserir @IdRe,@Situacao,@Nome,@Abreviacao,@Telefone,@Telefone2,@Celular,@Celular2,@Email," +
                "@Observacao,@Sexo,@Cpf,@Rg,@DataNascimento;select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@idRe", cliente.IdRe);
            cmd.Parameters.AddWithValue("@Situacao", cliente.Situacao);
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@Abreviacao", cliente.Abreviacao);
            cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);

            if (cliente.Telefone2 == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Telefone2", cliente.Telefone2).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Telefone2", cliente.Telefone2);
            }
            if (cliente.Celular == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Celular", cliente.Celular).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Celular", cliente.Celular);
            }
            if (cliente.Celular2 == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Celular2", cliente.Celular2).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Celular2", cliente.Celular2);
            }
            cmd.Parameters.AddWithValue("@Email", cliente.Email);

            if (cliente.Observacao == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Observacao", cliente.Observacao).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Observacao", cliente.Observacao);
            }
            if (cliente.Sexo == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Sexo", cliente.Sexo).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Sexo", cliente.Sexo);
            }
            if (cliente.Cpf == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Cpf", cliente.Cpf).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Cpf", cliente.Cpf);
            }
            if (cliente.Rg == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Rg", cliente.Rg).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Rg", cliente.Rg);
            }
            if (cliente.DataNascimento == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@DataNascimento", cliente.DataNascimento).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@DataNascimento", cliente.DataNascimento);
            }


            objConexao.Conectar();

            cliente.IdFuncionario = Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void IncluirCepFuncionario(CepFEcs cep)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            /*
            cmd.CommandText = "INSERT INTO [dbo].[P_Cep]([ID_CEP],[CEP],[TIPO_LOGRADOURO],[ENDERECO],[NUMERO],[COMPLEMENTO],[BAIRRO],[CIDADE],[SIGLA_CIDADE])"
            + " VALUES(@IdCep,@Cep,@TipoLogradouro,@Endereco,@Numero,@Complemento,@Bairro,@Cidade,@SiglaCidade);select @@IDENTITY;";
            */
            cmd.CommandText = "exec FuncionarioCepInserir @IdCep,@Cep,@TipoLogradouro,@Endereco,@Numero,@Complemento,@Bairro,@Cidade,@SiglaCidade;";

            cmd.Parameters.AddWithValue("@IdCep", cep.idCep);
            cmd.Parameters.AddWithValue("@Cep", cep.Cepc);
            cmd.Parameters.AddWithValue("@TipoLogradouro", cep.TipoLogradouro);
            cmd.Parameters.AddWithValue("@Endereco", cep.Endereco);
            cmd.Parameters.AddWithValue("Numero", cep.Numero);

            if (cep.Complemento == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Complemento", cep.Complemento).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Complemento", cep.Complemento);
            }
            cmd.Parameters.AddWithValue("@Bairro", cep.Bairro);
            cmd.Parameters.AddWithValue("@Cidade", cep.Cidade);
            cmd.Parameters.AddWithValue("@SiglaCidade", cep.SiglaCidade);

            objConexao.Conectar();
            cmd.ExecuteScalar();
        }

        //Altera informação de Funcionario-----------------------------------------------------------------------------------------------------------------------------------
        public void AlterarFuncionario(Funcionario cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            cmd.CommandText = "EXEC FuncionarioUpdate @idPessoa,@Situacao,@Nome,@Abreviacao,@Telefone,@Telefone2,@Celular,@Celular2,@Email,@Observacao;";
            cmd.Parameters.AddWithValue("@idPessoa", cliente.IdFuncionario);
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@Abreviacao", cliente.Abreviacao);
            cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
            cmd.Parameters.AddWithValue("@Situacao", cliente.Situacao);

            if (cliente.Telefone2 == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Telefone2", cliente.Telefone2).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Telefone2", cliente.Telefone2);
            }
            if (cliente.Celular == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Celular", cliente.Celular).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Celular", cliente.Celular);
            }
            if (cliente.Celular2 == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Celular2", cliente.Celular2).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Celular2", cliente.Celular2);
            }
            if (cliente.Email == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Email", cliente.Email).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
            }



            if (cliente.Observacao == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Observacao", cliente.Observacao).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Observacao", cliente.Observacao);
            }

            objConexao.Conectar();

            cmd.ExecuteNonQuery();

            objConexao.Desconectar();
        }
        public void AlteraCepFuncionario(CepFEcs cep)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            /*
            cmd.CommandText = "INSERT INTO [dbo].[P_Cep]([ID_CEP],[CEP],[TIPO_LOGRADOURO],[ENDERECO],[NUMERO],[COMPLEMENTO],[BAIRRO],[CIDADE],[SIGLA_CIDADE])"
            + " VALUES(@IdCep,@Cep,@TipoLogradouro,@Endereco,@Numero,@Complemento,@Bairro,@Cidade,@SiglaCidade);select @@IDENTITY;";
            */
            cmd.CommandText = "exec FuncionarioCepUpdate @IdCep,@Complemento";

            cmd.Parameters.AddWithValue("@IdCep", cep.idCep);
            if (cep.Complemento == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Complemento", cep.Complemento).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Complemento", cep.Complemento);
            }

            objConexao.Conectar();
            cmd.ExecuteScalar();
        }

 
        //Excluir informação de Funcionario---------------------------------------------------------------------------------------------------------------------------------
        public void ExcluirFuncionario(int funcionario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            cmd.CommandText = "DELETE FROM [dbo].[G_Funcionario] WHERE ID_FUNCIONARIO = @idPessoa;";
            cmd.Parameters.AddWithValue("@idPessoa", funcionario);

            objConexao.Conectar();
            cmd.ExecuteNonQuery();
            objConexao.Desconectar();

        }



        //Fornecedores Clientes Contatos
        //Base de Dados Funcionario. E tambem Cep---------------------------------------------------------------------------------------------------------------------------
        public void IncluirFContatos(FornecedorContatos cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            //transacao = objConexao.ObjetoConexao.BeginTransaction("");


            cmd.CommandText = "EXEC PessoaContatosInserir @idPessoa,@Situacao,@Nome,@Abreviacao, @Telefone,@Telefone2, @Celular,@Celular2,@Email,@Observacao;"; 



            cmd.Parameters.AddWithValue("@idPessoa", cliente.IdFornecedor);
            cmd.Parameters.AddWithValue("@Situacao", cliente.Situacao);
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@Abreviacao", cliente.Abreviacao);
            cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);

            if (cliente.Telefone2 == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Telefone2", cliente.Telefone2).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Telefone2", cliente.Telefone2);
            }
            if (cliente.Celular == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Celular", cliente.Celular).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Celular", cliente.Celular);
            }
            if (cliente.Celular2 == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Celular2", cliente.Celular2).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Celular2", cliente.Celular2);
            }

            cmd.Parameters.AddWithValue("@Email", cliente.Email);

            if (cliente.Observacao == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Observacao", cliente.Observacao).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Observacao", cliente.Observacao);
            }
           
            objConexao.Conectar();

            cliente.IdContatof = Convert.ToInt32(cmd.ExecuteScalar());
        }

        

        //Altera informação de Funcionario Contatos-------------------------------------------------------------------------------------------------------------------------
        public void AlterarFContatos(FornecedorContatos cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            cmd.CommandText = "EXEC PessoaContatosUpdate @idPessoa,@Situacao,@Nome,@Abreviacao,@Telefone,@Telefone2,@Celular,@Celular,@Email,@Observacao; ";

            cmd.Parameters.AddWithValue("@idPessoa", cliente.IdFornecedor);
            cmd.Parameters.AddWithValue("@Situacao", cliente.Situacao);
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@Abreviacao", cliente.Abreviacao);
            cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);

            if (cliente.Telefone2 == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Telefone2", cliente.Telefone2).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Telefone2", cliente.Telefone2);
            }
            if (cliente.Celular == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Celular", cliente.Celular).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Celular", cliente.Celular);
            }
            if (cliente.Celular2 == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Celular2", cliente.Celular2).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Celular2", cliente.Celular2);
            }
            if (cliente.Email == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Email", cliente.Email).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
            }



            if (cliente.Observacao == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Observacao", cliente.Observacao).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Observacao", cliente.Observacao);
            }

            objConexao.Conectar();

            cmd.ExecuteNonQuery();

            objConexao.Desconectar();
        }
        //Excluir informação de Funcionario---------------------------------------------------------------------------------------------------------------------------------
        public void ExcluirFcontatos(int funcionario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            cmd.CommandText = "DELETE FROM [dbo].[P_Contatos] WHERE ID_PESSOA_CONTATO = @idPessoa;";
            cmd.Parameters.AddWithValue("@idPessoa", funcionario);

            objConexao.Conectar();
            cmd.ExecuteNonQuery();
            objConexao.Desconectar();

        }

        //Clientes Contatos
        //Base de Dados Funcionario. E tambem Cep---------------------------------------------------------------------------------------------------------------------------
        public void IncluirCContatos(ClientesContatos cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            //transacao = objConexao.ObjetoConexao.BeginTransaction("");

            cmd.CommandText = "EXEC PessoaContatosInserir @idPessoa,@Situacao,@Nome,@Abreviacao, @Telefone,@Telefone2, @Celular,@Celular2,@Email,@Observacao;";

            cmd.Parameters.AddWithValue("@idPessoa", cliente.IdContatof);
            cmd.Parameters.AddWithValue("@Situacao", cliente.Situacao);
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@Abreviacao", cliente.Abreviacao);
            cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);

            if (cliente.Telefone2 == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Telefone2", cliente.Telefone2).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Telefone2", cliente.Telefone2);
            }
            if (cliente.Celular == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Celular", cliente.Celular).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Celular", cliente.Celular);
            }
            if (cliente.Celular2 == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Celular2", cliente.Celular2).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Celular2", cliente.Celular2);
            }
            if (cliente.Email == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Email", cliente.Email).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
            }

            if (cliente.Observacao == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Observacao", cliente.Observacao).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Observacao", cliente.Observacao);
            }


            objConexao.Conectar();

            cliente.IdFornecedor = Convert.ToInt32(cmd.ExecuteScalar());
        }



        //Altera informação de Funcionario Contatos-------------------------------------------------------------------------------------------------------------------------
        public void AlterarCContatos(ClientesContatos cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            cmd.CommandText = "EXEC PessoaContatosUpdate @idPessoa,@Situacao,@Nome,@Telefone,@Telefone2,@Celular,@Celular2,@Email,@Observacao"; 

            cmd.Parameters.AddWithValue("@idPessoa", cliente.IdContatof);
            cmd.Parameters.AddWithValue("@Situacao", cliente.Situacao);
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);

            if (cliente.Telefone2 == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Telefone2", cliente.Telefone2).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Telefone2", cliente.Telefone2);
            }
            if (cliente.Celular == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Celular", cliente.Celular).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Celular", cliente.Celular);
            }
            if (cliente.Celular2 == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Celular2", cliente.Celular2).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Celular2", cliente.Celular2);
            }
            if (cliente.Email == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Email", cliente.Email).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
            }



            if (cliente.Observacao == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@Observacao", cliente.Observacao).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Observacao", cliente.Observacao);
            }

            objConexao.Conectar();

            cmd.ExecuteNonQuery();

            objConexao.Desconectar();
        }
        //Excluir informação de Funcionario---------------------------------------------------------------------------------------------------------------------------------
        public void ExcluirCcontatos(int funcionario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            cmd.CommandText = "DELETE FROM [dbo].[P_Contatos] WHERE ID_PESSOA_CONTATO = @idPessoa;";
            cmd.Parameters.AddWithValue("@idPessoa", funcionario);

            objConexao.Conectar();
            cmd.ExecuteNonQuery();
            objConexao.Desconectar();

        }



        //Clientes OS
        //Base de Dados Funcionario. E tambem Cep---------------------------------------------------------------------------------------------------------------------------
        public void IncluiOS(Os cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            cmd.CommandText = "EXEC OsInserir @idPessoa,@IdContato,@Funcionario,@IdServico,@IdItemServico,@IdEstado,@IdSituacao,@OrigemChamado,@ServicosExecutados,@ValorObra," +
                "@HorarioInicio,@HorarioFinal,@DataSolicitacao,@DataFechamento;";

            cmd.Parameters.AddWithValue("@idPessoa", cliente.IdPessoaCliente);
            cmd.Parameters.AddWithValue("@IdContato", cliente.IdContato);
            cmd.Parameters.AddWithValue("@Funcionario", cliente.IdFuncionario);
            cmd.Parameters.AddWithValue("@IdServico", cliente.IdServico);
            cmd.Parameters.AddWithValue("@IdItemServico", cliente.IdItemServico);
            cmd.Parameters.AddWithValue("@IdEstado", cliente.Estado);
            cmd.Parameters.AddWithValue("@IdSituacao", cliente.Situacao);

            if (cliente.OrigemChamado == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@OrigemChamado", cliente.OrigemChamado).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@OrigemChamado", cliente.OrigemChamado);
            }
            if (cliente.ServicosExecutados == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@ServicosExecutados", cliente.ServicosExecutados).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@ServicosExecutados", cliente.ServicosExecutados);
            }
            if (cliente.ValorObra == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@ValorObra", cliente.ValorObra).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@ValorObra", cliente.ValorObra);
            }
            if (cliente.HorarioInicio == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@HorarioInicio", cliente.HorarioInicio).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@HorarioInicio", cliente.HorarioInicio);
            }
            if (cliente.HorarioFinal == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@HorarioFinal", cliente.HorarioFinal).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@HorarioFinal", cliente.HorarioFinal);
            }
            cmd.Parameters.AddWithValue("@DataSolicitacao", cliente.DataSolicitacao);

            //if (cliente.DataSolicitacao == "")
            //{
            //    // passa valor nulo para a tabela
            //    cmd.Parameters.AddWithValue("@DataSolicitacao", cliente.DataSolicitacao).Value = SqlDateTime.Null;
            //}
            //else
            //{
            //    cmd.Parameters.AddWithValue("@DataSolicitacao", cliente.DataSolicitacao);
            //}
            if(cliente.MudancaDataFechamento == 0)
            {
                if (!(cliente.DataFechamento == null))
                {
                    // passa valor nulo para a tabela
                    cmd.Parameters.AddWithValue("@DataFechamento", cliente.DataFechamento).Value = SqlDateTime.Null;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DataFechamento", cliente.DataFechamento);
                }
            }
            if (cliente.MudancaDataFechamento == 1)
            {
                if ((cliente.DataFechamento == null))
                {
                    // passa valor nulo para a tabela
                    cmd.Parameters.AddWithValue("@DataFechamento", cliente.DataFechamento).Value = SqlDateTime.Null;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DataFechamento", cliente.DataFechamento);
                }
            }

            objConexao.Conectar();

            cliente.IdOs = Convert.ToInt32(cmd.ExecuteScalar());
        }
        //Clientes OS
        //Base de Dados Funcionario. E tambem Cep---------------------------------------------------------------------------------------------------------------------------
        public void AlteraOS(Os cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            cmd.CommandText = "EXEC OsUpdates @IdOs,@OrigemChamado,@ServicosExecutados, @HorarioInicio,@HorarioFinal,@DataFechamento,@Estado;";

            cmd.Parameters.AddWithValue("@IdOs", cliente.IdOs);
            //cmd.Parameters.AddWithValue("@IdContato", cliente.OrigemChamado);
            //cmd.Parameters.AddWithValue("@Funcionario", cliente.ServicosExecutados);
            //cmd.Parameters.AddWithValue("@IdServico", cliente.HorarioInicio);
            //cmd.Parameters.AddWithValue("@IdItemServico", cliente.HorarioFinal);
            //cmd.Parameters.AddWithValue("@IdEstado", cliente.Estado);

            if (cliente.OrigemChamado == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@OrigemChamado", cliente.OrigemChamado).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@OrigemChamado", cliente.OrigemChamado);
            }
            if (cliente.ServicosExecutados == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@ServicosExecutados", cliente.ServicosExecutados).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@ServicosExecutados", cliente.ServicosExecutados);
            }
            //if (cliente.ValorObra == "")
            //{
            //    // passa valor nulo para a tabela
            //    cmd.Parameters.AddWithValue("@ValorObra", cliente.ValorObra).Value = SqlDateTime.Null;
            //}
            //else
            //{
            //    cmd.Parameters.AddWithValue("@ValorObra", cliente.ValorObra);
            //}
            if (cliente.HorarioInicio == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@HorarioInicio", cliente.HorarioInicio).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@HorarioInicio", cliente.HorarioInicio);
            }
            if (cliente.HorarioFinal == "")
            {
                // passa valor nulo para a tabela
                cmd.Parameters.AddWithValue("@HorarioFinal", cliente.HorarioFinal).Value = SqlDateTime.Null;
            }
            else
            {
                cmd.Parameters.AddWithValue("@HorarioFinal", cliente.HorarioFinal);
            }
            cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
            //cmd.Parameters.AddWithValue("@DataSolicitacao", cliente.DataSolicitacao);

            //if (cliente.DataSolicitacao == "")
            //{
            //    // passa valor nulo para a tabela
            //    cmd.Parameters.AddWithValue("@DataSolicitacao", cliente.DataSolicitacao).Value = SqlDateTime.Null;
            //}
            //else
            //{
            //    cmd.Parameters.AddWithValue("@DataSolicitacao", cliente.DataSolicitacao);
            //}
            if (cliente.MudancaDataFechamento == 0)
            {
                if (!(cliente.DataFechamento == null))
                {
                    // passa valor nulo para a tabela
                    cmd.Parameters.AddWithValue("@DataFechamento", cliente.DataFechamento).Value = SqlDateTime.Null;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DataFechamento", cliente.DataFechamento);
                }
            }
            if (cliente.MudancaDataFechamento == 1)
            {
                if ((cliente.DataFechamento == null))
                {
                    // passa valor nulo para a tabela
                    cmd.Parameters.AddWithValue("@DataFechamento", cliente.DataFechamento).Value = SqlDateTime.Null;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DataFechamento", cliente.DataFechamento);
                }
            }

            objConexao.Conectar();

            cmd.ExecuteNonQuery();

            objConexao.Desconectar();
        }

        //Base de Dados Os Imagem
        //Incluir Imagem de Os
        public void IncluirOsImagem(OsImagem Imagem)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            //transacao = objConexao.ObjetoConexao.BeginTransaction("");


            cmd.CommandText = "EXEC OsImagemInserir @IdOs,@Imagem;";

            cmd.Parameters.AddWithValue("@IdOs", Imagem.IdOs);
            cmd.Parameters.AddWithValue("@Imagem", Imagem.Imagem);  

            objConexao.Conectar();
            cmd.ExecuteScalar();
        }
        public void AlterarOsImagem(OsImagem Imagem)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;

            //transacao = objConexao.ObjetoConexao.BeginTransaction("");


            cmd.CommandText = "EXEC OsImagemUpdate @IdOs,@Imagem;";

            cmd.Parameters.AddWithValue("@IdOs", Imagem.IdOs);
            cmd.Parameters.AddWithValue("@Imagem", Imagem.Imagem);


            objConexao.Conectar();

            cmd.ExecuteScalar();
        }

    }
}

