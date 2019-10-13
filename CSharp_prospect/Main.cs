using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_prospect
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
            Login login = new Login();
            login.MdiParent = this;
            login.StartPosition = FormStartPosition.CenterScreen;
            login.Show();

         

            Form slotForm = new Theremino_SlotViewer.Form1();
            slotForm.MdiParent = this;
            slotForm.StartPosition = FormStartPosition.CenterScreen;
            slotForm.Show();
        }

        private void LoadHAL_Click(object sender, EventArgs e)
        {

        }
    }
}
