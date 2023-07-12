using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TextEditor.Models;
using TextEditor.ViewModels;

namespace TextEditor.Commands
{
    public class RunFileProcessingCommand : CommandBase
    {
        MainWindowViewModel _viewModel;
        EditedFileManager _manager;
        public RunFileProcessingCommand(MainWindowViewModel viewModel, EditedFileManager manager)
        {
            _viewModel = viewModel;
            _manager = manager;
        }
        public override void Execute(object? parameter)
        {
            if (_manager.IsNotEmpty())
            {
                _viewModel.IsNotRunned = false;
                _manager.IsNotRunned = false;
                var taskFileProcessing = new Task(() => _manager.RunFileProcessing());
                taskFileProcessing.Start();
                var taskIsNotRunned = new Task(() =>
                {
                    while (true)
                    {
                        if (_manager.IsNotRunned == true)
                        {
                            _viewModel.IsNotRunned = true;
                            return;
                        }
                        Thread.Sleep(100);
                    }                    
                });
                taskIsNotRunned.Start();
            }      
            else
            {
                MessageBox.Show("Для запуска нужно дабавить файлы для обработки.",
                        "Не выбраны файлы",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
            }
        }
    }
}
