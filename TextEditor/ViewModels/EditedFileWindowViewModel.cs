using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TextEditor.Commands;
using TextEditor.Models;

namespace TextEditor.ViewModels
{
    public class EditedFileWindowViewModel : ViewModelBase
    {
        EditedFileManager _manager;
        public EditedFileWindowViewModel(EditedFileManager manager)
        {
            _manager = manager;
            AddNewFile = new AddNewFileCommand(this, _manager);
            SetInputFileName = new SetInputFileNameCommand(this);
            SetOutputFileName = new SetOutputFileNameCommand(this);            
        }
        private string _inputName = "";        
        public string InputNameProperty
        {
            get { return _inputName; }
            set
            {
                _inputName = value;
                NotifyPropertyChanged("InputNameProperty");
            }
        }

        private string _outputName = "";
        public string OutputNameProperty
        {
            get { return _outputName; }
            set
            {
                _outputName = value;
                NotifyPropertyChanged("OutputNameProperty");
            }
        }

        private string _minFileLenght = "0";
        public string MinFileLenght
        {
            get { return _minFileLenght; }
            set
            {
                _minFileLenght = (value);
                int.Parse(value);                
                NotifyPropertyChanged("MinFileLenght");
            }
        }

        private bool _removePunctuationMarks = false;
        public bool RemovePunctuationMarks
        {
            get { return _removePunctuationMarks; }
            set
            {
                _removePunctuationMarks = value;
                NotifyPropertyChanged("RemovePunctuationMarks");
            }
        }

        public ICommand SetInputFileName { get; private set; }
        public ICommand SetOutputFileName { get; private set; }
        public ICommand AddNewFile { get; private set; }

        public bool IsValid()
        {
            if (_inputName.Length > 0 &&
                _outputName.Length > 0 &&
                _inputName != _outputName &&
                int.TryParse(MinFileLenght, out int result) == true &&
                result >= 0)
                return true;
            return false;
        }
        public EditedFile GetEditedFile()
        {
            return new EditedFile
            {
                InputName = _inputName,
                OutputName = _outputName,
                MinFileLenght = int.Parse(_minFileLenght),
                RemovePunctuationMarks = _removePunctuationMarks
            };
        }

        public event EventHandler EventCloseWindow;
        public void CloseWindow() => EventCloseWindow?.Invoke(this, EventArgs.Empty);
    }
}
