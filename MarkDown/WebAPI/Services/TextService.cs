using MarkDown.Classes;
using MarkDown.Interfaces;

namespace WebAPI.Services
{
    public class TextService
    {
        private readonly IMarkDown _markDown;

        public string RenderText(string text) 
        {
            return _markDown.Render(text);
        }
    }
}
