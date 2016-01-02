using SmashAttacks.Types;
using System;
using System.Windows.Forms;
using System.Linq;

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
        public FormEventList(InfoEvent[] events)
        {
            InitializeComponent();
            iEvents = events;
        }

        //  Form destructor.
        ~FormEventList()
        {

        }

        //  Setup procedure.
        public void Setup()
        {
            lstEvents.DataSource = iEvents;
            lstEvents.DisplayMember = "Name";
            lstEvents.ValueMember = "ID";

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
            txtEventId.Text = lstEvents.SelectedValue.ToString();
        }

        private void txtEventId_TextChanged(object sender, EventArgs e)
        {
            if (txtEventId.Text.Length != 8) return;
            string eventId = txtEventId.Text;

            //  Select the event corresponding to the id input.
            lstEvents.SelectedIndex = -1;
            lstEvents.SelectedIndex = 
                lstEvents.Items.IndexOf(lstEvents.Items.Cast<InfoEvent>().Single(x => x.ID.ToString() == eventId));

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lstEvents.DataSource =
                iEvents.Cast<InfoEvent>().Where(x =>
                x.Name.ToLower().Contains(textBox1.Text.ToLower())).ToArray();
        }
    }
}
