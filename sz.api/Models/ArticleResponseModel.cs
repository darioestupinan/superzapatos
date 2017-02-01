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
    public class ArticleResponseModel : FailureModel
    {
        [DataMember]
        [JsonProperty(PropertyName = "article")]
        public Article Article { get; private set; }

        public ArticleResponseModel CreateOkModel(Article article)
        {
            Success = true;
            Article = article;
            return this;
        }
    }


    public class ArticlesResponseModel : FailureModel
    {
        [JsonProperty(PropertyName = "articles", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Article> Articles { get; set; }

        [JsonProperty(PropertyName = "total_elements", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TotalElements { get; set; }

        public ArticlesResponseModel CreateOkModel(IEnumerable<Article> articles)
        {
            Success = true;
            Articles = articles;
            TotalElements = articles.Count();
            return this;
        }

        public bool ShouldSerializeManager()
        {
            // don't serialize the Manager property if an employee is their own manager
            return (Articles.Count() > 0);
        }

    }
}
