using Identificacoes.Bu;
using Identificacoes.Util;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Text;
using Windows.ApplicationModel.DataTransfer;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Identificacoes.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CPFPage : Page
    {
        public CPFPage()
        {
            this.InitializeComponent();
        }

        private void Gerar_CPF(object sender, RoutedEventArgs e)
        {
            var builder = new StringBuilder();
            int quantidade = (int)Quantidade.Value;
            
            for (int i = 0; i < quantidade; i++)
            {
                var identificacaoCPF = IdentificacaoFactory.GetInstance().GetIdentificacao(Constantes.CPF);
                if ((bool)Formatado.IsChecked)
                {
                    builder.Append(identificacaoCPF.ObterIdentificacaoFormatada() + "\n");
                }
                else
                {
                    builder.Append(identificacaoCPF.ObterIdentificacao() + "\n");
                }
            }
            
            Resultado.Text = builder.ToString();
            
            // Fornecer feedback para leitores de tela
            string mensagem = quantidade == 1 
                ? "1 CPF gerado com sucesso" 
                : $"{quantidade} CPFs gerados com sucesso";
            
            NotificacaoLiveRegion.Text = mensagem;
            NotificacaoBorder.Visibility = Visibility.Visible;
            
            // Esconder a notificação após alguns segundos
            DispatcherQueue.TryEnqueue(async () => {
                await Task.Delay(3000);
                NotificacaoBorder.Visibility = Visibility.Collapsed;
            });
        }

        private void Copiar_Resultado(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Resultado.Text))
            {
                DataPackage package = new DataPackage();
                package.SetText(Resultado.Text);
                Clipboard.SetContent(package);
                
                // Fornecer feedback para leitores de tela
                NotificacaoLiveRegion.Text = "CPFs copiados para a área de transferência";
                NotificacaoBorder.Visibility = Visibility.Visible;
                
                // Esconder a notificação após alguns segundos
                DispatcherQueue.TryEnqueue(async () => {
                    await Task.Delay(3000);
                    NotificacaoBorder.Visibility = Visibility.Collapsed;
                });
            }
        }
    }
}
