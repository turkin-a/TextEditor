using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.Models
{
    public class TextReader : IReader
    {
        StreamReader _reader;
        private int _buffSize;
        private char[] _buffer;
        private string _restText;
        public TextReader(string fileName, int buffSize)
        {
            _reader = new StreamReader(fileName, Encoding.Default);
            _buffSize = buffSize;
            _buffer = new char[buffSize];
            _restText = "";
        }

        public bool ReadNextTextPart(ref string line)
        {
            if (!_reader.EndOfStream || _restText.Length > 0)
            {
                var readedChars = _reader.Read(_buffer, 0, _buffSize);
                var index = Array.FindLastIndex(_buffer, b => b == '\n' || b == ' ');
                line = _restText + new string(_buffer, 0, index+1);
                if (readedChars - index - 1 > 0)
                    _restText = new string(_buffer, index + 1, readedChars - index - 1);
                else
                    _restText = "";
                return true;
            }
            return false;
        }
        public void Dispose()
        {
            _reader.Dispose();
        }
    }
}
