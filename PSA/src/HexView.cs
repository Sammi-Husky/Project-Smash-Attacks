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
using SmashAttacks.src.HexBox.Forms;

namespace SmashAttacks
{
    public partial class HexView : Form
    {
        public byte[] _Data;
        public byte[] _workingSource;
        public bool _dirty;

        public long _address;
        public long _length;

        public HexView(byte[] Data, long address, long length)
        {
            this._Data = Data;
            this._address = address;
            this._length = length;

            _workingSource = new byte[0];
            Array.Resize(ref _workingSource, (int)length);
            Array.Copy(_Data, address, _workingSource, 0, (int)length);

            InitializeComponent();
            hexBox.ByteProvider = new DynamicByteProvider(_workingSource);
        }

        private void gotoAdressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GotoDialog dlg = new GotoDialog();
            DialogResult result = dlg.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                if (dlg.radioBegin.Checked)
                    hexBox.ScrollByteIntoView(dlg.offset);
                else if (dlg.radioHere.Checked)
                    hexBox.ScrollByteIntoView(hexBox._bytePos + dlg.offset);
                else if (dlg.radioEnd.Checked)
                    hexBox.ScrollByteIntoView(hexBox.ByteProvider.Length - dlg.offset);
            }
        }

        private void hexBox_CurrentPositionInLineChanged(object sender, EventArgs e)
        {
            statusOffset.Text = "0x" + hexBox._bytePos.ToString("x");
        }
        private void hexBox_SelectionLengthChanged(object sender, EventArgs e)
        {
            statusSelLength.Text = "0x" + hexBox.SelectionLength.ToString("x");
        }

        public byte[] ReturnData()
        {
            byte[] data = new byte[hexBox.ByteProvider.Length];
            for (int i = 0; i < hexBox.ByteProvider.Length; i++)
            {
                data[i] = hexBox.ByteProvider.ReadByte(i);
            }
            return data;
        }

        private void HexView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hexBox.ByteProvider.HasChanges())
            {
                DialogResult result = MessageBox.Show("Keep Changes?", "", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes) { _dirty = true; }
                else if (result == DialogResult.No) { _dirty = false; }
                else if (result == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }
    }
}
