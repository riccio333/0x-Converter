using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace _0x_Converter
{
    public partial class Ox_converter : Form
    {

        private PrivateFontCollection pfc = new PrivateFontCollection();

        private void LoadFont()
        {
            int fontLength = Properties.Resources.Monospac821_BT.Length;
            byte[] fontdata = Properties.Resources.Monospac821_BT;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            pfc.AddMemoryFont(data, fontLength);

            converter_title_lbl.Font = new Font(pfc.Families[0], converter_title_lbl.Font.Size, FontStyle.Bold);
            text_grb.Font = new Font(pfc.Families[0], text_grb.Font.Size);
            text_lbl.Font = new Font(pfc.Families[0], text_lbl.Font.Size);
            binary_grb.Font = new Font(pfc.Families[0], binary_grb.Font.Size);
            binary_lbl.Font = new Font(pfc.Families[0], binary_lbl.Font.Size);
            with_spaces_checkbox.Font = new Font(pfc.Families[0], with_spaces_checkbox.Font.Size);
            hex_grb.Font = new Font(pfc.Families[0], hex_grb.Font.Size);
            hex_lbl.Font = new Font(pfc.Families[0], hex_lbl.Font.Size);
            copy_hex_btn.Font = new Font(pfc.Families[0], copy_hex_btn.Font.Size);
            with_dash_hex_checkbox.Font = new Font(pfc.Families[0], with_dash_hex_checkbox.Font.Size);
            ascii_grb.Font = new Font(pfc.Families[0], ascii_grb.Font.Size);
            ascii_lbl.Font = new Font(pfc.Families[0], ascii_lbl.Font.Size);
            with_spaces_ascii_checkbox.Font = new Font(pfc.Families[0], with_spaces_ascii_checkbox.Font.Size);
            base64_grb.Font = new Font(pfc.Families[0], base64_grb.Font.Size);
            base64_lbl.Font = new Font(pfc.Families[0], base64_lbl.Font.Size);
            copy_base64_btn.Font = new Font(pfc.Families[0], copy_base64_btn.Font.Size);
            oct_grb.Font = new Font(pfc.Families[0], oct_grb.Font.Size);
            oct_lbl.Font = new Font(pfc.Families[0], oct_lbl.Font.Size);
            oct_with_spaces_checkbox.Font = new Font(pfc.Families[0], oct_with_spaces_checkbox.Font.Size);
            copied_lbl.Font = new Font(pfc.Families[0], copied_lbl.Font.Size);
            copyright_linklbl.Font = new Font(pfc.Families[0], copyright_linklbl.Font.Size);
        }

        public Ox_converter()
        {
            InitializeComponent();
            LoadFont();
        }

        private void Ox_converter_FormClosing(object sender, FormClosingEventArgs e)
        {
            pfc.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ComboboxStart();
        }

        public Point mouseLocation;

        private void mouse_down(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void mouse_move(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void ComboboxStart()
        {
            if (convert_cbx.SelectedIndex == -1)
            {
                with_spaces_checkbox.Visible = false;
                with_dash_hex_checkbox.Visible = false;
                with_spaces_ascii_checkbox.Visible = false;
                oct_with_spaces_checkbox.Visible = false;
                requirements.Visible = false;

                copy_text_btn.Visible = false;
                copy_binary_btn.Visible = false;
                copy_hex_btn.Visible = false;
                copy_ascii_btn.Visible = false;
                copy_base64_btn.Visible = false;
                copy_oct_btn.Visible = false;
                copy_all_btn.Visible = false;

                text_lbl.Text = "Please";
                binary_lbl.Text = "select";
                hex_lbl.Text = "a";
                ascii_lbl.Text = "format";
                base64_lbl.Text = "in the";
                oct_lbl.Text = "Combobox";
            }
        }

        private void convert_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            convert_text_box.Clear();

            with_spaces_checkbox.Visible = true;
            with_dash_hex_checkbox.Visible = true;
            with_spaces_ascii_checkbox.Visible = true;
            oct_with_spaces_checkbox.Visible = true;

            text_lbl.Text = "";
            binary_lbl.Text = "";
            hex_lbl.Text = "";
            ascii_lbl.Text = "";
            base64_lbl.Text = "";
            oct_lbl.Text = "";

            copy_text_btn.Visible = true;
            copy_binary_btn.Visible = true;
            copy_hex_btn.Visible = true;
            copy_ascii_btn.Visible = true;
            copy_base64_btn.Visible = true;
            copy_oct_btn.Visible = true;
            copy_all_btn.Visible = true;

            if (convert_cbx.SelectedIndex == 0)
            {
                text_grb.Visible = false;

                requirements.Visible = false;
                binary_grb.Visible = true;
                hex_grb.Visible = true;
                ascii_grb.Visible = true;
                base64_grb.Visible = true;
                oct_grb.Visible = true;

                with_spaces_checkbox.Checked = true;
                with_spaces_ascii_checkbox.Checked = true;
                oct_with_spaces_checkbox.Checked = true;
            }
            else if (convert_cbx.SelectedIndex == 1)
            {
                binary_grb.Visible = false;
                with_dash_hex_checkbox.Visible = false;

                base64_grb.Visible = true;
                requirements.Visible = false;
                text_grb.Visible = true;
                hex_grb.Visible = true;
                ascii_grb.Visible = true;
                oct_grb.Visible = true;

                with_spaces_checkbox.Checked = true;
                with_spaces_ascii_checkbox.Checked = true;
                oct_with_spaces_checkbox.Visible = false;
            }
            else if (convert_cbx.SelectedIndex == 2)
            {
                hex_grb.Visible = false;
                with_spaces_checkbox.Visible = false;
                oct_with_spaces_checkbox.Visible = false;

                requirements.Visible = false;
                text_grb.Visible = true;
                binary_grb.Visible = true;
                ascii_grb.Visible = true;
                base64_grb.Visible = true;
                oct_grb.Visible = true;
            }
            else if (convert_cbx.SelectedIndex == 3)
            {
                ascii_grb.Visible = false;

                requirements.Visible = true;
                text_grb.Visible = true;
                binary_grb.Visible = true;
                hex_grb.Visible = true;
                base64_grb.Visible = true;
                oct_grb.Visible = true;
            }
            else if (convert_cbx.SelectedIndex == 4)
            {
                base64_grb.Visible = false;

                requirements.Visible = false;
                text_grb.Visible = true;
                binary_grb.Visible = true;
                hex_grb.Visible = true;
                ascii_grb.Visible = true;
                oct_grb.Visible = true;
            }
            else if (convert_cbx.SelectedIndex == 5)
            {
                oct_grb.Visible = false;
                with_spaces_checkbox.Visible = false;
                with_dash_hex_checkbox.Visible = false;
                requirements.Visible = true;

                text_grb.Visible = true;
                binary_grb.Visible = true;
                hex_grb.Visible = true;
                ascii_grb.Visible = true;
                base64_grb.Visible = true;
            }
        }

        //

        private void ComboboxErr()
        {
            if (convert_cbx.SelectedIndex == -1)
            {
                if (convert_text_box.Text == "")
                {
                    //
                }
                else
                {
                    convert_text_box.Clear();
                    MessageBox.Show("You need to select a format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //

        public static byte[] ConvertToByteArray(string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }

        public static String StringToBinary(Byte[] data)
        {
            try
            {
                return string.Join(" ", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
            }
            catch
            {
                return "Can't convert";
            }
        }

        //

        public static string BinaryToString(string data)
        {
            data = data.Replace(" ", "");
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }

            return Encoding.UTF8.GetString(byteList.ToArray());
        }

        //

        public static byte[] HexToString(string hex)
        {
            hex = hex.Replace("-", "").Replace(" ", "").Replace("0x" ,"");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }

        //

        public static string StringToBase64(string text)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(text);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        //

        public static string Base64ToString(string base64)
        {
            byte[] data = Convert.FromBase64String(base64);
            return Encoding.UTF8.GetString(data);
        }

        //

        public static byte[] ConvertFromStringToHex(string inputHex)
        {
            inputHex = inputHex.Replace("-", "").Replace(" ", "");

            byte[] resultantArray = new byte[inputHex.Length / 2];
            for (int i = 0; i < resultantArray.Length; i++)
            {
                resultantArray[i] = Convert.ToByte(inputHex.Substring(i * 2, 2), 16);
            }
            return resultantArray;
        }

        //

        public bool IsNumeric(string input)
        {
            int test;
            return int.TryParse(input, out test);
        }

        //

        public string DecodeASCII(string str) //many thanks to ZioEren for this decoder <3
        {
            if (str.Contains(" "))
            {
                string result = "";
                string[] splitted = str.Split(' ');

                foreach (string number in splitted)
                {
                    if (!IsNumeric(number))
                    {
                        return "Can't convert";
                    }

                    int theNumber = int.Parse(number);
                    char theChar = (char)theNumber;
                    result += theChar;
                }

                return result;
            }
            else if (IsNumeric(str))
            {
                return ((char)int.Parse(str)).ToString();
            }

            return "";
        }

        //

        private void BinaryConversions()
        {
            string convert = convert_text_box.Text;

            if (convert_cbx.SelectedIndex == 0)
            {
                if (with_spaces_checkbox.Checked == false)
                {
                    try
                    {
                        binary_lbl.Text = StringToBinary(ConvertToByteArray(convert, Encoding.ASCII)).Replace(" ", "");
                    }
                    catch
                    {
                        binary_lbl.Text = "Can't convert";
                    }
                }
                else if (with_spaces_checkbox.Checked == true)
                {
                    try
                    {
                        binary_lbl.Text = StringToBinary(ConvertToByteArray(convert, Encoding.ASCII));
                    }
                    catch
                    {
                        binary_lbl.Text = "Can't convert";
                    }
                }
            }

            else if (convert_cbx.SelectedIndex == 3)
            {
                try
                {
                    string asciitotext = DecodeASCII(convert);

                    if (with_spaces_checkbox.Checked == false)
                    {
                        try
                        {
                            binary_lbl.Text = StringToBinary(ConvertToByteArray(asciitotext, Encoding.ASCII)).Replace(" ", "");
                        }
                        catch
                        {
                            binary_lbl.Text = "Can't convert";
                        }
                    }
                    else if (with_spaces_checkbox.Checked == true)
                    {
                        try
                        {
                            binary_lbl.Text = StringToBinary(ConvertToByteArray(asciitotext, Encoding.ASCII));
                        }
                        catch
                        {
                            binary_lbl.Text = "Can't convert";
                        }
                    }
                }
                catch
                {
                    binary_lbl.Text = "Can't convert";
                }
            }

            else if (convert_cbx.SelectedIndex == 4)
            {
                try
                {
                    string conv = Base64ToString(convert);

                    if (with_spaces_checkbox.Checked == false)
                    {
                        try
                        {
                            binary_lbl.Text = StringToBinary(ConvertToByteArray(conv, Encoding.ASCII)).Replace(" ", "");
                        }
                        catch
                        {
                            binary_lbl.Text = "Can't convert";
                        }
                    }
                    else if (with_spaces_checkbox.Checked == true)
                    {
                        try
                        {
                            binary_lbl.Text = StringToBinary(ConvertToByteArray(conv, Encoding.ASCII));
                        }
                        catch
                        {
                            binary_lbl.Text = "Can't convert";
                        }
                    }
                }
                catch
                {
                    binary_lbl.Text = "Can't convert";
                }
            }
        }

        private void HexConversion()
        {
            string convert = convert_text_box.Text;

            if (convert_cbx.SelectedIndex == 0)
            {
                if (with_dash_hex_checkbox.Checked == false)
                {
                    try
                    {
                        byte[] bytez = Encoding.Default.GetBytes(convert);
                        var hex = BitConverter.ToString(bytez);
                        hex = hex.Replace("-", "");
                        hex_lbl.Text = hex;
                    }
                    catch
                    {
                        hex_lbl.Text = "Can't convert";
                    }                    
                }
                else if (with_dash_hex_checkbox.Checked == true)
                {
                    try
                    {
                        byte[] bytez = Encoding.Default.GetBytes(convert);
                        var hex = BitConverter.ToString(bytez);
                        hex_lbl.Text = hex;
                    }
                    catch
                    {
                        hex_lbl.Text = "Can't convert";
                    }
                }
            }

            else if (convert_cbx.SelectedIndex == 3)
            {
                try
                {
                    string asciitotext = DecodeASCII(convert);

                    if (with_dash_hex_checkbox.Checked == false)
                    {
                        try
                        {
                            byte[] bytez = Encoding.Default.GetBytes(asciitotext);
                            var hex = BitConverter.ToString(bytez);
                            hex = hex.Replace("-", "");
                            hex_lbl.Text = hex;
                        }
                        catch
                        {
                            hex_lbl.Text = "Can't convert";
                        }
                    }
                    else if (with_dash_hex_checkbox.Checked == true)
                    {
                        try
                        {
                            byte[] bytez = Encoding.Default.GetBytes(asciitotext);
                            var hex = BitConverter.ToString(bytez);
                            hex_lbl.Text = hex;
                        }
                        catch
                        {
                            hex_lbl.Text = "Can't convert";
                        }
                    }
                }
                catch
                {
                    hex_lbl.Text = "Can't convert";
                }
            }

            else if (convert_cbx.SelectedIndex == 4)
            {
                try
                {
                    byte[] bytes = Convert.FromBase64String(convert);

                    if (with_dash_hex_checkbox.Checked == false)
                    {
                        try
                        {
                            hex_lbl.Text = BitConverter.ToString(bytes).Replace("-", "");
                        }
                        catch
                        {
                            hex_lbl.Text = "Can't convert";
                        }
                    }
                    else if (with_dash_hex_checkbox.Checked == true)
                    {
                        try
                        {
                            hex_lbl.Text = BitConverter.ToString(bytes);
                        }
                        catch
                        {
                            hex_lbl.Text = "Can't convert";
                        }
                    }
                }
                catch
                {
                    hex_lbl.Text = "Can't convert";
                }
            }
        }

        private void AsciiConversions()
        {
            string convert = convert_text_box.Text;

            if (convert_cbx.SelectedIndex == 0)
            {
                if (with_spaces_ascii_checkbox.Checked == false)
                {
                    try
                    {
                        byte[] ascii = Encoding.ASCII.GetBytes(convert);

                        ascii_lbl.Text = string.Join("", ascii.Where(x => ((int)x) < 127));
                    }
                    catch
                    {
                        ascii_lbl.Text = "Can't convert";
                    }
                }
                else if (with_spaces_ascii_checkbox.Checked == true)
                {
                    try
                    {
                        byte[] ascii = Encoding.ASCII.GetBytes(convert);

                        ascii_lbl.Text = string.Join(" ", ascii.Where(x => ((int)x) < 127));
                    }
                    catch
                    {
                        ascii_lbl.Text = "Can't convert";
                    }
                }
            }
            else if (convert_cbx.SelectedIndex == 1)
            {
                try
                {
                    string text = BinaryToString(convert);

                    if (with_spaces_ascii_checkbox.Checked == false)
                    {
                        byte[] ascii = Encoding.ASCII.GetBytes(text);

                        ascii_lbl.Text = string.Join("", ascii.Where(x => ((int)x) < 127));
                    }
                    else if (with_spaces_ascii_checkbox.Checked == true)
                    {
                        byte[] ascii = Encoding.ASCII.GetBytes(text);

                        ascii_lbl.Text = string.Join(" ", ascii.Where(x => ((int)x) < 127));
                    }
                }
                catch
                {
                    ascii_lbl.Text = "Can't convert";
                }
            }
            else if (convert_cbx.SelectedIndex == 2)
            {
                try
                {
                    convert = convert.Replace("-", "").Replace("0x", "").Replace(" ", "");
                    byte[] bytez = HexToString(convert);
                    string hextotext = Encoding.ASCII.GetString(bytez);

                    if (with_spaces_ascii_checkbox.Checked == false)
                    {
                        try
                        {
                            byte[] ascii = Encoding.ASCII.GetBytes(hextotext);

                            ascii_lbl.Text = string.Join("", ascii.Where(x => ((int)x) < 127));
                        }
                        catch
                        {
                            ascii_lbl.Text = "Can't convert";
                        }
                    }
                    else if (with_spaces_ascii_checkbox.Checked == true)
                    {
                        try
                        {
                            byte[] ascii = Encoding.ASCII.GetBytes(hextotext);

                            ascii_lbl.Text = string.Join(" ", ascii.Where(x => ((int)x) < 127));
                        }
                        catch
                        {
                            ascii_lbl.Text = "Can't convert";
                        }
                    }
                }
                catch
                {
                    ascii_lbl.Text = "Can't convert";
                }
            }
            else if (convert_cbx.SelectedIndex == 3)
            {
                try
                {
                    string asciitotext = DecodeASCII(convert);

                    if (with_spaces_checkbox.Checked == false)
                    {
                        try
                        {
                            binary_lbl.Text = StringToBinary(ConvertToByteArray(asciitotext, Encoding.ASCII)).Replace(" ", "");
                        }
                        catch
                        {
                            ascii_lbl.Text = "Can't convert";
                        }
                    }
                    else if (with_spaces_checkbox.Checked == true)
                    {
                        try
                        {
                            binary_lbl.Text = StringToBinary(ConvertToByteArray(asciitotext, Encoding.ASCII));
                        }
                        catch
                        {
                            ascii_lbl.Text = "Can't convert";
                        }
                    }
                }
                catch
                {
                    ascii_lbl.Text = "Can't convert";
                }
            }
            else if (convert_cbx.SelectedIndex == 4)
            {
                try
                {
                    string conv = Base64ToString(convert);

                    if (with_spaces_ascii_checkbox.Checked == false)
                    {
                        try 
                        {
                            byte[] ascii = Encoding.ASCII.GetBytes(conv);

                            ascii_lbl.Text = string.Join("", ascii.Where(x => ((int)x) < 127));
                        }
                        catch
                        {
                            ascii_lbl.Text = "Can't convert";
                        }
                    }
                    else if (with_spaces_ascii_checkbox.Checked == true)
                    {
                        try
                        {
                            byte[] ascii = Encoding.ASCII.GetBytes(conv);

                            ascii_lbl.Text = string.Join(" ", ascii.Where(x => ((int)x) < 127));
                        }
                        catch
                        {
                            ascii_lbl.Text = "Can't convert";
                        }
                    }
                }
                catch
                {
                    ascii_lbl.Text = "Can't convert";
                }
            }
        }

        private void OctConversions()
        {
            string convert = convert_text_box.Text;

            if (convert_cbx.SelectedIndex == 0)
            {
                if (oct_with_spaces_checkbox.Checked == false)
                {
                    if (convert_text_box.Text == "")
                    {
                        oct_lbl.Text = "";
                    }
                    else
                    {
                        try
                        {
                            var s = convert
                            .Select(c => Convert.ToInt32(c))
                            .Select(v => Convert.ToString(v, 8))
                            .Aggregate((v0, v1) => $"{v0} {v1}");
                            oct_lbl.Text = s.Replace(" ", "");
                        }
                        catch
                        {
                            oct_lbl.Text = "Can't convert";
                        }
                    }
                }
                else if (oct_with_spaces_checkbox.Checked == true)
                {
                    if (convert_text_box.Text == "")
                    {
                        oct_lbl.Text = "";
                    }
                    else
                    {
                        try
                        {
                            var s = convert
                            .Select(c => Convert.ToInt32(c))
                            .Select(v => Convert.ToString(v, 8))
                            .Aggregate((v0, v1) => $"{v0} {v1}");
                            oct_lbl.Text = s;
                        }
                        catch
                        {
                            oct_lbl.Text = "Can't convert";
                        }
                    }
                }
            }

            else if (convert_cbx.SelectedIndex == 3)
            {
                string asciitotext = DecodeASCII(convert);

                if (oct_with_spaces_checkbox.Checked == false)
                {
                    if (convert_text_box.Text == "")
                    {
                        oct_lbl.Text = "";
                    }
                    else
                    {
                        try
                        {
                            var s = asciitotext
                            .Select(c => Convert.ToInt32(c))
                            .Select(v => Convert.ToString(v, 8))
                            .Aggregate((v0, v1) => $"{v0} {v1}");
                            oct_lbl.Text = s.Replace(" ", "");
                        }
                        catch
                        {
                            oct_lbl.Text = "Can't convert";
                        }
                    }
                }
                else if (oct_with_spaces_checkbox.Checked == true)
                {
                    if (convert_text_box.Text == "")
                    {
                        oct_lbl.Text = "";
                    }
                    else
                    {
                        try
                        {
                            var s = asciitotext
                            .Select(c => Convert.ToInt32(c))
                            .Select(v => Convert.ToString(v, 8))
                            .Aggregate((v0, v1) => $"{v0} {v1}");
                            oct_lbl.Text = s;
                        }
                        catch
                        {
                            oct_lbl.Text = "Can't convert";
                        }
                    }
                }
            }

            else if (convert_cbx.SelectedIndex == 4)
            {
                string conv = Base64ToString(convert);

                if (oct_with_spaces_checkbox.Checked == false)
                {
                    if (convert_text_box.Text == "")
                    {
                        oct_lbl.Text = "";
                    }
                    else
                    {
                        var s = conv
                        .Select(c => Convert.ToInt32(c))
                        .Select(v => Convert.ToString(v, 8))
                        .Aggregate((v0, v1) => $"{v0} {v1}");
                        oct_lbl.Text = s.Replace(" ", "");
                    }
                }
                else if (oct_with_spaces_checkbox.Checked == true)
                {
                    if (convert_text_box.Text == "")
                    {
                        oct_lbl.Text = "";
                    }
                    else
                    {
                        var s = conv
                        .Select(c => Convert.ToInt32(c))
                        .Select(v => Convert.ToString(v, 8))
                        .Aggregate((v0, v1) => $"{v0} {v1}");
                        oct_lbl.Text = s;
                    }
                }
            }
        }

        //

        //conversions
        private void textbox_TextChanged(object sender, EventArgs e)
        {

            ComboboxErr();
            string convert = convert_text_box.Text;

            //text
            if (convert_cbx.SelectedIndex == 0)
            {
                //to binary
                try
                {
                    BinaryConversions();
                }
                catch
                {
                    binary_lbl.Text = "Can't convert";
                }

                //to hex
                try
                {
                    HexConversion();
                }
                catch
                {
                    hex_lbl.Text = "Can't convert";
                }

                //to ascii
                try
                {
                    AsciiConversions();
                }
                catch
                {
                    ascii_lbl.Text = "Can't convert";
                }

                //to base64
                try
                {
                    base64_lbl.Text = StringToBase64(convert);
                }
                catch
                {
                    base64_lbl.Text = "Can't convert";
                }

                //to oct
                try
                {
                    OctConversions();
                }
                catch
                {
                    oct_lbl.Text = "Can't convert";
                }
            }

            //

            //binary
            if (convert_cbx.SelectedIndex == 1)
            {

                //to text
                try
                {
                    text_lbl.Text = BinaryToString(convert);
                }
                catch
                {
                    text_lbl.Text = "Can't convert";
                }

                //to hex
                try
                {
                    string binary = convert.Replace(" ", "");
                    StringBuilder result = new StringBuilder(binary.Length / 8 + 1);

                    int mod4Len = binary.Length % 8;
                    if (mod4Len != 0)
                    {
                        // pad to length multiple of 8
                        binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');
                    }

                    for (int i = 0; i < binary.Length; i += 8)
                    {
                        string eightBits = binary.Substring(i, 8);
                        result.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
                    }

                    hex_lbl.Text = result.ToString();
                }
                catch
                {
                    hex_lbl.Text = "Can't convert";
                }

                //to ASCII
                try
                {
                    AsciiConversions();
                }
                catch
                {
                    ascii_lbl.Text = "Can't convert";
                }

                //to base64
                try
                {
                    string conv = BinaryToString(convert);
                    base64_lbl.Text = StringToBase64(conv);
                }
                catch
                {
                    base64_lbl.Text = "Can't convert";
                }

                //oct
                try
                {
                    convert = convert.Replace(" ", "");
                    int binary = Convert.ToInt32(convert, 2);
                    oct_lbl.Text = Convert.ToString(binary, 8);
                }
                catch
                {
                    if (convert_text_box.Text == "")
                    {
                        oct_lbl.Text = "";
                    }
                    else
                    {
                        oct_lbl.Text = "Can't convert";
                    }
                }

            }
            //

            //hex
            if (convert_cbx.SelectedIndex == 2)
            {
                //to text
                try
                {
                    byte[] bytez = HexToString(convert);
                    text_lbl.Text = Encoding.ASCII.GetString(bytez);
                }
                catch
                {
                    text_lbl.Text = "Can't convert";
                }

                //to binary
                try
                {
                    string conv = convert.Replace(" ", "").Replace("0x", "").Replace("-", "");
                    string binarystring = String.Join(String.Empty,
                        conv.Select(
                            c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
                            )
                        );

                    binary_lbl.Text = binarystring;
                }
                catch
                {
                    binary_lbl.Text = "Can't convert";
                }

                //to ASCII
                try
                {
                    AsciiConversions();
                }
                catch
                {
                    ascii_lbl.Text = "Can't convert";
                }

                //to base64
                try
                {
                    byte[] data = ConvertFromStringToHex(convert.Replace(" ", "").Replace("0x", "").Replace("-", ""));
                    base64_lbl.Text = Convert.ToBase64String(data);
                }
                catch
                {
                    base64_lbl.Text = "Can't convert";
                }

                //oct
                try
                {
                    string octal = "";
                    convert = convert.Replace(" ", "").Replace("-", "").Replace("0x" , "");

                    for (int i = convert.Length; i > 0; i -= 6)
                    {
                        string threebyte;
                        if (i < 6)
                            threebyte = convert.Substring(0, convert.Length % 6);
                        else
                            threebyte = convert.Substring(i - 6, 6);

                        octal = Convert.ToString(Convert.ToInt32(threebyte, 16), 8) + octal;
                    }

                    oct_lbl.Text = octal;
                }
                catch
                {
                    oct_lbl.Text = "Can't convert";
                }
            }
            //

            //ASCII
            if (convert_cbx.SelectedIndex == 3)
            {
                //to text
                try
                {
                    text_lbl.Text = DecodeASCII(convert);
                }
                catch
                {
                    text_lbl.Text = "Can't convert";
                }

                //to binary
                try
                {
                    AsciiConversions();
                }
                catch
                {
                    binary_lbl.Text = "Can't convert";
                }

                //to hex
                try
                {
                    HexConversion();
                }
                catch
                {
                    hex_lbl.Text = "Can't convert";
                }

                //to base64
                try
                {
                    string asciitotext = DecodeASCII(convert);

                    base64_lbl.Text = StringToBase64(asciitotext);
                }
                catch
                {
                    base64_lbl.Text = "Can't convert";
                }

                //oct
                try
                {
                    OctConversions();
                }
                catch
                {
                    oct_lbl.Text = "Can't convert";
                }
            }
            //

            //base64
            if (convert_cbx.SelectedIndex == 4)
            {
                //to text
                try
                {
                    text_lbl.Text = Base64ToString(convert);
                }
                catch
                {
                    text_lbl.Text = "Can't convert";
                }

                //to binary
                try
                {
                    BinaryConversions();
                }
                catch
                {
                    binary_lbl.Text = "Can't convert";
                }

                //to hex
                try
                {
                    HexConversion();
                }
                catch
                {
                    hex_lbl.Text = "Can't convert";
                }

                //to ASCII
                try
                {
                    AsciiConversions();
                }
                catch
                {
                    ascii_lbl.Text = "Can't convert";
                }

                //oct
                try
                {
                    OctConversions();
                }
                catch
                {
                    oct_lbl.Text = "Can't convert";
                }
            }
            //

            //oct
            if (convert_cbx.SelectedIndex == 5)
            {
                //to text
                try
                {
                    byte[] bytez = convert.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(s => (byte)Convert.ToInt32(s, 8))
                                          .ToArray();

                    text_lbl.Text = Encoding.UTF8.GetString(bytez);
                }
                catch
                {
                    text_lbl.Text = "Can't convert";
                }

                //to binary
                try
                {
                    convert = convert.Replace(" ", "");
                    int tobinary = Convert.ToInt32(convert, 8);
                    binary_lbl.Text = Convert.ToString(tobinary, 2);
                }
                catch
                {
                    binary_lbl.Text = "Can't convert";
                }

                //to hex
                try
                {
                    convert = convert.Replace(" ", "");
                    int tobinary = Convert.ToInt32(convert, 8);
                    string binary = Convert.ToString(tobinary, 2);

                    StringBuilder result = new StringBuilder(binary.Length / 8 + 1);

                    int mod4Len = binary.Length % 8;
                    if (mod4Len != 0)
                    {
                        // pad to length multiple of 8
                        binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');
                    }

                    for (int i = 0; i < binary.Length; i += 8)
                    {
                        string eightBits = binary.Substring(i, 8);
                        result.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
                    }

                    hex_lbl.Text = result.ToString();
                }
                catch
                {
                    hex_lbl.Text = "Can't convert";
                }

                //to ASCII
                try
                {
                    AsciiConversions();
                }
                catch
                {
                    ascii_lbl.Text = "Can't convert";
                }

                //to base64
                try
                {
                    convert = convert_text_box.Text;
                    byte[] bytezz = convert.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                      .Select(ss => (byte)Convert.ToInt32(ss, 8))
                      .ToArray();

                    base64_lbl.Text = StringToBase64(Encoding.UTF8.GetString(bytezz));
                }
                catch
                {
                    base64_lbl.Text = "Can't convert";
                }
            }
        }

        //

        private void with_spaces_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            BinaryConversions();
        }

        private void with_dash_hex_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            HexConversion();
        }

        private void with_spaces_ascii_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            AsciiConversions();
        }

        private void oct_with_spaces_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            OctConversions();
        }

        private void copy_text_btn_Click(object sender, EventArgs e)
        {
            if (text_lbl.Text == "")
            {
                //
            }
            else
            {
                Clipboard.SetText(text_lbl.Text);
                copied_lbl.Text = "Copied text!";

                var t = new Timer();
                t.Interval = 1200;
                t.Tick += (s, en) =>
                {
                    copied_lbl.Text = "";
                    t.Stop();
                };
                t.Start();
            }
        }

        private void copy_binary_btn_Click(object sender, EventArgs e)
        {
            if (binary_lbl.Text == "")
            {
                //
            }
            else
            {
                Clipboard.SetText(binary_lbl.Text);
                copied_lbl.Text = "Copied text!";

                var t = new Timer();
                t.Interval = 1200;
                t.Tick += (s, en) =>
                {
                    copied_lbl.Text = "";
                    t.Stop();
                };
                t.Start();
            }
        }

        private void copy_hex_btn_Click(object sender, EventArgs e)
        {
            if (hex_lbl.Text == "")
            {
                //
            }
            else
            {
                Clipboard.SetText(hex_lbl.Text);
                copied_lbl.Text = "Copied text!";

                var t = new Timer();
                t.Interval = 1200;
                t.Tick += (s, en) =>
                {
                    copied_lbl.Text = "";
                    t.Stop();
                };
                t.Start();
            }
        }

        private void copy_ascii_btn_Click(object sender, EventArgs e)
        {
            if (ascii_lbl.Text == "")
            {
                //
            }
            else
            {
                Clipboard.SetText(ascii_lbl.Text);
                copied_lbl.Text = "Copied text!";

                var t = new Timer();
                t.Interval = 1200;
                t.Tick += (s, en) =>
                {
                    copied_lbl.Text = "";
                    t.Stop();
                };
                t.Start();
            }
        }

        private void copy_base64_btn_Click(object sender, EventArgs e)
        {
            if (base64_lbl.Text == "")
            {
                //
            }
            else
            {
                Clipboard.SetText(base64_lbl.Text);
                copied_lbl.Text = "Copied text!";

                var t = new Timer();
                t.Interval = 1200;
                t.Tick += (s, en) =>
                {
                    copied_lbl.Text = "";
                    t.Stop();
                };
                t.Start();
            }
        }

        private void copy_oct_btn_Click(object sender, EventArgs e)
        {
            if (oct_lbl.Text == "")
            {
                //
            }
            else
            {
                Clipboard.SetText(oct_lbl.Text);
                copied_lbl.Text = "Copied text!";

                var t = new Timer();
                t.Interval = 1200;
                t.Tick += (s, en) =>
                {
                    copied_lbl.Text = "";
                    t.Stop();
                };
                t.Start();
            }
        }

        private void copy_all_btn_Click(object sender, EventArgs e)
        {
            if (convert_cbx.SelectedIndex == 0)
            {
                string copyall = $@"Text: {convert_text_box.Text}
Binary: {binary_lbl.Text}
Hex: {hex_lbl.Text}
ASCII: {ascii_lbl.Text}
Base64: {base64_lbl.Text}
Octal: {oct_lbl.Text}";

                Clipboard.SetText(copyall);
                copied_lbl.Text = "Copied text!";

                var t = new Timer();
                t.Interval = 1200;
                t.Tick += (s, en) =>
                {
                    copied_lbl.Text = "";
                    t.Stop();
                };
                t.Start();
            }
            else if (convert_cbx.SelectedIndex == 1)
            {
                string copyall = $@"Text: {text_lbl.Text}
Binary: {convert_text_box.Text}
Hex: {hex_lbl.Text}
ASCII: {ascii_lbl.Text}
Base64: {base64_lbl.Text}
Octal: {oct_lbl.Text}";

                Clipboard.SetText(copyall);
                copied_lbl.Text = "Copied text!";

                var t = new Timer();
                t.Interval = 1200;
                t.Tick += (s, en) =>
                {
                    copied_lbl.Text = "";
                    t.Stop();
                };
                t.Start();
            }
            else if (convert_cbx.SelectedIndex == 2)
            {
                string copyall = $@"Text: {text_lbl.Text}
Binary: {binary_lbl.Text}
Hex: {convert_text_box.Text}
ASCII: {ascii_lbl.Text}
Base64: {base64_lbl.Text}
Octal: {oct_lbl.Text}";

                Clipboard.SetText(copyall);
                copied_lbl.Text = "Copied text!";

                var t = new Timer();
                t.Interval = 1200;
                t.Tick += (s, en) =>
                {
                    copied_lbl.Text = "";
                    t.Stop();
                };
                t.Start();
            }
            else if (convert_cbx.SelectedIndex == 3)
            {
                string copyall = $@"Text: {text_lbl.Text}
Binary: {binary_lbl.Text}
Hex: {hex_lbl.Text}
ASCII: {convert_text_box.Text}
Base64: {base64_lbl.Text}
Octal: {oct_lbl.Text}";

                Clipboard.SetText(copyall);
                copied_lbl.Text = "Copied text!";

                var t = new Timer();
                t.Interval = 1200;
                t.Tick += (s, en) =>
                {
                    copied_lbl.Text = "";
                    t.Stop();
                };
                t.Start();
            }
            else if (convert_cbx.SelectedIndex == 4)
            {
                string copyall = $@"Text: {text_lbl.Text}
Binary: {binary_lbl.Text}
Hex: {hex_lbl.Text}
ASCII: {ascii_lbl.Text}
Base64: {convert_text_box.Text}
Octal: {oct_lbl.Text}";

                Clipboard.SetText(copyall);
                copied_lbl.Text = "Copied text!";

                var t = new Timer();
                t.Interval = 1200;
                t.Tick += (s, en) =>
                {
                    copied_lbl.Text = "";
                    t.Stop();
                };
                t.Start();
            }
            else if (convert_cbx.SelectedIndex == 5)
            {
                string copyall = $@"Text: {text_lbl.Text}
Binary: {binary_lbl.Text}
Hex: {hex_lbl.Text}
ASCII: {ascii_lbl.Text}
Base64: {base64_lbl.Text}
Octal: {convert_text_box.Text}";

                Clipboard.SetText(copyall);
                copied_lbl.Text = "Copied text!";

                var t = new Timer();
                t.Interval = 1200;
                t.Tick += (s, en) =>
                {
                    copied_lbl.Text = "";
                    t.Stop();
                };
                t.Start();
            }
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/riccio333/0x-Converter");
        }
    }
}