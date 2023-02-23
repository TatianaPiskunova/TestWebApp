using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using TestWebApp.EF;
using TestWebApp.Models;


namespace TestWebApp.Controllers
{


    public class HomeController : Controller    
    {

        private readonly OfferContext _context;
        private readonly ILogger<HomeController> _logger;
        public HomeController(OfferContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
    }
       
        List<Category> listOfCategories = new();
        List<VendorModelOffer> listOfVendorModelOffer = new();
        List<BookOffer> listOfBookOffer = new();
        List<AudiobookOffer> listOfAudiobookOffer = new();
        List<ArtistTitleOffer> listOfArtistTitleOffer = new();
        List<TourOffer> listOfTourOffer = new();
        List<EventTicketOffer> listOfEventTicketOffers=new();

       
        public IActionResult Index()
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string URLString = "http://partner.market.yandex.ru/pages/help/YML.xml";

            ViewBag.listOfCategories = listOfCategories;
            ViewBag.listOfVendorModelOffer= listOfVendorModelOffer;
            ViewBag.listOfBookOffer = listOfBookOffer;
            ViewBag.listOfAudiobookOffer= listOfAudiobookOffer;
            ViewBag.listOfArtistTitleOffer= listOfArtistTitleOffer;
            ViewBag.listOfTourOffer= listOfTourOffer;
            ViewBag.listOfEventTicketOffers= listOfEventTicketOffers;

