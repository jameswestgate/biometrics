using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Xamarin.Forms;

namespace biometrics
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Lets first try do some fingerprint shit here yo
            Task.Run(async () => await StartAuthenticationProcess());
        }

        private async Task StartAuthenticationProcess()
        {
            //Lets first try do some fingerprint shit here yo

            // Code to run on the main thread
            try
            {
                Console.WriteLine("STARTING ALL THE AUTHENTICATION NOW.");

                var result = await AuthenticateWithBiometrics();

                Console.WriteLine("MAKING TASK GO.");

                //task.GetAwaiter().GetResult();

                if (result.Authenticated)
                {
                    Console.WriteLine("ALL THE COOKIES BELONG TO YOU.");
                }
                else
                {
                    Console.WriteLine("NOT ALLOWED THE SECRETS.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SAD PANDA ERROR. {ex}");
            }
        }

        private async Task<FingerprintAuthenticationResult> AuthenticateWithBiometrics()
        {
            var config = new AuthenticationRequestConfiguration("Need your body to unlock the secrets!");

            return await CrossFingerprint.Current.AuthenticateAsync(config);
        }
    }
}
