using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreT3.DataModel.Models
{
    public class BookModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("type of book id")]
        public int TypeOfBookId { get; set; }
    }
}
