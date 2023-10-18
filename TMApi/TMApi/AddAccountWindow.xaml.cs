using System.Windows;

namespace TMApi
{
    public class AccountInfo
    {
        public string AccountName { get; set; }
        public string ApiKey { get; set; }
        public string PaymentPassword { get; set; }
    }

    public partial class AddAccountWindow : Window
    {
        public AccountInfo NewAccount { get; set; }

        public AddAccountWindow()
        {
            InitializeComponent();
            NewAccount = new AccountInfo();
            DataContext = NewAccount;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

    }

}
