using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Windows.Data;

namespace TMApi
{
    public partial class PassAPIManager : Window
    {
        private List<AccountInfo> accountList;
        private string dataFilePath = "account_data.json";
        private ICollectionView accountCollectionView;

        public PassAPIManager()
        {
            InitializeComponent();
            LoadData();
            accountCollectionView = CollectionViewSource.GetDefaultView(accountList);
            accountDataGrid.ItemsSource = accountCollectionView;
        }

        private void LoadData()
        {
            if (File.Exists(dataFilePath))
            {
                string jsonData = File.ReadAllText(dataFilePath);
                accountList = JsonConvert.DeserializeObject<List<AccountInfo>>(jsonData);
            }
            else
            {
                accountList = new List<AccountInfo>();
            }
        }

        private void SaveData()
        {
            string jsonData = JsonConvert.SerializeObject(accountList);
            File.WriteAllText(dataFilePath, jsonData);
        }

        private void AddAccount_Click(object sender, RoutedEventArgs e)
        {
            AddAccountWindow addAccountWindow = new AddAccountWindow();
            if (addAccountWindow.ShowDialog() == true)
            {
                AccountInfo newAccount = addAccountWindow.NewAccount;
                accountList.Add(newAccount);
                SaveData(); // Сохранение данных
                RefreshDataGrid();
            }
        }

        private void DeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is AccountInfo accountToDelete)
            {
                accountList.Remove(accountToDelete);
                SaveData();
                RefreshDataGrid();
            }
        }

        private void RefreshDataGrid()
        {
            accountCollectionView.Refresh();
        }
    }
}
