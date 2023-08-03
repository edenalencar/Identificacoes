using Identificacoes.Bu;
using Identificacoes.Util;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using System.Text;
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

            if ((bool)Filiais.IsChecked)
            {
                var matriz = IdentificacaoFactory.GetInstance().GetIdentificacao(Constantes.CNPJ);
                identificacaoCNPJ.Add(matriz);

                for (int i = 1; i < Quantidade.Value; i++)
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
                        builder.Append(identificacao.GetIdentificacao() + "\n");
                    }

                }
            }
            else
            {
                for (int i = 0; i < Quantidade.Value; i++)
                {
                    var identificacao = new IdentificacaoCNPJ();
                    if ((bool)Formatado.IsChecked)
                    {
                        builder.Append(identificacao.ObterIdentificacaoFormatada() + "\n");
                    }
                    else
                    {
                        builder.Append(identificacao.GetIdentificacao() + "\n");
                    }
                }
            }
            Resultado.Text = builder.ToString();
        }
        public void Copiar_Resultado(object sender, RoutedEventArgs e)
        {
            DataPackage package = new DataPackage();
            package.SetText(Resultado.Text);
            Clipboard.SetContent(package);
        }
    }
}
