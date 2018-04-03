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
                AssertionConcern.AssertLength(prato.Descricao,1,100,"A descrição deve conter até 100 caracteres."),
                AssertionConcern.AssertIsGreaterThan(prato.Preco,0, "O Preço deverá ser informado.")
                ,AssertionConcern.AssertIsTrue(prato.RestauranteId >0,"O restaurante deverá ser informado.","Preenchimento incorreto!")
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
                AssertionConcern.AssertLength(prato.Descricao, 1, 100, "A descrição deve conter até 100 caracteres"),
                AssertionConcern.AssertIsGreaterThan(prato.Preco, 0, "O Preço deverá ser informado.")
                ,AssertionConcern.AssertIsTrue(prato.RestauranteId > 0, "O restaurante deverá ser informado.", "Preenchimento incorreto!")          
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
