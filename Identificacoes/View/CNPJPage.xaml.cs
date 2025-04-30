using Identificacoes.Bu;
using Identificacoes.Util;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Identificacoes.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CNPJPage : Page
    {
        public CNPJPage()
        {
            this.InitializeComponent();
        }

        public void Gerar_CNPJ(object sender, RoutedEventArgs e)
        {
            var builder = new StringBuilder();
            var identificacaoCNPJ = new List<Identificacao>();
            int quantidade = (int)Quantidade.Value;

            if ((bool)Filiais.IsChecked)
            {
                var matriz = IdentificacaoFactory.GetInstance().GetIdentificacao(Constantes.CNPJ);
                identificacaoCNPJ.Add(matriz);

                for (int i = 1; i < quantidade; i++)
                {
                    var filial = new IdentificacaoCNPJ(matriz.identificacaoModel.Nucleo, i.ToString());
                    identificacaoCNPJ.Add(filial);
                }
                foreach (var identificacao in identificacaoCNPJ)
                {
                    if ((bool)Formatado.IsChecked)
                    {
                        builder.Append(identificacao.ObterIdentificacaoFormatada() + "\n");
                    }
                    else
                    {
                        builder.Append(identificacao.ObterIdentificacao() + "\n");
                    }
                }
            }
            else
            {
                for (int i = 0; i < quantidade; i++)
                {
                    var identificacao = new IdentificacaoCNPJ();
                    if ((bool)Formatado.IsChecked)
                    {
                        builder.Append(identificacao.ObterIdentificacaoFormatada() + "\n");
                    }
                    else
                    {
                        builder.Append(identificacao.ObterIdentificacao() + "\n");
                    }
                }
            }
            Resultado.Text = builder.ToString();
            
            // Fornecer feedback para leitores de tela
            string tipoGeracao = (bool)Filiais.IsChecked ? "filiais" : "";
            string mensagem = quantidade == 1 
                ? "1 CNPJ gerado com sucesso" 
                : $"{quantidade} CNPJs {tipoGeracao} gerados com sucesso";
            
            NotificacaoLiveRegion.Text = mensagem;
            NotificacaoBorder.Visibility = Visibility.Visible;
            
            // Esconder a notificação após alguns segundos
            DispatcherQueue.TryEnqueue(async () => {
                await Task.Delay(3000);
                NotificacaoBorder.Visibility = Visibility.Collapsed;
            });
        }

        public void Copiar_Resultado(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Resultado.Text))
            {
                DataPackage package = new DataPackage();
                package.SetText(Resultado.Text);
                Clipboard.SetContent(package);
                
                // Fornecer feedback para leitores de tela
                NotificacaoLiveRegion.Text = "CNPJs copiados para a área de transferência";
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
