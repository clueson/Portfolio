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
    }
}
