using DesafioBTG.Requisicao;
using DesafioBTG.Servicos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBTG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AliquotaController : Controller
    {
        private readonly IAliquotaServico _aliquotaServico;

        public AliquotaController(IAliquotaServico aliquotaServico)
        {
            _aliquotaServico = aliquotaServico;
        }

        [HttpPost("{fundoId}/aplicacao")]
        public async Task<IActionResult> Aplicar(int fundoId, [FromBody] Requisicoes requisicoes)
        {
            try
            {
                requisicoes.NumeroFundo = fundoId;
                var aplicacao = await _aliquotaServico.Aplicar(requisicoes);

                return CreatedAtAction(nameof(Aplicar), new {
                    data = new {
                        id = aplicacao.Id,
                        valor = aplicacao.Valor,
                        dataAplicacao = aplicacao.DataAplicacao }
                });
            }
            catch (ArgumentException ex)
            {
                return NotFound(new {
                    data = new {
                        error = ex.Message
                    }
                });
            }

            catch (InvalidOperationException ex)
            {
                return BadRequest(new
                {
                    data = new {
                        error = ex.Message
                    }
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new {
                        error = ex.Message
                    }
                });
            }

        }


        [HttpPost("{fundoId}/resgate")]
        public async Task<IActionResult> Resgatar(int fundoId, [FromBody] Requisicoes requisicoes)
        {
            try
            {
                requisicoes.NumeroFundo = fundoId;
                var resgate = await _aliquotaServico.Resgatar(requisicoes);

                return CreatedAtAction(nameof(Resgatar), new
                {
                    data = new
                    {
                        id = resgate.Id,
                        valor = resgate.Valor,
                        dataAplicacao = resgate.DataResgate
                    }
                });
            }
            catch (ArgumentException ex)
            {
                return NotFound(new
                {
                    data = new
                    {
                        error = ex.Message
                    }
                });
            }

            catch (InvalidOperationException ex)
            {
                return BadRequest(new
                {
                    data = new
                    {
                        error = ex.Message
                    }
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new
                    {
                        error = ex.Message
                    }
                });
            }
        }

        [HttpGet("/listar")]
        public async Task<IActionResult> Listar()
        {
            
            var fundosAplicacoes = await _aliquotaServico.Listar();

            return Ok(new{data = fundosAplicacoes});
        }
    }
}
