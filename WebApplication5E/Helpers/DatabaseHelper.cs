using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WebApplication5E.Models.Entity;
using Dapper;

namespace WebApplication5E.Helpers
{
    public static class DatabaseHelper
    {
        private static string _connectionString;

        public static void InitConnectionString()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DbShop"].ConnectionString;
        }

        public static List<Prodotto> GetAllProdotti()
        {
            var prodotti = new List<Prodotto>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM prodotto";
                prodotti = connection.Query<Prodotto>(sql).ToList();
            }

            return prodotti;
        }

        public static Prodotto GetProdottoById(int id)
        {
            var prodotto = new Prodotto();
            using (var connection = new MySqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM prodotto WHERE id = @id";
                prodotto = connection.Query<Prodotto>(sql, new { id }).FirstOrDefault();
            }
            return prodotto;
        }
    }
}