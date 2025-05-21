using ProdutosModel;
using ProdutosData;
using Microsoft.EntityFrameworkCore;

namespace ProdutosBusiness;
public class ProdutosService
{
    private readonly AppDbContext _context;

    public ProdutosService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProdutoModel>> ListarTodosAsync()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task<ProdutoModel?> ObterPorIdAsync(int id)
        => await _context.Produtos.FindAsync(id);

    public async Task<ProdutoModel> CriarAsync(ProdutoModel produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<bool> AtualizarAsync(ProdutoModel produto)
    {
        var existente = await _context.Produtos.FindAsync(produto.Id);
        if (existente == null) return false;
        existente.Nome = produto.Nome;
        existente.Preco = produto.Preco;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoverAsync(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);
        if (produto == null) return false;
        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
        return true;
    }
}