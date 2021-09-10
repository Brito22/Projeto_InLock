using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JogosController : ControllerBase
    {

        private IJogosReposirtory _jogosRepository { get; set; }

        public JogosController()
        {
            _jogosRepository = new JogosRepository();
        }
        [Authorize(Roles = "ADMINISTRADOR, CLIENTE")]
        [HttpGet]
        public IActionResult Get()
        {
            List<JogosDomain> listaJogos = _jogosRepository.ListarTodos();

            return Ok(listaJogos);

        }

        [Authorize(Roles = "ADMINISTRADOR, CLIENTE")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            JogosDomain JogosBuscado = _jogosRepository.BuscarPorId(id);

            if (JogosBuscado == null)
            {
                return NotFound("Nenhum jogo encontrado!");
            }

            return Ok(JogosBuscado);
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost("cadastrar")]
        public IActionResult Post(JogosDomain novoJogo)
        {
            _jogosRepository.Cadastrar(novoJogo);

            return StatusCode(201);
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, JogosDomain jogoAtualizado)
        {
            JogosDomain jogoBuscado = _jogosRepository.BuscarPorId(id);

            if (jogoBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Jogo não encontrado!",
                            erro = true
                        }
                    );
            }

            try
            {
                _jogosRepository.AtualizarIUrl(id, jogoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult PutIdBody(JogosDomain jogoAtualizado)
        {
            if (jogoAtualizado.nomeJogo == null || jogoAtualizado.idJogo <= 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Nome ou o id do jogo não foi informado!"
                    });
            }

            JogosDomain jogoBuscado = _jogosRepository.BuscarPorId(jogoAtualizado.idJogo);

            if (jogoBuscado != null)
            {
                try
                {
                    _jogosRepository.AtualizarIdCorpo(jogoAtualizado);

                    return NoContent();
                }
                catch (Exception codErro)
                {
                    return BadRequest(codErro);
                }
            }

            return NotFound(
                    new
                    {
                        mensagem = "Jogo não encontrado!",
                        errorStatus = true
                    }
                );
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _jogosRepository.Deletar(id);

            return NoContent();
        }
    }
}
