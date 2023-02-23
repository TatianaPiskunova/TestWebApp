using Microsoft.EntityFrameworkCore;
using TestWebApp.Models;

namespace TestWebApp.EF
{
    public class OfferContext : DbContext
    {
        public OfferContext(DbContextOptions options) : base(options)
        { }
        public DbSet<ArtistTitleOffer> ArtistTitleOffers { get; set; }
        public DbSet<AudiobookOffer> AudiobookOffers { get; set; }
        public DbSet<BookOffer> BookOffers { get; set; }
        public DbSet<EventTicketOffer> EventTicketOffers { get; set; }
        public DbSet<TourOffer> TourOffers { get; set; }
        public DbSet<VendorModelOffer> VendorModelOffers { get; set; }
        
    }
}
