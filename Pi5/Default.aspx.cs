using Pi5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pi5
{
    public partial class _Default : Page
    {
        private EventoModel _evento;

        public _Default()
            : this(new EventoModel())
        {

        }

        public _Default(EventoModel evento)
        {
            _evento = evento;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { CarregaProdutos(); }
        }

        private void CarregaProdutos()
        {
            gvList.DataSource = _evento.buscarTodosOsEventos();
            gvList.DataBind();
        }

        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvList.PageIndex = e.NewPageIndex;
            CarregaProdutos();
        }
    }
}