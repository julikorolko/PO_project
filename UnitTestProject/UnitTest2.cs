using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TravelAgency;
namespace UnitTestProject
{
	[TestClass]
	public class UnitTest2
	{
		Client c_test = new Client("Jan", "Kowalski", "ul. Wolska 34/6", "Warszawa 33-100",
				"504120203", "jan.kowalski34@gmail.com");
		Offer o_test = new Offer("France - Nice", "Kraków", "Le Lazueu", 7, 1500, "21-01-2021", "28-01-2021");

		[TestMethod]
		public void TestBooking()
		{
			Booking b_test = new Booking(c_test, o_test, 3, Accomodation.Extra,
				Flight_types.Standard, Board_types.Full, true);

			Assert.IsNotNull(b_test.Accomodation);
			Assert.IsNotNull(b_test.Flight);
			Assert.IsNotNull(b_test.Board);
		}

		[TestMethod]
		public void TestOfferDate()
		{
			DateTime arr = o_test.Date_arr;
			DateTime dep = o_test.Date_dep;
			int days = (arr - dep).Days;
			Assert.AreEqual(days, o_test.Days);
		}

	}
}
