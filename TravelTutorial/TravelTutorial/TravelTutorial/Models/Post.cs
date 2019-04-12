using SQLite;
using System;
using System.Collections.Generic;
using System.Text;


namespace TravelTutorial.Models
{
    public class Post
    {
        //class to create table definitons for SQLlite

        //Primary key coloumn
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //Experience coloumn
        [MaxLength(250)]
        public string Experience { get; set; }

        public string VenueName { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Address { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Distance { get; set; }

    }
}
