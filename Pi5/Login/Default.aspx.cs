using Pi5.App_Code;
using Pi5.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pi5.Login
{
    public partial class Default : System.Web.UI.Page
    {
        private UsuarioModel _logar = new UsuarioModel();
        private usuario _cliente;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                litMensagem.Visible = false;
                litMensagem.Text = string.Empty;
            }
        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            //busca cliente com base no e-mail digitado
            _cliente = _logar.Buscar(txtMail.Text.Trim());

            if (_cliente != null)
            {
                //verifica se a senha digitada esta correta
                if (_cliente.senha == txtSenha.Text.Trim())
                {
                    #region faz login do usuario
                    IdentityServices.SetLoggedCliente(_cliente);

                    FormsAuthentication.SetAuthCookie(_cliente.email.ToString(), false);
                    FormsAuthentication.RedirectFromLoginPage(_cliente.email.ToString(), false);
                    #endregion
                }
                else
                {
                    litMensagem.Text = "<div class=\"warning\">Senha incorreta. Por favor, verifique se seu usuário e senha foram informados corretamente e tente novamente.</div>";
                    litMensagem.Visible = true;
                }
            }
            else
            {
                litMensagem.Text = "<div class=\"warning\">E-mail não cadastrado. Por favor, verifique se seu usuário e senha foram informados corretamente e tente novamente.</div>";
                litMensagem.Visible = true;
            }
        }
    }
}