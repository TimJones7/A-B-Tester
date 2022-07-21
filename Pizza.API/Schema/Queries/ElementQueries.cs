using Entities.Models;
using Pizza.API.Repository.Queries;

namespace Pizza.API.Schema.Queries
{
    public partial class Query
    {

        private readonly IElementQueries _elementQueries;

        public Query(IElementQueries elementQueries)
        {
            _elementQueries = elementQueries;
        }



        public string getElement() => "Getting the element";


        public async Task<List<Element>> GetElementsAsync()
        {
            return await _elementQueries.GetAllElements();
        }


    }
}
