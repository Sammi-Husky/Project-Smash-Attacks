using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmashAttacks
{
    public partial class FormModifyEvent : Form
    {
        public DialogResult status; //  Status indicator on return.
        public Event eventData;     //  Event data passed in.
        public FormMain p;          //  Handler for parent form for ease of access.

        Panel[] typeDisp;           //  Accessor array for the different panels.
        InfoParameter paramData;    //  Information for the current event's parameters.

        // --------------------------------------------------- \\
        // ------------------Startup Methods------------------ \\
        // --------------------------------------------------- \\
        //  Form constructor.
        public FormModifyEvent()
        {
            InitializeComponent();
        }

        //  Form destructor.
        ~FormModifyEvent()
        {

        }
        
        //  Setup procedure.
        public void Setup()
        {
            typeDisp = new Panel[]{
                pnlBasic,
                pnlScalar,
                pnlPointer,
                pnlBoolean,
                pnlType4,
                pnlVariable,
                pnlRequirement
            };
               
            //  Setup requirements list.
            if (cboRequirement.Items.Count == 0)
                for (int i = 0; i < p.iRequirements.Length; i++)
                    cboRequirement.Items.Add(p.iRequirements[i]);

            status = DialogResult.Cancel;

            DisplayEvent(eventData);
        }

        // --------------------------------------------------- \\
        // ------------------Form Methods--------------------- \\
        // --------------------------------------------------- \\
        private void FormModifyEvent_Load(object sender, EventArgs e)
        {
            Setup();
        }

        private void FormModifyEvent_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        // --------------------------------------------------- \\
        // -----------------Display Methods------------------- \\
        // --------------------------------------------------- \\
        //  Display the event's name, offset and parameters.
        public void DisplayEvent(Event eventData)
        {
            lstParameters.Items.Clear();
            cboType.SelectedIndex = -1;
            cboType.Text = "";
            cboType.Enabled = false;
            lblParamDescription.Text = "No Description Available.";
            for (int i = 0; i < typeDisp.Length; i++)
                typeDisp[i].Visible = false;

            paramData = p.GetParameterInfo(eventData.eventId);
            lblEventName.Text = p.GetEventInfo(eventData.eventId).name;
            lblEventId.Text = eventData.eventId;
            lblParameterListOffset.Text = "0x" + p.Hex(eventData.pParameters);

            for (int i = 0; i < eventData.lParameters; i++)
                lstParameters.Items.Add(paramData.GetName(i));
        }

        //  Display the selected parameter's value, type and description.
        private void DisplayParameter(int index)
        {
            long paramType = eventData.parameters[index].word1;
            long paramValue = eventData.parameters[index].word2;

            cboType.Enabled = true;
            try { cboType.SelectedIndex = (int)paramType; }
            catch { cboType.SelectedIndex = -1; cboType.Text = "(" + p.Hex(paramType) + ")"; }
            DisplayInType(paramType, paramValue);
            lblParamDescription.Text = paramData.GetDescription(index);
        }

        //  Display the parameter's value according to it's type.
        public void DisplayInType(long type, long value){
            for (int i = 0; i < typeDisp.Length; i++)
                typeDisp[i].Visible = false;
            typeDisp[type].Visible = true; 

            switch(type){
                case 0: ShowBasic(value); break;
                case 1: ShowScalar(value); break;
                case 2: ShowPointer(value); break;
                case 3: ShowBoolean(value); break;
                case 4: ShowType4(value); break;
                case 5: ShowVariable(value); break;
                case 6: ShowRequirement(value); break;
            }
        }

        //  Display the parameter as a basic variable.
        public void ShowBasic(long value)
        {
            txtBasic.Text = p.Hex8(value);
        }

        //  Display the parameter as a scalar variable.
        public void ShowScalar(long value)
        {
            txtScalar.Text = p.UnScalar(value).ToString();
        }

        //  Display the parameter as a pointer.
        public void ShowPointer(long value)
        {
            txtPointer.Text = p.Hex8(value);
        }

        //  Display the parameter as a boolean.
        public void ShowBoolean(long value)
        {
            cboBoolean.SelectedIndex = (value == 0 ? 0 : 1);
        }

        //  Display the parameter as the unknown type 4.
        public void ShowType4(long value)
        {
            txtType4.Text = p.Hex8(value);
        }

        //  Display the parameter as a variable.
        public void ShowVariable(long value)
        {
            int vMemType = (int)(value & 0xF0000000) / 0x10000000;
            int vType = (int)(value & 0xF000000) / 0x1000000;
            int vNumber = (int)value & 0xFFFFFF;
            txtVariableNumber.Text = vNumber.ToString();
            cboVariableMemType.SelectedIndex = vMemType;
            cboVariableType.SelectedIndex = vType;
        }

        //  Display the parameter as a requirement.
        public void ShowRequirement(long value)
        {
            int requirement = (int)value & 0xFF;
            long not = (value & 0xF0000000) / 0x10000000;

            cboRequirement.SelectedIndex = requirement;
            chkNot.Checked = (not == 8 ? true : false);
        }

        // --------------------------------------------------- \\
        // --------------Parameter Control Methods------------ \\
        // --------------------------------------------------- \\
        private void btnChangeEvent_Click(object sender, EventArgs e)
        {
            //  Pass in the event word.
            p.frmEventList.eventWord = eventData.GetEventWord();

            p.frmEventList.ShowDialog();

            //  Retrieve and setup the new event according to the new event word.
            if (p.frmEventList.status == DialogResult.OK)
            {
                eventData.SetEventWord(p.frmEventList.eventWord);
                eventData.parameters.Initialize();
                for (int i = 0; i < eventData.lParameters; i++)
                    eventData.parameters[i].word1 = p.GetEventInfo(eventData.eventId).GetDfltParameter(i);
            }

            DisplayEvent(eventData);
        }

        private void lstParameters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstParameters.SelectedIndex == -1) return;
            int index = lstParameters.SelectedIndex;
            DisplayParameter(index);
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex == -1) return;
            if (lstParameters.SelectedIndex == -1) return;
            int index = lstParameters.SelectedIndex;

            //  Change the type to the type selected and update the view window.
            eventData.parameters[index].word1 = cboType.SelectedIndex;
            DisplayParameter(index);
        }


        private void txtBasic_Leave(object sender, EventArgs e)
        {
            if (lstParameters.SelectedIndex == -1) return;
            int index = lstParameters.SelectedIndex;

            try { eventData.parameters[index].word2 = p.UnHex(txtBasic.Text);}
            catch { eventData.parameters[index].word2 = 0; }
            txtBasic.Text = p.Hex8(eventData.parameters[index].word2); 
        }

        private void txtScalar_Leave(object sender, EventArgs e)
        {
            if (lstParameters.SelectedIndex == -1) return;
            int index = lstParameters.SelectedIndex;

            try { eventData.parameters[index].word2 = p.Scalar(float.Parse(txtScalar.Text)); }
            catch { eventData.parameters[index].word2 = 0; }
            txtScalar.Text = p.UnScalar(eventData.parameters[index].word2).ToString();
        }

        private void txtPointer_Leave(object sender, EventArgs e)
        {
            if (lstParameters.SelectedIndex == -1) return;
            int index = lstParameters.SelectedIndex;

            try { eventData.parameters[index].word2 = p.UnHex(txtPointer.Text); }
            catch { eventData.parameters[index].word2 = 0; }
            txtPointer.Text = p.Hex8(eventData.parameters[index].word2);
        }

        private void cboBoolean_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBoolean.SelectedIndex == -1) return;
            if (lstParameters.SelectedIndex == -1) return;
            int index = lstParameters.SelectedIndex;

            eventData.parameters[index].word2 = cboBoolean.SelectedIndex;
        }

        private void txtType4_Leave(object sender, EventArgs e)
        {
            if (lstParameters.SelectedIndex == -1) return;
            int index = lstParameters.SelectedIndex;

            try { eventData.parameters[index].word2 = p.UnHex(txtType4.Text); }
            catch { eventData.parameters[index].word2 = 0; }
            txtType4.Text = p.Hex8(eventData.parameters[index].word2);
        }

        private void Variable_Handle(object sender, EventArgs e)
        {
            if (cboVariableMemType.SelectedIndex == -1) return;
            if (cboVariableType.SelectedIndex == -1) return;
            if (lstParameters.SelectedIndex == -1) return;
            int index = lstParameters.SelectedIndex;
            long vMemType = cboVariableMemType.SelectedIndex;
            long vType = cboVariableType.SelectedIndex;
            long vNumber;

            try { vNumber = long.Parse(txtVariableNumber.Text); }
            catch { vNumber = 0; }
            txtVariableNumber.Text = vNumber.ToString();

            eventData.parameters[index].word2 = (vMemType * 0x10000000) + (vType * 0x1000000) + (vNumber);
        }

        private void Requirement_Handle(object sender, EventArgs e)
        {
            if (cboRequirement.SelectedIndex == -1) return;
            if (lstParameters.SelectedIndex == -1) return;
            int index = lstParameters.SelectedIndex;
            long value = cboRequirement.SelectedIndex;
            if (chkNot.Checked) value |= 0x80000000;

            eventData.parameters[index].word2 = value;
        }

        // --------------------------------------------------- \\
        // ----------------Form Control Methods--------------- \\
        // --------------------------------------------------- \\
        private void btnCancel_Click(object sender, EventArgs e)
        {
            status = DialogResult.Cancel;
            this.Close();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            status = DialogResult.OK;
            this.Close();
        }
    }
}
