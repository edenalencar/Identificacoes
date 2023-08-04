using Identificacoes.Bu;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
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
    public sealed partial class IEPage : Page
    {        
        public IEPage()
        {
            this.InitializeComponent();
        }
        
        public void Gerar_IE(object sender, RoutedEventArgs e)
        {
            var builder = new StringBuilder();            
            for (int i = 0; i < Quantidade.Value; i++)
            {
                var identificacao = IdentificacaoFactory.GetInstance().GetIdentificacao("IE-" +((Tuple<string, string>)ListaUFs.SelectedValue).Item1);
                if ((bool)Formatado.IsChecked)
                {
                    builder.Append(identificacao.ObterIdentificacaoFormatada() + "\n");
                }
                else
                {
                    builder.Append(identificacao.ObterIdentificacao() + "\n");
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
        public List<Tuple<string, string>> UFs { get; } = new List<Tuple<string, string>>()
            {
                    new Tuple<string,string>("AC","Acre"),
                    new Tuple<string,string>("AL","Alagoas"),
                    new Tuple<string,string>("AP","Amapá"),
                    new Tuple<string,string>("AM","Amazonas"),
                    new Tuple<string,string>("BA","Bahia"),
                    new Tuple<string,string>("CE","Ceará" ),
                    new Tuple<string,string>("DF","Distrito Federal" ),
                    new Tuple<string,string>("ES","Espírito Santo"),
                    new Tuple<string,string>("GO","Goiás"),
                    new Tuple<string,string>("MA","Maranhão"),
                    new Tuple<string,string>("MT","Mato Grosso"),
                    new Tuple<string,string>("MS","Mato Grosso do Sul"),                    
                    new Tuple<string,string>("MG","Minas Gerais"),
                    new Tuple<string,string>("PA","Pará"),
                    new Tuple<string,string>("PB","Paraíba"),
                    new Tuple<string,string>("PR","Paraná"),
                    new Tuple<string,string>("PE","Pernambuco"),
                    new Tuple<string,string>("PI","Piauí"),
                    new Tuple<string,string>("RJ","Rio de Janeiro"),
                    new Tuple<string,string>("RN","Rio Grande do Norte"),
                    new Tuple<string,string>("RS","Rio Grande do Sul"),
                    new Tuple<string,string>("RO","Rondônia"),
                    new Tuple<string,string>("RR","Roraima"),
                    new Tuple<string,string>("SC","Santa Catariana"),
                    new Tuple<string,string>("SP","São Paulo"),                    
                    new Tuple<string,string>("SE","Sergipe"),
                    new Tuple<string,string>("TO","Tocantins")
            };
    }
}
