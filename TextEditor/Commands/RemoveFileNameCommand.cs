using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TextEditor.Models;
using TextEditor.ViewModels;

namespace TextEditor.Commands
{
    public class RemoveFileNameCommand : CommandBase
    {
        MainWindowViewModel _viewModel;
        EditedFileManager _manager;
        public RemoveFileNameCommand(MainWindowViewModel viewModel, EditedFileManager manager)
        {
            _viewModel = viewModel;
            _manager = manager;
        }
        public override void Execute(object? parameter)
        {
            if (_viewModel.ListIndex != null)
            {
                _manager.RemoveEditedFile((int)_viewModel.ListIndex);
            }
        }
    }
}
