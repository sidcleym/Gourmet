using Gourmet.Domain.IRepository;
using Gourmet.Domain.IServices;
using Gourmet.Domain.Models;
using Gourmet.Domain.Repository;
using Gourmet.Persistence.Infra;
using Gourmet.Shared.Utils;
using System;
using System.Linq;

namespace Gourmet.ApplicationServices.Services
{
    public class UsuarioService : ServiceBase, IUsuarioService
    {
        private readonly IRepositorioBase<Usuario> _repositorioUsuario;


        private DataContext _context;


        public UsuarioService(IUnitofWork unitOfWork,  DataContext context) : base(unitOfWork)
        {            
            this._repositorioUsuario = new RepositorioBase<Usuario>(context);
            this._context            = context;
        }

       
        public IQueryable Get()
        {
            return this._repositorioUsuario.Get() as IQueryable;
        }

    
        public Usuario Get(int id)
        {
            var usuario   = _repositorioUsuario.Get().Where(x => x.Id == id).First();
            usuario.SenhaCriptografada = null;

            if (usuario == null)
                throw new Exception("Usuário inexistente");

            return usuario;
        }

    
        
        public Usuario Get(string login)
        {
            var usuario = _repositorioUsuario.Get()

                .Where(x => x.Email == login).FirstOrDefault();

            if (usuario == null)
                throw new Exception("Usuário inexistente");

            return usuario;
        }

        
        public Usuario Salva(Usuario usuarioPostado)
        {
            usuarioPostado.DtInclusao      = DateTime.Now;
        
            usuarioPostado.SenhaCriptografada = (!String.IsNullOrWhiteSpace(usuarioPostado.Senha)) ? CriptografiaHelper.CriptografarSenha(usuarioPostado.Senha) : null;
            //UsuarioEscopo.SalvarIsValid(usuarioPostado);


            _repositorioUsuario.Save(usuarioPostado);

            if (Commit())
                return usuarioPostado;

            return null;
        }

        public Usuario Atualiza(int id, Usuario usuarioPostado )
        {

   //         Usuario usuario        = _repositorio.Get(id);
   //         if (usuario == null)
   //             throw new Exception("Usuário inexistente");

   //         usuario.senhaAnterior          = usuario.senha;
   //         usuario.senhaAnteriorInformada = usuarioPostado.senhaAnteriorInformada;

   //         //Se naum informar uma senha é pq vai continuar com a anterior
   //         if (String.IsNullOrWhiteSpace(usuarioPostado.senha)) { 
   //             usuarioPostado.senha            = usuario.senha;
   //             usuarioPostado.confirmacaoSenha = usuario.senha;
   //         }

   //         this.AnexarVirtuais(usuario);
   //         TPatch.Patch<Usuario, Usuario>(usuarioPostado, usuario, ViewsAttributeConstantes.viewUpdate);
            
   //         usuario.logAtualizacao  = DateTime.Now;
   //         usuario.logPctUsuarioId = TUser.idUsuario;

   //         //Se o usuário for administrador, não precisará de informar a senha anterior
   //         if (TUser.isAdmin) {
   //             usuario.senhaAnteriorInformada = usuario.senhaAnterior;
   //             if (usuario.senha == null) {
   //                 usuario.senha            = usuario.senhaAnterior;
   //                 usuario.confirmacaoSenha = usuario.senhaAnterior;      
   //             }
   //         }
                                   
   //         UsuarioEscopos.AtualizarIsValid(usuario);
			//this.AnexarVirtuais(usuario);
   //         usuario.intColaborador   = null;
   //         usuario.pctUsuarioPerfil = null;

   //         _repositorio.Atualiza(usuario);

   //         if (Commit())
   //             return usuario;

            return null;
        }

        //metodo usado para operações internas do sistema (login)
        public void Atualiza(Usuario usuario)
        {
            var ususarioAntigo = _repositorioUsuario.Get(usuario.Id);
           // _context.UsuarioPerfil.Attach(usuario.pctUsuarioPerfil);
            this._context.Entry(ususarioAntigo).CurrentValues.SetValues(usuario);
           // _repositorio.Atualiza(usuario);
            
            this._context.SaveChanges();
        }

        public Usuario Delete(int id)
        {
            var usuario = this._repositorioUsuario.Get(id);

            if (usuario == null)
                throw new Exception("Usuário inexistente");
           
			//if(!UsuarioEscopo.ExcluirIsValid(usuario))
				//return null;

            this._repositorioUsuario.Delete(usuario);
            
            if (Commit())
                return usuario;

            return null;

        }

        public bool isLoginValid(string login, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
