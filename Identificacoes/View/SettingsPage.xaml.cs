using Identificacoes.Util;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.System;
using Windows.ApplicationModel.DataTransfer;
using System.ComponentModel;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Automation.Peers;
using Microsoft.UI.Dispatching;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Automation;
using Microsoft.UI.Composition;
using Microsoft.UI.Xaml.Hosting;
using Microsoft.UI.Xaml.Media; // Para VisualTreeHelper
using Microsoft.UI.Xaml.Media.Animation; // Para TransitionCollection
using System.Collections.Generic; // Para IEnumerable
using System.Linq; // Para FirstOrDefault e outros métodos LINQ

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Identificacoes.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page, INotifyPropertyChanged
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            
            // Carregar configurações salvas de acessibilidade
            var localSettings = ApplicationData.Current.LocalSettings;
            
            // Alto contraste
            bool altoContraste = localSettings.Values[Constantes.AltoContraste] is bool savedValue ? savedValue : false;
            AltoContrasteToggle.IsOn = altoContraste;
            
            // Tamanho da fonte
            double tamanhoFonte = localSettings.Values[Constantes.TamanhoFonte] is double savedSize ? savedSize : 100;
            TamanhoFonteSlider.Value = tamanhoFonte;
            
            // Desativar animações
            bool desativarAnimacoes = localSettings.Values[Constantes.DesativarAnimacoes] is bool savedAnim ? savedAnim : false;
            DesativarAnimacoesToggle.IsOn = desativarAnimacoes;
        }

        private void ThemeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                // Verificar se o remetente é realmente um RadioButton
                if (!(sender is RadioButton selectedTheme))
                {
                    System.Diagnostics.Debug.WriteLine("O remetente não é um RadioButton");
                    return;
                }

                // Verificar se a Tag não é nula
                if (selectedTheme.Tag == null)
                {
                    System.Diagnostics.Debug.WriteLine("Tag do RadioButton é nula");
                    return;
                }

                string tag = selectedTheme.Tag.ToString();

                // Primeiro, salvar a escolha do usuário mesmo se a aplicação não puder ser atualizada imediatamente
                ApplicationData.Current.LocalSettings.Values[Constantes.TemaAppSelecionado] = tag;
                
                // Tentar aplicar o tema ao elemento raiz da aplicação
                if (App.Window?.Content is FrameworkElement frameworkElement)
                {
                    ElementTheme novoTema = ElementTheme.Default;
                    
                    switch (tag)
                    {
                        case Constantes.Light:
                            novoTema = ElementTheme.Light;
                            break;
                        case Constantes.Dark:
                            novoTema = ElementTheme.Dark;
                            break;
                        case "Default":
                            novoTema = ElementTheme.Default;
                            break;
                    }
                    
                    // Aplicar o tema
                    frameworkElement.RequestedTheme = novoTema;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("App.Window?.Content não é um FrameworkElement ou é nulo");
                    // Tentar obter acesso à janela principal por outro meio
                    // Não é necessário falhar - já salvamos a escolha do usuário
                }
            }
            catch (Exception ex)
            {
                // Registrar o erro mas não deixar que a exceção seja lançada
                System.Diagnostics.Debug.WriteLine($"Erro ao alterar o tema: {ex.Message}");
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

        private void CopiarEmail_Click(object sender, RoutedEventArgs e)
        {
            // Criar um data package para a área de transferência
            var dataPackage = new Windows.ApplicationModel.DataTransfer.DataPackage();
            dataPackage.SetText("contato@identificacoes.com.br");
            Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(dataPackage);
            
            // Feedback visual para o usuário
            var flyout = new Flyout();
            var textBlock = new TextBlock { Text = "E-mail copiado para a área de transferência!" };
            flyout.Content = textBlock;
            flyout.ShowAt((FrameworkElement)sender);
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

        public string TamanhoFonteFormatado => $"{TamanhoFonteSlider?.Value ?? 100:0}%";

        private void AltoContraste_Toggled(object sender, RoutedEventArgs e)
        {
            bool isOn = AltoContrasteToggle.IsOn;
            ApplicationData.Current.LocalSettings.Values[Constantes.AltoContraste] = isOn;
            
            // Aplicar configuração de alto contraste
            var resourceDictionaries = Application.Current.Resources.MergedDictionaries;
            
            // Aplicar estilo de alto contraste se ativado
            if (isOn)
            {
                ApplyHighContrastStyling();
            }
            else
            {
                RestoreDefaultStyling();
            }
            
            // Notificar usuários de leitores de tela
            NotificarAlteracaoAcessibilidade(isOn ? "Alto contraste ativado" : "Alto contraste desativado");
        }

        private void TamanhoFonte_ValueChanged(object sender, Microsoft.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            double novoTamanho = e.NewValue;
            ApplicationData.Current.LocalSettings.Values[Constantes.TamanhoFonte] = novoTamanho;
            
            // Aplicar novo tamanho de fonte
            AplicarTamanhoFonte(novoTamanho);
            
            // Notificar mudança de propriedade para atualizar o texto formatado
            OnPropertyChanged(nameof(TamanhoFonteFormatado));
            
            // Notificar usuários de leitores de tela quando os valores mudarem significativamente
            if (Math.Abs(e.OldValue - e.NewValue) >= 10)
            {
                NotificarAlteracaoAcessibilidade($"Tamanho da fonte ajustado para {novoTamanho:0}%");
            }
        }

        private void DesativarAnimacoes_Toggled(object sender, RoutedEventArgs e)
        {
            bool isOn = DesativarAnimacoesToggle.IsOn;
            ApplicationData.Current.LocalSettings.Values[Constantes.DesativarAnimacoes] = isOn;
            
            // Aplicar configurações de animação usando Composition API
            AplicarConfiguracoesAnimacao(isOn);
            
            // Notificar usuários de leitores de tela
            NotificarAlteracaoAcessibilidade(isOn ? "Animações desativadas" : "Animações ativadas");
        }

        private void ApplyHighContrastStyling()
        {
            var resources = Application.Current.Resources;
            
            // Aplicar estilos de alto contraste para toda a aplicação
            if (App.Window?.Content is FrameworkElement rootElement)
            {
                // Adicionar uma classe CSS virtual para facilitar identificação visual no depurador
                rootElement.RequestedTheme = ElementTheme.Dark; // Base para alto contraste
            }
            
            // Aplicar estilos de alto contraste substituindo os estilos regulares
            if (resources.TryGetValue("HighContrastCardStyle", out object cardStyle))
            {
                resources["CardStyle"] = cardStyle;
            }
            
            if (resources.TryGetValue("HighContrastPrimaryButtonStyle", out object primaryBtnStyle))
            {
                resources["PrimaryButtonStyle"] = primaryBtnStyle;
            }
            
            if (resources.TryGetValue("HighContrastSecondaryButtonStyle", out object secondaryBtnStyle))
            {
                resources["SecondaryButtonStyle"] = secondaryBtnStyle;
            }
            
            if (resources.TryGetValue("HighContrastHeaderTextStyle", out object headerStyle))
            {
                resources["HeaderTextStyle"] = headerStyle;
            }
            
            if (resources.TryGetValue("HighContrastResultTextBoxStyle", out object resultStyle))
            {
                resources["ResultTextBoxStyle"] = resultStyle;
            }
            
            if (resources.TryGetValue("HighContrastSliderStyle", out object sliderStyle))
            {
                resources["ModernSliderStyle"] = sliderStyle;
            }
            
            if (resources.TryGetValue("HighContrastCheckBoxStyle", out object checkboxStyle))
            {
                resources["ModernCheckBoxStyle"] = checkboxStyle;
            }
            
            // Notificar a aplicação sobre a mudança
            // Isso pode ser implementado em uma classe de serviço de acessibilidade
            // para centralizar a lógica
        }

        private void RestoreDefaultStyling()
        {
            // Restaurar tema padrão
            if (App.Window?.Content is FrameworkElement rootElement)
            {
                // Restaurar o tema conforme a preferência do usuário
                string temaSalvo = ApplicationData.Current.LocalSettings.Values[Constantes.TemaAppSelecionado]?.ToString();
                switch (temaSalvo)
                {
                    case Constantes.Light:
                        rootElement.RequestedTheme = ElementTheme.Light;
                        break;
                    case Constantes.Dark:
                        rootElement.RequestedTheme = ElementTheme.Dark;
                        break;
                    default:
                        rootElement.RequestedTheme = ElementTheme.Default;
                        break;
                }
            }
            
            // Recarregar os estilos compartilhados originais
            // Uma abordagem melhor seria armazenar os estilos originais antes de substituí-los
            // Esta é uma implementação simplificada
            var originalStyles = new ResourceDictionary 
            { 
                Source = new Uri("ms-appx:///Styles/SharedStyles.xaml", UriKind.Absolute) 
            };
            
            foreach (var key in originalStyles.Keys)
            {
                if (Application.Current.Resources.ContainsKey(key))
                {
                    Application.Current.Resources[key] = originalStyles[key];
                }
            }
        }

        private void AplicarTamanhoFonte(double tamanhoPercentual)
        {
            // Fator de escala (100% = 1.0, 150% = 1.5, etc.)
            double fator = tamanhoPercentual / 100.0;
            
            if (App.Window?.Content is FrameworkElement rootElement)
            {
                // Criar dicionário de recursos temporário para armazenar estilos escalados
                var recursos = Application.Current.Resources;
                var estilosEscalados = new ResourceDictionary();
                
                // Processar e escalar estilos comuns de texto
                string[] estilosParaEscalar = { "BodyTextBlockStyle", "HeaderTextStyle", "SubheaderTextStyle" };
                
                foreach (var nomeEstilo in estilosParaEscalar)
                {
                    if (recursos.TryGetValue(nomeEstilo, out object estiloObj) && estiloObj is Style estiloOriginal)
                    {
                        // Criar cópia do estilo que pode ser modificada
                        var estiloEscalado = CriarEstiloEscalado(estiloOriginal, fator);
                        if (estiloEscalado != null)
                        {
                            // Armazenar o estilo escalado com um nome diferente
                            string nomeEstiloEscalado = $"{nomeEstilo}_Escalado";
                            recursos[nomeEstiloEscalado] = estiloEscalado;
                            
                            // Aplicar o estilo escalado a elementos existentes
                            AplicarEstiloEscaladoAosElementos(rootElement, nomeEstilo, nomeEstiloEscalado);
                        }
                    }
                }
                
                // Ajustar diretamente os TextBlocks que não usam estilos predefinidos
                foreach (var textBlock in FindDescendantsByType<TextBlock>(rootElement))
                {
                    // Pular TextBlocks que já possuem estilos aplicados (serão tratados pelo método acima)
                    if (textBlock.ReadLocalValue(FrameworkElement.StyleProperty) == DependencyProperty.UnsetValue)
                    {
                        // Preservar o tamanho original usando uma propriedade anexada ou tag
                        if (!(textBlock.Tag is double))
                        {
                            textBlock.Tag = textBlock.FontSize;
                        }
                        
                        // Ajustar baseado no tamanho original
                        double tamanhoOriginal = textBlock.Tag is double ? (double)textBlock.Tag : textBlock.FontSize;
                        textBlock.FontSize = tamanhoOriginal * fator;
                    }
                }
            }
        }

        private Style CriarEstiloEscalado(Style estiloOriginal, double fator)
        {
            try
            {
                // Criamos um novo estilo baseado no estilo original
                Style novoEstilo = new Style(estiloOriginal.TargetType);
                
                // Copiamos todos os setters, aplicando escala ao FontSize
                foreach (var setterOriginal in estiloOriginal.Setters)
                {
                    if (setterOriginal is Setter setter)
                    {
                        if (setter.Property == TextBlock.FontSizeProperty && setter.Value is double tamanhoOriginal)
                        {
                            // Criar um novo setter com o valor ajustado
                            var novoSetter = new Setter
                            {
                                Property = TextBlock.FontSizeProperty,
                                Value = tamanhoOriginal * fator
                            };
                            novoEstilo.Setters.Add(novoSetter);
                        }
                        else
                        {
                            // Adicionar os outros setters sem modificação
                            var novoSetter = new Setter
                            {
                                Property = setter.Property,
                                Value = setter.Value
                            };
                            novoEstilo.Setters.Add(novoSetter);
                        }
                    }
                }
                
                // Copiar o BasedOn se existir
                if (estiloOriginal.BasedOn != null)
                {
                    novoEstilo.BasedOn = CriarEstiloEscalado(estiloOriginal.BasedOn, fator);
                }
                
                return novoEstilo;
            }
            catch (Exception ex)
            {
                // Em caso de erro, registrar e retornar null
                System.Diagnostics.Debug.WriteLine($"Erro ao criar estilo escalado: {ex}");
                return null;
            }
        }

        private void AplicarEstiloEscaladoAosElementos(DependencyObject root, string estiloOriginal, string estiloEscalado)
        {
            try
            {
                // Obter o estilo escalado do dicionário de recursos
                if (Application.Current.Resources.TryGetValue(estiloEscalado, out object estiloObj) && 
                    estiloObj is Style estilo)
                {
                    // Encontrar todos os elementos que usam o estilo original e aplicar o escalado
                    foreach (var elemento in FindDescendantsByType<FrameworkElement>(root))
                    {
                        // Para WinUI 3, não podemos acessar diretamente a chave do estilo
                        // Em vez disso, tentamos verificar se o estilo é obtido do mesmo recurso
                        if (elemento.GetValue(FrameworkElement.StyleProperty) is Style estiloAtual)
                        {
                            // Verificamos se o estilo atual e o estilo original dos recursos são iguais
                            // ou têm a mesma origem verificando suas propriedades
                            if (Application.Current.Resources.TryGetValue(estiloOriginal, out object estiloOriginalObj) &&
                                estiloOriginalObj is Style estiloOriginalAtual &&
                                StylesAreEquivalent(estiloAtual, estiloOriginalAtual))
                            {
                                elemento.Style = estilo;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao aplicar estilo escalado: {ex}");
            }
        }

        // Método auxiliar para verificar se dois estilos são equivalentes
        private bool StylesAreEquivalent(Style style1, Style style2)
        {
            // Verificação simplificada, podemos aprimorar isso com comparações mais detalhadas se necessário
            if (style1 == style2)
                return true;
                
            // Verificar se têm o mesmo tipo alvo
            if (style1.TargetType != style2.TargetType)
                return false;
                
            // Verificar se têm o mesmo número de setters (verificação básica)
            if (style1.Setters.Count != style2.Setters.Count)
                return false;
                
            // Comparar alguns setters comuns para maior confiança
            // Caso específico para TextBlock e FontSize que é frequentemente usado
            var fontSizeSetter1 = style1.Setters.OfType<Setter>()
                .FirstOrDefault(s => s.Property == TextBlock.FontSizeProperty);
            var fontSizeSetter2 = style2.Setters.OfType<Setter>()
                .FirstOrDefault(s => s.Property == TextBlock.FontSizeProperty);
                
            if (fontSizeSetter1 != null && fontSizeSetter2 != null)
            {
                return fontSizeSetter1.Value.Equals(fontSizeSetter2.Value);
            }
            
            // Se não encontrou setters específicos para comparar, considera uma correspondência aproximada
            return true;
        }

        private void NotificarAlteracaoAcessibilidade(string mensagem)
        {
            // Criar um TextBlock LiveRegion para notificar leitores de tela
            TextBlock notificacao = new TextBlock();
            notificacao.Text = mensagem;
            AutomationProperties.SetLiveSetting(notificacao, AutomationLiveSetting.Assertive);
            notificacao.Visibility = Visibility.Collapsed;
            
            // Adicionar à árvore visual
            var grid = AltoContrasteToggle.Parent as Grid;
            if (grid != null)
            {
                grid.Children.Add(notificacao);
                
                // Tornar visível brevemente e depois remover
                notificacao.Visibility = Visibility.Visible;
                
                DispatcherQueue.TryEnqueue(async () => {
                    await Task.Delay(3000);
                    grid.Children.Remove(notificacao);
                });
            }
        }

        private void AplicarConfiguracoesAnimacao(bool desativar)
        {
            if (App.Window?.Content is FrameworkElement rootElement)
            {
                if (desativar)
                {
                    // Aplicar estilo global que desativa animações
                    if (Application.Current.Resources.TryGetValue("DisabledAnimationsStyle", out object style))
                    {
                        rootElement.Style = style as Style;
                    }
                    
                    // Aplicar estilos específicos para controles comuns
                    ApplyStyleToVisualTree<TextBlock>(rootElement, "NoAnimationTextBlockStyle");
                    ApplyStyleToVisualTree<Button>(rootElement, "NoAnimationButtonStyle", "NavigationViewMenuButton");
                    
                    // Desativar outras animações específicas que não são controladas pelo estilo
                    DesativarAnimacoesControles(rootElement);
                }
                else
                {
                    // Remover estilo global
                    rootElement.Style = null;
                    
                    // Remover estilos específicos de forma segura, preservando os botões de navegação
                    RemoveStyleFromVisualTree<TextBlock>(rootElement);
                    RemoveStyleFromVisualTreeExceptNavigation(rootElement);
                    
                    // Restaurar animações em controles
                    RestaurarAnimacoesControles(rootElement);
                    
                    // Garantir que os botões de navegação mantenham seu estilo apropriado
                    RestaurarEstilosNavegacao(rootElement);
                }
            }
        }

        // Método auxiliar para aplicar estilos a elementos de um tipo específico na árvore visual
        private void ApplyStyleToVisualTree<T>(DependencyObject root, string styleName) where T : FrameworkElement
        {
            if (Application.Current.Resources.TryGetValue(styleName, out object styleObj) && styleObj is Style style)
            {
                foreach (var element in FindDescendantsByType<T>(root))
                {
                    // Se for um botão, verificar se não é o botão de menu
                    if (element is Button btn)
                    {
                        // Pular o botão de menu da NavigationView e outros botões especiais do sistema
                        if (IsNavigationButton(btn))
                        {
                            continue;
                        }
                    }
                    
                    element.Style = style;
                }
            }
        }

        // Método auxiliar para verificar se um elemento é um botão de navegação ou botão especial do sistema
        private bool IsNavigationButton(Button btn)
        {
            // Verificar pelo nome - os botões de menu do NavigationView geralmente têm nomes específicos
            if (btn.Name == "NavigationViewBackButton" || 
                btn.Name == "TogglePaneButton" || 
                btn.Name.Contains("NavigationView") ||
                btn.Name.Contains("Menu"))
            {
                return true;
            }
            
            // Verificar se tem algum ancestral do tipo NavigationView
            DependencyObject parent = VisualTreeHelper.GetParent(btn);
            while (parent != null)
            {
                if (parent.GetType().Name.Contains("NavigationView"))
                {
                    // É um botão dentro de um NavigationView
                    return true;
                }
                parent = VisualTreeHelper.GetParent(parent);
            }
            
            // Não é um botão de navegação
            return false;
        }

        // Método sobrecarregado para aplicar estilos a elementos, exceto os especificados
        private void ApplyStyleToVisualTree<T>(DependencyObject root, string styleName, string excludeElementName) where T : FrameworkElement
        {
            if (Application.Current.Resources.TryGetValue(styleName, out object styleObj) && styleObj is Style style)
            {
                foreach (var element in FindDescendantsByType<T>(root))
                {
                    // Pular o elemento com o nome especificado
                    if (element.Name == excludeElementName || IsNavigationButton(element as Button))
                    {
                        continue;
                    }
                    
                    element.Style = style;
                }
            }
        }

        // Método auxiliar para remover estilos de elementos de um tipo específico na árvore visual
        private void RemoveStyleFromVisualTree<T>(DependencyObject root) where T : FrameworkElement
        {
            foreach (var element in FindDescendantsByType<T>(root))
            {
                // Restaurar para o estilo padrão ou nulo
                element.ClearValue(FrameworkElement.StyleProperty);
            }
        }

        // Método auxiliar para remover estilos de elementos, exceto botões de navegação
        private void RemoveStyleFromVisualTreeExceptNavigation(DependencyObject root)
        {
            foreach (var element in FindDescendantsByType<Button>(root))
            {
                if (!IsNavigationButton(element))
                {
                    element.ClearValue(FrameworkElement.StyleProperty);
                }
            }
        }

        // Método auxiliar para restaurar estilos apropriados para botões de navegação
        private void RestaurarEstilosNavegacao(DependencyObject root)
        {
            foreach (var element in FindDescendantsByType<Button>(root))
            {
                if (IsNavigationButton(element))
                {
                    if (Application.Current.Resources.TryGetValue("NavigationButtonStyle", out object styleObj) && styleObj is Style style)
                    {
                        element.Style = style;
                    }
                }
            }
        }

        // Método auxiliar para encontrar controles de um tipo específico na árvore visual
        private IEnumerable<T> FindDescendantsByType<T>(DependencyObject root) where T : DependencyObject
        {
            int count = VisualTreeHelper.GetChildrenCount(root);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);
                
                if (child is T match)
                {
                    yield return match;
                }
                
                foreach (var descendant in FindDescendantsByType<T>(child))
                {
                    yield return descendant;
                }
            }
        }

        private void DesativarAnimacoesControles(DependencyObject root)
        {
            // Percorrer a árvore visual e desativar animações em controles específicos
            int count = VisualTreeHelper.GetChildrenCount(root);
            for (int i = 0; i < count; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(root, i);
                
                // Desativar animações para cada tipo de controle
                if (child is ContentControl contentControl)
                {
                    // Desativar animações de conteúdo, se houver
                    contentControl.Tag = "DisableAnimations";
                }
                else if (child is ListViewBase listView)
                {
                    // Desativar animações de itens
                    listView.ItemContainerTransitions = null;
                }
                else if (child is Control control)
                {
                    // Desativar transições
                    control.Transitions = null;
                }
                
                // Continuar recursivamente
                DesativarAnimacoesControles(child);
            }
        }

        private void RestaurarAnimacoesControles(DependencyObject root)
        {
            // Implementação semelhante à DesativarAnimacoesControles, mas restaurando os valores padrão
            int count = VisualTreeHelper.GetChildrenCount(root);
            for (int i = 0; i < count; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(root, i);
                
                // Restaurar animações para cada tipo de controle
                if (child is ContentControl contentControl)
                {
                    contentControl.Tag = null;
                }
                else if (child is ListViewBase listView)
                {
                    // Restaurar animações de itens
                    listView.ItemContainerTransitions = new TransitionCollection();
                }
                else if (child is Control control)
                {
                    // Restaurar transições
                    control.Transitions = new TransitionCollection();
                }
                
                // Continuar recursivamente
                RestaurarAnimacoesControles(child);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
