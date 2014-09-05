using SmashAttacks.Types;
using System;
using System.Windows.Forms;

namespace SmashAttacks
{
    public partial class FormAnimationFlags : Form
    {
        public DialogResult status;         //  Status indicator on return.
        public Bitset flags = new Bitset(); //  Animation flags.
        public byte inTransitionTime;       //  In transition time.
        public FormMain p;                  //  Handler for parent form for ease of access.

        //  Array accessor for each check box.
        CheckBox[] chkFlags;


        // --------------------------------------------------- \\
        // ------------------Startup Methods------------------ \\
        // --------------------------------------------------- \\
        //  Form constructor.
        public FormAnimationFlags()
        {
            InitializeComponent();
        }

        //  Form destructor.
        ~FormAnimationFlags()
        {

        }

        //  Setup procedure.
        public void Setup()
        {
            chkFlags = new CheckBox[]{
                chkNoOutTransition,
                chkLoop,
                chkMovesCharacter,
                chkFixedTranslation,
                chkFixedRotation,
                chkFixedScale,
                chkTransitionOutFromStart,
                chkUnknown4};

            status = DialogResult.Cancel;
        }

        // --------------------------------------------------- \\
        // ------------------Form Methods--------------------- \\
        // --------------------------------------------------- \\
        private void FormAnimationFlags_Load(object sender, EventArgs e)
        {
            Setup();

            txtInTransitionTime.Text = inTransitionTime.ToString();
            for (int i = 0; i < 8; i++) chkFlags[i].Checked = flags.GetBit(i);
        }

        private void FormAnimationFlags_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        // --------------------------------------------------- \\
        // -----------------Control Methods------------------- \\
        // --------------------------------------------------- \\
        private void txtInTransitionTime_Leave(object sender, EventArgs e)
        {
            try { inTransitionTime = byte.Parse(txtInTransitionTime.Text); }
            catch { txtInTransitionTime.Text = inTransitionTime.ToString(); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            status = DialogResult.Cancel;
            this.Close();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++) flags.SetBit(i, chkFlags[i].Checked);
            inTransitionTime = byte.Parse(txtInTransitionTime.Text);

            status = DialogResult.OK;
            this.Close();
        }
    }
}