            var xDoc = new XmlDocument();
            xDoc.Load(URLString);
            XmlElement? xRoot = xDoc.DocumentElement;
            
            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "categories")
                        {
                           
                            foreach (XmlNode child in childnode)
                            {
                                Category category = new()
                                {
                                    id = child.Attributes?.GetNamedItem("id")?.Value,
                                    parentId = child.Attributes?.GetNamedItem("parentId")?.Value,
                                    Name = child.InnerText
                                };
                                listOfCategories.Add(category);
                            }
                           
                        }
                        if (childnode.Name == "offers")
                        {
                            foreach (XmlNode childOffer in childnode)
                            {
                                XmlNode? attrType = childOffer.Attributes?.GetNamedItem("type");
                                if (attrType?.Value == "vendor.model")
                                {

                                    VendorModelOffer vendorModelOffer = new()
                                    {
                                        id = childOffer.Attributes?.GetNamedItem("id")?.Value,
                                        type = attrType?.Value,
                                        bid = childOffer.Attributes?.GetNamedItem("bid")?.Value,
                                        cbid = childOffer.Attributes?.GetNamedItem("cbid")?.Value,
                                        available = childOffer.Attributes?.GetNamedItem("available")?.Value
                                    };
                                    foreach (XmlNode ch in childOffer.ChildNodes)
                                    {
                                        if (ch.Name== "url") vendorModelOffer.url = ch.InnerText;
                                        if (ch.Name == "price") vendorModelOffer.price = ch.InnerText;
                                        if (ch.Name == "currencyId") vendorModelOffer.currencyId = ch.InnerText;
                                        if (ch.Name == "categoryId") 
                                            { vendorModelOffer.categoryId = ch.InnerText;
                                              vendorModelOffer.categoryIdType = ch.Attributes?.GetNamedItem("type")?.Value;
                                            }

                                        if (ch.Name == "picture") vendorModelOffer.picture = ch.InnerText;
                                        if (ch.Name == "delivery") vendorModelOffer.delivery = ch.InnerText;
                                        if (ch.Name == "local_delivery_cost") vendorModelOffer.localDeliveryCost = ch.InnerText;
                                        if (ch.Name == "typePrefix") vendorModelOffer.typePrefix = ch.InnerText;
                                        if (ch.Name == "vendor") vendorModelOffer.vendor = ch.InnerText;
                                        if (ch.Name == "vendorCode") vendorModelOffer.vendorCode = ch.InnerText;
                                        if (ch.Name == "model") vendorModelOffer.model = ch.InnerText;
                                        if (ch.Name == "description") vendorModelOffer.description = ch.InnerText;
                                        if (ch.Name == "manufacturer_warranty") vendorModelOffer.manufacturerWarranty = ch.InnerText;
                                        if (ch.Name == "country_of_origin") vendorModelOffer.countryOforigin = ch.InnerText;
                                    }
                                    listOfVendorModelOffer.Add(vendorModelOffer);
                                  
                                }

                                if (attrType?.Value == "book")
                                {
                                    BookOffer bookOffer = new()
                                    {
                                        id = childOffer.Attributes?.GetNamedItem("id")?.Value,
                                        type = attrType?.Value,
                                        bid = childOffer.Attributes?.GetNamedItem("bid")?.Value,
                                        available = childOffer.Attributes?.GetNamedItem("available")?.Value
                                    };
                                    foreach (XmlNode ch in childOffer.ChildNodes)
                                    {
                                        if (ch.Name == "url") bookOffer.url = ch.InnerText;
                                        if (ch.Name == "price") bookOffer.price = ch.InnerText;
                                        if (ch.Name == "currencyId") bookOffer.currencyId = ch.InnerText;
                                        if (ch.Name == "categoryId")
                                        {
                                            bookOffer.categoryId = ch.InnerText;
                                            bookOffer.categoryIdType = ch.Attributes?.GetNamedItem("type")?.Value;
                                        }

                                        if (ch.Name == "picture") bookOffer.picture = ch.InnerText;
                                        if (ch.Name == "delivery") bookOffer.delivery = ch.InnerText;
                                        if (ch.Name == "local_delivery_cost") bookOffer.localDeliveryCost = ch.InnerText;
                                        if (ch.Name == "author") bookOffer.author = ch.InnerText;
                                        if (ch.Name == "name") bookOffer.name = ch.InnerText;
                                        if (ch.Name == "publisher") bookOffer.publisher = ch.InnerText;
                                        if (ch.Name == "series") bookOffer.series = ch.InnerText;
                                        if (ch.Name == "year") bookOffer.year = ch.InnerText;
                                        if (ch.Name == "ISBN") bookOffer.ISBN = ch.InnerText;
                                        if (ch.Name == "volume") bookOffer.volume = ch.InnerText;
                                        if (ch.Name == "part") bookOffer.part = ch.InnerText;
                                        if (ch.Name == "language") bookOffer.language = ch.InnerText;
                                        if (ch.Name == "binding") bookOffer.binding = ch.InnerText;
                                        if (ch.Name == "page_extent") bookOffer.pageExtent = ch.InnerText;
                                        if (ch.Name == "description") bookOffer.description = ch.InnerText;
                                        if (ch.Name == "downloadable") bookOffer.downloadable = ch.InnerText;
                                    }
                                    listOfBookOffer.Add(bookOffer);
                                }


                                if (attrType?.Value == "audiobook") {
                                    AudiobookOffer audiobookOffer = new()
                                    {
                                        id = childOffer.Attributes?.GetNamedItem("id")?.Value,
                                        type = attrType?.Value,
                                        bid = childOffer.Attributes?.GetNamedItem("bid")?.Value,
                                        available = childOffer.Attributes?.GetNamedItem("available")?.Value
                                    };
                                    foreach (XmlNode ch in childOffer.ChildNodes)
                                    {
                                        if (ch.Name == "url") audiobookOffer.url = ch.InnerText;
                                        if (ch.Name == "price") audiobookOffer.price = ch.InnerText;
                                        if (ch.Name == "currencyId") audiobookOffer.currencyId = ch.InnerText;
                                        if (ch.Name == "categoryId")
                                        {
                                            audiobookOffer.categoryId = ch.InnerText;
                                            audiobookOffer.categoryIdType = ch.Attributes?.GetNamedItem("type")?.Value;
                                        }

                                        if (ch.Name == "picture") audiobookOffer.picture = ch.InnerText;
                                        if (ch.Name == "author") audiobookOffer.author = ch.InnerText;
                                        if (ch.Name == "name") audiobookOffer.name = ch.InnerText;
                                        if (ch.Name == "publisher") audiobookOffer.publisher = ch.InnerText;
                                        if (ch.Name == "year") audiobookOffer.year = ch.InnerText;
                                        if (ch.Name == "ISBN") audiobookOffer.ISBN = ch.InnerText;
                                        if (ch.Name == "language") audiobookOffer.language = ch.InnerText;
                                        if (ch.Name == "performed_by") audiobookOffer.performedBy = ch.InnerText;
                                        if (ch.Name == "performance_type") audiobookOffer.performanceType = ch.InnerText;
                                        if (ch.Name == "storage") audiobookOffer.storage = ch.InnerText;
                                        if (ch.Name == "format") audiobookOffer.format = ch.InnerText;
                                        if (ch.Name == "recording_length") audiobookOffer.recordingLength = ch.InnerText;
                                        if (ch.Name == "description") audiobookOffer.description = ch.InnerText;
                                        if (ch.Name == "downloadable") audiobookOffer.downloadable = ch.InnerText;
                                    }
                                    listOfAudiobookOffer.Add(audiobookOffer);

                                }
                                if (attrType?.Value == "artist.title") {
                                    ArtistTitleOffer artistTitleOffer = new()
                                    {
                                        id = childOffer.Attributes?.GetNamedItem("id")?.Value,
                                        type = attrType?.Value,
                                        bid = childOffer.Attributes?.GetNamedItem("bid")?.Value,
                                        available = childOffer.Attributes?.GetNamedItem("available")?.Value
                                    };
                                    foreach (XmlNode ch in childOffer.ChildNodes)
                                    {
                                        if (ch.Name == "url") artistTitleOffer.url = ch.InnerText;
                                        if (ch.Name == "price") artistTitleOffer.price = ch.InnerText;
                                        if (ch.Name == "currencyId") artistTitleOffer.currencyId = ch.InnerText;
                                        if (ch.Name == "categoryId")
                                        {
                                            artistTitleOffer.categoryId = ch.InnerText;
                                            artistTitleOffer.categoryIdType = ch.Attributes?.GetNamedItem("type")?.Value;
                                        }

                                        if (ch.Name == "picture") artistTitleOffer.picture = ch.InnerText;
                                        if (ch.Name == "delivery") artistTitleOffer.delivery = ch.InnerText;
                                        if (ch.Name == "artist") artistTitleOffer.artist = ch.InnerText;
                                        if (ch.Name == "title") artistTitleOffer.title = ch.InnerText;
                                        if (ch.Name == "year") artistTitleOffer.year = ch.InnerText;
                                        if (ch.Name == "media") artistTitleOffer.media = ch.InnerText;
                                        if (ch.Name == "starring") artistTitleOffer.starring = ch.InnerText;
                                        if (ch.Name == "director") artistTitleOffer.director = ch.InnerText;
                                        if (ch.Name == "originalName") artistTitleOffer.originalName = ch.InnerText;
                                        if (ch.Name == "country") artistTitleOffer.country = ch.InnerText;
                                        if (ch.Name == "description") artistTitleOffer.description = ch.InnerText;
                                    
                                    }
                                    listOfArtistTitleOffer.Add(artistTitleOffer);
                                }
                                if (attrType?.Value == "tour") {
                                    TourOffer tourOffer = new()
                                    {
                                        id = childOffer.Attributes?.GetNamedItem("id")?.Value,
                                        type = attrType?.Value,
                                        bid = childOffer.Attributes?.GetNamedItem("bid")?.Value,
                                        available = childOffer.Attributes?.GetNamedItem("available")?.Value
                                    };
                                    foreach (XmlNode ch in childOffer.ChildNodes)
                                    {
                                        if (ch.Name == "url") tourOffer.url = ch.InnerText;
                                        if (ch.Name == "price") tourOffer.price = ch.InnerText;
                                        if (ch.Name == "currencyId") tourOffer.currencyId = ch.InnerText;
                                        if (ch.Name == "categoryId")
                                        {
                                            tourOffer.categoryId = ch.InnerText;
                                            tourOffer.categoryIdType = ch.Attributes?.GetNamedItem("type")?.Value;
                                        }

                                        if (ch.Name == "picture") tourOffer.picture = ch.InnerText;
                                        if (ch.Name == "delivery") tourOffer.delivery = ch.InnerText;
                                        if (ch.Name == "local_delivery_cost") tourOffer.localDeliveryCost = ch.InnerText;
                                        if (ch.Name == "worldRegion") tourOffer.worldRegion = ch.InnerText;
                                        if (ch.Name == "country") tourOffer.country = ch.InnerText;
                                        if (ch.Name == "region") tourOffer.region = ch.InnerText;
                                        if (ch.Name == "days") tourOffer.days = ch.InnerText;
                                        if (ch.Name == "dataTour") tourOffer.dataTour = ch.InnerText;
                                        if (ch.Name == "name") tourOffer.name = ch.InnerText;
                                        if (ch.Name == "hotel_stars") tourOffer.hotelStars = ch.InnerText;
                                        if (ch.Name == "room") tourOffer.room = ch.InnerText;
                                        if (ch.Name == "meal") tourOffer.meal = ch.InnerText;
                                        if (ch.Name == "included") tourOffer.included = ch.InnerText;
                                        if (ch.Name == "transport") tourOffer.transport = ch.InnerText;
                                        if (ch.Name == "description") tourOffer.description = ch.InnerText;

                                    }
                                    listOfTourOffer.Add(tourOffer);
                                }
                                if (attrType?.Value == "event-ticket") {
                                    EventTicketOffer eventTicketOffer = new()
                                    {
                                        id = childOffer.Attributes?.GetNamedItem("id")?.Value,
                                        type = attrType?.Value,
                                        bid = childOffer.Attributes?.GetNamedItem("bid")?.Value,
                                        available = childOffer.Attributes?.GetNamedItem("available")?.Value
                                    };
                                    foreach (XmlNode ch in childOffer.ChildNodes)
                                    {
                                        if (ch.Name == "url") eventTicketOffer.url = ch.InnerText;
                                        if (ch.Name == "price") eventTicketOffer.price = ch.InnerText;
                                        if (ch.Name == "currencyId") eventTicketOffer.currencyId = ch.InnerText;
                                        if (ch.Name == "categoryId")
                                        {
                                            eventTicketOffer.categoryId = ch.InnerText;
                                            eventTicketOffer.categoryIdType = ch.Attributes?.GetNamedItem("type")?.Value;
                                        }

                                        if (ch.Name == "picture") eventTicketOffer.picture = ch.InnerText;
                                        if (ch.Name == "delivery") eventTicketOffer.delivery = ch.InnerText;
                                        if (ch.Name == "local_delivery_cost") eventTicketOffer.localDeliveryCost = ch.InnerText;
                                        if (ch.Name == "name") eventTicketOffer.name = ch.InnerText;
                                        if (ch.Name == "place") eventTicketOffer.place = ch.InnerText;
                                        if (ch.Name == "hall")
                                        {
                                            eventTicketOffer.hall = ch.InnerText;
                                            eventTicketOffer.hallPlan = ch.Attributes?.GetNamedItem("plan")?.Value;
                                        }
                                        if (ch.Name == "hall_part") eventTicketOffer.hallPart = ch.InnerText;
                                        if (ch.Name == "date") eventTicketOffer.date = ch.InnerText;
                                        if (ch.Name == "is_premiere") eventTicketOffer.isPremiere = ch.InnerText;
                                        if (ch.Name == "is_kids") eventTicketOffer.isKids = ch.InnerText;
                                        if (ch.Name == "description") eventTicketOffer.description = ch.InnerText;

                                    }
                                    listOfEventTicketOffers.Add(eventTicketOffer);
                                }

                            }
                        }
                    }
                    
                }
            }

                return View();
        }
        public IActionResult SearchOffer()
        {
            var vm = new SearchOfferViewModel();

            return View(vm);
        }

        [HttpPost]
        public IActionResult SearchOffer(SearchOfferViewModel vm)
        {

            var a = new XmlDocument();
            a.Load("http://partner.market.yandex.ru/pages/help/YML.xml");
            XmlElement? b = a.DocumentElement;
            
            XmlNode? offerNodes = b?.SelectSingleNode("//offer[@id='"+vm.id?.ToString()+"']");
            if (offerNodes != null)
            {
                var tmpOffer = offerNodes.Attributes?.GetNamedItem("type");
                if (tmpOffer?.Value == "vendor.model")
                {

                    VendorModelOffer vmo = new()
                    {
                        id = offerNodes.Attributes?.GetNamedItem("id")?.Value,
                        type = tmpOffer?.Value,
                        bid = offerNodes?.Attributes?.GetNamedItem("bid")?.Value,
                        cbid = offerNodes?.Attributes?.GetNamedItem("cbid")?.Value,
                        available = offerNodes?.Attributes?.GetNamedItem("available")?.Value
                    };
                    foreach (XmlNode ch in offerNodes.ChildNodes)
                    {
                        if (ch.Name == "url") vmo.url = ch.InnerText;
                        if (ch.Name == "price") vmo.price = ch.InnerText;
                        if (ch.Name == "currencyId") vmo.currencyId = ch.InnerText;
                        if (ch.Name == "categoryId")
                        {
                            vmo.categoryId = ch.InnerText;
                            vmo.categoryIdType = ch.Attributes?.GetNamedItem("type")?.Value;
                        }

                        if (ch.Name == "picture") vmo.picture = ch.InnerText;
                        if (ch.Name == "delivery") vmo.delivery = ch.InnerText;
                        if (ch.Name == "local_delivery_cost") vmo.localDeliveryCost = ch.InnerText;
                        if (ch.Name == "typePrefix") vmo.typePrefix = ch.InnerText;
                        if (ch.Name == "vendor") vmo.vendor = ch.InnerText;
                        if (ch.Name == "vendorCode") vmo.vendorCode = ch.InnerText;
                        if (ch.Name == "model") vmo.model = ch.InnerText;
                        if (ch.Name == "description") vmo.description = ch.InnerText;
                        if (ch.Name == "manufacturer_warranty") vmo.manufacturerWarranty = ch.InnerText;
                        if (ch.Name == "country_of_origin") vmo.countryOforigin = ch.InnerText;
                    }
                    return View("VendorModelOfferView", vmo);

                }
                if (tmpOffer?.Value == "book")
                {
                    BookOffer bo = new()
                    {
                        id = offerNodes.Attributes?.GetNamedItem("id")?.Value,
                        type = tmpOffer?.Value,
                        bid = offerNodes.Attributes?.GetNamedItem("bid")?.Value,
                        available = offerNodes.Attributes?.GetNamedItem("available")?.Value
                    };
                    foreach (XmlNode ch in offerNodes.ChildNodes)
                    {
                        if (ch.Name == "url") bo.url = ch.InnerText;
                        if (ch.Name == "price") bo.price = ch.InnerText;
                        if (ch.Name == "currencyId") bo.currencyId = ch.InnerText;
                        if (ch.Name == "categoryId")
                        {
                            bo.categoryId = ch.InnerText;
                            bo.categoryIdType = ch.Attributes?.GetNamedItem("type")?.Value;
                        }

                        if (ch.Name == "picture") bo.picture = ch.InnerText;
                        if (ch.Name == "delivery") bo.delivery = ch.InnerText;
                        if (ch.Name == "local_delivery_cost") bo.localDeliveryCost = ch.InnerText;
                        if (ch.Name == "author") bo.author = ch.InnerText;
                        if (ch.Name == "name") bo.name = ch.InnerText;
                        if (ch.Name == "publisher") bo.publisher = ch.InnerText;
                        if (ch.Name == "series") bo.series = ch.InnerText;
                        if (ch.Name == "year") bo.year = ch.InnerText;
                        if (ch.Name == "ISBN") bo.ISBN = ch.InnerText;
                        if (ch.Name == "volume") bo.volume = ch.InnerText;
                        if (ch.Name == "part") bo.part = ch.InnerText;
                        if (ch.Name == "language") bo.language = ch.InnerText;
                        if (ch.Name == "binding") bo.binding = ch.InnerText;
                        if (ch.Name == "page_extent") bo.pageExtent = ch.InnerText;
                        if (ch.Name == "description") bo.description = ch.InnerText;
                        if (ch.Name == "downloadable") bo.downloadable = ch.InnerText;
                    }
                    return View("BookOfferView", bo);
                }


                if (tmpOffer?.Value == "audiobook")
                {
                    AudiobookOffer ao = new()
                    {
                        id = offerNodes.Attributes?.GetNamedItem("id")?.Value,
                        type = tmpOffer?.Value,
                        bid = offerNodes.Attributes?.GetNamedItem("bid")?.Value,
                        available = offerNodes.Attributes?.GetNamedItem("available")?.Value
                    };
                    foreach (XmlNode ch in offerNodes.ChildNodes)
                    {
                        if (ch.Name == "url") ao.url = ch.InnerText;
                        if (ch.Name == "price") ao.price = ch.InnerText;
                        if (ch.Name == "currencyId") ao.currencyId = ch.InnerText;
                        if (ch.Name == "categoryId")
                        {
                            ao.categoryId = ch.InnerText;
                            ao.categoryIdType = ch.Attributes?.GetNamedItem("type")?.Value;
                        }

                        if (ch.Name == "picture") ao.picture = ch.InnerText;
                        if (ch.Name == "author") ao.author = ch.InnerText;
                        if (ch.Name == "name") ao.name = ch.InnerText;
                        if (ch.Name == "publisher") ao.publisher = ch.InnerText;
                        if (ch.Name == "year") ao.year = ch.InnerText;
                        if (ch.Name == "ISBN") ao.ISBN = ch.InnerText;
                        if (ch.Name == "language") ao.language = ch.InnerText;
                        if (ch.Name == "performed_by") ao.performedBy = ch.InnerText;
                        if (ch.Name == "performance_type") ao.performanceType = ch.InnerText;
                        if (ch.Name == "storage") ao.storage = ch.InnerText;
                        if (ch.Name == "format") ao.format = ch.InnerText;
                        if (ch.Name == "recording_length") ao.recordingLength = ch.InnerText;
                        if (ch.Name == "description") ao.description = ch.InnerText;
                        if (ch.Name == "downloadable") ao.downloadable = ch.InnerText;
                    }
                    return View("AudiobookOfferView", ao);

                }
                if (tmpOffer?.Value == "artist.title")
                {
                    ArtistTitleOffer ato = new()
                    {
                        id = offerNodes.Attributes?.GetNamedItem("id")?.Value,
                        type = tmpOffer?.Value,
                        bid = offerNodes.Attributes?.GetNamedItem("bid")?.Value,
                        available = offerNodes.Attributes?.GetNamedItem("available")?.Value
                    };
                    foreach (XmlNode ch in offerNodes.ChildNodes)
                    {
                        if (ch.Name == "url") ato.url = ch.InnerText;
                        if (ch.Name == "price") ato.price = ch.InnerText;
                        if (ch.Name == "currencyId") ato.currencyId = ch.InnerText;
                        if (ch.Name == "categoryId")
                        {
                            ato.categoryId = ch.InnerText;
                            ato.categoryIdType = ch.Attributes?.GetNamedItem("type")?.Value;
                        }

                        if (ch.Name == "picture") ato.picture = ch.InnerText;
                        if (ch.Name == "delivery") ato.delivery = ch.InnerText;
                        if (ch.Name == "artist") ato.artist = ch.InnerText;
                        if (ch.Name == "title") ato.title = ch.InnerText;
                        if (ch.Name == "year") ato.year = ch.InnerText;
                        if (ch.Name == "media") ato.media = ch.InnerText;
                        if (ch.Name == "starring") ato.starring = ch.InnerText;
                        if (ch.Name == "director") ato.director = ch.InnerText;
                        if (ch.Name == "originalName") ato.originalName = ch.InnerText;
                        if (ch.Name == "country") ato.country = ch.InnerText;
                        if (ch.Name == "description") ato.description = ch.InnerText;

                    }
                    return View("ArtistTitleOfferView", ato);
                }
                if (tmpOffer?.Value == "tour")
                {
                    TourOffer to = new()
                    {
                        id = offerNodes.Attributes?.GetNamedItem("id")?.Value,
                        type = offerNodes?.Value,
                        bid = offerNodes?.Attributes?.GetNamedItem("bid")?.Value,
                        available = offerNodes?.Attributes?.GetNamedItem("available")?.Value
                    };
                    foreach (XmlNode ch in offerNodes.ChildNodes)
                    {
                        if (ch.Name == "url") to.url = ch.InnerText;
                        if (ch.Name == "price") to.price = ch.InnerText;
                        if (ch.Name == "currencyId") to.currencyId = ch.InnerText;
                        if (ch.Name == "categoryId")
                        {
                            to.categoryId = ch.InnerText;
                            to.categoryIdType = ch.Attributes?.GetNamedItem("type")?.Value;
                        }

                        if (ch.Name == "picture") to.picture = ch.InnerText;
                        if (ch.Name == "delivery") to.delivery = ch.InnerText;
                        if (ch.Name == "local_delivery_cost") to.localDeliveryCost = ch.InnerText;
                        if (ch.Name == "worldRegion") to.worldRegion = ch.InnerText;
                        if (ch.Name == "country") to.country = ch.InnerText;
                        if (ch.Name == "region") to.region = ch.InnerText;
                        if (ch.Name == "days") to.days = ch.InnerText;
                        if (ch.Name == "dataTour") to.dataTour = ch.InnerText;
                        if (ch.Name == "name") to.name = ch.InnerText;
                        if (ch.Name == "hotel_stars") to.hotelStars = ch.InnerText;
                        if (ch.Name == "room") to.room = ch.InnerText;
                        if (ch.Name == "meal") to.meal = ch.InnerText;
                        if (ch.Name == "included") to.included = ch.InnerText;
                        if (ch.Name == "transport") to.transport = ch.InnerText;
                        if (ch.Name == "description") to.description = ch.InnerText;

                    }
                    return View("TourOfferView", to);
                }
                if (tmpOffer?.Value == "event-ticket")
                {
                    EventTicketOffer eto = new()
                    {
                        id = offerNodes.Attributes?.GetNamedItem("id")?.Value,
                        type = tmpOffer?.Value,
                        bid = offerNodes.Attributes?.GetNamedItem("bid")?.Value,
                        available = offerNodes.Attributes?.GetNamedItem("available")?.Value
                    };
                    foreach (XmlNode ch in offerNodes.ChildNodes)
                    {
                        if (ch.Name == "url") eto.url = ch.InnerText;
                        if (ch.Name == "price") eto.price = ch.InnerText;
                        if (ch.Name == "currencyId") eto.currencyId = ch.InnerText;
                        if (ch.Name == "categoryId")
                        {
                            eto.categoryId = ch.InnerText;
                            eto.categoryIdType = ch.Attributes?.GetNamedItem("type")?.Value;
                        }

                        if (ch.Name == "picture") eto.picture = ch.InnerText;
                        if (ch.Name == "delivery") eto.delivery = ch.InnerText;
                        if (ch.Name == "local_delivery_cost") eto.localDeliveryCost = ch.InnerText;
                        if (ch.Name == "name") eto.name = ch.InnerText;
                        if (ch.Name == "place") eto.place = ch.InnerText;
                        if (ch.Name == "hall")
                        {
                            eto.hall = ch.InnerText;
                            eto.hallPlan = ch.Attributes?.GetNamedItem("plan")?.Value;
                        }
                        if (ch.Name == "hall_part") eto.hallPart = ch.InnerText;
                        if (ch.Name == "date") eto.date = ch.InnerText;
                        if (ch.Name == "is_premiere") eto.isPremiere = ch.InnerText;
                        if (ch.Name == "is_kids") eto.isKids = ch.InnerText;
                        if (ch.Name == "description") eto.description = ch.InnerText;

                    }
                    return View("EventTicketOfferView", eto);

                }
                
            }
            return NotFound("Не найден");

        }
        [HttpPost]
        public IActionResult SaveOfferVendorModel(VendorModelOffer vendorModel)
        {
            VendorModelOffer offer = new()
            {
                id = vendorModel.id,
                type = vendorModel.type,
                bid = vendorModel.bid,
                cbid = vendorModel.cbid,
                available = vendorModel.available,
                url = vendorModel.url,
                price = vendorModel.price,
                currencyId = vendorModel.currencyId,
                categoryId = vendorModel.categoryId,
                categoryIdType = vendorModel.categoryIdType,
                picture = vendorModel.picture,
                delivery = vendorModel.delivery,
                localDeliveryCost = vendorModel.localDeliveryCost,
                typePrefix = vendorModel.typePrefix,
                vendor = vendorModel.vendor,
                vendorCode = vendorModel.vendorCode,
                model = vendorModel.model,
                description = vendorModel.description,
                manufacturerWarranty = vendorModel.manufacturerWarranty,
                countryOforigin = vendorModel.countryOforigin
            };
            var tmp=_context.VendorModelOffers.FirstOrDefault(i=>i.id == offer.id);

            if (tmp != null) {
               return View("ErrorDB");
            }
            else {
                _context.Add(offer);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SaveOfferTour(TourOffer tourOffer)
        {
            TourOffer offer = new()
            {
                id = tourOffer.id,
                type = tourOffer.type,
                bid = tourOffer.bid,
                available = tourOffer.available,
                url = tourOffer.url,
                price = tourOffer.price,
                currencyId = tourOffer.currencyId,
                categoryId = tourOffer.categoryId,
                categoryIdType = tourOffer.categoryIdType,
                picture = tourOffer.picture,
                delivery = tourOffer.delivery,
                localDeliveryCost = tourOffer.localDeliveryCost,
                worldRegion=tourOffer.worldRegion,
                country=tourOffer.country,
                region=tourOffer.region,
                days=tourOffer.days,
                dataTour=tourOffer.dataTour,
                name=tourOffer.name,
                hotelStars=tourOffer.hotelStars,
                room=tourOffer.room,
                meal=tourOffer.meal,
                included=tourOffer.included,
                transport=tourOffer.transport,
                description=tourOffer.description

        };
            var tmp = _context.TourOffers.FirstOrDefault(i => i.id == offer.id);

            if (tmp != null)
            {
                return View("ErrorDB");
            }
            else
            {
                _context.Add(offer);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SaveOfferEventTicket(EventTicketOffer eventTicketOffer)
        {
            EventTicketOffer offer = new()
            {
                id = eventTicketOffer.id,
                type = eventTicketOffer.type,
                bid = eventTicketOffer.bid,
                available = eventTicketOffer.available,
                url = eventTicketOffer.url,
                price = eventTicketOffer.price,
                currencyId = eventTicketOffer.currencyId,
                categoryId = eventTicketOffer.categoryId,
                categoryIdType = eventTicketOffer.categoryIdType,
                picture = eventTicketOffer.picture,
                delivery = eventTicketOffer.delivery,
                localDeliveryCost = eventTicketOffer.localDeliveryCost,
                name=eventTicketOffer.name,
                place=eventTicketOffer.place,
                hall=eventTicketOffer.hall,
                hallPlan=eventTicketOffer.hallPlan,
                hallPart=eventTicketOffer.hallPart,
                date=eventTicketOffer.date,
                isPremiere=eventTicketOffer.isPremiere,
                isKids=eventTicketOffer.isKids,
                description=eventTicketOffer.description


        };
            var tmp = _context.EventTicketOffers.FirstOrDefault(i => i.id == offer.id);

            if (tmp != null)
            {
                return View("ErrorDB");
            }
            else
            {
                _context.Add(offer);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SaveOfferBook(BookOffer bookOffer)
        {
            BookOffer offer = new()
            {
                id = bookOffer.id,
                type = bookOffer.type,
                bid = bookOffer.bid,
                available = bookOffer.available,
                url = bookOffer.url,
                price = bookOffer.price,
                currencyId = bookOffer.currencyId,
                categoryId = bookOffer.categoryId,
                categoryIdType = bookOffer.categoryIdType,
                picture = bookOffer.picture,
                delivery = bookOffer.delivery,
                localDeliveryCost = bookOffer.localDeliveryCost,
                author=bookOffer.author,
                name=bookOffer.name,
                publisher=bookOffer.publisher,
                series=bookOffer.series,
                year=bookOffer.year,
                ISBN=bookOffer.ISBN,
                volume=bookOffer.volume,
                part=bookOffer.part,
                language=bookOffer.language,
                binding=bookOffer.binding,
                pageExtent=bookOffer.pageExtent,
                description=bookOffer.description,
                downloadable= bookOffer.downloadable

            };
            var tmp = _context.BookOffers.FirstOrDefault(i => i.id == offer.id);

            if (tmp != null)
            {
                return View("ErrorDB");
            }
            else
            {
                _context.Add(offer);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult SaveOfferAudiobook(AudiobookOffer audiobookOffer)
        {
            AudiobookOffer offer = new()
            {
                id = audiobookOffer.id,
                type = audiobookOffer.type,
                bid = audiobookOffer.bid,
                available = audiobookOffer.available,
                url = audiobookOffer.url,
                price = audiobookOffer.price,
                currencyId = audiobookOffer.currencyId,
                categoryId = audiobookOffer.categoryId,
                categoryIdType = audiobookOffer.categoryIdType,
                picture = audiobookOffer.picture,
                author=audiobookOffer.author,
                name=audiobookOffer.name,
                publisher=audiobookOffer.publisher,
                year=audiobookOffer.year,
                ISBN=audiobookOffer.ISBN,
                language=audiobookOffer.language,
                performedBy=audiobookOffer.performedBy,
                performanceType=audiobookOffer.performanceType,
                storage=audiobookOffer.storage,
                format=audiobookOffer.format,
                recordingLength=audiobookOffer.recordingLength,
                description=audiobookOffer.description,
                downloadable= audiobookOffer.downloadable,

        };
            var tmp = _context.AudiobookOffers.FirstOrDefault(i => i.id == offer.id);

            if (tmp != null)
            {
                return View("ErrorDB");
            }
            else
            {
                _context.Add(offer);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult SaveOfferArtistTitle(ArtistTitleOffer artistTitleOffer)
        {
            ArtistTitleOffer offer = new()
            {
                id = artistTitleOffer.id,
                type = artistTitleOffer.type,
                bid = artistTitleOffer.bid,
                available = artistTitleOffer.available,
                url = artistTitleOffer.url,
                price = artistTitleOffer.price,
                currencyId = artistTitleOffer.currencyId,
                categoryId = artistTitleOffer.categoryId,
                categoryIdType = artistTitleOffer.categoryIdType,
                picture = artistTitleOffer.picture,
                delivery=artistTitleOffer.delivery,
                artist=artistTitleOffer.artist,
                title=artistTitleOffer.title,
                year=artistTitleOffer.year,
                media=artistTitleOffer.media,
                starring=artistTitleOffer.starring,
                director=artistTitleOffer.director,
                originalName=artistTitleOffer.originalName,
                country=artistTitleOffer.country,
                description=artistTitleOffer.description,


        };
            var tmp = _context.ArtistTitleOffers.FirstOrDefault(i => i.id == offer.id);

            if (tmp != null)
            {
                return View("ErrorDB");
            }
            else
            {
                _context.Add(offer);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}