using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace TextEditor.Models
{
    public class EditedFileManager
    {
        private EditedFileStorage _storage = new EditedFileStorage();
        private int _buffSize = 30;

        public bool AddFile(EditedFile editedFile)
        {
            return _storage.AddEditedFile(editedFile);
        }
        public ObservableCollection<EditedFile> EditedFileList 
        { 
            get 
            { 
                return _storage.GetList(); 
            }
        }

        private object _isNotRunnedLocker = new();  // объект-заглушка 
        private bool _isNotRunned = true;
        public bool IsNotRunned
        {
            get
            {
                lock (_isNotRunnedLocker)
                {
                    return _isNotRunned;
                }
            }
            set
            {
                lock (_isNotRunnedLocker)
                {
                    _isNotRunned = value;                    
                }
            }
        }

        public void RemoveEditedFile(int index)
        {
            _storage.RemoveEditedFile(index);
        }
        public void Clear()
        {
            _storage.Clear();
        }
        public bool IsNotEmpty()
        {
            return _storage.IsNotEmpty();
        }
        public async Task RunFileProcessing()
        {
            //IsNotRunned = false;
            List<Task> tasks = new List<Task>();
            foreach (var editedFile in EditedFileList)
            {
                var task = new Task(() => FileProcessingAsync(editedFile));
                tasks.Add(task);
                task.Start();
            }

            await Task.WhenAll(tasks);
            IsNotRunned = true;
            MessageBox.Show("Обработка завершена",
                        "Information",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
        }
        public async Task FileProcessingAsync(EditedFile editedFile)
        {            
            using(TextReader textReader = new TextReader(editedFile.InputName, _buffSize))
            {
                using (TextWriter textWriter = new TextWriter(editedFile.OutputName))
                {
                    string inputLine = "";
                    while (textReader.ReadNextTextPart(ref inputLine))
                    {
                        StringEditor lineEditor = new StringEditor(editedFile);
                        textWriter.WriteString(lineEditor.Convert(inputLine));
                    }
                }                    
            }
        }
    }
}
