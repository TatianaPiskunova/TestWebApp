namespace TestWebApp.Models
{
    public class VendorModelOffer:Offer
    {
        public string? id { get; set; }
        public string? cbid { get; set; }
        public string? delivery { get; set; }
        public string? localDeliveryCost { get; set; }
        public string? typePrefix { get; set; }
        public string? vendor { get; set; }
        public string? vendorCode { get; set; }
        public string? model { get; set; }
        public string? manufacturerWarranty { get; set; }
        public string? countryOforigin { get; set; }
        
    }
}
