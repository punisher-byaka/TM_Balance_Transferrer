using System;
using System.Diagnostics;
using System.Windows;

namespace TMApi
{
    public partial class MainWindow : Window
    {
        private const string BaseUrl = "https://market.csgo.com/api/v2/money-send/";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            // Код для кнопки "Перейти"
        }

        private void InstructionText_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            // Создаем и отображаем новое окно с инструкцией
            InstructionWindow instructionWindow = new InstructionWindow();
            instructionWindow.Show();
        }
        private void PasswordManager_Click(object sender, RoutedEventArgs e)
        {
            PassAPIManager passAPIManager = new PassAPIManager();
            passAPIManager.Show();
        }


        private void OpenUrlInBrowser(string url)
        {
            // Код для открытия URL в браузере
        }
    }
}
