using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TextEditor.Models;
using TextEditor.ViewModels;

namespace TextEditor.Commands
{
    class SetInputFileNameCommand : CommandBase
    {
        EditedFileWindowViewModel _viewModel;
        public SetInputFileNameCommand(EditedFileWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == true)
            {
                _viewModel.InputNameProperty = openFileDialog.FileName;
            }
        }
    }
}
