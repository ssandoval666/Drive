using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.OneDrive.Sdk;
using Microsoft.OneDrive.Sdk.Helpers;

namespace OneDriveApi
{
    [Serializable()]
    public class Drive
    {
        public Drive(string sToken = null)
        {
            try
            {
                getUsersAsync().GetAwaiter().GetResult();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();

        }

        public async static Task getUsersAsync()
        {
            try
            {

                var msaAuthProvider = new myAuthProvider(
    myClientId,
    "https://login.live.com/oauth20_desktop.srf",
    { "onedrive.readonly", "wl.signin" });
                await msaAuthProvider.AuthenticateUserAsync();
                var oneDriveClient = new OneDriveClient("https://api.onedrive.com/v1.0", msaAuthProvider);

                /*

                var clientId = "5f5b8e0d-5a1b-4fcc-9b72-015284c042bf";
                var tenantId = "f8cdef31-a31e-4b4a-93e4-5f571e91255a";
                var clientSecret = "Ob_qdPJo1OP4KXA_ajhXR_FD5lM1I.43T6";




                IConfidentialClientApplication app;
                app = ConfidentialClientApplicationBuilder.Create(clientId)
                                                          .WithClientSecret(Authenticate.AppClientSecret)
                                                          .WithAuthority(new Uri(@"https://login.microsoftonline.com/common/oauth2/nativeclient"))
                                                          .Build();


                string scope = $"onedrive.readwrite offline_access";
                System.Collections.Generic.List<string> enumScopes = new System.Collections.Generic.List<string>();
                enumScopes.Add("api://<GUID>/.default");
                //enumScopes.Add(Authenticate.Scopes[1]);
                var result = Task.Run(async () => await app.AcquireTokenForClient(enumScopes).ExecuteAsync()).Result;




                // Configure app builder
                var authority = $"https://login.microsoftonline.com/{tenantId}";
                var app = ConfidentialClientApplicationBuilder
                    .Create(clientId)
                    .WithClientSecret(clientSecret)
                    .WithAuthority(new Uri(authority))
                    .Build();

                // Acquire tokens for Graph API
                string[] Scopes = new string[] { "https://graph.microsoft.com/.default" };

                var authenticationResult = await app.AcquireTokenForClient(Scopes).ExecuteAsync();

                // Create GraphClient and attach auth header to all request (acquired on previous step)
                var graphClient = new GraphServiceClient(
                    new DelegateAuthenticationProvider(requestMessage => {
                        requestMessage.Headers.Authorization =
                            new AuthenticationHeaderValue("bearer", authenticationResult.AccessToken);

                        return Task.FromResult(0);
                    }));

                // Call Graph API
                var user = await graphClient.Me.Request().GetAsync();
                */

            }
            catch (Exception ex)
            { }
        }
    }
}
