using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.Models
{
    public class TextReader : IReader
    {
        StreamReader _reader;
        public TextReader(string fileName)
        {
            _reader = new StreamReader(fileName, Encoding.Default);            
        }

        public bool ReadNextLine(ref string line)
        {
            if (!_reader.EndOfStream)
            {
                line = _reader.ReadLine();

                return true;
            }
            else
                return false;
        }
        public void Dispose()
        {
            _reader.Dispose();
        }
    }
}
