using System.Security.Cryptography;
using System.Xml.Linq;
using System;
using TestWebApp.Models;

namespace TestWebApp.Models
{
    public class BookOffer:Offer
    {
        public string? id { get; set; }
        public string? delivery { get; set; }
        public string? localDeliveryCost { get; set; }
        public string? author { get; set; }
        public string? name { get; set; }
        public string? publisher { get; set; }
        public string? series { get; set; }
        public string? year { get; set; }
        public string? ISBN { get; set; }
        public string? volume { get; set; }
        public string? part { get; set; }
        public string? language { get; set; }
        public string? binding { get; set; }
        public string? pageExtent { get; set; }
        public string? downloadable { get; set; }
      


    }
}
