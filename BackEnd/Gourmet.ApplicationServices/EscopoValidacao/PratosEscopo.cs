using Gourmet.Domain.IEscopo;
using Gourmet.Domain.Models;
using Gourmet.Shared.Notificacoes;

namespace Gourmet.ApplicationServices.EscopoValidacao
{
    public class PratoEscopo: EscopoBase
    {
        public static  bool SalvarIsValid(Prato prato)
        {

            if (prato == null)
            {
                CriaNotificacao("Nenhum dado postado", "Informe os dados");
                return false;
            }



            var retorno = AssertionConcern.IsSatisfiedBy(			
                AssertionConcern.AssertLength(prato.Descricao,6,100,"O Email deve conter até 100 caracteres."),
                AssertionConcern.AssertIsGreaterThan(prato.Preco,0, "O Preço deverá ser informado.")
                                
            );

          

            _notificacoes = AssertionConcern.mensagemErro;
            return retorno;

        }

        public static bool AtualizarIsValid(Prato prato)
        {

            if (prato == null)
            {
                CriaNotificacao("Nenhum dado postado", "Informe os dados");
                return false;
            }

            var retorno = AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertLength(prato.Descricao, 6, 100, "O Email deve conter até 100 caracteres"),
                AssertionConcern.AssertIsGreaterThan(prato.Preco, 0, "O Preço deverá ser informado.")

            //AssertionConcern.AssertContains(Pratos.desativado,"O campo desativado está incorreto","S","N"),
            //AssertionConcern.AssertContains(Pratos.acessoPorHora, "O campo acesso hora está incorreto", "S", "N")
            );


            _notificacoes = AssertionConcern.mensagemErro;
            return retorno;
        }


        public static bool ExcluirIsValid(Prato prato)
        {
           // TUser.User.Identity.Name
            var retorno = AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(prato, "Pratos inexistente")
                //AssertionConcern.AssertTrue(TUser.isAdmin,"É necessário ser um administrador para excluir usuários! ")
            );
            

            _notificacoes = AssertionConcern.mensagemErro;
            return retorno;
        }
    }
}
