using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sz.api.Models
{
    public class Article: sz.commons.models.Article
    {
        public Store Store { get; set; }
    }
}
