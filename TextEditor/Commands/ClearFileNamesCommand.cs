using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.Models;
using TextEditor.ViewModels;

namespace TextEditor.Commands
{
    public class ClearFileNamesCommand : CommandBase
    {
        MainWindowViewModel _viewModel;
        EditedFileManager _manager;
        public ClearFileNamesCommand(MainWindowViewModel viewModel, EditedFileManager manager)
        {
            _viewModel = viewModel;
            _manager = manager;
        }
        public override void Execute(object? parameter)
        {
            _manager.Clear();
        }
    }
}
