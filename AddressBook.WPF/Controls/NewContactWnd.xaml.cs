using AddressBook.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AddressBook.WPF.Controls
{
    /// <summary>
    /// Interaction logic for NewContactWnd.xaml
    /// </summary>
    public partial class NewContactWnd : Window
    {
        public NewContactWnd()
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                if (DataContext is NewContactViewModel vm)
                {
                    // Koppla bara en gång
                    vm.RequestClose -= OnRequestClose;
                    vm.RequestClose += OnRequestClose;
                }
            };
        }

        private void OnRequestClose()
        {
            if (DataContext is NewContactViewModel vm)
            {
                DialogResult = vm.WasSaved;
            }
            Close();
        }
    }
}
