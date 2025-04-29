using System;
using Windows.Storage;

namespace Identificacoes.Util
{
    /// <summary>
    /// Classe para rastrear o uso do aplicativo e gerenciar solicitações de avaliação
    /// </summary>
    public static class AppUsageTracker
    {
        // Chaves para armazenamento nas configurações
        private const string LastPromptDateKey = "LastRatingPromptDate";
        private const string LaunchCountKey = "AppLaunchCount";
        private const string HasRatedKey = "UserHasRatedApp";
        
        private static readonly ApplicationDataContainer LocalSettings = ApplicationData.Current.LocalSettings;
        
        /// <summary>
        /// Incrementa o contador de inicializações do aplicativo
        /// </summary>
        public static void IncrementLaunchCount()
        {
            int currentCount = GetLaunchCount();
            LocalSettings.Values[LaunchCountKey] = currentCount + 1;
        }
        
        /// <summary>
        /// Obtém o número de vezes que o aplicativo foi iniciado
        /// </summary>
        public static int GetLaunchCount()
        {
            if (LocalSettings.Values.TryGetValue(LaunchCountKey, out var count))
            {
                return (int)count;
            }
            return 0;
        }
        
        /// <summary>
        /// Registra a data da última solicitação de avaliação
        /// </summary>
        public static void SetLastPromptDate(DateTimeOffset date)
        {
            LocalSettings.Values[LastPromptDateKey] = date.ToString("o");
        }
        
        /// <summary>
        /// Obtém a data da última solicitação de avaliação
        /// </summary>
        public static DateTimeOffset? GetLastPromptDate()
        {
            if (LocalSettings.Values.TryGetValue(LastPromptDateKey, out var dateString))
            {
                if (DateTimeOffset.TryParse((string)dateString, out var date))
                {
                    return date;
                }
            }
            return null;
        }
        
        /// <summary>
        /// Define se o usuário já avaliou o aplicativo
        /// </summary>
        public static void SetUserHasRated(bool hasRated)
        {
            LocalSettings.Values[HasRatedKey] = hasRated;
        }
        
        /// <summary>
        /// Verifica se o usuário já avaliou o aplicativo
        /// </summary>
        public static bool GetUserHasRated()
        {
            if (LocalSettings.Values.TryGetValue(HasRatedKey, out var hasRated))
            {
                return (bool)hasRated;
            }
            return false;
        }
        
        /// <summary>
        /// Verifica se é o momento adequado para solicitar uma avaliação
        /// </summary>
        public static bool ShouldPromptForRating()
        {
            // Não mostrar se o usuário já avaliou
            if (GetUserHasRated())
            {
                return false;
            }
            
            // Verificar número de inicializações (mostrar após 5 usos)
            int launchCount = GetLaunchCount();
            if (launchCount < 5)
            {
                return false;
            }
            
            // Verificar quando foi a última vez que solicitamos (pelo menos 7 dias depois)
            var lastPrompt = GetLastPromptDate();
            if (lastPrompt.HasValue)
            {
                var daysSinceLastPrompt = (DateTimeOffset.Now - lastPrompt.Value).TotalDays;
                if (daysSinceLastPrompt < 7)
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}