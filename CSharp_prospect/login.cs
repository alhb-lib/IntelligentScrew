﻿using System;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {

            Form HALForm = new Theremino_HAL.Form1();
            HALForm.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
