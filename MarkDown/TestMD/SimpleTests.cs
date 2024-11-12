using MarkDown.Classes;

namespace TestMD
{
    public class Tests
    {
        private MD mdProcessor;

        [SetUp]
        public void Setup()
        {
            mdProcessor = new MD();
        }

        [Test]
        public void Render_EmptyInput()
        {
            string markdownText = "";
            string expectedHtml = "";

            string actualHtml = mdProcessor.Render(markdownText);

            Assert.AreEqual(expectedHtml, actualHtml);
        }

        [Test]
        public void Render_Header1()
        {
            string markdownText = "# Заголовок 1";
            string expectedHtml = "<h1>Заголовок 1</h1>";

            string actualHtml = mdProcessor.Render(markdownText);
            Assert.AreEqual(expectedHtml, actualHtml);
        }
        
        [Test]
        public void Render_Header2()
        {
            string markdownText = "## Заголовок 2";
            string expectedHtml = "<h2>Заголовок 2</h2>";

            string actualHtml = mdProcessor.Render(markdownText);
            Assert.AreEqual(expectedHtml, actualHtml);
        }
        [Test]
        public void Render_Header3()
        {
            string markdownText = "### Заголовок 3";
            string expectedHtml = "<h3>Заголовок 3</h3>";

            string actualHtml = mdProcessor.Render(markdownText);
            Assert.AreEqual(expectedHtml, actualHtml);
        }
        [Test]
        public void Render_Header4()
        {
            string markdownText = "#### Заголовок 4";
            string expectedHtml = "<h4>Заголовок 4</h4>";

            string actualHtml = mdProcessor.Render(markdownText);
            Assert.AreEqual(expectedHtml, actualHtml);
        }

        [Test]
        public void Render_Header5()
        {
            string markdownText = "##### Заголовок 5";
            string expectedHtml = "<h5>Заголовок 5</h5>";

            string actualHtml = mdProcessor.Render(markdownText);
            Assert.AreEqual(expectedHtml, actualHtml);
        }
        [Test]
        public void Render_Header6()
        {
            string markdownText = "###### Заголовок 6";
            string expectedHtml = "<h6>Заголовок 6</h6>";

            string actualHtml = mdProcessor.Render(markdownText);
            Assert.AreEqual(expectedHtml, actualHtml);
        }

        [Test]
        public void Render_BoldText()
        {
            string markdownText = "__Жирный текст__";
            string expectedHtml = "<strong>Жирный текст</strong>";

            string actualHtml = mdProcessor.Render(markdownText);

            Assert.AreEqual(expectedHtml, actualHtml);
        }

        [Test]
        public void Render_Text() 
        {
            string markdownText = "# Заголовок __с _разными_ символами__";
            string expectedHtml = "<h1>Заголовок <strong>с <em>разными</em> символами</strong></h1>";

            string actualHtml = mdProcessor.Render(markdownText);

            Assert.AreEqual(expectedHtml, actualHtml);
        }

        [Test]
        public void Render_More_StrongText() 
        {
            string markdownText = "__Жирный текст__ и еще один __Жирный текст__";
            string expectedHtml = "<strong>Жирный текст</strong> и еще один <strong>Жирный текст</strong>";

            string actualHtml = mdProcessor.Render(markdownText);

            Assert.AreEqual(expectedHtml, actualHtml);
        }


        [Test]
        public void Render_More_BoldText()
        {
            string markdownText = "__Жирный _текст и еще один Жирный_ текст__";
            string expectedHtml = "<strong>Жирный <em>текст и еще один Жирный</em> текст</strong>";

            string actualHtml = mdProcessor.Render(markdownText);

            Assert.AreEqual(expectedHtml, actualHtml);
        }

        [Test]
        public void QWE()
        {
            string markdownText = "__Жирный__текст__и еще__";
            string expectedHtml = "<strong>Жирный__текст__и еще__</strong>";

            string actualHtml = mdProcessor.Render(markdownText);

            Assert.AreEqual(expectedHtml, actualHtml);

        }
    }
}