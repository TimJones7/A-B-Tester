using Entities.Models;

namespace Pizza.API.Repository.Commands
{
    public interface IElementCommands
    {
        bool UploadElements(List<Element> elements);
    }
}
