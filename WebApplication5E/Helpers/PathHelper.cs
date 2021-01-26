using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WebApplication5E.Models.Entity;

namespace WebApplication5E.Helpers
{

    public static class PathHelper
    {
        private static string _uploadspath;
        private static string _imgprodottopath;

        public static string GetProdottoImagePath(Prodotto prodotto)
        {
            return $"{_uploadspath}{_imgprodottopath}/{prodotto.Id}/{prodotto.Immagine}";
        }

        public static void InitPaths()
        {
            _uploadspath = ConfigurationManager.AppSettings["uploadspath"];
            _imgprodottopath = ConfigurationManager.AppSettings["imgprodottopath"];
        }
    }
}