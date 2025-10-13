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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AddressBook.WPF.Controls
{
    /// <summary>
    /// Interaction logic for ContactDetailsCtrl.xaml
    /// </summary>
    public partial class ContactDetailsCtrl : UserControl
    {
        public ContactDetailsCtrl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SaveCommandProperty =
        DependencyProperty.Register(nameof(SaveCommand), typeof(ICommand), typeof(ContactDetailsCtrl));

        public ICommand? SaveCommand
        {
            get => (ICommand?)GetValue(SaveCommandProperty);
            set => SetValue(SaveCommandProperty, value);
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                CommitAndSave();
            }
        }

        private void CommitAndSave()
        {
            // Uppdatera alla TextBox-bindings innan vi sparar
            foreach (var tb in FindVisualChildren<TextBox>(this))
            {
                var binding = BindingOperations.GetBindingExpression(tb, TextBox.TextProperty);
                binding?.UpdateSource();
            }

            if (DataContext is ContactViewModel vm && vm.IsChanged && SaveCommand?.CanExecute(vm) == true)
            {
                SaveCommand.Execute(vm);
            }
        }

        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield break;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                if (child is T t) yield return t;

                foreach (var childOfChild in FindVisualChildren<T>(child))
                    yield return childOfChild;
            }
        }
    }
}
