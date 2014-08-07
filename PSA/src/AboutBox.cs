using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmashAttacks
{
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        private void AboutBox_Load(object sender, EventArgs e)
        {
            lblGNULicense.Text += "Smash Attacks: Super Smash Bros Brawl moveset editor.";

            lblGNULicense.Text += "\n\nThis program is free software: you can redistribute it and/or modify";
            lblGNULicense.Text += "\nit under the terms of the GNU General Public License as published by";
            lblGNULicense.Text += "\nthe Free Software Foundation, either version 3 of the License, or";
            lblGNULicense.Text += "\n(at your option) any later version.";

            lblGNULicense.Text += "\n\nThis program is distributed in the hope that it will be useful,";
            lblGNULicense.Text += "\nbut WITHOUT ANY WARRANTY; without even the implied warranty of";
            lblGNULicense.Text += "\nMERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the";
            lblGNULicense.Text += "\nGNU General Public License for more details at:";
            lblGNULicense.Text += "\nhttp://www.gnu.org/licenses.";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
