using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainApplication
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string formName = e.ClickedItem.Text + "Form";

            //we check if there is already an existing instance of the form which is hidden
            //if so, we will just show it
            //we also hide those forms that are showing but not the form we selected
            foreach (Control control in this.Controls)
            {
                if (control is BaseForm)
                {
                    if (control.Name == formName)
                    {
                        control.Show();
                        return;
                    }
                    else
                        control.Hide();
                }
            }

            //lets open an instance of the form
            BaseForm form = Activator.CreateInstance(Type.GetType("MainApplication." + formName)) as BaseForm;

            //lets set the properties before showing the form
            form.Parent = this;
            form.Location = new Point(0, menuStrip.Height);
            form.Size = new Size(this.Width, this.Height - menuStrip.Height);
            form.Show();
        }
        //It works!
    }
}
