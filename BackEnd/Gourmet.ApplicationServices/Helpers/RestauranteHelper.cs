using System;
using System.Collections.Generic;
using System.Linq;

namespace Gourmet.ApplicationServices.Helpers
{
    public class RestauranteHelper
    {

        public static string GeraDescricao()
        {
            IList<string> nomes = new List<string>(){
                "Boi Não lambe ",                   
                "Gato q mia",                
                "Panela de Barro",                  
                "Asturias",                
                "The Gallery",
                "Le pardon",
                "The Messiê",
                "La Rocha",
                "Ibiza Rest",
                "Petter Brason",
                "Pacco rabanne",
                "Colibri",
                "The Brain"
             };

            var ponteiro = Convert.ToInt16(Randomize(1, nomes.Count));
            return nomes.Skip(ponteiro).FirstOrDefault();
        }

        

        public static string Randomize(int ini, int final, Random pRnd = null)
        {
            Random rnd = (pRnd == null) ? new Random() : pRnd;
            return rnd.Next(ini, final).ToString();
        }

    }
}
