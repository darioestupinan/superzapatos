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

    [DataContract]
    public class ArticlesResponseModel : FailureModel
    {
        [DataMember]
        [JsonProperty(PropertyName = "articles")]
        public IEnumerable<Article> Articles { get; private set; }

        public ArticlesResponseModel CreateOkModel(IEnumerable<Article> articles)
        {
            Success = true;
            Articles = articles;
            return this;
        }        
    }
}
