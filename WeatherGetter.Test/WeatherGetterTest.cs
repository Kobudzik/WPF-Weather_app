using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherApp.Model;


namespace WeatherGetterTest
{
    [TestClass]
    public class WeatherGetterTest
    {
        [TestMethod]
        public void CreateHTTPRequestURL_EmptyCityDays_ErrorTrue()
        {
            //arrange
            WeatherGetter getter = new WeatherGetter();

            //act
            getter.CreateHTTPRequestURL();
            //assert
            Assert.IsTrue(getter.ErrorOccured);
            
        }



        [TestMethod]
        public void GetXMLData_TEST_EmptyURL_ErrorTrue()
        {
            //arrange
            WeatherGetter getter = new WeatherGetter();


            //act
            getter.GetXMLData();
            //assert
            Assert.IsTrue(getter.ErrorOccured);


        }
    }
}
