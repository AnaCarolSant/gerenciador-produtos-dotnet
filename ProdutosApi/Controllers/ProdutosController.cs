using Microsoft.AspNetCore.Mvc;
using ProdutosBusiness;
using ProdutosModel;

namespace ProdutosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutosService _produtosService;

        public ProdutosController(ProdutosService produtosService)
        {
            _produtosService = produtosService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var produtos = await _produtosService.ListarTodosAsync();
            return produtos == null || !produtos.Any() ? NoContent() : Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var produto = await _produtosService.ObterPorIdAsync(id);
            return produto == null ? NotFound() : Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProdutoModel produto)
        {
            if (produto == null || string.IsNullOrWhiteSpace(produto.Nome))
                return BadRequest("Nome é obrigatório.");

            try
            {
                var criado = await _produtosService.CriarAsync(produto);
                return CreatedAtAction(nameof(Get), new { id = criado.Id }, criado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao cadastrar produto: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProdutoModel produto)
        {
            if (produto == null || produto.Id != id)
                return BadRequest("Dados inconsistentes.");

            var atualizado = await _produtosService.AtualizarAsync(produto);
            return atualizado ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _produtosService.RemoverAsync(id);
            return removido ? NoContent() : NotFound();
        }
    }
}
