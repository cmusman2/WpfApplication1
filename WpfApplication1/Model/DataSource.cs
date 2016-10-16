using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApplication1.Model
{
    class DataSource
    {
        private static AppDB db;

        public static List<Hotel> Hotels { get { return GetHotels(); } }
        public static List<string> Cities { get { return GetCities(); } }
        

        public static List<string> GetSimilarCities(string similarName)
        {
            if (db == null) db = new AppDB();
            var cities = db.Cities(similarName);
            return cities;            
        }

        public static List<Hotel> GetHotel(string city)
        {
            if (db == null) db = new AppDB();
            List<Hotel> hotels =null;
            string s = "";
            

            if ((!String.IsNullOrWhiteSpace(city))&&(city.ToLower()!="all"))
              hotels = db.Hotels.Where(h => h.city == city).ToList();
            else
                  hotels = db.Hotels.Where(h => h.city !="").ToList();

            return hotels;
            
        }


        public static Hotel GetHotelById(string id)
        {
            if (db == null) db = new AppDB();

            // var hotels = db.Hotels.Where(h => h.id == id)

            var hotels = db.Hotels.Include("HotelRooms").Include("Images").Include("HotelSummary").
             Where(h => h.id == id).ToList();





            if ((hotels!=null) && (hotels.Count>0))
            {
                return hotels[0];
            }   

            
            return null;
        }

        public static List<Hotel> GetHotels()
        {
            if (db == null) db = new AppDB();

            var hotels = db.Hotels.Where(h => h.id != "").ToList();

            return hotels;
        }

        private static List<string> GetCities() 
        {
            if (db == null) db = new AppDB();
            return db.Cities();             
        }



        

    }
}
