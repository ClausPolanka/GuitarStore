using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using NHibernate.GuitarStore.Common;
using NHibernate.GuitarStore.DataAccess;

namespace GuitarStoreWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NHibernateBase nhb = new NHibernateBase();
            nhb.Initialize("NHibernate.GuitarStore");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateComboBox();
            NHibernateInventory nhi = new NHibernateInventory();
            IList<Inventory> list = nhi.ExecuteICriteriaOrderBy("Builder");
            dataGridInventory.ItemsSource = list;
            if (list != null)
            {
                HideTechnicalInformation();
            }
        }

        private void PopulateComboBox()
        {
            NHibernateBase nhb = new NHibernateBase();
            IList<Guitar> GuitarTypes = nhb.ExecuteICriteria<Guitar>();
            foreach (var item in GuitarTypes)
            {
                Guitar guitar = new Guitar(item.Id, item.Type);
                comboBoxGuitarTypes.DisplayMemberPath = "Type";
                comboBoxGuitarTypes.SelectedValuePath = "Id";
                comboBoxGuitarTypes.Items.Add(guitar);
            }
        }

        private void HideTechnicalInformation()
        {
            dataGridInventory.Columns[0 /* ID */].Visibility = Visibility.Hidden;
            dataGridInventory.Columns[1 /* Type ID */].Visibility = Visibility.Hidden;
            dataGridInventory.Columns[8 /* Version */].Visibility = Visibility.Hidden;
        }

        private void comboBoxGuitarTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                dataGridInventory.ItemsSource = null;
                Guitar guitar = (Guitar) comboBoxGuitarTypes.SelectedItem;
                Guid guitarType = new Guid(guitar.Id.ToString());
                
                NHibernateInventory nhi = new NHibernateInventory();
                List<Inventory> list = (List<Inventory>) nhi.ExecuteICriteria(guitarType);
                dataGridInventory.ItemsSource = list;
                if (list != null)
                {
                    HideTechnicalInformation();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Content = ex.Message;
            }
        }
    }
}