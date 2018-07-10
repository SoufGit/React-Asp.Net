using System.Web.Http;

namespace ServiceAws.Controllers
{
    /// <summary>
    /// Controlleur de gestion de la couche d'authentification
    /// </summary>
    public class AuthenticateController : ApiController
    {
        // GET: api/Authenticate
        [HttpGet]
        [Route("api/authenticate/{email}/{password}")]
        // GET: api/Authenticate/email/password
        [AuthorizeHeaderResponse] // filtre d'action qui ajoute Authorization dans le header de réponse
        public object Post(string email, string password)
        {
            //  from web.config
            string gemail = System.Configuration.ConfigurationManager.AppSettings["email"];
            string gpassword = System.Configuration.ConfigurationManager.AppSettings["password"];

            if (email == gemail && password == gpassword)
            {
                ActionContext.ActionArguments.Add("resultat", "success");
                return new { retour = true };
            }          
            else
            {
                ActionContext.ActionArguments.Add("resultat", "error");
                return new { retour = false };
            }
        }
    }    
}
