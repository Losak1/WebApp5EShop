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
        #region prodotto
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
        #endregion

        #region utente
        public static bool ExistsUtenteByEmail(string email)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var sql = "SELECT id FROM utente WHERE email = @email";
                var id = connection.Query<int>(sql, new { email }).FirstOrDefault();
                return id > 0;
            }
        }

        public static int InsertUtente(Utente utente)
        {
            var id = 0;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var sql = "INSERT INTO utente (nome, email, password, isprivacy) VALUES (@nome,@email,@password,1); SELECT LAST_INSERT_ID()";
                    id = connection.Query<int>(sql, utente).First();
                }
            }
            catch(Exception ex)
            {
                //TODO qui bisognerebbe loggare l'errore ex.Message
            }
            return id;
        }
        #endregion


    }
}