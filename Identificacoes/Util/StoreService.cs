using System;
using System.Threading.Tasks;
using Windows.System;

namespace Identificacoes.Util
{
    /// <summary>
    /// Serviço para interação com a Microsoft Store
    /// </summary>
    public static class StoreService
    {
        // ID do aplicativo na Microsoft Store - não altere 
        private const string AppStoreId = "9PJR7TBTZKR1";
        
        /// <summary>
        /// Abre a página de avaliação do aplicativo na Microsoft Store
        /// </summary>
        public static async Task OpenStoreReviewAsync()
        {
            // Formato URI para avaliação: ms-windows-store://review/?ProductId=AppStoreId
            string storeUri = $"ms-windows-store://review/?ProductId={AppStoreId}";
            await Launcher.LaunchUriAsync(new Uri(storeUri));
            
            // Marcar que o usuário foi para a página de avaliação
            AppUsageTracker.SetLastPromptDate(DateTimeOffset.Now);
        }
        
        /// <summary>
        /// Abre a página do aplicativo na Microsoft Store
        /// </summary>
        public static async Task OpenStorePageAsync()
        {
            // Formato URI para página do app: ms-windows-store://pdp/?ProductId=AppStoreId
            string storeUri = $"ms-windows-store://pdp/?ProductId={AppStoreId}";
            await Launcher.LaunchUriAsync(new Uri(storeUri));
        }
    }
}