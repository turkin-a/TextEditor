using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.Models
{
    public class EditedFileStorage
    {
        private readonly ObservableCollection<EditedFile> _editedFileList = new ObservableCollection<EditedFile>();
        public bool AddEditedFile(EditedFile editedFile)
        {
            var item = (_editedFileList).Where(x => x.OutputName == editedFile.OutputName).FirstOrDefault();
            if (item == null)
            {
                _editedFileList.Add(editedFile);
                return true;
            }
            return false;
        }
        public void RemoveEditedFile(int index)
        {
            _editedFileList.RemoveAt(index);
        }
        public void Clear()
        {
            _editedFileList.Clear();
        }
        public ObservableCollection<EditedFile> GetList()
        {
            return _editedFileList;
        }
        public bool IsNotEmpty()
        {
            return _editedFileList.Any();
        }

            
    }
}
