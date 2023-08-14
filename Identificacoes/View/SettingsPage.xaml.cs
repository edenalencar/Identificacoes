using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Automation.Peers;
using Microsoft.UI.Xaml.Controls;
using System;
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
            if (App.Window?.Content is FrameworkElement frameworkElement)
            {
                if (Application.Current.RequestedTheme.Equals(ElementTheme.Light))
                {
                    Tema.SelectedIndex = 0;
                }
                else if (Application.Current.RequestedTheme.Equals(ElementTheme.Dark))
                {
                    Tema.SelectedIndex = 1;
                }
                else
                {
                    Tema.SelectedIndex = 2;
                }
            }

        }

        private void themeMode_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (App.Window?.Content is FrameworkElement frameworkElement)
            {
                switch (((Microsoft.UI.Xaml.Controls.ContentControl)Tema.SelectedValue).Content)
                {
                    case "Claro": frameworkElement.RequestedTheme = ElementTheme.Light; break;
                    case "Escuro": frameworkElement.RequestedTheme = ElementTheme.Dark; break;
                    default: frameworkElement.RequestedTheme = ElementTheme.Default; break;
                }
            }

            var peer = FrameworkElementAutomationPeer.FromElement(sender as UIElement);
            peer.RaiseNotificationEvent(AutomationNotificationKind.ActionCompleted,
                                        AutomationNotificationProcessing.ImportantMostRecent, $"Theme changed to {ElementTheme.Light}", "ThemeChangedNotificationActivityId");

        }
        private async void bugRequestCard_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://github.com/edenalencar/Identificacoes/issues"));

        }
    }
}
