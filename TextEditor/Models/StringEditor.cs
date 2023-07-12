using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextEditor.Models
{
    public class StringEditor
    {
        private int _minFileLenght;
        private bool _removePunctuationMarks;
        public StringEditor(EditedFile editedFile) 
        {
            _minFileLenght =  editedFile.MinFileLenght;
            _removePunctuationMarks = editedFile.RemovePunctuationMarks;
        }
        public string Convert(string input)
        {
            StringBuilder output = RemoveShortWords(input);
            if (_removePunctuationMarks == true)
                output = RemovePunctuationMarks(output);
            return output.ToString();
        }
        private StringBuilder RemoveShortWords(string input)
        {            
            StringBuilder output = new StringBuilder(input);
            var words = Regex.Matches(input, "\\b\\w+\\b");
            for (int i = words.Count-1; i >=0; i--)
            {
                Match word = words[i];
                if (word.Length < _minFileLenght)
                {
                    output.Remove(word.Index, word.Length);
                }
            }            
            return output;
        }
        private StringBuilder RemovePunctuationMarks(StringBuilder input)
        {
            List<char> charsToRemove = new List<char>() { '!', '?', ',', '.', ';' };
            StringBuilder output = FilterByChars(input, charsToRemove);
            return output;
        }
        private StringBuilder FilterByChars(StringBuilder str, List<char> charsToRemove)
        {
            foreach (char c in charsToRemove)
            {
                str = str.Replace(c.ToString(), String.Empty);
            }
            return str;
        }
    }
}
