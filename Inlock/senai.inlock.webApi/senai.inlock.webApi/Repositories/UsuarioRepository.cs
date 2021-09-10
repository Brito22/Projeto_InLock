using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-PVCFVR0\\SQLEXPRESS; initial catalog=inlock_games_TARDE ; user Id=sa; pwd=senai@132";
        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {

                    string querySelect = @"    SELECT    idUsuario
			                                        ,email
			                                        ,senha
			                                        ,Titulo
                                          FROM USUARIO
                                          LEFT JOIN TIPO_DE_USUARIO
                                          ON USUARIO.idTipoUsuario = TIPO_DE_USUARIO.idTipoUsuario
                                          WHERE email = @email
                                          and senha = @senha ";

                    using (SqlCommand cmd = new SqlCommand(querySelect, con))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@senha", senha);

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        //caso os dados tenham sido obtidos
                        if (rdr.Read())
                        {
                            //cria um objeto do tipo UsuarioDomain
                            UsuarioDomain usuarioBuscado = new UsuarioDomain
                            {
                                //atribui às propriedades os valores das colunas do banco de dados
                                //idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                                Email = rdr["email"].ToString(),
                                TipoUsuario = new TipoUsuarioDomain() { Titulo = rdr["titulo"].ToString()},
                                //Titulo = rdr["titulo"].ToString(),
                                Senha = rdr["senha"].ToString()
                            };

                            //jwt.ex=  

                            //retorna o usuario buscado
                            return usuarioBuscado;

                        }

                        //Caso não encontre um email e senha correspondente, retorna null;
                        return null;

                    }
                }
            }
        }
    }

