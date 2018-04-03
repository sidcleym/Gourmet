using System;
using System.Net;
using System.Web;

namespace Gourmet.UI.Helpers
{
    
    public static class TRespostaHttp
    {
        public static HttpStatusCode StatusCode { get; private set; }

        public static void setStatusCode(HttpStatusCode pStatusCode)
        {
            StatusCode = pStatusCode;
        }

    }
    
    public static class Resposta : Object
    {
   
        public static void VerificaRetorno(bool pSucesso, Object pDados)
        {


            if (pSucesso == true)
            {
                TRespostaHttp.setStatusCode(HttpStatusCode.OK);
                //setando o statuscode
                switch (HttpContext.Current.Request.HttpMethod)
                {
                    case "POST":
                        if (pDados != null)
                            TRespostaHttp.setStatusCode(HttpStatusCode.Created);
                        else
                            TRespostaHttp.setStatusCode(HttpStatusCode.BadRequest);
                        break;
                    case "GET":
                        if (pDados == null)
                            TRespostaHttp.setStatusCode(HttpStatusCode.NotFound);
                        break;
                    case "PUT":
                        if (pDados == null)
                            TRespostaHttp.setStatusCode(HttpStatusCode.BadRequest);
                        else
                            TRespostaHttp.setStatusCode(HttpStatusCode.OK);
                        break;

                    case "DELETE":
                        if (pDados == null)
                            TRespostaHttp.setStatusCode(HttpStatusCode.BadRequest);
                        else
                            TRespostaHttp.setStatusCode(HttpStatusCode.OK);
                        break;

                }



            }


        }

    }
}

