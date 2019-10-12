using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Theremino_HAL; 

namespace CSharp_prospect
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form HALForm = new Theremino_HAL.Form1();
            HALForm.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form slotForm = new Theremino_SlotViewer.Form1();
            slotForm.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form singalForm = new Theremino_SignalScope.Form1();
            singalForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            float slotValue = float.Parse( this.slotValue.Text);
            MessageBox.Show(slotValue.ToString());
            thereminoSlots.WriteSlot(1, slotValue);  
        }
    }
}
 