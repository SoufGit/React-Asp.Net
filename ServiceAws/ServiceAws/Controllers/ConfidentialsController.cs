using System;
using System.IO;
using System.Web.Http;

namespace ServiceAws.Controllers
{
    /// <summary>
    /// Controlleur de gestion de la couche de confidentialité
    /// </summary>
    public class ConfidentialsController : ApiController
    {
        // GET: api/confidentials/login
        [HttpGet]
        [Route("api/confidentials/{email}/")]
        [AddAuthorization]
        public object Get(string email)
        {
            bool retour = false;
            SignatureStorage obj;
            string FilePath = System.Configuration.ConfigurationManager.AppSettings["FilePath"];
            string FileName = System.Configuration.ConfigurationManager.AppSettings["FileName"];
            //string txt = File.ReadAllText(FilePath + "\\" + FileName);
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            //serialisation
            using (StreamReader rd = new StreamReader(FilePath + "\\" + FileName))
            {
                Newtonsoft.Json.JsonTextReader tr = new Newtonsoft.Json.JsonTextReader(rd);
                obj = serializer.Deserialize<SignatureStorage>(tr);
            }

            if (email.ToLower() == obj.login)
            {
                try
                {
                    // controle sur le token
                    if (Request.Headers.Authorization.Parameter == "AWSAccessKeyId:" + obj.token)
                    {
                        retour = true;
                    }
                }
                catch
                {
                    throw new UnauthorizedAccessException("SOUFIANE ! IL N'Y A AUCUN JETON D'AUTHENTIFICATION");
                }
            }
            return new { retour };
        }
    }
}
