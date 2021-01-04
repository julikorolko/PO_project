using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TravelAgency
{
	class Program
	{
		static void Main()
		{
            Client c1 = new Client("Jan", "Kowalski", "ul. Wolska 34/6", "Warszawa 33-100",
                "504120203", "jan.kowalski34@gmail.com");
            Client c2 = new Client("Bartosz", "Kowalski", "ul. Wolska 34/6", "Warszawa 33-100",
                "504120203", "jan.kowalski34@gmail.com");

            Offer o1 = new Offer("France - Nice", "Kraków", "Le Lazueu", 7, 1500, "21-01-2021", "28-01-2021");

            Offer o2 = new Offer("Spain - Malaga", "Kraków", "Costa Docha", 5, 1300, "22-01-2021", "27-01-2021");

            Offer o3 = new Offer("USA - Honolulu", "Kraków", "Exopark", 10, 2500, "18-02-2021", "28-02-2021");

            Offer o4 = new Offer("Egypt - Dahab", "Kraków", "Happy Life Village", 10, 2100, "18-02-2021", "28-02-2021");

            Offer o5 = new Offer("Egypt - Hurghada", "Kraków", "Long Beach Resort", 7, 1500, "20-02-2021", "27-02-2021");

            Offer o6 = new Offer("Cyprus - Paphos", "Kraków", "Coral View", 7, 1000, "20-02-2021", "27-02-2021");

            Offer o7 = new Offer("Cyprus - Limassol", "Kraków", "Kapetanios", 6, 1400, "20-02-2021", "26-02-2021");

            Offer o8 = new Offer("Spain - Maspalomas", "Kraków", "Sandy Golf", 7, 1600, "03-03-2021", "10-03-2021");

            Offer o9 = new Offer("Spain - Costa Calma", "Kraków", "Royal Suite", 6, 1800, "14-03-2021", "20-03-2021");

            Offer o10 = new Offer("Greece - Platamonas", "Kraków", "Olympus Thea", 10, 2400, "14-03-2021", "24-03-2021");

            Offer o11 = new Offer("Turkey - Bitez", "Kraków", "Garden Life", 6, 1700, "24-03-2021", "30-03-2021");

            Offer o12 = new Offer("Italy - Rome", "Kraków", "Varase", 7, 2900, "09-04-2021", "16-04-2021");

            Offer o13 = new Offer("Italy - Milan", "Kraków", "Speronari Suites", 7, 3200, "09-04-2021", "16-04-2021");

            Offer o14 = new Offer("Greece - Hersonissos", "Kraków", "Golden Beach", 7, 1800, "10-04-2021", "17-04-2021");

            Offer o15 = new Offer("Greece - Hersonissos", "Kraków", "Palmera Beach", 7, 1700, "10-04-2021", "17-04-2021");

            Offer o16 = new Offer("Greece - Lixouri", "Kraków", "Palatino", 7, 1900, "13-04-2021", "20-04-2021");

            Offer o17 = new Offer("Turkey - Alanya", "Kraków", "Kleopatra Atlas", 6, 1850, "20-04-2021", "26-04-2021");

            Offer o18 = new Offer("Turkey - Alanya", "Kraków", "Tac Premier", 7, 2300, "20-04-2021", "27-04-2021");

            Offer o19 = new Offer("Egypt - Hurghada", "Kraków", "Roma", 4, 1300, "23-04-2021", "27-04-2021");

            Offer o20 = new Offer("Tanzania - Uroa", "Kraków", "Bay Beach Resort", 7, 5000, "07-05-2021", "14-05-2021");

            Booking b1 = new Booking(c1, o1, 2, Accomodation.Double,
                Flight_types.Economy, Board_types.Full, true);

            OffersList offers_list = new OffersList();

            offers_list.AddOffer(o2);
            offers_list.AddOffer(o1);
            offers_list.AddOffer(o3);
            offers_list.AddOffer(o4);
            offers_list.AddOffer(o5);
            offers_list.AddOffer(o6);
            offers_list.AddOffer(o7);
            offers_list.AddOffer(o8);
            offers_list.AddOffer(o9);
            offers_list.AddOffer(o10);
            offers_list.AddOffer(o11);
            offers_list.AddOffer(o12);
            offers_list.AddOffer(o13);
            offers_list.AddOffer(o14);
            offers_list.AddOffer(o15);
            offers_list.AddOffer(o16);
            offers_list.AddOffer(o17);
            offers_list.AddOffer(o18);
            offers_list.AddOffer(o19);
            offers_list.AddOffer(o20);
            //Console.WriteLine(offers_list.ToString());
            offers_list.SortAscendingByPrice();
            Console.WriteLine(offers_list.ToString());

            OffersList.SaveXML("offerslist.xml", offers_list);
            OffersList offers_list2 = OffersList.ReadXML("offerslist.xml");
            //Console.WriteLine(offers_list2);
            
        }
    }
}
