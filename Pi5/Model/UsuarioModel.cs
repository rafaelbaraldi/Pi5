using Pi5.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pi5
{
    public class UsuarioModel : ModelBase
    {
        //busca um usuario pelo id
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

        //busca todos usuarios
        public List<usuario> buscarTodosOsUsuario()
        {
            return (from p in _contexto.usuario
                    select p).ToList();
        }

        //altera senha do cliente passando e-mail para localiza-lo e a senha nova
        public void alterarSenha(string email, string senha)
        {
            try
            {
                var user = _contexto.usuario.First(p => p.email == email);
                user.senha = senha;
                _contexto.SaveChanges();
            }
            catch (System.Exception)
            {

            }
        }

        //altera dados do cliente passando id
        public void alterar(int id, usuario _user)
        {
            try
            {
                var user = _contexto.usuario.First(p => p.id == id);
                user.nome = _user.nome;
                user.email = _user.email;
                user.senha = _user.senha;
                user.telefone = _user.telefone;
                user.endereco = _user.endereco;
                _contexto.SaveChanges();
            }
            catch (System.Exception)
            {

            }
        }

        //insere um novo cliente na tabela cliente
        public void inserir(usuario cliente)
        {
            _contexto.usuario.Add(cliente);
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