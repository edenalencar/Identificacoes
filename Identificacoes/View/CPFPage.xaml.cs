using Identificacoes.Bu;
using Identificacoes.Util;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Text;
using Windows.ApplicationModel.DataTransfer;

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
            for (int i = 0; i < quantidade.Value; i++)
            {
                var identificacaoCPF = IdentificacaoFactory.GetInstance().GetIdentificacao(Constantes.CPF);
                if ((bool)formatado.IsChecked)
                {
                    builder.Append(identificacaoCPF.ObterIdentificacaoFormatada()+"\n");
                }
                else
                {
                    builder.Append(identificacaoCPF.ObterIdentificacao() + "\n");
                }
            }
            resultado.Text = builder.ToString();
        }

        private void Copiar_Resultado(object sender, RoutedEventArgs e)
        {
            DataPackage package = new DataPackage();
            package.SetText(resultado.Text);
            Clipboard.SetContent(package);
        }
        
    }
}
