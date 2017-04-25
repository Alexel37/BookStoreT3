using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreT3.DataModel.Models
{
    public class ExtraInfoModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("isbn10")]
        public string Isbn10 { get; set; }

        [JsonProperty("isbn13")]
        public string Isbn13 { get; set; }

        [JsonProperty("year")]
        public Nullable<int> Year { get; set; }
    }
}
