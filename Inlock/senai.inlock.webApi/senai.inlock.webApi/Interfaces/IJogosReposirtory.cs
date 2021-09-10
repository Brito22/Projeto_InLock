using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IJogosReposirtory
    {
        /// <summary>
        /// Lista jogos
        /// </summary>
        /// <returns>uma lista com todos os jogos</returns>
        List<JogosDomain> ListarTodos();
        /// <summary>
        /// Busca o jogo pelo seu id
        /// </summary>
        /// <param name="id">id do jogo a ser buscado</param>
        JogosDomain BuscarPorId(int id);
        /// <summary>
        /// Cadastra um novo jogo 
        /// </summary>
        /// <param name="novoJogo">novo jogo a ser cadastrado</param>
        void Cadastrar(JogosDomain novoJogo);
        /// <summary>
        /// Atualiza o jogo pelo body do cliente
        /// </summary>
        /// <param name="jogoATT">jogo atualizado</param>
        void AtualizarIdCorpo(JogosDomain jogoATT);
        /// <summary>
        /// Atualiza jogo pelo body do cliente podendo ter id na URL
        /// </summary>
        /// <param name="jogoATT"> jogo atualizado</param>
        void AtualizarIUrl(int id ,JogosDomain jogoATT);
        /// <summary>
        /// Deleta jogos pelo id
        /// </summary>
        /// <param name="id">id do jogo a ser deletado </param>
        void Deletar(int id);
    }
}
