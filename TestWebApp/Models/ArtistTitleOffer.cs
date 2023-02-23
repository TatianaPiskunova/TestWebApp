using System.Drawing;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System;
using TestWebApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.IO;

namespace TestWebApp.Models
{
    public class ArtistTitleOffer : Offer
    {
        public string? id { get; set; }
        public string? delivery { get; set; }
        public string? year { get; set; }
        public string? artist { get; set; }
        public string? title { get; set; }
        public string? media { get; set; }
        public string? starring { get; set; }
        public string? director { get; set; }
        public string? originalName { get; set; }
        public string? country { get; set; }
    }
}
