using Identificacoes.Util;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Threading.Tasks;

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
            SystemBackdrop = new MicaBackdrop() { Kind = MicaKind.BaseAlt };
            SetTitleBar(AppTitleBar);
            
            // Seleciona a aba CPF por padrão e navega para essa página
            navView.SelectedItem = NavItem_CPF;
            contentFrame.Navigate(typeof(CPFPage));
            
            // Registrar para o evento Loaded para verificar se devemos mostrar o diálogo de avaliação
            navView.Loaded += NavView_Loaded;
        }

        private async void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            // Aguardar um pouco antes de verificar para não interferir na experiência inicial
            await Task.Delay(5000);
            
            // Verificar se deve mostrar o diálogo de avaliação
            await CheckRatingPromptAsync();
        }
        
        /// <summary>
        /// Verifica se deve mostrar o diálogo de avaliação
        /// </summary>
        private async Task CheckRatingPromptAsync()
        {
            // Usar o XamlRoot do contentFrame para garantir que o diálogo seja mostrado corretamente
            if (contentFrame.Content is FrameworkElement frameworkElement)
            {
                await RatingDialog.CheckAndShowRatingDialogAsync(frameworkElement.XamlRoot);
            }
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

        public string CPF {  get => Constantes.CPF;  }    
        public string CNPJ { get => Constantes.CNPJ; }
        public string IE { get => Constantes.IE; }
        
    }
}
