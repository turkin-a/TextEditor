using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TextEditor.Commands;
using TextEditor.Models;

namespace TextEditor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        EditedFileManager _manager;
        public MainWindowViewModel( EditedFileManager manager)
        {
            _manager = manager;
            RemoveFileName = new RemoveFileNameCommand(this, manager);
            RunFileProcessing = new RunFileProcessingCommand(this, manager);
            ClearFileNames = new ClearFileNamesCommand (this, manager);
        }

        private ObservableCollection<EditedFile> _fileNameList;
        public ObservableCollection<EditedFile> FileNameList
        {
            get { return _fileNameList; }
            set
            {
                _fileNameList = value;
                NotifyPropertyChanged("FileNameList");
            }
        }

        private int? _listIndex;
        public int? ListIndex
        {
            get { return _listIndex; }
            set
            {
                _listIndex = value;
                NotifyPropertyChanged("ListIndex");
            }
        }
 
        private bool _isNotRunned = true;
        public bool IsNotRunned
        {
            get { return _isNotRunned; }
            set
            {
                _isNotRunned = value;
                NotifyPropertyChanged("IsNotRunned");
            }
        }
        public RemoveFileNameCommand RemoveFileName { get; private set; }
        public RunFileProcessingCommand RunFileProcessing { get; private set; }
        public ClearFileNamesCommand ClearFileNames { get; private set; }
    }
}
