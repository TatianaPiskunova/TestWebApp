using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;
using System.Xml.Linq;
using System;
using TestWebApp.Models;

namespace TestWebApp.Models
{
    public class EventTicketOffer:Offer
    {
        public string? id { get; set; }
        public string? delivery { get; set; }
        public string? localDeliveryCost { get; set; }
        public string? name { get; set; }
        public string? place { get; set; }
        public string? hall { get; set; }
        public string? hallPlan { get; set; }
        public string? hallPart { get; set; }
        public string? date { get; set; }
        public string? isPremiere { get; set; }
        public string? isKids { get; set; }
    }
}

