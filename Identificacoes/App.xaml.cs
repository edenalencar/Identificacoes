using Identificacoes.Util;
using Identificacoes.View;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.UI.Windowing;
using Microsoft.UI;
using Microsoft.Windows.AppLifecycle;
using Microsoft.Windows.AppNotifications;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Identificacoes
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        /// 

        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            Window = new View.MainWindow();
            Window.ExtendsContentIntoTitleBar = true;
            
            // Configurar o ícone para a janela da aplicação
            IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(Window);
            WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
            AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
            
            // Definir o ícone da aplicação usando o caminho completo
            string appIconPath = System.IO.Path.Combine(
                Windows.ApplicationModel.Package.Current.InstalledLocation.Path, 
                "Assets", "Square44x44Logo.scale.scale-200.png");
            appWindow.SetIcon(appIconPath);
            
            Window.Activate();

            // To ensure all Notification handling happens in this process instance, register for
            // NotificationInvoked before calling Register(). Without this a new process will
            // be launched to handle the notification.
            AppNotificationManager notificationManager = AppNotificationManager.Default;
            notificationManager.NotificationInvoked += NotificationManager_NotificationInvoked;
            notificationManager.Register();

            var activatedArgs = Microsoft.Windows.AppLifecycle.AppInstance.GetCurrent().GetActivatedEventArgs();
            var activationKind = activatedArgs.Kind;
            if (activationKind != ExtendedActivationKind.AppNotification)
            {
                LaunchAndBringToForegroundIfNeeded();
            }
            else
            {
                HandleNotification((AppNotificationActivatedEventArgs)activatedArgs.Data);
            }

            string temaSalvo = ApplicationData.Current.LocalSettings.Values[Constantes.TemaAppSelecionado]?.ToString();
            if (App.Window?.Content is FrameworkElement frameworkElement)
            {
                switch (temaSalvo)
                {
                    case Constantes.Light:
                        frameworkElement.RequestedTheme = ElementTheme.Light;
                        break;
                    case Constantes.Dark:
                        frameworkElement.RequestedTheme = ElementTheme.Dark;
                        break;
                    default:
                        frameworkElement.RequestedTheme = ElementTheme.Default;
                        break;
                }
            }

        }
        private void LaunchAndBringToForegroundIfNeeded()
        {
            if (Window == null)
            {
                Window = new MainWindow();
                Window.Activate();

                // Additionally we show using our helper, since if activated via a app notification, it doesn't
                // activate the window correctly
                WindowHelper.ShowWindow(Window);
            }
            else
            {
                WindowHelper.ShowWindow(Window);
            }
        }

        private void NotificationManager_NotificationInvoked(AppNotificationManager sender, AppNotificationActivatedEventArgs args)
        {
            HandleNotification(args);
        }

        private void HandleNotification(AppNotificationActivatedEventArgs args)
        {
            // Use the dispatcher from the window if present, otherwise the app dispatcher
            var dispatcherQueue = Window?.DispatcherQueue ?? DispatcherQueue.GetForCurrentThread();


            dispatcherQueue.TryEnqueue(async delegate
            {

                switch (args.Arguments["action"])
                {
                    // Send a background message
                    case "sendMessage":
                        string message = args.UserInput["textBox"].ToString();
                        // TODO: Send it

                        // If the UI app isn't open
                        if (Window == null)
                        {
                            // Close since we're done
                            Process.GetCurrentProcess().Kill();
                        }

                        break;

                    // View a message
                    case "viewMessage":

                        // Launch/bring window to foreground
                        LaunchAndBringToForegroundIfNeeded();

                        // TODO: Open the message
                        break;
                }
            });
        }

        public static Window? Window { get; private set; }
    }

    public static class WindowHelper
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void ShowWindow(Window window)
        {
            // Bring the window to the foreground... first get the window handle...
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(window);

            // Restore window if minimized... requires DLL import above
            ShowWindow(hwnd, 0x00000009);

            // And call SetForegroundWindow... requires DLL import above
            SetForegroundWindow(hwnd);
        }
    }
}
