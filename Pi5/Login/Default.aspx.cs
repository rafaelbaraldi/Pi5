using Pi5.App_Code;
using Pi5.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        protected void lbtnSenha_Click(object sender, EventArgs e)
        {
            lblMail.Visible = true;
            txtLostPass.Visible = true;
            btnRecuperar.Visible = true;
        }

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            //Verifica se e-mail digitado corresponde a algum usuario
            var user = _logar.Buscar(txtLostPass.Text);
            if (user == null)
            {
                //ShowMessageBox("Email não cadastrado");
                litMensagem.Text = "Email não cadastrado";
                litMensagem.Visible = true;

            }
            else
            {
                #region cria senha aleatoria
                Random rnd = new Random(DateTime.Now.Millisecond);
                int senha = rnd.Next(10000);
                _logar.alterarSenha(txtLostPass.Text, ("az" + senha + "s"));
                #endregion

                #region cria uma mensagem
                MailMessage mail = new MailMessage();

                //define os endereços
                mail.From = new MailAddress("rafael_baraldi_13@hotmail.com", "Eventos");
                mail.To.Add(txtLostPass.Text);

                //define o conteúdo
                mail.Subject = "Eventos - Nova Senha";
                mail.Body = "\n\nSuas nova senha é: az" + senha + "s\n\n";

                //envia a mensagem
                SmtpClient smtp = new SmtpClient("smtp.live.com");
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("rafael_baraldi_13@hotmail.com", "rafa9158175");
                #endregion

                try
                {
                    #region Envia mensagem
                    smtp.Send(mail);

                    //ShowMessageBox("Uma nova senha foi criada para você e enviada para seu email");
                    litMensagem.Text = "Uma nova senha foi criada para você e enviada para seu email";
                    litMensagem.Visible = true;
                    #endregion
                }

                catch (Exception ex)
                {
                    #region exibe erro ocorrido no momento do envio do email
                    litMensagem.Text = ex.Message;
                    litMensagem.Visible = true;
                    #endregion
                }
            }
        }
    }
}