using Pi5.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pi5.Cadastrar
{
    public partial class Default : System.Web.UI.Page
    {
        private UsuarioModel _usuario;

        public Default()
            : this(new UsuarioModel())
        {

        }

        public Default(UsuarioModel usuario)
        {
            _usuario = usuario;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpContext.Current.Session["usuario.alterar"] = false;
                CarregaProdutos();
            }
        }

        private void CarregaProdutos()
        {
            gvList.DataSource = _usuario.buscarTodosOsUsuario();
            gvList.DataBind();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            bool alterar = (bool)HttpContext.Current.Session["usuario.alterar.bool"];
            if (alterar)
            {
                usuario u = new usuario();
                u.nome = txtNome.Text;
                u.email = txtEmail.Text;
                u.senha = txtSenha.Text;
                u.telefone = txtTelefone.Text;
                u.endereco = txtEndereco.Text;

                _usuario.alterar(((int)HttpContext.Current.Session["usuario.alterar.id"]), u);

                lblValidaEmail.Text = "Usuario alterado com sucesso";
                lblValidaEmail.Visible = true;
            }
            else
            {
                usuario u = _usuario.Buscar(txtEmail.Text);

                if (u == null)
                {
                    u = new usuario();
                    u.nome = txtNome.Text;
                    u.email = txtEmail.Text;
                    u.senha = txtSenha.Text;
                    u.telefone = txtTelefone.Text;
                    u.endereco = txtEndereco.Text;

                    _usuario.inserir(u);
                    _usuario.SalvarAlteracoes();

                    lblValidaEmail.Text = "Usuario cadastrado com sucesso";
                    lblValidaEmail.Visible = true;
                }
                else
                {
                    lblValidaEmail.Visible = true;
                }
            }
        }

        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvList.PageIndex = e.NewPageIndex;
            CarregaProdutos();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["usuario.alterar.bool"] = false;

            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;

            txtNome.Visible = true;
            txtEmail.Visible = true;
            txtSenha.Visible = true;
            txtTelefone.Visible = true;
            txtEndereco.Visible = true;

            btnCadastrar.Visible = true;

            txtNome.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            txtTelefone.Text = "";
            txtEndereco.Text = "";
        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                HttpContext.Current.Session["usuario.alterar.id"] = Convert.ToInt32(e.CommandArgument);

                usuario alterado = _usuario.Buscar((int)HttpContext.Current.Session["usuario.alterar.id"]);

                txtNome.Text = alterado.nome;
                txtEmail.Text = alterado.email;
                txtSenha.Text = alterado.senha;
                txtTelefone.Text = alterado.telefone;
                txtEndereco.Text = alterado.endereco;

                HttpContext.Current.Session["usuario.alterar.bool"] = true;

                Label1.Visible = true;
                Label2.Visible = true;
                Label3.Visible = true;
                Label4.Visible = true;
                Label5.Visible = true;

                txtNome.Visible = true;
                txtEmail.Visible = true;
                txtSenha.Visible = true;
                txtTelefone.Visible = true;
                txtEndereco.Visible = true;

                btnCadastrar.Visible = true;
            }
        }
    }
}