# Instruções para o Copilot

Este documento contém instruções para o Copilot de IA utilizado no desenvolvimento com Windows App SDK, WinUI 3 e .NET 8.

## Contexto do Projeto

Este projeto é um aplicativo Windows moderno construído com:
- Windows App SDK 1.5
- WinUI 3
- .NET 8
- C# como linguagem de programação principal
- XAML para definição da interface do usuário
- MSIX para empacotamento e distribuição

## Capacidades Esperadas

O Copilot deve ser capaz de:

1. **Auxiliar na escrita de código C# e XAML**
2. **Fornecer exemplos e padrões específicos para Windows App SDK e WinUI 3**
3. **Sugerir melhorias de código e seguir as melhores práticas**
4. **Explicar conceitos e APIs relativos à plataforma**
5. **Auxiliar com problemas de CI/CD usando GitHub Actions**

## Orientações para Sugestões de Código

### XAML (WinUI 3)

Ao sugerir código XAML, o Copilot deve:

- Utilizar os controles nativos do WinUI 3 em vez de controles UWP legados
- Implementar os padrões de design Fluent
- Preferir recursos de estilo do sistema (ThemeDictionaries, estilos implícitos) quando apropriado
- Incluir comentários sobre considerações de acessibilidade
- Demonstrar o uso adequado do sistema de layout (Grid, StackPanel, etc.)
- Implementar corretamente binding de dados e comandos
- Respeitar o ciclo de vida da aplicação Windows App SDK

Exemplo de um bom padrão XAML:

```xml
<Page
    x:Class="MyApp.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:MyApp"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">

    <Grid Padding="{StaticResource ContentDialogPadding}">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
            
        <TextBlock 
            Text="Título da Página" 
            Style="{StaticResource TitleTextBlockStyle}"
            Margin="0,0,0,12" />
            
        <ListView 
            Grid.Row="1"
            ItemsSource="{x:Bind ViewModel.Items, Mode=OneWay}"
            SelectedItem="{x:Bind ViewModel.SelectedItem, Mode=TwoWay}"
            AutomationProperties.Name="Lista de itens">
            <!-- ListView content -->
        </ListView>
    </Grid>
</Page>
```

### C# (.NET 8)

Ao sugerir código C#, o Copilot deve:

- Utilizar as convenções de código modernas do C# e .NET 8
- Implementar padrões assíncronos adequados usando Task e async/await
- Favorecer tipos de valor nulos (nullable reference types)
- Utilizar as APIs específicas do Windows App SDK quando disponíveis
- Implementar corretamente o padrão MVVM ou outros padrões de arquitetura
- Utilizar interfaces fortemente tipadas
- Implementar manipulação de erros apropriada
- Considerar preocupações de desempenho e eficiência de memória

Exemplo de um bom padrão C#:

```csharp
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MyApp
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; }

        public MainPage()
        {
            this.InitializeComponent();
            ViewModel = new MainViewModel();
            Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await ViewModel.LoadDataAsync();
            }
            catch (Exception ex)
            {
                await ShowErrorDialogAsync(ex.Message);
            }
        }

        private async Task ShowErrorDialogAsync(string message)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Erro",
                Content = message,
                CloseButtonText = "OK",
                XamlRoot = this.XamlRoot
            };

            await dialog.ShowAsync();
        }
    }

    public class MainViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<ItemModel>? _items;
        private ItemModel? _selectedItem;

        public ObservableCollection<ItemModel>? Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public ItemModel? SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public async Task LoadDataAsync()
        {
            // Implementação de carregamento de dados
            Items = new ObservableCollection<ItemModel>();
            // Adicionar itens...
        }
    }
}
```

## Biblioteca de APIs e Namespaces

O Copilot deve estar familiarizado com os seguintes namespaces e APIs:

### Windows App SDK 1.5 / WinUI 3
- `Microsoft.UI.Xaml`
- `Microsoft.UI.Xaml.Controls`
- `Microsoft.UI.Xaml.Media`
- `Microsoft.UI.Xaml.Navigation`
- `Microsoft.Windows.ApplicationModel`
- `Microsoft.Windows.AppLifecycle`
- `Microsoft.Windows.PushNotifications`

### .NET 8
- `System.Text` (para manipulação eficiente de strings)
- `System.Random` (para geração de números aleatórios)
- `System.Collections.Generic`
- `System.Linq`
- `System.Threading.Tasks`
- `System.IO`
- `System.Net.Http`

## Problemas Comuns e Soluções

O Copilot deve estar preparado para auxiliar com os seguintes problemas comuns:

1. **Acesso ao XamlRoot**
   ```csharp
   // Solução correta para exibir ContentDialog em WinUI 3
   ContentDialog dialog = new ContentDialog()
   {
       XamlRoot = this.Content.XamlRoot,
       // Outras propriedades...
   };
   ```

2. **Ativação correta de aplicativo**
   ```csharp
   // Gerenciamento de instância única usando AppLifecycle
   public static async Task<bool> HandleActivationAsync()
   {
       var currentInstance = AppInstance.GetCurrent();
       var activatedEventArgs = AppInstance.GetCurrent().GetActivatedEventArgs();
       
       // Verificar se já existe uma instância ativa para esta ativação
       var instances = AppInstance.GetInstances();
       if (instances.Count > 1)
       {
           // Redirecionamento para a primeira instância...
           return false;
       }
       
       return true;
   }
   ```

