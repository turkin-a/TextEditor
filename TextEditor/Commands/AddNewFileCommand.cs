using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using TextEditor.Models;
using TextEditor.ViewModels;

namespace TextEditor.Commands
{
    public class AddNewFileCommand : CommandBase
    {
        EditedFileWindowViewModel _viewModel;
        EditedFileManager _editedFileManager;
        public AddNewFileCommand(EditedFileWindowViewModel viewModel, EditedFileManager manager) 
        {
            _viewModel = viewModel;
            _editedFileManager = manager;
        }
        public override void Execute(object? parameter)
        {
            if (IsValid())
            {
                var editedFile = _viewModel.GetEditedFile();
                if (!_editedFileManager.AddFile(editedFile))
                {
                    MessageBox.Show("Файл не может быть добавлен. Выходной файл с таким именем уже присутствует.",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                else
                    _viewModel.CloseWindow();
            }
            else
            {
                MessageBox.Show("Введены неверные параметры. Должны быть указаны имена входного и выходного файлов и они не должны совпадать.",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
        private bool IsValid()
        {
            if (_viewModel.IsValid())
                return true;
            return false;
        }
    }
}
