/*  Smash Attacks: Super Smash Bros Brawl moveset editor.
    Copyright (C) 2009  Phantom Wings

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details at:
    http://www.gnu.org/licenses.
*/

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
    public partial class FormMain : Form
    {
        //  Defined Constants.
        const long FADEDATA = 0xFADE0D8A;     //  Constant for the tag FADE0D8A representing the end of useable space.
        const long FADEFOOD = 0xFADEF00D;     //  Constant for the tag FADEF00D representing empty, useable space.
        const long S_WORD = 0x4;             //  Constant for the size of a Word.
        const long S_BLOCK = 0x8;            //  Constant for the size of a Block.
        const long B_WORD2 = 0x4;            //  Constant used for offsetting to the second word in a block.

        //  Classes for containing descriptions and information on the various parameters.
        public InfoAttribute[] iAttributes = new InfoAttribute[0];
        public InfoEvent[] iEvents = new InfoEvent[0];
        public InfoParameter[] iParameters = new InfoParameter[0];
        public InfoEventSyntax[] iEventSyntax = new InfoEventSyntax[0];
        public string[] iRequirements = new string[0];
        public string[] iAirGroundStats = new string[0];
        public string[] iCollisionStats = new string[0];

        //  Name of currently opened file.
        public string fname = "";
        public string sname = "";

        //  Byte arrays to contain the different segments of the file.
        public byte[] fileHeader = null;
        public byte[] partitionHeader = null;
        public byte[] dataHeader = null;
        public byte[] movesetData = null;
        public byte[] pointerList = null;
        public byte[] objectPointerList = null;
        public byte[] nameList = null;
        public byte[] partitionHeader2 = null;
        public byte[] effectPartition = null;


        //  Variables containing pointers to various pieces of data.
        long pAnimations = 0;               //  Pointer to the Animation List.
        long pAttributes = 0;               //  Pointer to the Attribute List.
        long pBEvents = 0;                  //  Pointer to the B Move Events List.
        long lBEvents = 0;                  //  Length of the B Move Events List.
        long[] pSubEvents = new long[4];    //  4 Pointers to the 4 Sub Event Lists.
        long lSubEvents = 0;                //  Length of the Sub Events List.

        long pAnimationData = 0;            //  Pointer to the current Animation.
        long ipEventData = 0;               //  Index pointer to the current Event List.
        long pEventData = 0;                //  Pointer to the current Event List.

        long pFadeData = 0;                 //  Pointer to the start of useable space in the file.

        //  Variables containing short term stored data.
        Event[] eventData = new Event[0];
        Event[] copyBuffer = new Event[0];
        int Ftype = 0;

        //  Data table for the attributes data grid.
        DataTable attributes = new DataTable();

        //  Handlers for the additional input forms.
        public FormModifyEvent frmModifyEvent = new FormModifyEvent();
        public FormEventList frmEventList = new FormEventList();
        public FormAnimationFlags frmAnimFlags = new FormAnimationFlags();

        public AboutBox frmAbout = new AboutBox();

        // --------------------------------------------------- \\
        // ------------------Startup Methods------------------ \\
        // --------------------------------------------------- \\
        //  Form constructor.
        public FormMain()
        {
            InitializeComponent();
        }

        //  From destructor.
        ~FormMain()
        {
            attributes.Dispose();
            frmModifyEvent.Dispose();
            frmEventList.Dispose();
            frmAnimFlags.Dispose();
            frmAbout.Dispose();
        }

        //  Standard setup procedure upon starting up.
        public void Setup()
        {
            StreamReader sr = null;

            //  Read known attributes and their descriptions.
            try { sr = new StreamReader(Application.StartupPath + "/Data/Attributes.txt"); }
            catch { MessageBox.Show("File Attributes.txt not found."); }
            if (sr != null)
            {
                for (int i = 0; !sr.EndOfStream && i <= FromWord(0x2E0); i++)
                {
                    Array.Resize<InfoAttribute>(ref iAttributes, i + 1);
                    iAttributes[i] = new InfoAttribute();
                    iAttributes[i].name = sr.ReadLine();
                    iAttributes[i].description = sr.ReadLine();
                    iAttributes[i].type = long.Parse(sr.ReadLine());
                    if (iAttributes[i].description == "")
                        iAttributes[i].description = "No Description Available.";

                    sr.ReadLine();
                    Graphics g = this.CreateGraphics();
                    Rectangle rect = new Rectangle(10, 10, 150, 150);
                    PaintEventArgs e = new PaintEventArgs(g,rect);
                    e.Graphics.DrawRectangle(Pens.Red, rect);
                    
                }
                sr.Close();
                sr = null;
            }

            //  Read known events and their descriptions.
            try { sr = new StreamReader(Application.StartupPath + "/Data/Events.txt"); }
            catch { MessageBox.Show("File Events.txt not found."); }
            if (sr != null)
            {
                for (int i = 0; !sr.EndOfStream; i++)
                {
                    Array.Resize<InfoEvent>(ref iEvents, i + 1);
                    iEvents[i] = new InfoEvent();
                    iEvents[i].idNumber = sr.ReadLine();
                    iEvents[i].name = sr.ReadLine();
                    iEvents[i].description = sr.ReadLine();
                    iEvents[i].SetDfltParameters(sr.ReadLine());
                    sr.ReadLine();
                }
                sr.Close();
                sr = null;
            }

            //  Read known parameters and their descriptions.
            try { sr = new StreamReader(Application.StartupPath + "/Data/Parameters.txt"); }
            catch { MessageBox.Show("File Parameters.txt not found."); }
            if (sr != null)
            {
                for (int i = 0; !sr.EndOfStream; i++)
                {
                    Array.Resize<InfoParameter>(ref iParameters, i + 1);
                    iParameters[i] = new InfoParameter();
                    iParameters[i].idNumber = sr.ReadLine();

                    for (int i2 = 0; ; i2++)
                    {
                        string name = sr.ReadLine();
                        if (name == null) name = "";

                        if (name != "")
                        {
                            Array.Resize<string>(ref iParameters[i].name, i2 + 1);
                            Array.Resize<string>(ref iParameters[i].description, i2 + 1);
                            iParameters[i].name[i2] = name;
                            iParameters[i].description[i2] = sr.ReadLine();
                        }
                        if (name == "")
                            break;
                    }

                }
                sr.Close();
                sr = null;
            }

            //  Read the list containing the syntax to display each event with.
            try { sr = new StreamReader(Application.StartupPath + "/Data/EventSyntax.txt"); }
            catch { MessageBox.Show("File EventSyntax.txt not found."); }
            if (sr != null)
            {
                for (int i = 0; !sr.EndOfStream; i++)
                {
                    string syntax = "";
                    Array.Resize(ref iEventSyntax, i + 1);
                    iEventSyntax[i] = new InfoEventSyntax();
                    iEventSyntax[i].idNumber = sr.ReadLine();
                    syntax = sr.ReadLine();
                    while (syntax != "" && syntax != null)
                    {
                        iEventSyntax[i].syntax += syntax;
                        syntax = sr.ReadLine();
                    }
                }
                sr.Close();
                sr = null;
            }

            //  Read the list of Event Requirements.
            try { sr = new StreamReader(Application.StartupPath + "/Data/Requirements.txt"); }
            catch { MessageBox.Show("File Attributes.txt not found."); }
            if (sr != null)
            {
                for (int i = 0; !sr.EndOfStream; i++)
                {
                    Array.Resize<string>(ref iRequirements, i + 1);
                    iRequirements[i] = sr.ReadLine();
                }
                sr.Close();
                sr = null;
            }

            // Read the list of Air Ground Stats.
            try { sr = new StreamReader(Application.StartupPath + "/Data/AirGroundStats.txt"); }
            catch { MessageBox.Show("File AirGroundStats.txt not found."); }
            if (sr != null)
            {
                for (int i = 0; !sr.EndOfStream; i++)
                {
                    Array.Resize<string>(ref iAirGroundStats, i + 1);
                    iAirGroundStats[i] = sr.ReadLine();
                }
                sr.Close();
                sr = null;
            }

            // Read the list of Collision Stats.
            try { sr = new StreamReader(Application.StartupPath + "/Data/CollisionStats.txt"); }
            catch { MessageBox.Show("File CollisionStats.txt not found."); }
            if (sr != null)
            {
                for (int i = 0; !sr.EndOfStream; i++)
                {
                    Array.Resize<string>(ref iCollisionStats, i + 1);
                    iCollisionStats[i] = sr.ReadLine();
                }
                sr.Close();
                sr = null;
            }

            //  Setup Attribute Table.
            attributes.Columns.Add("Name");
            attributes.Columns.Add("Value");
            attributes.Columns[0].ReadOnly = true;
            dtgrdAttributes.DataSource = attributes;

            for (int i = 0; i <= FromWord(0x2E0); i++)
            {
                if (i < iAttributes.Length) { attributes.Rows.Add(iAttributes[i].name); }
                else { attributes.Rows.Add("0x" + Hex(ToWord(i))); }
            }

            //  For ease of access, each form contains a reference to the main form in order
            //  to use the methods and variables in the main form.
            frmModifyEvent.p = this;
            frmEventList.p = this;
            frmAnimFlags.p = this;
        }

        // --------------------------------------------------- \\
        // ----------------Format Methods--------------------- \\
        // --------------------------------------------------- \\

        //  Crop the passed string down to the specified length.
        public string TruncateLeft(string strIn, int totalWidth)
        {
            if (totalWidth <= 0) return "";
            if (totalWidth > strIn.Length) return strIn;
            return strIn.Substring(strIn.Length - totalWidth);
        }

        //  Conversion to and from words (1 word = 4 bytes) for ease of programming.
        public long ToWord(long val) { return val * S_WORD; }
        public long FromWord(long val) { return val / S_WORD; }
        public long ToBlock(long val) { return val * S_BLOCK; }
        public long FromBlock(long val) { return val / S_BLOCK; }
        public long FromWordRU(long val) { return FromWord(RoundUp(val, S_WORD)); }
        public long FromWordRD(long val) { return FromWord(RoundDown(val, S_WORD)); }
        public long FromBlockRU(long val) { return FromBlock(RoundUp(val, S_BLOCK)); }
        public long FromBlockRD(long val) { return FromBlock(RoundDown(val, S_BLOCK)); }

        //  Conversion to and from hexadecimal with the option to automatically pad to 8 digits.
        public string Hex(int val) { return TruncateLeft(val.ToString("X"), 8); }
        public string Hex(long val) { return TruncateLeft(val.ToString("X"), 8); }
        public string Hex8(int val) { return TruncateLeft(val.ToString("X"), 8).PadLeft(8, '0'); }
        public string Hex8(long val) { return TruncateLeft(val.ToString("X"), 8).PadLeft(8, '0'); }
        public int UnHex(string val) { return int.Parse(val, System.Globalization.NumberStyles.HexNumber); }

        //  Method for retrieval of a halfword that is part of a word.
        public string WordH(string val, int wordNum)
        {
            if (wordNum >= 2) return "";
            return TruncateLeft(val, 8).PadLeft(8, '0').Substring(wordNum * 4, 4);
        }

        //  Method for retrieval of a byte that is part of a word.
        public string WordB(string val, int byteNum)
        {
            if (byteNum >= 4) return "";
            return TruncateLeft(val, 8).PadLeft(8, '0').Substring(byteNum * 2, 2);
        }

        //  Conversion from and to floating point methods.
        public long Float(float val)
        {
            if (val == 0) return 0;
            long sign = (val >= 0 ? 0 : 8);
            long exponent = 0x7F;
            float mantissa = Math.Abs(val);

            if (mantissa > 1)
                while (mantissa > 2)
                { mantissa /= 2; exponent++; }
            else
                while (mantissa < 1)
                { mantissa *= 2; exponent--; }
            mantissa -= 1;
            mantissa *= (float)Math.Pow(2, 23);

            return (
                  sign * 0x10000000
                + exponent * 0x800000
                + (long)mantissa);
        }
        public float UnFloat(long val)
        {
            if (val == 0) return 0;
            float sign = ((val & 0x80000000) == 0 ? 1 : -1);
            int exponent = ((int)(val & 0x7F800000) / 0x800000) - 0x7F;
            float mantissa = (val & 0x7FFFFF);
            long mantissaBits = 23;

            if (mantissa != 0)
                while (((long)mantissa & 0x1) != 1)
                { mantissa /= 2; mantissaBits--; }
            mantissa /= (float)Math.Pow(2, mantissaBits);
            mantissa += 1;

            mantissa *= (float)Math.Pow(2, exponent);
            return mantissa *= sign;
        }

        //  Conversion from and to scalar methods.
        public long Scalar(float val) { float fVal = (val * 60000); return (long)fVal; }
        public float UnScalar(float val) { return val / 60000; }

        //  Rounding up and down operations.
        public long RoundUp(long val, long factor) { return val + (factor - 1) - (val + (factor - 1)) % factor; }
        public long RoundDown(long val, long factor) { return val - val % factor; }

        //  Find the first occuring instance of the passed character.
        public int FindFirst(string str, int begin, char chr)
        {
            for (int i = begin; i < str.Length; i++)
                if (str[i] == chr) return i;

            return -1;
        }

        //  Find the first occuring instance of any of the passed characters.
        public int FindFirstOf(string str, int begin, char[] chr, ref char chrFound)
        {
            int result = -1;
            chrFound = '\0';
            for (int i = 0; i < chr.Length; i++)
            {
                int temp = FindFirst(str, begin, chr[i]);

                if (temp != -1 && (temp < result || result == -1))
                {
                    result = temp;
                    chrFound = chr[i];
                }
            }
            return result;
        }

        //  FindFist ignoring any pairs of () and anything contained inside.
        public int FindFirstIgnoreNest(string str, int begin, char chr)
        {
            if (chr == '(') return FindFirst(str, begin, chr);
            char[] searchCharacters = { chr, '(', ')' };
            char chrResult = '\0';
            int searchResult = begin;
            int nested = 0;

            do
            {
                if (chrResult == ')' && nested > 0) nested--;
                searchResult = FindFirstOf(str, searchResult, searchCharacters, ref chrResult);
                if (chrResult == '(') nested++;
                searchResult++;
            } while ((nested > 0 || chrResult != chr) && chrResult != '\0');
            searchResult--;

            return searchResult;
        }

        //  FindFirstOf ignoring any paris of () and anything contained inside.
        public int FindFirstOfIgnoreNest(string str, int begin, char[] chr, ref char chrFound)
        {
            int result = -1;
            chrFound = '\0';
            for (int i = 0; i < chr.Length; i++)
            {
                int temp = FindFirstIgnoreNest(str, begin, chr[i]);

                if (temp != -1 && (temp < result || result == -1))
                {
                    result = temp;
                    chrFound = chr[i];
                }
            }
            return result;
        }

        //  Find the first instance that is not the character passed.
        public int FindFirstNot(string str, int begin, char chr)
        {
            for (int i = begin; i < str.Length; i++)
                if (str[i] != chr) return i;

            return -1;
        }

        //  Return the string passed with the new string insterted into the specified position.
        public string InsString(string str, string insString, int begin)
        {
            return str.Substring(0, begin) + insString + str.Substring(begin);
        }

        //  Return the string passed minus the substring specified.
        public string DelSubstring(string str, int begin, int len)
        {
            return str.Substring(0, begin) + str.Substring(begin + len);
        }

        //  Delete any whitespace before and after the string.
        public string ClearWhiteSpace(string str)
        {
            int whiteSpace = FindFirstNot(str, 0, ' ');
            if (whiteSpace > 0)
                str = DelSubstring(str, 0, whiteSpace);

            whiteSpace = -1;
            for (int i = str.Length - 1; i >= 0; i--)
                if (str[i] == ' ') whiteSpace = i;
                else break;
            if (whiteSpace != -1)
                str = DelSubstring(str, whiteSpace, str.Length - whiteSpace);

            return str;
        }
        // --------------------------------------------------- \\
        // ------------------Syntax Methods------------------- \\
        // --------------------------------------------------- \\

        //  Return the name and description corresponding to the event id passed.
        public InfoEvent GetEventInfo(string id)
        {
            for (int i = 0; i < iEvents.Length; i++)
                if (id == iEvents[i].idNumber) return (iEvents[i]);

            return new InfoEvent("DEAD", id, "No Description Available.");
        }

        //  Return the parameter information corresponding to the id passed.
        public InfoParameter GetParameterInfo(string id)
        {
            for (int i = 0; ; i++)
            {
                if (i >= iParameters.Length) return new InfoParameter();
                if (id == iParameters[i].idNumber) return (iParameters[i]);
            }
        }

        //  Return the event syntax corresponding to the event id passed
        public string GetEventSyntax(string id)
        {
            for (int i = 0; i < iEventSyntax.Length; i++)
                if (id == iEventSyntax[i].idNumber) return iEventSyntax[i].syntax;

            return "";
        }

        //  Return a string of the parameter in the format corresponding to it's type.
        public string[] ResolveParamTypes(Event eventData)
        {
            string[] p = new string[eventData.parameters.Length];

            for (int i = 0; i < p.Length; i++)
            {
                switch (eventData.parameters[i].word1)
                {
                    case 0: p[i] = Hex(eventData.parameters[i].word2); break;
                    case 1: p[i] = UnScalar(eventData.parameters[i].word2).ToString(); break;
                    case 2: p[i] = ResolvePointer(eventData.pParameters + ToBlock(i) + B_WORD2, eventData.parameters[i]); break;
                    case 3: p[i] = (eventData.parameters[i].word2 != 0 ? "true" : "false"); break;
                    case 4: p[i] = Hex(eventData.parameters[i].word2); break;
                    case 5: p[i] = ResolveVariable(eventData.parameters[i].word2); break;
                    case 6: p[i] = GetRequirement(eventData.parameters[i].word2); break;
                }
            }
            return p;
        }

        //  Return the name of the external pointer corresponding to the address if 
        //  one is available, otherwise return the string of the value passed.
        public string ResolvePointer(long pointer, Block parameter)
        {
            if (GetByte(pointerList, pointer) == 2)
            {
                long nPointer = GetWord(pointerList, pointer) & 0xFFFFFF;
                return "External: name=" + GetString(nameList, nPointer);
            }

            return "0x" + Hex8(parameter.word2);
        }

        //  Return the full name of the variable corresponding to the value passed.
        public string ResolveVariable(long value)
        {
            string variableName = "";
            long variableMemType = (value & 0xF0000000) / 0x10000000;
            long variableType = (value & 0xF000000) / 0x1000000;
            long variableNumber = (value & 0xFF);
            if (variableMemType == 0) variableName = "IC-";
            if (variableMemType == 1) variableName = "LA-";
            if (variableMemType == 2) variableName = "RA-";
            if (variableType == 0) variableName += "Basic";
            if (variableType == 1) variableName += "Float";
            if (variableType == 2) variableName += "Bit";
            variableName += "[" + variableNumber + "]";

            return variableName;

        }

        //  Return a comparrison sign corresponding to the value passed.
        public string GetComparrisonSign(long value)
        {

            switch (value)
            {
                case 0: return "<";
                case 1: return "<=";
                case 2: return "==";
                case 3: return "!=";
                case 4: return ">=";
                case 5: return ">";
                default: return "(" + value + ")";
            }
        }

        //  Return the requirement corresponding to the value passed.
        public string GetRequirement(long value)
        {
            bool not = (value & 0x80000000) == 0x80000000;
            long requirement = value & 0xFF;

            if (requirement > iRequirements.Length)
                return Hex(requirement);

            if (not == true)
                return "Not " + iRequirements[requirement];

            return iRequirements[requirement];
        }

        //  Return the collision status corresponding to the value passed.
        public string GetCollisionStatus(long value)
        {
            if (value > iCollisionStats.Length)
                return "Undefined(" + value + ")";

            return iCollisionStats[value];
        }

        //  Return the air or ground status corresponding to the value passed.
        public string GetAirGroundStatus(long value)
        {
            if (value > iAirGroundStats.Length)
                return "Undefined(" + value + ")";

            return iAirGroundStats[value];
        }



        //  Return the passed syntax with all keywords replaced with their proper values.
        public string ResolveEventSyntax(string syntax, Event eventData)
        {
            while (true)
            {
                string keyword = "";
                string keyResult = "";
                string strParams = "";
                string[] kParams;
                int keyBegin = FindFirst(syntax, 0, '\\');
                if (keyBegin == -1) break;
                int keyEnd = FindFirst(syntax, keyBegin, '(');
                if (keyEnd == -1) keyEnd = syntax.Length;
                int paramsBegin = keyEnd + 1;
                int paramsEnd = FindFirstIgnoreNest(syntax, paramsBegin, ')');
                if (paramsEnd == -1) paramsEnd = syntax.Length;

                keyword = syntax.Substring(keyBegin, keyEnd - keyBegin);
                strParams = syntax.Substring(paramsBegin, paramsEnd - paramsBegin);
                kParams = GetParameters(strParams, eventData);
                keyResult = ResolveKeyword(keyword, kParams, eventData);
                syntax = DelSubstring(syntax, keyBegin, (paramsEnd + 1) - keyBegin);
                syntax = InsString(syntax, keyResult, keyBegin);
            }

            return syntax;
        }

        //  Return the parameters contained in the keyword's parameter list.
        public string[] GetParameters(string strParams, Event eventData)
        {
            string[] parameters = new string[0];
            char chrFound = '\0';
            int paramEnd = -1;
            int index = 0;
            int loc = 0;

            //  Search for a ',' or a ')' and return the preceeding string.
            do
            {
                paramEnd = FindFirstOfIgnoreNest(strParams, loc, new char[] { ',', ')' }, ref chrFound);
                if (paramEnd == -1) paramEnd = strParams.Length;

                Array.Resize<string>(ref parameters, index + 1);
                parameters[index] = strParams.Substring(loc, paramEnd - loc);
                parameters[index] = ClearWhiteSpace(parameters[index]);

                loc = paramEnd + 1;
                index++;
            } while (chrFound != ')' && chrFound != '\0');

            //  Check each parameter for keywords and resolve if they are present.
            for (int i = 0; i < parameters.Length; i++)
                if (parameters[i] != "") parameters[i] = ResolveEventSyntax(parameters[i], eventData);

            return parameters;
        }

        //  Return the string result from the passed keyword and it`s parameters.
        public string ResolveKeyword(string keyword, string[] Params, Event eventData)
        {
            switch (keyword)
            {
                case "\\value":
                    try { return ResolveParamTypes(eventData)[int.Parse(Params[0])]; }
                    catch { return "Value-" + Params[0]; }
                case "\\type":
                    try { return eventData.parameters[int.Parse(Params[0])].word1.ToString(); }
                    catch { return "Type-" + Params[0]; }
                case "\\if":
                    bool compare = false;

                    try
                    {
                        switch (Params[1])
                        {
                            case "==": compare = int.Parse(Params[0]) == int.Parse(Params[2]); break;
                            case "!=": compare = int.Parse(Params[0]) != int.Parse(Params[2]); break;
                            case ">=": compare = int.Parse(Params[0]) >= int.Parse(Params[2]); break;
                            case "<=": compare = int.Parse(Params[0]) <= int.Parse(Params[2]); break;
                            case ">": compare = int.Parse(Params[0]) > int.Parse(Params[2]); break;
                            case "<": compare = int.Parse(Params[0]) < int.Parse(Params[2]); break;
                        }
                    }
                    finally { }

                    if (compare) return Params[3];
                    else return Params[4];
                case "\\unhex":
                    try { return UnHex(Params[0]).ToString(); }
                    catch { return Params[0]; }
                case "\\hex":
                    try { return Hex(int.Parse(Params[0])); }
                    catch { return Params[0]; }
                case "\\hex8":
                    try { return Hex8(int.Parse(Params[0])); }
                    catch { return Params[0]; }
                case "\\half1":
                    return WordH(Params[0], 0);
                case "\\half2":
                    return WordH(Params[0], 1);
                case "\\byte1":
                    return WordB(Params[0], 0);
                case "\\byte2":
                    return WordB(Params[0], 1);
                case "\\byte3":
                    return WordB(Params[0], 2);
                case "\\byte4":
                    return WordB(Params[0], 3);
                case "\\collision":
                    try { return GetCollisionStatus(UnHex(Params[0])); }
                    catch { return Params[0]; }
                case "\\airground":
                    try { return GetAirGroundStatus(UnHex(Params[0])); }
                    catch { return Params[0]; }
                case "\\cmpsign":
                    try { return GetComparrisonSign(UnHex(Params[0])); }
                    catch { return Params[0]; }
                case "\\name":
                    return GetEventInfo(eventData.eventId).name;
                case "\\white":
                    return " ";
                default:
                    return "";
            }
        }

        //  Return the event name followed by each parameter paired with it's type.
        public string GetDefaultSyntax(Event eventData)
        {
            string script = GetEventInfo(eventData.eventId).name + ": ";
            for (int i = 0; i < eventData.lParameters; i++)
                script += Hex(eventData.parameters[i].word1) + "-" + Hex(eventData.parameters[i].word2) + ", ";

            return script;
        }



        //  Construct the scirpt for the events to be displayed in the windows.
        public string[] MakeScript(Event[] events)
        {
            string[] script = new string[events.Length];
            long tabs = 0;

            for (int i = 0; i < events.Length; i++)
            {
                //  Format the event and it's parameters into readable script.
                string syntax = GetEventSyntax(events[i].eventId);
                script[i] = ResolveEventSyntax(syntax, events[i]);
                if (script[i] == "") script[i] = GetDefaultSyntax(events[i]);

                //  Add tabs to the script in correspondence to the code blocks.
                tabs -= TabDownEvents(events[i].eventId);
                for (int i2 = 0; i2 < tabs; i2++) script[i] = "\t" + script[i];
                tabs += TabUpEvents(events[i].eventId);
            }
            return script;
        }

        //  Handler for specific events covering the start of a code block.
        public long TabUpEvents(string eventId)
        {
            switch (eventId)
            {
                case "00040100":
                case "000A0100":
                case "000A0200":
                case "000A0400":
                case "000E0000":
                case "00100200":
                case "00110100":
                case "00120000":
                    return 1;
                default:
                    return 0;
            }
        }

        //  Handler for specific events covering the end of a code block.
        public long TabDownEvents(string eventId)
        {
            switch (eventId)
            {
                case "00050000":
                case "000E0000":
                case "000F0000":
                case "00110100":
                case "00120000":
                case "00130000":
                    return 1;
                default:
                    return 0;
            }
        }



        //  Default values for each special.
        public string ResolveSpecials(long id)
        {
            switch (id)
            {
                case 0x112: return Hex(id) + " Neutral B";
                case 0x113: return Hex(id) + " Side B";
                case 0x114: return Hex(id) + " Up B";
                case 0x115: return Hex(id) + " Down B";
                case 0x116: return Hex(id) + " Final Smash";
                default: return Hex(id);
            }
        }

        // --------------------------------------------------- \\
        // --------------Data Handling Methods---------------- \\
        // --------------------------------------------------- \\

        //  Retrieve a byte from the moveset data.
        public long GetByte(long offset)
        {
            return GetByte(movesetData, offset);
        }

        //  Retrieve a byte from the specified array of bytes.
        public long GetByte(byte[] data, long offset)
        {
            if (offset >= data.Length) throw new Exception("Offset out of range.");
            return data[offset];
        }

        //  Retrieve a word from the moveset data.
        public long GetWord(long offset)
        {
            return GetWord(movesetData, offset);
        }

        //  Retrieve a word from the specified array of bytes.
        public long GetWord(byte[] data, long offset)
        {
            if (offset % 4 != 0) throw new Exception("Odd word offset");
            if (offset >= data.Length) throw new Exception("Offset out of range.");

            return (uint)(data[offset + 0] * 0x1000000)
                 + (uint)(data[offset + 1] * 0x10000)
                 + (uint)(data[offset + 2] * 0x100)
                 + (uint)(data[offset + 3] * 0x1);
        }

        //  Set a byte into the moveset data.
        public void SetByte(byte value, long offset)
        {
            SetByte(ref movesetData, value, offset);
        }

        //  Set a byte into the specified array of bytes. Resize the array if needed.
        public void SetByte(ref byte[] data, byte value, long offset)
        {
            if (offset >= data.Length)
            {
                Array.Resize<byte>(ref data, (int)offset);
                Array.Resize<byte>(ref pointerList, (int)offset);
            }
            data[offset] = value;
        }

        //  Set a word into the moveset data.
        public void SetWord(long value, long offset)
        {
            SetWord(ref movesetData, value, offset);
        }

        //  Set a word into an array of bytes. Resize the array if needed.
        public void SetWord(ref byte[] data, long value, long offset)
        {
            if (offset % 4 != 0) throw new Exception("Odd word offset");
            if (offset >= data.Length)
            {
                Array.Resize<byte>(ref data, (int)offset + 4);
                Array.Resize<byte>(ref pointerList, (int)offset);
            }

            data[offset + 0] = (byte)((value & 0xFF000000) / 0x1000000);
            data[offset + 1] = (byte)((value & 0xFF0000) / 0x10000);
            data[offset + 2] = (byte)((value & 0xFF00) / 0x100);
            data[offset + 3] = (byte)((value & 0xFF) / 0x1);
        }

        //  Retrieve a string from the moveset data.
        public string GetString(long offset)
        {
            return GetString(movesetData, offset);
        }

        //  Retrieve a string from the specified array of bytes.
        public string GetString(byte[] data, long offset)
        {
            string sString = "";
            while (data[offset] != 0)
            {
                sString += (char)data[offset];
                offset++;
            }
            return sString;
        }

        //  Set a string into the moveset data.
        public void SetString(string str, long offset)
        {
            SetString(ref movesetData, str, offset);
        }

        //  Set a string into the specified array of bytes.
        public void SetString(ref byte[] data, string str, long offset)
        {
            if (offset > data.Length) Array.Resize<byte>(ref data, (int)offset);
            for (int i = 0; i < str.Length; i++)
                data[offset + i] = (byte)str[i];

            data[offset + str.Length] = 0x00;
        }

        //  Read a word from a file stream.
        public long ReadWord(FileStream fstream, long offset)
        {
            byte[] bytes = new byte[4];

            fstream.Seek(offset, SeekOrigin.Begin);
            fstream.Read(bytes, 0, bytes.Length);

            return (
                  bytes[0] * 0x1000000
                + bytes[1] * 0x10000
                + bytes[2] * 0x100
                + bytes[3] * 0x1
                );
        }

        public void WriteWord(FileStream fstream, long value, long offset)
        {
            byte[] bytes = new byte[4];
            bytes[0] = (byte)((value & 0xFF000000) / 0x1000000);
            bytes[1] = (byte)((value & 0xFF0000) / 0x10000);
            bytes[2] = (byte)((value & 0xFF00) / 0x100);
            bytes[3] = (byte)((value & 0xFF) / 0x1);

            fstream.Seek(offset, SeekOrigin.Begin);
            fstream.Write(bytes, 0, bytes.Length);
        }

        //  Read the moveset data from the file specified.
        public bool OpenFile(string fname)
        {
            bool errStatus = false;
            try
            {
                if (UnpackFile(fname) == true)
                    throw (new Exception("Error unpacking file."));

                // Search for "data" node.
                int off = -8;
                bool found = false;
                while (off < objectPointerList.Length &&!found)
                {
                    off += 8;
                    found = GetString(nameList, GetWord(objectPointerList, 0x4 + off)).Substring(0, 4) == "data";
                }
                if (!found)
                    throw (new Exception("Cannot locate file data."));

                //  Get all important pointers.
                long pData  = GetWord(objectPointerList, off);
                pAnimations = GetWord(pData + 0x0); //Pointer - animation table
                pAttributes = GetWord(pData + 0x8); //Pointer - attributes

                //  Set the number of selections for the actions and sub actions lists.
                DataTree.Nodes.Add(new DataNode(sname.Substring(3, sname.Length - 7),DataNode.Type.EventData,pData));
                DataTree.Nodes[0].Nodes.Add(new DataNode("Attributes", DataNode.Type.ValueList, pAttributes));
                ResolveObjects();

                GetActions(pData);
                GetSubactions(pData);

                //  Add attributes to the attribute table.
                for (int i = 0; i <= FromWord(0x2E0); i++)
                {
                    if (i < iAttributes.Length) { attributes.Rows.Add(iAttributes[i].name); }
                    else { attributes.Rows.Add("0x" + Hex(ToWord(i))); }
                    if (iAttributes[i].type == 0)
                        attributes.Rows[i][1] = UnFloat(GetWord(pAttributes + ToWord(i)));
                    else
                        attributes.Rows[i][1] = GetWord(pAttributes + ToWord(i));
                }

                //  Setup the empty space buffer at the end of the moveset data.
                if (GetWord(movesetData.Length - 0x8) != FADEDATA)
                {
                    SetWord(FADEDATA, movesetData.Length);
                    SetWord(movesetData.Length - 4, movesetData.Length);
                }
                pFadeData = GetWord(movesetData.Length - 4);
                GetArticles(pData);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                errStatus = true;
            }

            return errStatus;
        }
        public bool OpenItem(string fname)
        {
            bool errStatus = false;
            try
            {
                if (UnpackFile(fname) == true)
                    throw (new Exception("Error unpacking file."));

                // Search for "data" node.
                int off = -8;
                bool found = false;
                while (off < 8 * 10 && !found)
                {
                    off += 8;
                    found = GetString(nameList, GetWord(objectPointerList, 0x4 + off)).Substring(0, 4) == "anim";
                }
                if (!found)
                    throw (new Exception("Cannot locate file data."));

                //  Get all important pointers.
                long pData = GetWord(objectPointerList, off);

                pAnimations = GetWord(pData + 0x0); //Pointer - animation table
                pAttributes = GetWord(pData + 0x8); //Pointer - attributes

                //  Set the number of selections for the actions and sub actions lists.
                DataTree.Nodes.Add(new DataNode(sname.Substring(3, sname.Length - 7), DataNode.Type.EventData, pData));
                ResolveObjects();

                GetActions(pData);
                GetSubactions(pData);

                //  Add attributes to the attribute table.
                attributes.Rows.Add("0x00");
                iAttributes[0].description = "No description";
                for (int i = 0; i <= FromWord(0x00); i++)
                {
                    if (iAttributes[i].type == 0)
                        attributes.Rows[i][1] = UnFloat(GetWord(pAttributes + ToWord(i)));
                    else
                        attributes.Rows[i][1] = GetWord(pAttributes + ToWord(i));
                }

                //  Setup the empty space buffer at the end of the moveset data.
                if (GetWord(movesetData.Length - 0x8) != FADEDATA)
                {
                    SetWord(FADEDATA, movesetData.Length);
                    SetWord(movesetData.Length - 4, movesetData.Length);
                }
                pFadeData = GetWord(movesetData.Length - 4);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                errStatus = true;
            }

            return errStatus;
        }
        public bool OpenKirbyHat(string fname)
        {
            bool errStatus = false;
            try
            {
                if (UnpackFile(fname) == true)
                    throw (new Exception("Error unpacking file."));
                // Search for "data" node.
                int off = -8;
                bool found = false;
                while (off < 8 * 10 && !found)
                {
                    off += 8;
                    found = GetString(nameList, GetWord(objectPointerList, 0x4 + off)).Substring(0, 4) == "data";
                }
                if (!found)
                    throw (new Exception("Cannot locate file data."));

                //  Get all important pointers.
                long pData = GetWord(objectPointerList, off);  //Data offsets

                //Enumerate object list
                DataTree.Nodes.Add(new DataNode(sname.Substring(3, sname.Length - 7), DataNode.Type.EventData, pData));
                ResolveObjects();

                //  Set the number of selections for the actions and sub actions lists.
                DataTree.SelectedNode = DataTree.Nodes[0];
                GetActions(pData);

                //  Setup the empty space buffer at the end of the moveset data.
                if (GetWord(movesetData.Length - 0x8) != FADEDATA)
                {
                    SetWord(FADEDATA, movesetData.Length);
                    SetWord(movesetData.Length - 4, movesetData.Length);
                }
                pFadeData = GetWord(movesetData.Length - 4);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                errStatus = true;
            }
            return errStatus;
        }

        public void GetActions(long pData)
        {
            cboAction.Items.Clear();
            switch (Ftype)
            {

                case 0:
                    pBEvents = GetWord(pData + 0x24); //Pointer - the Action list
                    lBEvents = FromWord(GetWord(pData + 0x2c) - pBEvents); //Number of Actions
                    for (int i = 0; i < lBEvents; i++) cboAction.Items.Add(ResolveSpecials(i + 0x112));
                    break;
                case 1:
                    pBEvents = GetWord(pData); //Pointer - the Action list
                    lBEvents = GetWord(pData + 0x4) * 2; //Number of Actions
                    for (int i = 0; i < lBEvents; i++) cboAction.Items.Add(ResolveSpecials(i));
                    break;
                case 2:
                    pBEvents = GetWord(pData + 0x28); //Pointer - the Action list
                    lBEvents = FromWord(GetWord(pData + 0x2c) - pBEvents); //Number of Actions
                    for (int i = 0; i < lBEvents; i++) cboAction.Items.Add(ResolveSpecials(i));
                    break;
            }

        }

        public void GetSubactions(long pData)
        {
            cboSubAction.Items.Clear();
            switch (Ftype)
            {

                case 0:
                    pSubEvents[0] = GetWord(pData + 0x30); //Pointer - Subaction Main list
                    pSubEvents[1] = GetWord(pData + 0x34); //Pointer  - Subaction gfx list
                    pSubEvents[2] = GetWord(pData + 0x38); //Pointer - Subaction sfx list
                    pSubEvents[3] = GetWord(pData + 0x3C); //Pointer - Subaction other list
                    lSubEvents = FromWord(pSubEvents[1] - pSubEvents[0]); //Number of subactions
                    break;
                case 1:

                    break;
                case 2:
                    pSubEvents[0] = GetWord(pData + 0x1c); //Pointer - Subaction Main list
                    pSubEvents[1] = GetWord(pData + 0x20); //Pointer  - Subaction gfx list
                    pSubEvents[2] = GetWord(pData + 0x24); //Pointer - Subaction sfx list
                    pSubEvents[3] = GetWord(pData + 0x14); //Pointer - Subaction other list
                    lSubEvents = FromWord(pSubEvents[1] - pSubEvents[0]); //Number of subactions
                    break;
            }
            for (int i = 0; i < lSubEvents; i++) cboSubAction.Items.Add(Hex(i));
        }

        public void GetArticles(long pData)
        {
            long pFloats = pData + 0x7c;
            long lFloats = FromWord((pFadeData - pFloats))/2;

            long pArticles = pFloats + ToWord(lFloats);
            if (GetWord(pArticles + 0x04) < 0x50) { lFloats += 2; pArticles += ToWord(2); }           
            long lArticles = FromWord(pFadeData - pArticles);

            for (int i = 0; i < lArticles; i++)
            {
                ArticleNode n = new ArticleNode("Article[" + i + "]", GetWord(pArticles + ToWord(i)));
                DataTree.Nodes[0].Nodes.Add(n);
            }
        }
        public void ResolveArticle(long pData)
        {
            cboAction.Items.Clear();
            cboSubAction.Items.Clear();

            pAnimations = GetWord(pData + 0x10);// pointer - Animations list
            pBEvents = GetWord(pData + 0x14); //Pointer - the Action list
            pSubEvents[0] = GetWord(pData + 0x18); //Pointer - Subaction Main list
            pSubEvents[1] = GetWord(pData + 0x1c); //Pointer  - Subaction gfx list
            pSubEvents[2] = GetWord(pData + 0x20); //Pointer - Subaction sfx list
            //pSubEvents[3] = GetWord(pData + 0x3C); //Pointer - Subaction other list

            lBEvents = FromWord(GetWord(pAnimations + 0x04) - pBEvents); //Number of Actions
            lSubEvents = FromWord(pSubEvents[1] - pSubEvents[0]); //Number of subactions

            for (int i = 0; i < lSubEvents; i++) cboSubAction.Items.Add(Hex(i));
            for (int i = 0; i < lBEvents; i++) cboAction.Items.Add(ResolveSpecials(i));

        }
        public void ResolveObjects()
        {
            int off1 = 0;
            if (objectPointerList.Length > 1)
            {
                DataTree.Nodes.Add(new BaseNode("References"));
                while (off1 < objectPointerList.Length - 8)
                {
                    var n = new DataNode(GetString(nameList, GetWord(objectPointerList, 0x4 + off1)), DataNode.Type.None, GetWord(objectPointerList, off1));
                    if (n.Text != "data") { DataTree.Nodes[1].Nodes.Add(n); }
                    off1 += 8;
                }
            }
        }

        public void DisplayAttributes(long length, long off)
        {
            attributes.Clear();
            for (int i = 0; i <= length; i++)
            {
                if (i < iAttributes.Length) { attributes.Rows.Add(iAttributes[i].name); }
                else { attributes.Rows.Add("0x" + Hex(ToWord(i))); }
                if (iAttributes[i].type == 0)
                    attributes.Rows[i][1] = UnFloat(GetWord(off + ToWord(i)));
                else
                    attributes.Rows[i][1] = GetWord(off + ToWord(i));
            }
        }

        //  Save the moveset data into the file specified.
        public void SaveFile(string fname)
        {
            long lPartition1 = 0;
            long lDataHeader = 0;
            long lMovesetData = 0;
            long lPointerList = 0;
            long lObjectPointerList = 0;
            long lExternalPointerList = 0;
            long lNameList = 0;

            lDataHeader = dataHeader.Length;
            lMovesetData = movesetData.Length;
            lNameList = nameList.Length;
            for (int i = 0; i < FromWord(pointerList.Length); i++)
            {
                long pointerTag = GetByte(pointerList, ToWord(i));
                if (pointerTag == 0x1) lPointerList += 0x4;
                if (pointerTag == 0x2) lExternalPointerList += 0x8;
            }
            lObjectPointerList = objectPointerList.Length;
            lPartition1 = lDataHeader + lMovesetData + lPointerList
                        + lObjectPointerList + lExternalPointerList + lNameList;

            //  Set the size value in the partition header.
            SetWord(ref partitionHeader, lPartition1, 0x4);

            //  Set the size values in the moveset data header.
            SetWord(ref dataHeader, lPartition1, 0x0);
            SetWord(ref dataHeader, lMovesetData, 0x4);
            SetWord(ref dataHeader, FromWord(lPointerList), 0x8);
            SetWord(ref dataHeader, FromBlock(lObjectPointerList), 0xC);
            SetWord(ref dataHeader, FromBlock(lExternalPointerList), 0x10);

            RepackFile(fname);
        }

        //  Read the data in the file and split it up into the various arrays.
        public bool UnpackFile(string fileName)
        {
            bool errStatus = false;
            FileStream fstream = null;
            try
            {
                fstream = new FileStream(fileName, FileMode.Open);

                //  Calculate the length of each important segment in the file.
                long lHeader = 0x40;
                long lPartitionHeader = 0x20;
                long lPartition1 = ReadWord(fstream, lHeader + 0x4);
                long lPartition2 = ReadWord(fstream, RoundUp(lHeader + lPartitionHeader + lPartition1, 0x20) + 0x4);
                long lDataHeader = 0x20;
                long lData = ReadWord(fstream, 0x64);
                long lPointerList = ToWord(ReadWord(fstream, 0x68));
                long lObjectPointerList = ToBlock(ReadWord(fstream, 0x6C));
                long lExternalPointerList = ToBlock(ReadWord(fstream, 0x70));
                long lNameList = lPartition1 - lDataHeader - lData - lPointerList - lObjectPointerList - lExternalPointerList;

                //  Check each segment length against the size of the file.
                if (lPartition1 > fstream.Length) throw new Exception("Bad partition 1 size.");
                if (lPartition2 > fstream.Length) throw new Exception("Bad partition 2 size.");
                if (lData > fstream.Length) throw new Exception("Bad data size.");
                if (lPointerList > fstream.Length) throw new Exception("Bad pointer list size.");
                if (lObjectPointerList > fstream.Length) throw new Exception("Bad object list size.");
                if (lExternalPointerList > fstream.Length) throw new Exception("Bad external pointer list size.");
                if (lNameList > fstream.Length) throw new Exception("Bad name list size.");
                fstream.Seek(0, SeekOrigin.Begin);

                //  Resize each buffer to the appropriate size.
                Array.Resize<byte>(ref fileHeader, (int)lHeader);
                Array.Resize<byte>(ref partitionHeader, (int)lPartitionHeader);
                Array.Resize<byte>(ref dataHeader, (int)lDataHeader);
                Array.Resize<byte>(ref movesetData, (int)lData);
                Array.Resize<byte>(ref pointerList, (int)lData);
                Array.Resize<byte>(ref objectPointerList, (int)lObjectPointerList);
                Array.Resize<byte>(ref nameList, (int)lNameList);
                Array.Resize<byte>(ref partitionHeader2, (int)lPartitionHeader);
                Array.Resize<byte>(ref effectPartition, (int)lPartition2);

                //  Start reading the data for each important segment of the file.
                fstream.Read(fileHeader, 0, fileHeader.Length);
                fstream.Read(partitionHeader, 0, partitionHeader.Length); ;
                fstream.Read(dataHeader, 0, dataHeader.Length);
                fstream.Read(movesetData, 0, movesetData.Length);

                //  Instead of recording the list and searching through it each time a
                //  pointer needs to be accessed, the size of the moveset data is replicated
                //  and each position marked as a pointer is set to a 1.
                //  This way is faster, but slightly less efficient on memory.
                for (int i = 0; i < FromWord(lPointerList); i++)
                {
                    long pOffset = ReadWord(fstream, fstream.Position);
                    SetByte(ref pointerList, 0x1, pOffset);
                }

                fstream.Read(objectPointerList, 0, objectPointerList.Length);

                //  On the same list as the pointers, but the external pointers are marked
                //  by a 2 followed by the name offset.
                for (int i = 0; i < FromBlock(lExternalPointerList); i++)
                {
                    long epOffset = ReadWord(fstream, fstream.Position);
                    SetWord(ref pointerList, ReadWord(fstream, fstream.Position), epOffset);
                    SetByte(ref pointerList, 0x2, epOffset);
                }

                fstream.Read(nameList, 0, nameList.Length);

                //  The second partition does not need to be broken down unless PSA gains
                //  the ability to modify the effect file as well.
                fstream.Seek(RoundUp(fstream.Position, 0x20), SeekOrigin.Begin);
                fstream.Read(partitionHeader2, 0, partitionHeader2.Length);
                fstream.Read(effectPartition, 0, effectPartition.Length);

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                errStatus = true;
            }
            if (fstream != null) fstream.Dispose();

            return errStatus;
        }

        //  Place all data from the byte arrays back into the file specified.
        public void RepackFile(string fileName)
        {
            FileStream fstream = null;
            try
            {
                fstream = new FileStream(fileName, FileMode.Create);

                fstream.Write(fileHeader, 0, fileHeader.Length);
                fstream.Write(partitionHeader, 0, partitionHeader.Length);
                fstream.Write(dataHeader, 0, dataHeader.Length);
                fstream.Write(movesetData, 0, movesetData.Length);

                for (int i = 0; i < FromWordRD(pointerList.Length); i++)
                    if (GetByte(pointerList, ToWord(i)) == 0x1)
                    {
                        WriteWord(fstream, ToWord(i), fstream.Position);
                    }

                fstream.Write(objectPointerList, 0, objectPointerList.Length);

                for (int i = 0; i < FromWordRD(pointerList.Length); i++)
                    if (GetByte(pointerList, ToWord(i)) == 0x2)
                    {
                        long nOffset = GetWord(pointerList, ToWord(i)) & 0xFFFFFF;
                        WriteWord(fstream, ToWord(i), fstream.Position);
                        WriteWord(fstream, nOffset, fstream.Position);
                    }

                fstream.Write(nameList, 0, nameList.Length);

                fstream.Seek(RoundUp(fstream.Position, 0x20), SeekOrigin.Begin);
                fstream.Write(partitionHeader2, 0, partitionHeader2.Length);
                fstream.Write(effectPartition, 0, effectPartition.Length);
                fstream.Close();
            }
            catch
            {
                MessageBox.Show("Unhandled error while saving. File has become corrupt.");
            }
        }

        //  Read the event data at the specified offset and return as an Event.
        public Event ReadEventData(long offset)
        {
            Event eventData = new Event();

            try
            {
                eventData.pThis = offset;
                eventData.SetEventWord(GetWord(eventData.pThis));
                eventData.pParameters = GetWord(eventData.pThis + B_WORD2);

                for (int i = 0; i < eventData.lParameters; i++)
                {
                    eventData.parameters[i].word1 = GetWord(eventData.pParameters + ToBlock(i));
                    eventData.parameters[i].word2 = GetWord(eventData.pParameters + ToBlock(i) + B_WORD2);
                }
            }
            catch
            {
                eventData = new Event();
            }

            return eventData;
        }

        //  Read the list of events at the specified offset and return as an array of Events.
        public Event[] ReadEventList(long offset)
        {
            Event[] eventData = new Event[0];

            if (offset != 0)
            {
                for (int i = 0; ; i++)
                {
                    Array.Resize<Event>(ref eventData, i + 1);
                    eventData[i] = ReadEventData(offset + ToBlock(i));

                    if (eventData[i].GetEventWord() == 0)
                    { Array.Resize<Event>(ref eventData, i); break; }
                }
            }
            return eventData;
        }


        // --------------------------------------------------- \\
        // ------------Pointer Management Methods------------- \\
        // --------------------------------------------------- \\

        //  Set a pointer and it's reference on the pointer list to the value passed
        //  and return weather the specified location already contained a pointer.
        public bool SetPointer(long value, long offset)
        {
            if (value == 0x00000000) return ClearPointer(value, offset);
            SetWord(ref movesetData, value, offset);

            if (GetByte(pointerList, offset) == 1)
                return true;
            SetByte(ref pointerList, 1, offset);
            return false;
        }

        //  Remove a pointer from the pointer list, set it's address to the value passed
        //  And return weather the specified location contained a pointer.
        public bool ClearPointer(long value, long offset)
        {
            SetWord(ref movesetData, value, offset);

            if (GetByte(pointerList, offset) == 1)
            {
                SetByte(ref pointerList, 0, offset);
                return true;
            }
            return false;
        }

        //  Delete the pointer to an event list and all data contained within.
        public void DeleteEventPointer(long value, long pEventList)
        {
            long pEventData = GetWord(pEventList);
            if (ClearPointer(value, pEventList) == false) return;
            long loc = pEventData;

            //  Delete each event and it's parameter pointer in the event list.
            while (GetWord(loc) != 0)
            {
                long lParameters = (GetWord(loc) & 0xFF00) / 0x100;

                SetWord(FADEFOOD, loc);
                DeleteParamPointer(loc + B_WORD2, lParameters);
                loc += 0x8;
            }

            //  Delete the termination code at the end of the list.
            SetWord(FADEFOOD, loc);
            SetWord(FADEFOOD, loc + B_WORD2);
        }

        //  Delete the pointer to a parameter list and all data contained within.
        public void DeleteParamPointer(long pPointer, long numParams)
        {
            long pParameters = GetWord(pPointer);
            if (ClearPointer(FADEFOOD, pPointer) == false) return;

            for (int i = 0; i < numParams; i++)
            {
                SetWord(FADEFOOD, pParameters + ToBlock(i));
                ClearPointer(FADEFOOD, pParameters + ToBlock(i) + B_WORD2);
            }

        }

        //  Allocate new space at the end of the file and return a pointer to it.
        public long Allocate(long words)
        {
            if (words == 0) return 0;
            long pFree = pFadeData;
            long available = 0;
            long sample = 0;
            long loc = pFree;
            bool endFound = false;

            //  Search for available space. If the end of available space is reached without
            //  finding enough space, increase the size of the moveset data to accomadate it.
            while (available < words)
            {
                sample = 0;
                available++;
                if (!endFound) sample = GetWord(loc);
                if (sample == FADEDATA) endFound = true;

                if (endFound) SetWord(FADEFOOD, loc);

                loc += 0x4;
                if (sample != FADEFOOD && !endFound)
                {
                    available = 0;
                    pFree = loc;
                }
            }

            //  Add the end tag for signalling the end of available space if the amount of
            //  available space was extended.
            if (endFound)
            {
                SetWord(FADEDATA, loc);
                SetWord(pFadeData, loc + 0x4);
            }
            return pFree;
        }

        //  Release the space specified also taking care to remove any pointers as well.
        public void Release(long offset, long words)
        {
            for (int i = 0; i < words; i++)
                ClearPointer(FADEFOOD, offset + ToWord(i));
        }

        // --------------------------------------------------- \\
        // ---------------Event List Methods------------------ \\
        // --------------------------------------------------- \\

        //  Desplay the list of events currently pointed to in pEventData.
        public void DisplayEvents()
        {
            int[] index = new int[lstEvents.SelectedIndices.Count];
            lstEvents.SelectedIndices.CopyTo(index, 0);
            Array.Resize<Event>(ref eventData, 0);
            lblEventListOffset.Text = "0x0" + Hex(pEventData);
            lstEvents.Items.Clear();

            if (pEventData != 0)
            {
                string[] script;

                //  Retrieve the event data and display the script accordingly.
                eventData = ReadEventList(pEventData);
                script = MakeScript(eventData);
                for (int i = 0; i < script.Length; i++)
                    lstEvents.Items.Add(script[i]);

                //  Reselect the items that were previously selected before updating the list.
                for (int i = 0; i < index.Length; i++)
                    if (index[i] < lstEvents.Items.Count) lstEvents.SelectedIndices.Add(index[i]);
            }
        }

        //  Add the specified event to the current list of events.
        public void AddEvent(long eventWord, long pParameters)
        {
            int lEventData = eventData.Length;

            //  Because adding an event requires the list to get longer, the list will have
            //  To be reallocated to accomadate the new size.
            if (lEventData != 0)
                Release(pEventData, (lEventData + 1) * 2);
            pEventData = Allocate((lEventData + 2) * 2);

            //  Re-add the events to the new list.
            for (int i = 0; i < lEventData; i++)
            {
                SetWord(eventData[i].GetEventWord(), pEventData + ToBlock(i));
                SetPointer(eventData[i].pParameters, pEventData + ToBlock(i) + B_WORD2);
            }

            //  Add the new event and the end block to end the list.
            SetWord(eventWord, pEventData + ToBlock(lEventData));
            SetPointer(pParameters, pEventData + ToBlock(lEventData) + B_WORD2);
            SetWord(0x00000000, pEventData + ToBlock(lEventData + 1));
            ClearPointer(0x00000000, pEventData + ToBlock(lEventData + 1) + B_WORD2);

            //  Redirect the index pointer if there is one.
            if (ipEventData != 0)
                SetPointer(pEventData, ipEventData);
        }

        //  Open the modify event dialog for the specified event.
        public void ModifyEvent()
        {
            if (pEventData == 0) return;
            if (lstEvents.SelectedIndex == -1) return;
            int index = lstEvents.SelectedIndex;
            long olParameters = eventData[index].lParameters;

            frmModifyEvent.eventData = eventData[index];
            frmModifyEvent.ShowDialog();

            if (frmModifyEvent.status == DialogResult.OK)
            {
                eventData[index] = frmModifyEvent.eventData;
                long nlParameters = eventData[index].lParameters;
                long pParameters = eventData[index].pParameters;
                long pEvent = eventData[index].pThis;

                SetWord(eventData[index].GetEventWord(), pEvent);

                //  Clear the old parameter data and reallocate to a new position if necessary.
                //  Also account for if the parameters list is void.
                if (pParameters != 0)
                    Release(pParameters, olParameters * 2);
                if (nlParameters == 0)
                    pParameters = 0;
                if (nlParameters > olParameters)
                    pParameters = Allocate(nlParameters * 2);
                eventData[index].pParameters = pParameters;
                SetPointer(pParameters, eventData[index].pThis + 4);

                //  Set parameters - making sure to account for pointers.
                for (int i = 0; i < nlParameters; i++)
                {
                    SetWord(eventData[index].parameters[i].word1, pParameters + ToBlock(i));

                    if (eventData[index].parameters[i].word1 != 2)
                        SetWord(eventData[index].parameters[i].word2, pParameters + ToBlock(i) + 0x4);
                    else
                        SetPointer(eventData[index].parameters[i].word2, pParameters + ToBlock(i) + 0x4);
                }
            }
        }

        //  Remove the specified event from the event list.
        public void RemoveEvent()
        {
            foreach (int index in lstEvents.SelectedIndices)
            {
                if (pEventData == 0) return;
                long olParameters = eventData[index].lParameters;

                long nlParameters = 0;
                long pParameters = eventData[index].pParameters;
                long pEvent = eventData[index].pThis;

                SetWord(0x00020000, pEvent);

                //  Clear the old parameter data and reallocate to a new position if necessary.
                //  Also account for if the parameters list is void.
                if (pParameters != 0)
                    Release(pParameters, olParameters * 2);
                if (nlParameters == 0)
                    pParameters = 0;
                if (nlParameters > olParameters)
                    pParameters = Allocate(nlParameters * 2);
                eventData[index].pParameters = pParameters;
                SetPointer(pParameters, eventData[index].pThis + 4);

                //  Set parameters - making sure to account for pointers.
                for (int i = 0; i < nlParameters; i++)
                {
                    SetWord(0x00000000, pParameters + ToBlock(i));

                    if (eventData[index].parameters[i].word1 != 2)
                        SetWord(0x00000000, pParameters + ToBlock(i) + 0x4);
                    else
                        SetPointer(0x00000000, pParameters + ToBlock(i) + 0x4);
                }
            }
        }

        //  Move the specified event the distance passed.
        public void MoveEvent(int index, int distance)
        {
            if (pEventData == 0) return;
            if (index == -1) return;
            if (index + distance < 0) return;
            if (index + distance >= eventData.Length) return;
            int i = index;
            int d = distance;

            //  Exchange the two event's positions.
            SetWord(eventData[i + d].GetEventWord(), pEventData + ToBlock(i));
            SetPointer(eventData[i + d].pParameters, pEventData + ToBlock(i) + B_WORD2);
            SetWord(eventData[i].GetEventWord(), pEventData + ToBlock(i + d));
            SetPointer(eventData[i].pParameters, pEventData + ToBlock(i + d) + B_WORD2);
            eventData[i] = ReadEventData(pEventData + ToBlock(i));
            eventData[i + d] = ReadEventData(pEventData + ToBlock(i + d));
        }

        //  Copy the specified event into the copy/paste buffer.
        public void CopyEvent(int index)
        {
            int lBuffer = copyBuffer.Length;
            Array.Resize<Event>(ref copyBuffer, lBuffer + 1);
            copyBuffer[lBuffer] = new Event();
            copyBuffer[lBuffer].SetEventWord(eventData[index].GetEventWord());
            for (int i = 0; i < eventData[index].parameters.Length; i++)
            {
                copyBuffer[lBuffer].parameters[i].word1 = eventData[index].parameters[i].word1;
                copyBuffer[lBuffer].parameters[i].word2 = eventData[index].parameters[i].word2;
            }
        }

        //  Paste the specified event from the copy/paste buffer.
        public void PasteEvent(int index)
        {
            Event newEvent = new Event();
            newEvent.SetEventWord(copyBuffer[index].GetEventWord());
            newEvent.pParameters = Allocate(newEvent.lParameters * 2);

            //  Replicate the parameter list in the newly allocated space for the parameters.
            for (int i = 0; i < newEvent.lParameters; i++)
            {
                newEvent.parameters[i].word1 = copyBuffer[index].parameters[i].word1;
                newEvent.parameters[i].word2 = copyBuffer[index].parameters[i].word2;
                SetWord(newEvent.parameters[i].word1, newEvent.pParameters + ToBlock(i));
                if (newEvent.parameters[i].word1 != 2)
                    SetWord(newEvent.parameters[i].word2, newEvent.pParameters + ToBlock(i) + B_WORD2);
                else
                    SetPointer(newEvent.parameters[i].word2, newEvent.pParameters + ToBlock(i) + B_WORD2);
            }

            AddEvent(newEvent.GetEventWord(), newEvent.pParameters);
        }


        // --------------------------------------------------- \\
        // ------------------Form Methods--------------------- \\
        // --------------------------------------------------- \\
        private void FormMain_Load(object sender, EventArgs e)
        {
            Setup();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        // --------------------------------------------------- \\
        // -----------------Action Tab Methods---------------- \\
        // --------------------------------------------------- \\
        private void tbctrlActionEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnModify.Enabled = true;
            btnNOP.Enabled = true;
            btnUp.Enabled = true;
            btnDown.Enabled = true;
            btnPasteEvent.Enabled = true;
            btnCopyEvent.Enabled = true;

            //  Update the events window when you change tabs.
            if (tbctrlActionEvents.SelectedIndex == 0) cboAction_SelectedIndexChanged(sender, e);
            if (tbctrlActionEvents.SelectedIndex == 1) cboSubAction_SelectedIndexChanged(sender, e);
            if (tbctrlActionEvents.SelectedIndex == 2) btnGo_Click(sender, e);
        }

        // --------------------Specials Tab------------------- \\
        private void cboAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAction.SelectedIndex == -1) return;
            int index = cboAction.SelectedIndex;
            ipEventData = pBEvents + ToWord(index);
            pEventData = GetWord(ipEventData);
            DisplayEvents();
        }

        // -------------------Sub Actions Tab----------------- \\
        private void cboSubAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEventList.SelectedIndex == -1) return;
            if (cboSubAction.SelectedIndex == -1) return;
            int index1 = cboEventList.SelectedIndex;
            int index2 = cboSubAction.SelectedIndex;
            long pAnimationName;

            pAnimationData = pAnimations + ToBlock(index2);
            pAnimationName = GetWord(pAnimationData + 4);
            if (pAnimationName != 0)
            {
                txtAnimationName.Text = GetString(pAnimationName);
                btnAnimationFlags.Enabled = true;
            }
            else
            {
                txtAnimationName.Text = "NONE\n";
                btnAnimationFlags.Enabled = false;
            }

            ipEventData = pSubEvents[index1] + ToWord(index2);
            pEventData = GetWord(ipEventData);
            DisplayEvents();

        }

        private void txtAnimationName_TextChanged(object sender, EventArgs e)
        {
            long pAnimationName = GetWord(pAnimationData + B_WORD2);
            string AnimationName = (pAnimationName != 0 ? GetString(pAnimationName) : "");
            string nAnimationName = txtAnimationName.Text;
            long lAnimationName = AnimationName.Length + 1;
            long nlAnimationName = txtAnimationName.Text.Length;
            if (nAnimationName == AnimationName) return;
            if (nAnimationName == "NONE\n") return;
            if (nlAnimationName == 0) btnAnimationFlags.Enabled = false;
            if (nlAnimationName > 0) btnAnimationFlags.Enabled = true;

            //  Release the memory held by the animation name if it is located in free space.
            if (pAnimationName >= pFadeData)
                Release(pAnimationName, FromWordRU(lAnimationName));

            //  Account for the termination character only if the string's length is greater than 1.
            if (nlAnimationName > 0) nlAnimationName++;

            //  Allocate a new place for the name if necessary.
            if (nlAnimationName > lAnimationName || pAnimationName >= pFadeData)
                pAnimationName = Allocate(FromWordRU(nlAnimationName));

            if (nlAnimationName == 0) pAnimationName = 0;
            SetPointer(pAnimationName, pAnimationData + B_WORD2);

            if (nlAnimationName > 1)
                SetString(nAnimationName, pAnimationName);
        }

        private void btnAnimationFlags_Click(object sender, EventArgs e)
        {
            //  Pass in the transition time and animation flags.
            frmAnimFlags.inTransitionTime = (byte)GetByte(pAnimationData);
            frmAnimFlags.flags.SetByte((byte)GetByte(pAnimationData + 1));

            frmAnimFlags.ShowDialog();

            //  Retrieve and set the changed transition time and flags.
            if (frmAnimFlags.status == DialogResult.OK)
            {
                SetByte(frmAnimFlags.inTransitionTime, pAnimationData);
                SetByte(frmAnimFlags.flags.GetByte(), pAnimationData + 1);
            }
        }

        // ------------------Sub Routines Tab---------------- \\
        private void btnGo_Click(object sender, EventArgs e)
        {
            bool notList = false;
            btnAdd.Enabled = false;
            btnModify.Enabled = false;
            btnNOP.Enabled = false;
            btnUp.Enabled = false;
            btnDown.Enabled = false;
            btnPasteEvent.Enabled = false;
            btnCopyEvent.Enabled = false;

            try
            {
                if (txtOffset.Text == "") throw new Exception("");
                pEventData = UnHex(txtOffset.Text);
                ipEventData = 0;

                //  Check for various errors in the offset input.
                if (pEventData == 0) throw new Exception("");
                if (pEventData % 4 != 0) throw new Exception("Invalid Offset.");
                if (pEventData > movesetData.Length) throw new Exception("Offset too large.");

                DisplayEvents();

                //  Check the event Data for signs that it is not a valid event list.
                for (int i = 0; i < eventData.Length; i++)
                {
                    if (eventData[i].pParameters > movesetData.Length) notList = true;
                    if (eventData[i].pParameters % 4 != 0) notList = true;

                    for (int i2 = 0; i2 < eventData[i].lParameters; i2++)
                        if (eventData[i].parameters[i2].word1 > 6) notList = true;

                    if (notList)
                        throw new Exception("Offset not recognised as a valid event list.");
                }

                //  Allow basic modification of the event list.
                btnModify.Enabled = true;
                btnUp.Enabled = true;
                btnDown.Enabled = true;
                btnCopyEvent.Enabled = true;

                //  Only allow addition, removal, and pasting of events if the subroutine has been created by PSA.
                if (pEventData >= pFadeData)
                {
                    btnAdd.Enabled = true;
                    btnNOP.Enabled = true;
                    btnPasteEvent.Enabled = true;
                }
            }
            catch (Exception error)
            {
                if (error.Message != "") MessageBox.Show(error.Message);
                Array.Resize<Event>(ref eventData, 0);
                lstEvents.Items.Clear();
                lblEventListOffset.Text = "0x0";
                pEventData = 0;
            }
        }

        private void btnCreateSubRoutine_Click(object sender, EventArgs e)
        {
            Array.Resize<Event>(ref eventData, 0);
            lstEvents.Items.Clear();
            pEventData = 0;
            ipEventData = 0;

            AddEvent(0x00020000, 0x00000000);
            txtOffset.Text = Hex(pEventData);
            btnGo_Click(sender, e);
        }

        // --------------------------------------------------- \\
        // ----------------Event Window Methods--------------- \\
        // --------------------------------------------------- \\
        private void lstEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pEventData == 0) return;
            if (lstEvents.SelectedIndex == -1) return;
            int index = lstEvents.SelectedIndex;
            string eventId = eventData[index].eventId;

            //  Show description of the selected event.
            lblEventDescription.Text = GetEventInfo(eventId).description;
        }

        private void lstEvents_DoubleClick(object sender, EventArgs e)
        {
            if (btnModify.Enabled == true) btnModify_Click(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEvent(0x00020000, 0x00000000);
            DisplayEvents();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            ModifyEvent();
            DisplayEvents();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstEvents.SelectedIndices.Count == 0) return;
            int lSelected = lstEvents.SelectedIndices.Count;
            ListBox.SelectedIndexCollection selected = lstEvents.SelectedIndices;

            //  Remove all events selected.
            for (int i = lSelected - 1; i >= 0; i--)
            {
                RemoveEvent();
                DisplayEvents();
            }
            lSelected = lstEvents.SelectedIndices.Count;

            //  If multiple items were selected, deselect all items to avoid erros by the user.
            if (lSelected > 1)
                selected.Clear();
            //  If the item selected was the last item on the list, select the new last item on the list.
            if (lSelected == 0)
                selected.Add(lstEvents.Items.Count - 1);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (lstEvents.SelectedIndices.Count == 0) return;
            int lSelected = lstEvents.SelectedIndices.Count;
            ListBox.SelectedIndexCollection selected = lstEvents.SelectedIndices;

            //  Move each event up - return if the top selected event is at the top of the list.
            for (int i = 0; i < lSelected; i++)
                if (selected[i] > 0) MoveEvent(selected[i], -1);
                else return;

            //  Move each selection on the list up.
            for (int i = 0; i < lSelected; i++)
            {
                int index = selected[i];
                selected.Add(index - 1);
                selected.Remove(index);
            }

            DisplayEvents();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (lstEvents.SelectedIndices.Count == 0) return;
            int lSelected = lstEvents.SelectedIndices.Count;
            ListBox.SelectedIndexCollection selected = lstEvents.SelectedIndices;

            //  Move each event down - return if the bottom selected event is at the bottom of the list.
            for (int i = lSelected - 1; i >= 0; i--)
                if (selected[i] < lstEvents.Items.Count - 1) MoveEvent(selected[i], 1);
                else return;

            //  Move each selection on the list down.
            for (int i = lSelected - 1; i >= 0; i--)
            {
                int index = selected[i];
                selected.Add(index + 1);
                selected.Remove(index);
            }

            DisplayEvents();
        }

        private void btnCopyEvent_Click(object sender, EventArgs e)
        {
            if (lstEvents.SelectedIndices.Count == 0) return;
            int lSelected = lstEvents.SelectedIndices.Count;
            ListBox.SelectedIndexCollection selected = lstEvents.SelectedIndices;
            Array.Resize<Event>(ref copyBuffer, 0);

            //  Copy each selected event on the event list.
            string s1 = "";
            for (int i = 0; i < lSelected; i++)
            {
                CopyEvent(selected[i]);
                s1 += (lstEvents.Items[selected[i]].ToString() + "\n");
            }
            s1 += "\n\n ============= \n";
            s1 += "   " + lblEventListOffset.Text + "   ";
            s1 += "\n ============= \n";
            for (int i = 0; i < lSelected; i++)
            {
                string EventID = eventData[selected[i]].eventId; string Params = eventData[selected[i]].pParameters.ToString("x");
                Params = Params.PadLeft(8, '0');
                s1 += EventID + " " + Params + "\n";
            }
            Clipboard.SetText(s1);
            selected.Clear();
        }

        private void btnPasteEvent_Click(object sender, EventArgs e)
        {
            ListBox.SelectedIndexCollection selected = lstEvents.SelectedIndices;
            selected.Clear();

            for (int i = 0; i < copyBuffer.Length; i++)
            {
                PasteEvent(i);
                DisplayEvents();
                selected.Add(lstEvents.Items.Count - 1);
            }
        }

        // --------------------------------------------------- \\
        // ---------------Attributes Tab Methods-------------- \\
        // --------------------------------------------------- \\
        private void dtgrdAttributes_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dtgrdAttributes.CurrentCell == null) return;
            int index = dtgrdAttributes.CurrentCell.RowIndex;

            //  Display description of the selected attribute.
            lblAttributeDescription.Text = iAttributes[index].description;
        }

        private void dtgrdAttributes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgrdAttributes.CurrentCell == null) return;
            int index = dtgrdAttributes.CurrentCell.RowIndex;
            string value = attributes.Rows[index][1].ToString();

            if (iAttributes[index].type == 0)
                try { SetWord(Float(float.Parse(value)), pAttributes + ToWord(index)); }
                catch { value = UnFloat(GetWord(pAttributes + ToWord(index))).ToString(); }
            else if (iAttributes[index].type == 1)
                try { SetWord(long.Parse(value), pAttributes + ToWord(index)); }
                catch { value = GetWord(pAttributes + ToWord(index)).ToString(); }

            attributes.Rows[index][1] = value;
        }
        private void showAsFloatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = dtgrdAttributes.SelectedRows[0].Index;
            attributes.Rows[i][1] = UnFloat(GetWord(pAttributes + ToWord(i)));
            dtgrdAttributes.Invalidate();
        }
        private void showAsIntToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = dtgrdAttributes.SelectedRows[0].Index;
            attributes.Rows[i][1] = GetWord(pAttributes + ToWord(i));
            dtgrdAttributes.Invalidate();
        }

        // --------------------------------------------------- \\
        // ------------------Menu Methods--------------------- \\
        // --------------------------------------------------- \\
        private void mnuOpen_Click(object sender, EventArgs e)
        {
            if (opnDlg.ShowDialog() == DialogResult.Cancel) return;
            sname = opnDlg.SafeFileName;
            fname = opnDlg.FileName;
            saveDlg.FileName = sname;

            cboSubAction.Items.Clear();
            cboAction.Items.Clear();
            cboSubAction.Enabled = false;
            cboEventList.Enabled = false;

            txtAnimationName.Text = "";
            attributes.Clear();
            
            DataTree.Nodes.Clear(); lstEvents.Items.Clear();
            fileHeader = null; partitionHeader = null; dataHeader = null;
            movesetData = null; pointerList = null; objectPointerList = null;
            nameList = null; partitionHeader2 = null; effectPartition = null;
            try
            {
                if (sname.Contains("irby") && !sname.Contains("irby.pac"))
                {
                    Ftype = 1;
                    if (OpenKirbyHat(fname) == true)
                        throw new Exception("Could not open file.");
                }
                else if (sname.Contains("Itm") || sname.Contains("Item") || sname.Contains("itm"))
                {
                    Ftype = 2;
                    if (OpenItem(fname) == true)
                        throw new Exception("Could not open file.");
                }
                else
                {
                    Ftype = 0;
                    if (OpenFile(fname) == true)
                        throw new Exception("Could not open file.");
                }

                this.Text = "Smash Attacks! - " + sname;
                mnuSave.Enabled = true;
                mnuSaveAs.Enabled = true;
                tbctrlMain.Enabled = true;
                tbctrlMain.SelectedIndex = 0;
                tbctrlActionEvents.SelectedIndex = 0;
                txtOffset.Text = "";

                if (cboAction.Items.Count == 0) { cboAction.Items.Add("<null>"); }
                if (cboSubAction.Items.Count != 0) 
                {
                    cboSubAction.Enabled = true; cboEventList.Enabled = true;
                    cboSubAction.SelectedIndex = 0; cboSubAction_SelectedIndexChanged(sender, e);
                    cboEventList.SelectedIndex = 0; cboSubAction_SelectedIndexChanged(sender, e);
                }
                cboAction.SelectedIndex = 0; cboAction_SelectedIndexChanged(sender, e);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            SaveFile(fname);
        }
        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            if (saveDlg.ShowDialog() == DialogResult.Cancel) return;
            string sname = "";
            fname = saveDlg.FileName;
            opnDlg.FileName = fname;
            sname = opnDlg.SafeFileName;
            opnDlg.FileName = sname;

            SaveFile(fname);

            this.Text = "Smash Attacks! - " + sname;
        }
        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void mnuAbout_Click(object sender, EventArgs e)
        {
            frmAbout.ShowDialog();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (!chkDataTree.Checked)
            {
                if (tbctrlMain.Width != this.Width - 31) { tbctrlMain.Width = this.Width - 31; }
            }
            else if (chkDataTree.Checked)
            {
                if (tbctrlMain.Width != this.Width - (DataTree.Width + 62)) { tbctrlMain.Width = this.Width - (DataTree.Width + 62); }
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDataTree.Checked)
            {
                tbctrlMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                DataTree.Visible = true;
                    this.Width += DataTree.Width + 31;
                    tbctrlMain.Width = this.Width - (DataTree.Width + 62);                
            }
            else if (!chkDataTree.Checked)
            {
                tbctrlMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
                DataTree.Visible = false; this.Width -= DataTree.Width + 31; tbctrlMain.Width = this.Width - 31;
            }
        }

        private void DataTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (DataTree.SelectedNode != null)
            {
                if (DataTree.SelectedNode is DataNode)
                {
                    DataNode selected = (DataNode)DataTree.SelectedNode;
                    if (selected.type == DataNode.Type.EventData)
                    {
                        tbctrlMain.SelectedTab = tbctrlMain.TabPages[0];
                        GetActions(selected.address);
                        GetSubactions(selected.address);
                    }
                    else if (selected.type == DataNode.Type.ValueList)
                    {
                        tbctrlMain.SelectedTab = tbctrlMain.TabPages[1];
                        DisplayAttributes(FromWord(0x2E0), selected.address);
                        tbctrlMain.Invalidate();
                    }
                }
                else if (DataTree.SelectedNode is ArticleNode)
                {
                    cboAction.Items.Clear();
                    lstEvents.Items.Clear();
                    ArticleNode selected = (ArticleNode)DataTree.SelectedNode;
                    tbctrlMain.SelectedTab = tbctrlMain.TabPages[0];
                    ResolveArticle(selected.address);

                    cboAction.SelectedIndex = 0;
                    cboSubAction.SelectedIndex = 0;
                }
            }
        }
    }

    // --------------------------------------------------- \\
    // ---------------------Classes----------------------- \\
    // --------------------------------------------------- \\

    //  Info holder for attributes.
    public class InfoAttribute
    {
        public InfoAttribute() { }
        ~InfoAttribute() { }

        public string name;
        public string description;
        public long type;
    }

    //  Info holder for events.
    public class InfoEvent
    {
        public InfoEvent() { dfltParameters = new long[0]; }
        public InfoEvent(string nId, string nName, string nDescription)
        {
            idNumber = nId; name = nName; description = nDescription;
            dfltParameters = new long[0];
        }
        ~InfoEvent() { }

        //  Translate a string of numbers into a set of default parameter types for the event.
        public void SetDfltParameters(string s)
        {
            if (s == null) return;
            Array.Resize<long>(ref dfltParameters, s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                try { dfltParameters[i] = long.Parse(s.Substring(i, 1)); }
                catch { dfltParameters[i] = 0; }
            }
        }

        //  Return the default type for the parameter number passed.
        public long GetDfltParameter(int i)
        {
            if (i >= dfltParameters.Length) return 0;
            if (dfltParameters[i] > 6) return 0;
            return dfltParameters[i];
        }

        public string idNumber;
        public string name;
        public string description;

        private long[] dfltParameters;
    }

    //  Info holder for an event's parameters.
    public class InfoParameter
    {
        public InfoParameter()
        {
            name = new string[0];
            description = new string[0];
        }

        ~InfoParameter() { }

        public string GetName(long i)
        {
            if (i >= name.Length) return "Parameter " + i;
            return name[i];
        }

        public string GetDescription(long i)
        {
            if (i >= description.Length) return "No Description Available.";
            return description[i];
        }

        public string idNumber;
        public string[] name;
        public string[] description;
    }

    //  Info holder for the syntax of an event.
    public class InfoEventSyntax
    {
        public InfoEventSyntax() { }
        ~InfoEventSyntax() { }

        public string idNumber;
        public string syntax;
    }

    //  Data holder for an event.
    public class Event
    {
        public void SetEventWord(long v) { eventWord = v; ResolveEventWord(); }
        public long GetEventWord() { return eventWord; }

        //  Resolve for the string-hex version of the event word and adjust the number
        //  of parameters to the amount indicated by the event word.
        public void ResolveEventWord()
        {
            eventId = eventWord.ToString("X");
            eventId = eventId.PadLeft(8, '0');
            if (eventId.Length > 8)
                eventId = eventId.Substring(eventId.Length - 8);

            lParameters = (eventWord & 0xFF00) / 0x100;

            Array.Resize<Block>(ref parameters, (int)lParameters);
            for (int i = 0; i < lParameters; i++) parameters[i] = new Block();
        }

        public string eventId;
        public long pParameters;
        public long lParameters;
        public Block[] parameters;
        public long pThis;
        long eventWord;
    }

    //  Data holder for a block (2 words).
    public class Block
    {
        public long word1;
        public long word2;
    }

    //  Data holder for an 8-bit-set.
    public class Bitset
    {
        public Bitset() { bitVal = new bool[8]; }
        ~Bitset() { }

        public void SetByte(byte v) { byteVal = v; ResolveBits(); }
        public void SetBit(int b, bool v) { bitVal[b] = v; ResolveByte(); }

        public byte GetByte() { return byteVal; }
        public bool GetBit(int b) { return bitVal[b]; }

        //  Set each bit according to the bitset's current byte value.
        public void ResolveBits()
        {
            for (int i = 0; i < 8; i++)
                bitVal[i] = (((long)Math.Pow(0x2, i) & byteVal) != 0 ? true : false);
        }

        //  Set the byte value according to the bitset's bits.
        public void ResolveByte()
        {
            byteVal = 0;
            for (int i = 0; i < 8; i++)
                if (bitVal[i] == true)
                    byteVal += (byte)Math.Pow(0x2, i);
        }

        byte byteVal;
        bool[] bitVal;
    }

    // Extended Treenode classes
    public class BaseNode : TreeNode
    {
        public BaseNode(string Name) {address = 0; this.Text = Name; type = Type.None;}
        public BaseNode(string Name, Type Type, long Address)
        {
            address = Address;
            this.Text = Name;
            type = Type;
        }

        public Type type;
        public long address;
        public enum Type
        {
            None = -1,
            EventData = 0,
            ValueList = 1,
        }
    }
    public class DataNode : BaseNode
    {
        public DataNode(string name, Type type, long address): base(name, type, address)
        {
            this.Text = name;
            this.address = address;
        }
        public long pAnimations;
        public long pActions;
        public long lActions;
        public long[] pSubactions;
        public long lSubactions;
    }
    public class ArticleNode : BaseNode
    {
        public ArticleNode(string name,long address): base(name,Type.EventData,address)
        {
            this.Text = name;
            this.address = address;
        }
        public long pAnimations;
        public long pActions;
        public long lActions;
        public long[] pSubactions;
        public long lSubactions;
    }
}

