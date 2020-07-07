using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherApp.Model;







namespace WeatherGetterTest
{
    ///<remarks> class used to convert view's visibility</remarks>
    [TestClass]
    public class WeatherGetterTest
    {
        /// <summary>
        /// Tests CreateHTTPRequestURL method by providing various days
        /// </summary>
        [TestMethod]
        public void CreateHTTPRequestURL_EmptyCityDays_ErrorTrue()
        {
            //arrange
            WeatherGetter getter = new WeatherGetter();
            getter.City = "Katowice";
            getter.Days = "5";

            WeatherGetter badDay = new WeatherGetter();
            badDay.City = "Katowice";
            badDay.Days = "-5";

            WeatherGetter badCity = new WeatherGetter();
            badDay.City = "MiastoPlacków";
            badDay.Days = "5";
            //act
            getter.CreateHTTPRequestURL();
            badDay.CreateHTTPRequestURL();
            badDay.CreateHTTPRequestURL();
            //assert
            Assert.IsFalse(getter.ErrorOccured);
            Assert.IsTrue(badDay.ErrorOccured);
            Assert.IsTrue(badCity.ErrorOccured);

        }


        /// <summary>
        /// Tests GetXMLData_TEST_EmptyURL_ErrorTrue method by providing various days
        /// </summary>
        [TestMethod]
        public void GetXMLData_TEST_EmptyURL_ErrorTrue()
        {
            //arrange
            WeatherGetter getter = new WeatherGetter();
            getter.City = "Katowice";
            getter.Days = "5";

            WeatherGetter badDay = new WeatherGetter();
            badDay.City = "Katowice";
            badDay.Days = "5sdas";

            WeatherGetter badCity = new WeatherGetter();
            badDay.City = "MiastoPlacków";
            badDay.Days = "5";

            //act

            getter.CreateHTTPRequestURL();
            badDay.CreateHTTPRequestURL();
            badCity.CreateHTTPRequestURL();

            getter.GetXMLData();
            badDay.GetXMLData();
            badCity.GetXMLData();
            //assert
            Assert.IsFalse(getter.ErrorOccured);
            Assert.IsTrue(badDay.ErrorOccured);
            Assert.IsTrue(badCity.ErrorOccured);


        }
    }
}
