namespace TextEditor.Tests
{
    public class StringEditorTests
    {
        private string _text;
        [SetUp]
        public void Setup()
        {
            _text = "א אב אבג! אבגד, אבגדה. אבגדהו; בגדהו? גדהו דהו הו ו";
        }
        [Test]
        [TestCase(0, false, "א אב אבג! אבגד, אבגדה. אבגדהו; בגדהו? גדהו דהו הו ו")]
        [TestCase(1, false, "א אב אבג! אבגד, אבגדה. אבגדהו; בגדהו? גדהו דהו הו ו")]
        [TestCase(2, false, " אב אבג! אבגד, אבגדה. אבגדהו; בגדהו? גדהו דהו הו ")]
        [TestCase(3, false, "  אבג! אבגד, אבגדה. אבגדהו; בגדהו? גדהו דהו  ")]
        [TestCase(4, false, "  ! אבגד, אבגדה. אבגדהו; בגדהו? גדהו   ")]
        [TestCase(5, false, "  ! , אבגדה. אבגדהו; בגדהו?    ")]
        [TestCase(6, false, "  ! , . אבגדהו; ?    ")]
        [TestCase(7, false, "  ! , . ; ?    ")]
        [TestCase(8, false, "  ! , . ; ?    ")]
        [TestCase(0, true, "א אב אבג אבגד אבגדה אבגדהו בגדהו גדהו דהו הו ו")]
        [TestCase(1, true, "א אב אבג אבגד אבגדה אבגדהו בגדהו גדהו דהו הו ו")]
        [TestCase(2, true, " אב אבג אבגד אבגדה אבגדהו בגדהו גדהו דהו הו ")]
        [TestCase(3, true, "  אבג אבגד אבגדה אבגדהו בגדהו גדהו דהו  ")]
        [TestCase(4, true, "   אבגד אבגדה אבגדהו בגדהו גדהו   ")]
        [TestCase(5, true, "    אבגדה אבגדהו בגדהו    ")]
        [TestCase(6, true, "     אבגדהו     ")]
        [TestCase(7, true, "          ")]
        [TestCase(8, true, "          ")]
        public void ConvertString(int minFileLenght, bool removePunctuationMarks, string expectedResult)
        {
            // Arrange
            EditedFile editedFile = new EditedFile()
            {
                InputName = "InputName",
                OutputName = "OutputName",
                MinFileLenght = minFileLenght,
                RemovePunctuationMarks = removePunctuationMarks
            };
            StringEditor stringEditor = new StringEditor(editedFile);
            // Act
            var result = stringEditor.Convert(_text);
            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }
        [Test]
        [TestCase(0, false)]
        [TestCase(1, false)]
        [TestCase(2, false)]
        [TestCase(0, true)]
        [TestCase(1, true)]
        [TestCase(2, true)]
        public void ConvertEmptyString(int minFileLenght, bool removePunctuationMarks)
        {
            // Arrange
            string expectedResult = "";
            string input = "";
            EditedFile editedFile = new EditedFile()
            {
                InputName = "InputName",
                OutputName = "OutputName",
                MinFileLenght = minFileLenght,
                RemovePunctuationMarks = removePunctuationMarks
            };
            StringEditor stringEditor = new StringEditor(editedFile);
            // Act
            var result = stringEditor.Convert(input);
            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }
    }
}