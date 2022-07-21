using Entities.Models;
using HtmlAgilityPack;
using Pizza.API.Helpers;
using Pizza.API.Repository.Commands;

namespace Pizza.API.Schema.Mutations
{
    public partial class Mutation
    {

        private readonly IElementCommands _elementCommands;

        public Mutation(IElementCommands elementCommands)
        {
            _elementCommands = elementCommands;
        }
        

        public bool ElementsByURL(string url)
        {
            Dictionary<HtmlNode, Element> seenNodes1 = new Dictionary<HtmlNode, Element>();
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(url);
            List<Element> elements = ParseHtml.ParseHTMLDocument(htmlDoc, seenNodes1);
            return _elementCommands.UploadElements(elements);
        }

        public bool ElementsByString(string htmlString)
        {
            Dictionary<HtmlNode, Element> seenNodes1 = new Dictionary<HtmlNode, Element>();
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlString);
            List<Element> elements = ParseHtml.ParseHTMLDocument(htmlDoc, seenNodes1);
            return _elementCommands.UploadElements(elements);
        }
    }
}
