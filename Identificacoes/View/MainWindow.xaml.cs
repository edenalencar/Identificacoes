using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Identificacoes.View
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void navView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            FrameNavigationOptions navOptions = new FrameNavigationOptions();
            navOptions.TransitionInfoOverride = args.RecommendedNavigationTransitionInfo;
            if (sender.PaneDisplayMode == NavigationViewPaneDisplayMode.Top)
            {
                navOptions.IsNavigationStackEnabled = false;
            }
            Type pageType = typeof(CPFPage); ;
            var selectedItem = (NavigationViewItem)args.SelectedItem;
            if (selectedItem.Name == NavItem_CPF.Name)
            {
                pageType = typeof(CPFPage);
            }
            else if (selectedItem.Name == NavItem_CNPJ.Name)
            {
                pageType = typeof(CNPJPage);
            }
            else if (selectedItem.Name == NavItem_IE.Name)
            {
                pageType = typeof(IEPage);
            }
            else
            {
                pageType = typeof(SettingsPage);
            }

            _ = contentFrame.Navigate(pageType);
        }
    }
}
