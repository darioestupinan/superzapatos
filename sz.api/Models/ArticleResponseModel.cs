using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using sz.commons.models;

namespace sz.api.Models
{
    [DataContract]
    public class ArticleResponseModel : StoreModelBase
    {
        [DataMember]
        [JsonProperty(PropertyName = "article")]
        public Article Article { get; private set; }

        public ArticleResponseModel (Article article) : base (true)
        {
            Article = article;         
        }
    }


    public class ArticlesResponseModel : StoreModelBase
    {
        [JsonProperty(PropertyName = "articles", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Article> Articles { get; set; }

        [JsonProperty(PropertyName = "total_elements", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TotalElements { get; set; }

        public ArticlesResponseModel (IEnumerable<Article> articles) : base (true)
        {
            Articles = articles;
            TotalElements = articles.Count();
        }
    }
}
