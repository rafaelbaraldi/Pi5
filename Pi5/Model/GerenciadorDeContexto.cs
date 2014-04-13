using Pi5.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pi5
{
    public class GerenciadorDeContexto
    {
        private const string nomeContexto = "EventosContext";

        private static Database1Entities _itemHttp
        {
            get
            {
                return HttpContext.Current.Items[nomeContexto] as Database1Entities;
            }
            set
            {
                HttpContext.Current.Items[nomeContexto] = value;
            }
        }

        public static Database1Entities ContextoCorrente
        {
            get
            {
                if (_itemHttp == null)
                {
                    _itemHttp = new Database1Entities();
                }

                return _itemHttp;
            }
        }
    }
}