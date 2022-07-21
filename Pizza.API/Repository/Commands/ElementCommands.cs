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

            using(PizzaDbContext _context = _contextFactory.CreateDbContext())
            {
                foreach (var item in elements)
                {
                    _context.Elements.Add(item);
                }
                return _context.SaveChanges() > 0;
            }
        }
    }
}
