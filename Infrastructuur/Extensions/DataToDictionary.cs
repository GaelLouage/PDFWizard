using HtmlAgilityPack;
using Infrastructuur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructuur.Extensions
{
    public static class DataToDictionary
    {
        public static int dictionaryId = 0;
        public static  Dictionary<string, string> DictionaryData(this Dictionary<string, string> data, WebsiteEntity websiteToScrap, HtmlNodeCollection? linkNodes,  Action<Dictionary<string,string>, int, HtmlNode> HrefOrSource)
        {
       
            foreach (var linkNode in linkNodes)
            {
                if (websiteToScrap.TagName == "a")
                {
                    HrefOrSource(data, dictionaryId, linkNode);
                }
                else if (websiteToScrap.TagName == "img")
                {
                    HrefOrSource(data, dictionaryId, linkNode);
                }
                else
                {
                    if (!data.ContainsKey(dictionaryId.ToString()))
                    {
                        data.Add(websiteToScrap.TagName + dictionaryId.ToString(), linkNode.InnerText);
                    }
                }
                dictionaryId++;
            }
            dictionaryId = 0;
            return data;
        }
    }
}
