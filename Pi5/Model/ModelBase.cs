using Pi5.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pi5
{
    public class ModelBase
    {
        protected Database1Entities  _contexto;
         
        public ModelBase()
        {
            _contexto = GerenciadorDeContexto.ContextoCorrente;
        }

        public void SalvarAlteracoes()
        {
            _contexto.SaveChanges();

            #region tratamento de erro para o EF
            //try
            //{
            //    _contexto.SaveChanges();
            //}
            //catch (System.Data.Entity.Validation.DbEntityValidationException e)
            //{
            //    var outputLines = new List<string>();
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        outputLines.Add(string.Format(
            //            "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:",
            //            DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            outputLines.Add(string.Format(
            //                "- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage));
            //        }
            //    }
            //    System.IO.File.AppendAllLines(@"c:\temp\errors.txt", outputLines);
            //}
            #endregion
        }
    }
}