using SmashAttacks.Types;
using System;
using System.Windows.Forms;

namespace SmashAttacks
{
    public partial class FormEventList : Form
    {
        public DialogResult status; //  Status indicator on return.
        public long eventWord;      //  Initial event word passed.
        public FormMain p;          //  Handler for parent form for ease of access.

        //  Array containing available events.
        InfoEvent[] iEvents = new InfoEvent[0];


        // --------------------------------------------------- \\
        // ------------------Startup Methods------------------ \\
        // --------------------------------------------------- \\
        //  Form constructor.
        public FormEventList()
        {
            InitializeComponent();
        }

        //  Form destructor.
        ~FormEventList()
        {

        }

        //  Setup procedure.
        public void Setup()
        {
            //  Add each event to the event list, but omit any events lacking a formal name.
            if (lstEvents.Items.Count <= 0)
                for (int i = 0; i < p.iEvents.Length; i++)
                    if (p.iEvents[i].name != p.iEvents[i].idNumber)
                    {
                        int i2 = iEvents.Length;
                        Array.Resize<InfoEvent>(ref iEvents, i2 + 1);
                        iEvents[i2] = p.iEvents[i];
                        lstEvents.Items.Add(p.iEvents[i].name);
                    }

            txtEventId.Text = p.Hex8(eventWord);
            status = DialogResult.Cancel;
        }


        // --------------------------------------------------- \\
        // -------------------Form Methods-------------------- \\
        // --------------------------------------------------- \\
        private void FormEventList_Load(object sender, EventArgs e)
        {
            Setup();
        }

        private void FormEventList_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        // --------------------------------------------------- \\
        // ------------------Control Methods------------------ \\
        // --------------------------------------------------- \\
        private void lstEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEvents.SelectedIndex == -1) return;
            long index = lstEvents.SelectedIndex;

            txtEventId.Text = iEvents[index].idNumber;
        }

        private void txtEventId_TextChanged(object sender, EventArgs e)
        {
            if (txtEventId.Text.Length != 8) return;
            string eventId = txtEventId.Text;

            //  Select the event corresponding to the id input.
            lstEvents.SelectedIndex = -1;
            for (int i = 0; i < iEvents.Length; i++)
                if (eventId == iEvents[i].idNumber)
                { lstEvents.SelectedIndex = i; break; }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            status = DialogResult.Cancel;
            this.Close();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            try { eventWord = p.UnHex(txtEventId.Text); }
            catch { eventWord = 0; }
            if (eventWord == 0)
            {
                MessageBox.Show("Invalid event Id.", "Invalid Id");
                return;
            }

            status = DialogResult.OK;
            this.Close();
        }
    }
}
