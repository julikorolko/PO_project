using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProjektPO
{
    [Serializable]
    public class OffersList:IStore
    {
        List<Offer> offers = new List<Offer>();

        public List<Offer> Offers { get => offers; set => offers = value; }

		public OffersList()
		{

		}

		public void AddOffer(Offer offer)
        {
            Offers.Add(offer);
           
        }
        public void RemoveOffer(Offer offer)
        {
            Offers.Remove(offer);
        }
      
        public void ClearOffers()
        {
            Offers.Clear();
           
        }
        public List<Offer> FilterByDestination(string destination)
        {
            return offers.FindAll(c => c.Destination.ToLower() == destination.ToLower());
        }
        public List<Offer> FilterByDeparture(string departure)
        {
            return offers.FindAll(c => c.Departure.ToLower() == departure.ToLower());
        }
        public List<Offer> FilterByPrice1(double price)
        {
            return offers.FindAll(c => c.Price <= price);
        }
        public List<Offer> FilterByPrice2(double price)
        {
            return offers.FindAll(c => c.Price >= price);
        }

        public void SortAscendingByDestination()
        {
            offers.Sort();
        }
        public void SortDescendingByDestination()
        {
            offers.Sort(new DestinationComparator());
        }
        public void SortAscendingByPrice()
        {
            offers.Sort(new PriceComparator());
        }
        public void SortDescendingByPrice()
        {
            offers.Sort(new PriceComparator2());
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            foreach (Offer offer in offers)
            {
                stringBuilder.AppendLine(offer.ToString());
            }
            return stringBuilder.ToString();

        }
        public static void ZapiszXML(string nazwa, OffersList ol) 
        {
            using (StreamWriter writer = new StreamWriter(nazwa))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(OffersList));
                serializer.Serialize(writer, ol);
            }
        }

        public static OffersList OdczytajXML(string nazwa)
        {
            using (StreamReader reader = new StreamReader(nazwa))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(OffersList));
                return serializer.Deserialize(reader) as OffersList;
            }
        }
    }
}