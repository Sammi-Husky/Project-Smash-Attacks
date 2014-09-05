using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Be.Windows.Forms;
using System.IO;

namespace SmashAttacks.src
{
    public partial class HexView : Form
    {
        public byte[] _Data;

        public HexView(byte[] Data)
        {
            this._Data = Data;
            InitializeComponent();
            hexBox1.ByteProvider = new DynamicByteProvider(_Data);
        }
    }
}
