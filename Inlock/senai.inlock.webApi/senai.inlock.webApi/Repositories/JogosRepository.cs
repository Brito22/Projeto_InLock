using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class JogosRepository : IJogosReposirtory
    {
        private string stringConexao = "Data Source=DESKTOP-PVCFVR0\\SQLEXPRESS; initial catalog=inlock_games_TARDE ; user Id=sa; pwd=senai@132";

        public void AtualizarIdCorpo(JogosDomain jogoATT)
        {
            if (jogoATT.nomeJogo != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE JOGOS SET nomeJogo = @nomeJogo, descrição = @descrição , dataLançamento = @data, valor = @valor WHERE idJogo = @idJogo";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@nomeGenero", jogoATT.nomeJogo);
                        cmd.Parameters.AddWithValue("@descrição", jogoATT.descrição);
                        cmd.Parameters.AddWithValue("@data", jogoATT.dataLançamento);
                        cmd.Parameters.AddWithValue("@valor", jogoATT.Valor);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        public void AtualizarIUrl(int id ,JogosDomain jogoATT)
        {
            if (jogoATT.nomeJogo != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE JOGOS SET nomeJogo = @nomeJogo, descrição = @descrição , dataLançamento = @data, valor = @valor WHERE idJogo = @idJogo";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@nomeJogo", jogoATT.nomeJogo);
                        cmd.Parameters.AddWithValue("@descrição", jogoATT.descrição);
                        cmd.Parameters.AddWithValue("@data", jogoATT.dataLançamento);
                        cmd.Parameters.AddWithValue("@valor", jogoATT.Valor);
                        cmd.Parameters.AddWithValue("@idJogo", id);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public JogosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = @"SELECT idJogo, nomeJogo as Jogo, descrição, dataLançamento as DataLançamento, valor, nomeEstudio as Estudio FROM JOGOS
                                            LEFT JOIN ESTUDIO
                                            ON JOGOS.idEstudio = ESTUDIO.idEstudio
                                            WHERE idJogo = @idJogo
                                            ";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idJogo", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogosDomain jogoBuscado = new JogosDomain
                        {
                            idJogo = Convert.ToInt32(rdr[0]),

                            nomeJogo = rdr[1].ToString(),
                            descrição = rdr[2].ToString(),
                            dataLançamento = Convert.ToDateTime(rdr[3]),


                            Valor = Convert.ToDecimal(rdr[4]),

                            estudio = new EstudioDomain() { nomeEstudio = rdr[5].ToString() },
                        };

                        return jogoBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(JogosDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = "INSERT INTO JOGOS (nomeJogo, descrição, dataLançamento,valor,idEstudio) VALUES (@nomeJogo, @descrição, @dataLançamento, @valor, @idEstudio)";

                con.Open();

                

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    EstudioDomain e = new EstudioDomain();
                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@descrição", novoJogo.descrição);
                    cmd.Parameters.AddWithValue("@dataLançamento", novoJogo.dataLançamento);
                    cmd.Parameters.AddWithValue("@valor", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@idEstudio", novoJogo.idEstudio );

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
              
                string queryDelete = "DELETE FROM JOGOS WHERE idJogo = @idJogo";

                
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    
                    cmd.Parameters.AddWithValue("@idJogo", id);

                    
                    con.Open();

                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogosDomain> ListarTodos()
        {
            List<JogosDomain> listajogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idjogo, nomeJogo as Jogo, descrição, dataLançamento as DataLançamento, valor, nomeEstudio as Estudio FROM JOGOS LEFT JOIN ESTUDIO ON JOGOS.idEstudio = ESTUDIO.idEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogosDomain jogo = new JogosDomain()
                        {
                            idJogo = Convert.ToInt32(rdr[0]),

                            nomeJogo = rdr[1].ToString(),
                            descrição = rdr[2].ToString(),
                            dataLançamento = Convert.ToDateTime(rdr[3]),
                            
                            
                            Valor = Convert.ToDecimal(rdr[4]),

                            estudio = new EstudioDomain() { nomeEstudio = rdr[5].ToString()}, 
                            
                        };

                        listajogos.Add(jogo);
                    }
                }
            }

            return listajogos;
        }
    }
}