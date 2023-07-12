using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.ViewModels;

namespace TextEditor.Commands
{
    class SetOutputFileNameCommand : CommandBase
    {
        EditedFileWindowViewModel _viewModel;
        public SetOutputFileNameCommand(EditedFileWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                _viewModel.OutputNameProperty = saveFileDialog.FileName;
            }
        }
    }
}
