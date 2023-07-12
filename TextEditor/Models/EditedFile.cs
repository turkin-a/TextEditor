using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.Models
{
    public class EditedFile
    {
        public string InputName { get; set; } = "";
        public string OutputName { get; set; } = "";
        public int MinFileLenght { get; set; }
        public bool RemovePunctuationMarks { get; set; }

        public override string ToString()
        {
            return $"Input name: {Path.GetFileName(InputName)}, " +
                $"Output name: {Path.GetFileName(OutputName)} " +
                $"(Min file lenght: {MinFileLenght}, " +
                $"remove punctuation marks: {RemovePunctuationMarks})";
        }
    }
}
