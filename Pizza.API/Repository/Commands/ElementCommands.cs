using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Pizza.API.Data;

namespace Pizza.API.Repository.Commands
{
    public class ElementCommands : IElementCommands
    {

        private readonly IDbContextFactory<PizzaDbContext> _contextFactory;
        //private readonly PizzaDbContext _dbContext;

        public ElementCommands(IDbContextFactory<PizzaDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public bool UploadElements(List<Element> elements)
        {
            
            Parallel.ForEach(elements, currentElement =>
            {
                using (PizzaDbContext _context = _contextFactory.CreateDbContext())
                {
                    _context.Elements.Add(currentElement);
                    _context.SaveChanges();
                   
                }
            });
            return true;
            
        }
    }
}
