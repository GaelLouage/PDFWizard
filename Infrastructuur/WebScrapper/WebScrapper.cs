using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructuur.WebScrapper;
using Infrastructuur.Models;
using Infrastructuur.Extensions;

namespace Infrastructuur.WebScrapper
{
    public class WebScrapper
    {
        public async Task<Dictionary<string, string>> GetByTagNameAsync(WebsiteEntity websiteToScrap)
        {
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync(websiteToScrap.Url);

            var data = new Dictionary<string, string>();

            var linkNodes = doc.DocumentNode.SelectNodes($"//{websiteToScrap.TagName}");

            if (linkNodes is not null)
            {
                data.DictionaryData(websiteToScrap, linkNodes,
                     (x, y, z) => HrefOrSource(data, DataToDictionary.dictionaryId, linkNodes[DataToDictionary.dictionaryId], websiteToScrap.TagName));
            }
            return data;
        }
        private void HrefOrSource(Dictionary<string, string> data, int dictionaryId, HtmlNode? linkNode, string node)
        {
            switch (node)
            {
                case "img":
                    if (!data.ContainsKey(dictionaryId.ToString()))
                    {
                        data.Add("img"+dictionaryId.ToString(), "src:" + linkNode.GetAttributeValue("src", ""));
                    }
                    break;
                case "a":
                    if (!data.ContainsKey(dictionaryId.ToString()))
                    {
                        data.Add("href"+dictionaryId.ToString(), "href:" + linkNode.GetAttributeValue("href", ""));
                    }
                    break;
            }
        }
    }
}
