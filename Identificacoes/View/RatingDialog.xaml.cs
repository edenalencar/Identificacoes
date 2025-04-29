using Identificacoes.Util;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Identificacoes.View
{
    public sealed partial class RatingDialog : ContentDialog
    {
        public RatingDialog()
        {
            this.InitializeComponent();
        }

        private async void AvaliarAgora_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // Marcar que o usuário decidiu avaliar para não mostrarmos o diálogo novamente
            AppUsageTracker.SetUserHasRated(true);
            await StoreService.OpenStoreReviewAsync();
        }

        private void Lembrar_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // Atualizar a data da última solicitação
            AppUsageTracker.SetLastPromptDate(DateTimeOffset.Now);
        }

        private void NuncaPerguntar_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // Marcar como já avaliado para não mostrar novamente
            AppUsageTracker.SetUserHasRated(true);
        }

        /// <summary>
        /// Verifica se deve mostrar o diálogo de avaliação e o exibe se apropriado
        /// </summary>
        public static async Task CheckAndShowRatingDialogAsync(XamlRoot xamlRoot)
        {
            if (AppUsageTracker.ShouldPromptForRating())
            {
                var dialog = new RatingDialog
                {
                    XamlRoot = xamlRoot
                };
                
                await dialog.ShowAsync();
            }
        }
    }
}