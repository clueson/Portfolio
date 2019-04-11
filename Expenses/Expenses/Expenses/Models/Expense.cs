using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expenses.Models
{
    /// <summary>
    /// Data Model exposing the SQLite objects
    /// </summary>
    public class Expense
    {
        #region Fields
        #endregion

        #region Properties
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(25)]
        public string Name { get; set; }
        public float Amount { get; set; }
        [MaxLength(25)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Catagory { get; set; }
        #endregion

        #region Constructor
        #endregion

        #region Class Methods
        /// <summary>
        /// Inserts the expense data object into the database
        /// </summary>
        /// <param name="thexpenses"></param>
        /// <returns></returns>
        public static int InsertExpense(Expense thexpenses)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                //creates a table or skips if found
                conn.CreateTable<Expense>();
                //returns an int of rows affected
                return conn.Insert(thexpenses);
            }
        }

        /// <summary>
        /// Gets the data from the database and returns a list object
        /// </summary>
        /// <returns></returns>
        public static List<Expense> GetExpenses()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                //creates a table or skips if found
                conn.CreateTable<Expense>();
                //returns a list object
                return conn.Table<Expense>().ToList();
            }
        }

        /// <summary>
        /// Gets the filtered lists of catagories returns as a list
        /// </summary>
        /// <param name="thecatagory"></param>
        /// <returns></returns>
        public static List<Expense> GetExpenses(string thecatagory)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Expense>();
                return conn.Table<Expense>().Where(e => e.Catagory == thecatagory).ToList();
            }
        }

        /// <summary>
        /// Gets the filtered list of amounts in all the records
        /// </summary>
        /// <returns></returns>
        public static float TotalExpensesAmount()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Expense>();
                return conn.Table<Expense>().Sum(e => e.Amount);
            }
        }
        #endregion
    }
}
