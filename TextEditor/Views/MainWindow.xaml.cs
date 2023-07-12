using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using TextEditor.Models;
using TextEditor.ViewModels;

namespace TextEditor.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly EditedFileManager _editedFileManager = new EditedFileManager();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(this, _editedFileManager);
            EditFileNamesListBox.ItemsSource = _editedFileManager.EditedFileList;
        }

        private void AddFile_Click(object sender, RoutedEventArgs e)
        {
            EditedFileWindow addFileWindow = new EditedFileWindow(_editedFileManager);
            addFileWindow.ShowDialog();
            
        }
    }
}
