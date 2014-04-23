using Pi5.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pi5
{
    public class UsuarioModel : ModelBase
    {
        //busca um registro de estatistica com base em uma session
        public usuario Buscar(int id)
        {
            try
            {
                return _contexto.usuario.First(p => p.id == id);
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public usuario Buscar(string mail)
        {
            try
            {
                return _contexto.usuario.First(p => p.email == mail);
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}