using Domain.Entities;
using Domain.Repos;
using Domain.Shared;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos;

public class BookRepo : IBookRepo
{
    private readonly AppDbContext _context;

    public BookRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Book entity)
    {
        await _context.Books.AddAsync(entity);
    }

    public async Task<bool> DeleteByIdAsync(long id, CancellationToken cancellationToken)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (book is not null)
        {
            _context.Books.Remove(book);
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteByTitleAsync(string title)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Title == title);
        if (book is not null)
        {
            _context.Books.Remove(book);
            return true;
        }
        return false;
    }

    public Task<List<Book>> GetAllAsync(CancellationToken cancellationToken)
    {
        return _context.Books.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Book?> GetByTitleAsync(string title)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Title == title);
        return book ?? default;
    }

    public void Update(Book entity)
    {
        _context.Books.Update(entity);
    }
}
