using IRM.Livraria.Domain.Abstractions;
using IRM.Livraria.Domain.Entities;
using IRM.Livraria.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace IRM.Livraria.Infraestructure.Repositories;

public class LivroRepository : ILivroRepository
{
    private readonly ApplicationDbContext _context;

    public LivroRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Livro> AdicionarLivro(Livro livro)
    {
        _context.Add(livro);
        await _context.SaveChangesAsync();
        return livro;
    }

    public async Task AtualizarLivro(Livro livro)
    {
        _context.Entry(livro).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeletarLivro(int id)
    {
        var livro = await ObterLivro(id);
        if (livro is not null)
        {
            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
        }
        else
        {
            var message = ($"Livro Id {0} não localizado", id).ToString();
            throw new InvalidOperationException(message);
        }
    }

    public async Task<Livro?> ObterLivro(int id)
    {
        return await _context.Livros.FirstOrDefaultAsync(x => x.LivroId == id);
    }

    public async Task<IEnumerable<Livro>> ObterLivros()
    {
        return await _context.Livros.ToListAsync();
    }
}