3. **Acesso a APIs Win32**
   ```csharp
   // Usando PInvoke para acessar APIs Win32
   using System.Runtime.InteropServices;
   
   public static class NativeMethods
   {
       [DllImport("user32.dll")]
       public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
   }
   ```

## Práticas para CI/CD no GitHub Actions

O Copilot deve orientar sobre a configuração do CI/CD com GitHub Actions para:

1. **Compilação e testes automatizados**
   ```yaml
   name: Build and Test
   
   on:
     push:
       branches: [ main ]
     pull_request:
       branches: [ main ]
   
   jobs:
     build:
       runs-on: windows-latest
       
       steps:
       - uses: actions/checkout@v3
       
       - name: Setup .NET
         uses: actions/setup-dotnet@v3
         with:
           dotnet-version: 8.0.x
           
       - name: Restore dependencies
         run: dotnet restore
         
       - name: Build
         run: dotnet build --no-restore
         
       - name: Test
         run: dotnet test --no-build --verbosity normal
   ```

2. **Empacotamento MSIX**
   ```yaml
   - name: Create MSIX Package
     run: |
       # Comandos para criar o pacote MSIX
       # ...
   ```

3. **Publicação na Microsoft Store**
   ```yaml
   - name: Publish to Microsoft Store
     if: github.ref == 'refs/heads/main'
     # Comandos para publicação
     # ...
   ```

## Melhores Práticas para Windows App SDK

O Copilot deve promover estas práticas:

1. **Gerenciamento adequado de recursos**
   - Implementar `IDisposable` quando apropriado
   - Gerenciar corretamente eventos para evitar vazamentos de memória

2. **Design responsivo**
   - Usar ViewBox, RelativePanel e outros layouts adaptáveis
   - Implementar estados visuais para diferentes tamanhos de tela

3. **Desempenho**
   - Virtualização para listas longas
   - Carregamento de dados em segundo plano
   - Cache de recursos quando apropriado

4. **Acessibilidade**
   - Garantir que todos os controles tenham nomes de automação apropriados
   - Suportar navegação por teclado
   - Implementar contraste adequado e tamanhos de fonte configuráveis

## Lembretes e Limitações

- O Windows App SDK 1.5 é diferente do UWP - certifique-se de usar as APIs corretas
- WinUI 3 tem algumas diferenças de API em relação ao WinUI 2.x
- Os aplicativos Windows App SDK podem não ter acesso a todas as APIs UWP
- Em alguns casos, pode ser necessário usar interoperabilidade com Win32
- Use `DispatcherQueue` em vez de `Dispatcher` para operações de UI thread

## Exemplos de Arquitetura Recomendada

### Estrutura de diretórios recomendada:

```
MyApp/
├── App.xaml
├── App.xaml.cs
├── MainWindow.xaml
├── MainWindow.xaml.cs
├── Assets/
│   └── (ícones, imagens, etc.)
├── Models/
│   └── (classes de modelo)
├── ViewModels/
│   └── (classes de viewmodel)
├── Views/
│   └── (páginas e controles personalizados)
├── Services/
│   └── (serviços da aplicação)
├── Helpers/
│   └── (classes auxiliares)
└── Package.appxmanifest
```

### Padrão de injeção de dependência:

```csharp
// Program.cs
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

public static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        WinRT.ComWrappersSupport.InitializeComWrappers();
        
        var builder = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) => 
            {
                // Registrar serviços
                services.AddSingleton<IDataService, DataService>();
                services.AddTransient<MainViewModel>();
                // ...
            });
        
        var host = builder.Build();
        
        // Armazene o provedor de serviços para uso na aplicação
        App.ServiceProvider = host.Services;
        
        Application.Start((p) => {
            var context = new ActivationRegistrationContext();
            var app = new App();
        });
    }
}

// App.xaml.cs
public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; set; } = null!;
    
    // Resto da implementação...
}
```

## Considerações de Segurança

O Copilot deve orientar para:

1. **Gerenciamento seguro de dados**
   - Uso de APIs de criptografia do Windows
   - Armazenamento seguro de credenciais
   - Proteção contra injeção de dados

2. **Permissões mínimas**
   - Solicitar apenas as capacidades necessárias no manifesto
   - Implementar verificação de capacidades em tempo de execução

3. **Validação de entrada**
   - Sanitizar todas as entradas do usuário
   - Implementar validação robusta de dados

## Boas Práticas para MSIX

O Copilot deve auxiliar com:

1. **Configuração do manifesto**
   - Definir corretamente as capacidades e extensões
   - Configurar protocolos apropriados

2. **Gerenciamento de versões**
   - Incrementar versões corretamente
   - Implementar atualizações

3. **Empacotamento para diferentes arquiteturas**
   - x86, x64, ARM64
   - Bundle de arquiteturas múltiplas

## Recursos Adicionais

O Copilot deve sugerir a consulta a estes recursos quando apropriado:

1. Documentação oficial do Windows App SDK
2. Repositório WinUI no GitHub
3. Exemplos de código do Windows App SDK
4. Diretrizes de design Fluent
5. Blog do Desenvolvedor Windows