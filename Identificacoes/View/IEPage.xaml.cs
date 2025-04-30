using Identificacoes.Controller;
using Identificacoes.Model;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
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
    public sealed partial class IEPage : Page
    {
        private List<UF> listaUFs;

        public IEPage()
        {
            this.InitializeComponent();
            
            // Inicializar a lista de UFs
            listaUFs = UF.ListarTodas();
            
            // Selecionar o primeiro item por padrão
            if (Estados.Items.Count > 0)
            {
                Estados.SelectedIndex = 0;
            }
        }

        private void Gerar_IE(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            ComboBoxItem selectedItem = Estados.SelectedItem as ComboBoxItem;
            
            if (selectedItem != null)
            {
                string tag = selectedItem.Tag.ToString();
                string estado = tag.Replace("IE-", "");
                string nomeEstado = selectedItem.Content.ToString();
                
                // Obter a quantidade selecionada
                int quantidade = (int)Quantidade.Value;
                bool formatado = Formatado.IsChecked ?? false;
                
                // Gerar IEs
                IEController ieController = new IEController();
                for (int i = 0; i < quantidade; i++)
                {
                    string ie = ieController.Gerar(estado, formatado);
                    sb.AppendLine(ie);
                }
                
                Resultado.Text = sb.ToString();
                
                // Fornecer feedback para leitores de tela
                string mensagem = quantidade == 1 
                    ? $"1 Inscrição Estadual de {nomeEstado} gerada com sucesso" 
                    : $"{quantidade} Inscrições Estaduais de {nomeEstado} geradas com sucesso";
                
                NotificacaoLiveRegion.Text = mensagem;
                NotificacaoBorder.Visibility = Visibility.Visible;
                
                // Esconder a notificação após alguns segundos
                DispatcherQueue.TryEnqueue(async () => {
                    await Task.Delay(3000);
                    NotificacaoBorder.Visibility = Visibility.Collapsed;
                });
            }
            else
            {
                Resultado.Text = "Selecione um estado para gerar a Inscrição Estadual.";
                
                // Feedback para leitores de tela
                NotificacaoLiveRegion.Text = "Erro: Nenhum estado selecionado";
                NotificacaoBorder.Visibility = Visibility.Visible;
                
                DispatcherQueue.TryEnqueue(async () => {
                    await Task.Delay(3000);
                    NotificacaoBorder.Visibility = Visibility.Collapsed;
                });
            }
        }

        private void Copiar_Resultado(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Resultado.Text))
            {
                // Criar um data package
                var dataPackage = new Windows.ApplicationModel.DataTransfer.DataPackage();
                dataPackage.SetText(Resultado.Text);
                
                // Copiar para a área de transferência
                Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(dataPackage);
                
                // Fornecer feedback para leitores de tela
                ComboBoxItem selectedItem = Estados.SelectedItem as ComboBoxItem;
                string nomeEstado = selectedItem?.Content.ToString() ?? "selecionado";
                
                NotificacaoLiveRegion.Text = $"Inscrições Estaduais de {nomeEstado} copiadas para a área de transferência";
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
