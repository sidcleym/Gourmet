using Gourmet.Domain.Models;
using Gourmet.Shared.Notificacoes;

namespace Gourmet.ApplicationServices.EscopoValidacao
{
    public class RestauranteEscopo: EscopoBase
    {
        public static bool SalvarIsValid(Restaurante restaurante)
        {
           
            if (restaurante == null)
            {               
                CriaNotificacao("Nenhum dado postado", "Informe os dados");
                return false;
            }

           

            var retorno = AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotNull(restaurante, "Nenhum dado informado"),					
                AssertionConcern.AssertLength(restaurante.Descricao,3,100,"A descrição do Restaurante deve conter até 100 caracteres")             
            );

          

            _notificacoes = AssertionConcern.mensagemErro;
            return retorno;

        }

        public static bool AtualizarIsValid(Restaurante restaurante)
        {

            if (restaurante == null)
            {
                CriaNotificacao("Nenhum dado postado", "Informe os dados");
                return false;
            }


            var retorno = AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotNull(restaurante, "Nenhuma informação informada"),
                AssertionConcern.AssertLength(restaurante.Descricao, 3, 100, "A descrição do Restaurante deve conter até 100 caracteres")

            //AssertionConcern.AssertContains(Restaurante.desativado,"O campo desativado está incorreto","S","N"),
            //AssertionConcern.AssertContains(Restaurante.acessoPorHora, "O campo acesso hora está incorreto", "S", "N")
            );


            _notificacoes = AssertionConcern.mensagemErro;
            return retorno;
        }


        
    }
}
