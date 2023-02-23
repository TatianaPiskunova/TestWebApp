using System.Diagnostics.Metrics;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography;
using System.Xml.Linq;
using System;
using TestWebApp.Models;

namespace TestWebApp.Models
{
    public class TourOffer:Offer
    {
        public string? id { get; set; }
        public string? delivery { get; set; }
        public string? localDeliveryCost { get; set; }
        public string? name { get; set; }
        public string? country { get; set; }
        public string? worldRegion { get; set; }
        public string? region { get; set; }
        public string? days { get; set; }
        public string? dataTour { get; set; }
        public string? hotelStars { get; set; }
        public string? room { get; set; }
        public string? meal { get; set; }
        public string? included { get; set; }
        public string? transport { get; set; }
     
    }
}

