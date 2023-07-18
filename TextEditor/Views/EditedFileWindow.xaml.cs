using Microsoft.Win32;
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
using TextEditor.Models;
using TextEditor.ViewModels;

namespace TextEditor.Views
{
    /// <summary>
    /// Логика взаимодействия для EditedFileWindow.xaml
    /// </summary>
    public partial class EditedFileWindow : Window
    {
        private readonly EditedFileManager _editedFileManager;
        public EditedFileWindow(EditedFileManager manager)
        {
            InitializeComponent();
            this._editedFileManager = manager;
            EditedFileWindowViewModel viewModel =  new EditedFileWindowViewModel(manager);
            viewModel.EventCloseWindow += (sender, args) => { this.Close(); };
            this.DataContext = viewModel;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
