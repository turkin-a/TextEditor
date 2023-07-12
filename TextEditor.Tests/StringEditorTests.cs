namespace TextEditor.Tests
{
    public class StringEditorTests
    {
        private string _text;
        [SetUp]
        public void Setup()
        {
            _text = "� �� ���! ����, �����. ������; �����? ���� ��� �� �";
        }
        [Test]
        [TestCase(0, false, "� �� ���! ����, �����. ������; �����? ���� ��� �� �")]
        [TestCase(1, false, "� �� ���! ����, �����. ������; �����? ���� ��� �� �")]
        [TestCase(2, false, " �� ���! ����, �����. ������; �����? ���� ��� �� ")]
        [TestCase(3, false, "  ���! ����, �����. ������; �����? ���� ���  ")]
        [TestCase(4, false, "  ! ����, �����. ������; �����? ����   ")]
        [TestCase(5, false, "  ! , �����. ������; �����?    ")]
        [TestCase(6, false, "  ! , . ������; ?    ")]
        [TestCase(7, false, "  ! , . ; ?    ")]
        [TestCase(8, false, "  ! , . ; ?    ")]
        [TestCase(0, true, "� �� ��� ���� ����� ������ ����� ���� ��� �� �")]
        [TestCase(1, true, "� �� ��� ���� ����� ������ ����� ���� ��� �� �")]
        [TestCase(2, true, " �� ��� ���� ����� ������ ����� ���� ��� �� ")]
        [TestCase(3, true, "  ��� ���� ����� ������ ����� ���� ���  ")]
        [TestCase(4, true, "   ���� ����� ������ ����� ����   ")]
        [TestCase(5, true, "    ����� ������ �����    ")]
        [TestCase(6, true, "     ������     ")]
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