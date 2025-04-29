using Identificacoes.Util;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Identificacoes.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();

            string temaSalvo = ApplicationData.Current.LocalSettings.Values[Constantes.TemaAppSelecionado]?.ToString();
            switch (temaSalvo)
            {
                case Constantes.Light:
                    LightTheme.IsChecked = true;
                    break;
                case Constantes.Dark:
                    DarkTheme.IsChecked = true;
                    break;
                default:
                    DefaultTheme.IsChecked = true;
                    break;
            }
        }

        private void ThemeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (App.Window?.Content is FrameworkElement frameworkElement)
            {
                RadioButton selectedTheme = sender as RadioButton;
                if (selectedTheme != null)
                {
                    string tag = selectedTheme.Tag.ToString();
                    switch (tag)
                    {
                        case Constantes.Light:
                            frameworkElement.RequestedTheme = ElementTheme.Light;
                            break;
                        case Constantes.Dark:
                            frameworkElement.RequestedTheme = ElementTheme.Dark;
                            break;
                        case "Default":
                            frameworkElement.RequestedTheme = ElementTheme.Default;
                            break;
                    }
                    ApplicationData.Current.LocalSettings.Values[Constantes.TemaAppSelecionado] = tag;
                }
            }
        }

        private async void requisitarNovoRecurso_click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://github.com/edenalencar/Identificacoes/issues"));
        }
        
        private async void AvaliarAplicativo_Click(object sender, RoutedEventArgs e)
        {
            // Marcar que o usuário escolheu avaliar para não mostrarmos o diálogo novamente
            AppUsageTracker.SetUserHasRated(true);
            
            // Abrir a página de avaliação na Microsoft Store
            await StoreService.OpenStoreReviewAsync();
        }

        public string DireitosTexto
        {
            get
            {
                return $"© {DateTime.Now.Year} Eden Alencar";
            }
        }

        public string Versao
        {
            get
            {
                // Obtém o objeto Package do aplicativo atual
                Package package = Package.Current;
                // Obtém a versão do pacote
                PackageVersion version = package.Id.Version;
                return $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
            }
        }
    }
}
