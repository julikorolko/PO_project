using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgency;
namespace UnitTestProject
{
	[TestClass]
	public class UnitTest1
	{
		Client c_test = new Client("Jan", "Kowalski", "ul. Wolska 34/6", "Warszawa 33-100",
				   "504120236", "jankowalski201@gmail.com");
		[TestMethod]
		public void TestPhoneNumber()
		{
			string phone_num_test = "504120236";
			Assert.AreEqual(c_test.Phone_num, phone_num_test);
		}
		[TestMethod]
		public void TestMail()
		{
			string email_test = "jankowalski201@gmail.com";
			Assert.AreEqual(c_test.Email, email_test);
		}
	}
}
