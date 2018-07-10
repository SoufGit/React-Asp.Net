using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.Filters;
using System.IO;

namespace ServiceAws
{
    public class AuthorizeHeaderResponse : ActionFilterAttribute
    {
        public string YourSecretAccessKeyID = "GQDstc21ewfffffffffffFiwDffVvVBrk";

        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            if (!(context.ActionContext.ActionArguments["resultat"].ToString()=="error"))
            {
                System.Security.Cryptography.HMACSHA1 encodeur = new System.Security.Cryptography.HMACSHA1();
                encodeur.Key = Encoding.UTF8.GetBytes(YourSecretAccessKeyID);

                string verb = "HTTP-GET";
                string content_MD5 = "";
                string content_type = "";
                string CanonicalizedAmzHeaders = "";
                string CanonicalizedResource = "/johnsmith";
                IEnumerable<string> values;
                bool retour = context.Request.Headers.TryGetValues("Content-MD5", out values);
                if (retour)
                {
                    content_MD5 = values.First();
                }

                retour = context.Request.Headers.TryGetValues("Content-Type", out values);
                if (retour)
                {
                    content_type = values.First();
                }

                retour = context.Request.Headers.TryGetValues("Content-Type", out values);
                if (retour)
                {
                    content_type = values.First();
                }

                byte[] infos = Encoding.UTF8.GetBytes("HTTP-GET" + System.Environment.NewLine
                                                      + content_MD5 + System.Environment.NewLine
                                                      + content_type + System.Environment.NewLine
                                                      + context.Request.Headers.Date.ToString() + System.Environment.NewLine
                                                      + CanonicalizedAmzHeaders + System.Environment.NewLine
                                                      + CanonicalizedResource + System.Environment.NewLine

                    );
                byte[] texte = encodeur.ComputeHash(infos);

                string signature = Convert.ToBase64String(texte, 0, texte.Length);
                string login = context.ActionContext.ActionArguments["email"].ToString();
                saveSignatureInDatabase(login, signature); // sauvegarder la signature en base

                context.Response.Headers.Add("Authorization", new string[] { "AWS AWSAccessKeyId:" + signature });
            }
            base.OnActionExecuted(context);
        }

        public void saveSignatureInDatabase(string login, string token)
        {
            SignatureStorage obj = new SignatureStorage() { login = login, token = token };
            Newtonsoft.Json.JsonSerializer sr = new Newtonsoft.Json.JsonSerializer();
            string FilePath = System.Configuration.ConfigurationManager.AppSettings["FilePath"];
            string FileName = System.Configuration.ConfigurationManager.AppSettings["FileName"]; 
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }

            using (StreamWriter s = File.CreateText(FilePath + "\\" + FileName))
            {
                sr.Serialize(s, obj);

            }
        }     
    }
}