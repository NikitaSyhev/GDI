using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GDI
{
    internal class AreaComment
    {
        private string text;
        private Rectangle area;
        public AreaComment(string _text, Rectangle _rectangle)
        {
            this.text = _text;
            this.area = _rectangle;
        }
        public string Text { get { return text; } }
        public Rectangle Area { get { return area; } }
    }
}
