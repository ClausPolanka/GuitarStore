using System.Collections.Generic;
using System.Windows;
using NHibernate.GuitarStore.Common;
using NHibernate.GuitarStore.DataAccess;

namespace GuitarStoreWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
            NHibernateInventory nhi         = new NHibernateInventory();
            IList<Inventory> list = nhi.ExecuteICriteriaOrderBy("Builder");
            dataGridInventory.ItemsSource = list;
            if (list != null)
            {
                dataGridInventory.Columns[0].Visibility = System.Windows.Visibility.Hidden;
                dataGridInventory.Columns[1].Visibility = System.Windows.Visibility.Hidden;
                dataGridInventory.Columns[8].Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}