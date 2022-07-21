using Entities.Models;
using HtmlAgilityPack;

namespace Pizza.API.Helpers
{
    public class ParseHtml
    {
        public static List<Element> ParseHTMLDocument(HtmlDocument htmlDoc, Dictionary<HtmlNode, Element> seenNodes)
        {
           
            //  Set Root Node
            HtmlNode currentNode = htmlDoc.DocumentNode;
            var hasChildren = currentNode.HasChildNodes;
            var hasNextSibling = currentNode.NextSibling != null;
            seenNodes[currentNode] = new Element()
            {
                Id = Guid.NewGuid(),
                IsRoot = true,
                NodeType = currentNode.Name,
                HtmlId = currentNode.Attributes["id"]?.Value,
                HtmlClasses = currentNode.Attributes["class"]?.Value,
                HtmlStyles = currentNode.Attributes["style"]?.Value,
                HtmlName = currentNode.Attributes["name"]?.Value,
                HtmlValue = currentNode.Attributes["value"]?.Value,
                ParentId = null,
                FirstChildId = hasChildren ? Guid.NewGuid() : null,
                NextSiblingId = hasNextSibling ? Guid.NewGuid() : null,
            };
            //  Recurse Starting on First Child if exists, else return
            if (!hasChildren)
            {
                return seenNodes.Values.ToList();
            }

            WalkTree(currentNode.FirstChild, true, seenNodes);
            //  At this point dictionary should be filled???
            //  Turn dict into List<PageElement> and return it.
            List<Element> returnList = seenNodes.Values.ToList();
            return returnList;
        }

        public static void WalkTree(HtmlNode node, bool CalledAsFirstChild, Dictionary<HtmlNode, Element> seenNodes)
        {
            var hasChildren = node.HasChildNodes;
            var hasNextSibling = node.NextSibling != null;
            //  If called by first child, Id comes from Parent, 
            //  If called by sibling, Id comes from previous Sibling.
            Guid? _Id = CalledAsFirstChild ? seenNodes[node.ParentNode].FirstChildId : seenNodes[node.PreviousSibling].NextSiblingId;
            Guid? _FirstChildId = hasChildren ? Guid.NewGuid() : null;
            Guid? _NextSiblingId = hasNextSibling ? Guid.NewGuid() : null;
            Guid? _ParentId = seenNodes[node.ParentNode].Id;
            //  Add New Element to Dictionary
            seenNodes[node] = new Element()
            {
                Id = _Id,
                IsRoot = false,
                NodeType = node.Name,
                HtmlId = node.Attributes["id"]?.Value,
                HtmlClasses = node.Attributes["class"]?.Value,
                HtmlStyles = node.Attributes["style"]?.Value,
                HtmlName = node.Attributes["name"]?.Value,
                HtmlValue = node.Attributes["value"]?.Value,
                ParentId = _ParentId,
                FirstChildId = _FirstChildId,
                NextSiblingId = _NextSiblingId
            };
            //If Next Child exists, call recursion on it
            if (hasChildren)
            {
                WalkTree(node.FirstChild, true, seenNodes);
            }

            //If Next Sibling exists, call recursion on it
            if (hasNextSibling)
            {
                WalkTree(node.NextSibling, false, seenNodes);
            }
        }
    }
}
