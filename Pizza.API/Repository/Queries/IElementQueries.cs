using Entities.Models;

namespace Pizza.API.Repository.Queries
{
    public interface IElementQueries
    {
        Task<List<Element>> GetAllElements();
    }
}
