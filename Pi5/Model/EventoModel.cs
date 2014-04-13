using Pi5.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pi5.Model
{
    public class EventoModel : ModelBase
    {
        public List<evento> buscarTodosOsEventos()
        {
            return (from p in _contexto.evento
                    select p).ToList();
        }
    }
}