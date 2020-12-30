using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProjektPO
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c1 = new Client("Jan", "Kowalski", "ul. Wolska 34/6", "Warszawa 33-100", 
                "504120203", "jan.kowalski34@gmail.com");
            Client c2 = new Client("Bartosz", "Kowalski", "ul. Wolska 34/6", "Warszawa 33-100",
                "504120203", "jan.kowalski34@gmail.com");

            Offer o1 = new Offer("France - Nice", "Kraków", "Le Lazueu", 7,1500,"21-01-2021","28-01-2021");

            Offer o2 = new Offer("Spain - Malaga", "Kraków", "Costa Docha", 5,1300, "22-01-2021", "27-01-2021");

            Offer o3 = new Offer("USA - Honolulu", "Kraków", "Exopark", 10,2500, "20-02-2021", "30-02-2021");

            Booking b1 = new Booking(c1, o1, 2,  Accomodation.Double,
                Flight_types.Economy, Board_types.Full, true);

            OffersList offers_list = new OffersList();

            offers_list.AddOffer(o2);
            offers_list.AddOffer(o1);
            offers_list.AddOffer(o3);
            Console.WriteLine(offers_list.ToString());
            offers_list.SortAscendingByPrice();
            Console.WriteLine(offers_list.ToString());

 

            //Console.WriteLine(offers[1]);

            //Console.WriteLine(b1);

        }
    }
}
