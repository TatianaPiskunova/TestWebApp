using System.Security.Cryptography;
using System.Xml.Linq;
using System;
using TestWebApp.Models;

namespace TestWebApp.Models
{
    public class AudiobookOffer:Offer
    {
        public string? id { get; set; }
        public string? author { get; set; }
        public string? name { get; set; }
        public string? publisher { get; set; }
        public string? year { get; set; }
        public string? ISBN { get; set; }
        public string? language { get; set; }
        public string? downloadable { get; set; }
        public string? performedBy { get; set; }
        public string? performanceType { get; set; }
        public string? storage { get; set; }
        public string? format { get; set; }
        public string? recordingLength { get; set; }
       
    }
}
