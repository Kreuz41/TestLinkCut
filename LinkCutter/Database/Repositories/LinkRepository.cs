using LinkCutter.Models;
using Microsoft.EntityFrameworkCore;

namespace LinkCutter.Database.Repositories;

public class LinkRepository
{
    private readonly AppDbContext _dbContext;

    public LinkRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Link?> GetLinkByUrl(string link)
    {
        return _dbContext.Links.FirstOrDefaultAsync(l => l.FullLink == link);
    }
    
    public Task<Link?> GetLinkById(long id)
    {
        return _dbContext.Links.FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<Link> InsertLink(string link)
    {
        var addedLink = new Link
        {
            FullLink = link
        };
        var entity = _dbContext.Links.Add(addedLink);
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }

        return entity.Entity;
    }
}