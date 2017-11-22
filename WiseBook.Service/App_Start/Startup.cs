using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;

[assembly: OwinStartup(typeof(WiseBook.Service.App_Start.Startup))]

namespace WiseBook.Service.App_Start
{
    
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfiguration = new HttpConfiguration();

            OAuthAuthorizationServerOptions oAuthAuthorizationServerOptions = new OAuthAuthorizationServerOptions()
            {
                //TokenEndpointPath ile geçerli token alacağımız adresi belirtiyoruz.
                TokenEndpointPath = new PathString("/token"),
                // AccessTokenExpireTimeSpan ise sağlanan token’ın geçerlilik süresini belirtir.
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                // AllowInsecureHttp ise token requestlerin HTTPS olmayan protokollere açılmasını sağlar.
                AllowInsecureHttp = true,
                Provider = new SimpleAuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(oAuthAuthorizationServerOptions);

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
       
    }


    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }


        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            if (DataService.Service
                    .UserService
                    .CheckCredentials(context.UserName, context.Password))
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim("sub",context.UserName));
                identity.AddClaim(new Claim("role","user"));


                context.Validated(identity);
            }

            else
            {
                context.SetError("invalid_grant","Email veya şifre yanlış");
            }
        }
    }
}
