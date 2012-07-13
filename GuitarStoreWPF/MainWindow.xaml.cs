using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using NHibernate.GuitarStore.Common;
using NHibernate.GuitarStore.DataAccess;

namespace GuitarStoreWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var nhb = new NHibernateBase();
            nhb.Initialize("NHibernate.GuitarStore");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateDataGrid();
            PopulateComboBox();
            SetDatabaseRoundTripImage();
        }

        private void PopulateDataGrid()
        {
            var nhi = new NHibernateInventory();
            IList<Inventory> list = nhi.ExecuteICriteriaOrderBy("Builder");
            dataGridInventory.ItemsSource = list;

            if (list != null)
                HideColumnsWhichContainTechnicalInformation();
        }

        private void HideColumnsWhichContainTechnicalInformation()
        {
            dataGridInventory.Columns[0 /* ID */].Visibility = Visibility.Hidden;
            dataGridInventory.Columns[1 /* Type ID */].Visibility = Visibility.Hidden;
            dataGridInventory.Columns[8 /* Version */].Visibility = Visibility.Hidden;
        }

        private void PopulateComboBox()
        {
            var nhb = new NHibernateBase();
            IList<Guitar> GuitarTypes = nhb.ExecuteICriteria<Guitar>();
            foreach (Guitar item in GuitarTypes)
            {
                var guitar = new Guitar(item.Id, item.Type);
                comboBoxGuitarTypes.DisplayMemberPath = "Type";
                comboBoxGuitarTypes.SelectedValuePath = "Id";
                comboBoxGuitarTypes.Items.Add(guitar);
            }
        }

        public void SetDatabaseRoundTripImage()
        {
            if (Utils.QueryCounter < 0)
            {
                ImageDatabaseCounter.Source = (ImageSource) FindResource("ImageDatabaseCounterRed");
                ImageDatabaseCounter.ToolTip = "Error";
            }
            else if (Utils.QueryCounter == 0)
            {
                //Image is reset when, for example, the Configuration is changed
                ImageDatabaseCounter.Source = (ImageSource) FindResource("ImageDatabaseCounterGreen");
                ImageDatabaseCounter.ToolTip = "";
            }
            else if (Utils.QueryCounter == 1)
            {
                ImageDatabaseCounter.Source = (ImageSource) FindResource("ImageDatabaseCounterGreen");
                ImageDatabaseCounter.ToolTip = "1 round trip to database";
            }
            else if (Utils.QueryCounter == 2)
            {
                ImageDatabaseCounter.Source = (ImageSource) FindResource("ImageDatabaseCounterYellow");
                ImageDatabaseCounter.ToolTip = "2 round trip to database";
            }
            else if (Utils.QueryCounter > 2)
            {
                ImageDatabaseCounter.Source = (ImageSource) FindResource("ImageDatabaseCounterRed");
                ImageDatabaseCounter.ToolTip = Utils.QueryCounter.ToString() + " round trip to database";
            }
            //reset the value each time this method is called.
            Utils.QueryCounter = 0;
        }

        private void comboBoxGuitarTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                dataGridInventory.ItemsSource = null;
                var guitar = (Guitar) comboBoxGuitarTypes.SelectedItem;
                var guitarType = new Guid(guitar.Id.ToString());

                var nhi = new NHibernateInventory();
                var list = (List<Inventory>) nhi.ExecuteICriteria(guitarType);
                dataGridInventory.ItemsSource = list;

                if (list != null)
                    HideColumnsWhichContainTechnicalInformation();
            }
            catch (Exception ex)
            {
                labelMessage.Content = ex.Message;
            }
        }

        private void buttonViewSQL_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Utils.FormatSQL(), "Most recent NHibernate generated SQL", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            var inventoryItem = (Inventory) dataGridInventory.SelectedItem;
            var item = new Guid(inventoryItem.Id.ToString());

            var nhi = new NHibernateInventory();
            if (nhi.DeleteInventoryItem(item))
            {
                dataGridInventory.ItemsSource = null;
                PopulateDataGrid();
                labelMessage.Content = "Item deleted.";
            }
            else
                labelMessage.Content = "Item deletion failed.";
        }
    }
}