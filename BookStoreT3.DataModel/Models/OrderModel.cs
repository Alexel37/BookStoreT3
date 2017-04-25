using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreT3.DataModel.Models
{
    public class OrderModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("total value")]
        public double TotalValue { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("user id")]
        public int UserId { get; set; }
    }
}
