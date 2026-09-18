

using Microsoft.Identity.Client;
using System;

public class ExchangeManager


    {

    public static async System.Threading.Tasks.Task<string> GetToken()
    {

        // Configure the MSAL client to get tokens
        var pcaOptions = new PublicClientApplicationOptions
        {
            ClientId = "0193f183-1db1-4f39-8c7d-225e066d6280",
            TenantId = "5f62f7a2-c28f-421f-aeb7-fe49992f11b1"
        };

        var pca = PublicClientApplicationBuilder
            .CreateWithApplicationOptions(pcaOptions)
            .WithRedirectUri("https://login.microsoftonline.com/common/oauth2/nativeclient")
            .Build();

        var ewsScopes = new string[] { "https://outlook.office365.com/EWS/Exchange.asmx" };

        try
        {
            // Make the interactive token request
            var authResult = await pca.AcquireTokenInteractive(ewsScopes).ExecuteAsync();

            return authResult.AccessToken;

        }
        catch (MsalException ex)
        {
            Console.WriteLine($"Error acquiring access token: {ex}");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
            return null;
        }
    }



        public static async System.Threading.Tasks.Task<AuthenticationResult> Connect()
        {
   
            // Configure the MSAL client to get tokens
            var pcaOptions = new PublicClientApplicationOptions
            {
                ClientId = "0193f183-1db1-4f39-8c7d-225e066d6280",
                TenantId = "5f62f7a2-c28f-421f-aeb7-fe49992f11b1"
            };

            var pca = PublicClientApplicationBuilder
                .CreateWithApplicationOptions(pcaOptions)
                .WithRedirectUri("https://login.microsoftonline.com/common/oauth2/nativeclient")
                .Build();

            // The permission scope required for EWS access
           var ewsScopes = new string[] { "https://outlook.office365.com/EWS.AccessAsUser.All" };
        // var ewsScopes = new string[] { "https://outlook.office365.com/EWS/Exchange.asmx" };

        try
            {
                // Make the interactive token request
                var authResult = await pca.AcquireTokenInteractive(ewsScopes).ExecuteAsync();

            return authResult;

            }
            catch (MsalException ex )
            {
                 Console.WriteLine($"Error acquiring access token: {ex}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            return null;
        }


    }
    }
