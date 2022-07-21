using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Pizza.API.Data;

namespace Pizza.API.Repository.Queries
{
    public class ElementQueries : IElementQueries
    {
        private readonly IDbContextFactory<PizzaDbContext> _contextFactory;
        //private readonly PizzaDbContext _dbContext;

        public ElementQueries(IDbContextFactory<PizzaDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Element>> GetAllElements()
        {
            using (PizzaDbContext _context = _contextFactory.CreateDbContext())
            {
                var elements = await _context.Elements.ToListAsync();
                return elements;
            }
        }
    }
}
