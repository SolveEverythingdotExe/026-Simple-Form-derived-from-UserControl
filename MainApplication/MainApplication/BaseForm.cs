using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainApplication
{
    public partial class BaseForm : UserControl
    {
        //lets add a property "Caption"
        private string _Caption;
        public string Caption
        {
            get { return _Caption; }
            set
            {
                _Caption = value;

                //lets repaint the panel
                panelCaption.Invalidate();
            }
        }

        public BaseForm()
        {
            InitializeComponent();
        }

        //now lets paint the caption
        private void panelCaption_Paint(object sender, PaintEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.Caption))
            {
                int fontSize = 12;
                //lets calculate the location of the caption to make it center
                int captionXPosition = (this.Width - (int)e.Graphics.MeasureString(this.Caption, new Font(this.Font.Name, fontSize, FontStyle.Bold)).Width) / 2;

                using (SolidBrush brush = new SolidBrush(Color.White))
                    e.Graphics.DrawString(this.Caption, new Font(this.Font.Name, fontSize, FontStyle.Bold), brush, new Point(captionXPosition, 5));
            }
        }
    }
}
