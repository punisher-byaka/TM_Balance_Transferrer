using System;
using System.Diagnostics;
using System.Windows;

namespace TMApi
{
    public partial class InstructionWindow : Window
    {
        public InstructionWindow()
        {
            InitializeComponent();

            // Установите размеры окна
            Width = 1000;
            Height = 400;

            // Установите SizeToContent в Manual
            SizeToContent = SizeToContent.Manual;
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = e.Uri.AbsoluteUri,
                    UseShellExecute = true
                });
                e.Handled = true; // Помечаем событие как обработанное
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии ссылки: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
