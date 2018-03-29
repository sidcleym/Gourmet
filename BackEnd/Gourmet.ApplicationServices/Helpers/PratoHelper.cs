using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoJogos.Domain.Helpers
{
    public class PratoHelper
    {

        public static string primeiroNome()
        {
            IList<string> nomes = new List<string>(){
                "Pato",     
                "Frango",   
                "Peixe",    
                "Lula",     
                "Roballo",  
                "Dourado",  
                "Ganso",    
                "Guaiamum",
                "Carangueijo",
                "Peru"
             };

            var ponteiro = Convert.ToInt16(Randomize(1, nomes.Count));
            return nomes.Skip(ponteiro).FirstOrDefault();
        }


        public static string sobreNome1()
        {
            IList<string> sobreNome = new List<string>(){
                 "Frito",   
                 "Cozido",     
                 "Marinado",    
                 "Grelhado",      
                 "Assado",    
                 "Temperado"                               
             };

            var ponteiro = Convert.ToInt16(Randomize(1, sobreNome.Count));
            return sobreNome.Skip(ponteiro).FirstOrDefault();
        }


       

        public static string Randomize(int ini, int final, Random pRnd = null)
        {
            Random rnd = (pRnd == null) ? new Random() : pRnd;
            return rnd.Next(ini, final).ToString();
        }

    }
}
