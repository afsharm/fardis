using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fardis.Audio;
using Fardis.Audio.Number;

namespace Fardis
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void rtbText_TextChanged(object sender, EventArgs e)
        {
            rtbText.Text = rtbText.Text[0].ToString();
            txtHex.Text = EncodingHelper.GetHex(rtbText.Text);
            txtDecimal.Text = EncodingHelper.GetDecimal(rtbText.Text).ToString();
            txtRoya.Text = rtbText.Text;
            txtTahoma.Text = rtbText.Text;
            txtArialU.Text = rtbText.Text;
            txtUnicodeName.Text = EncodingHelper.GetUnicodeName(rtbText.Text);
            txtCSharpRep.Text = EncodingHelper.GetCSharpRep(rtbText.Text[0]);
            string link = General.GenerateLink(rtbText.Text[0]);
            lnkSiteLink.Text = link;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            rtbString.Text = "";
            rtbString.Text += string.Format("Text length is {0}\n=====\n", txtString.Text.Length);
            for (byte b = 0; b < txtString.Text.Length; b++)
            {
                rtbString.Text += string.Format("«{0}» --> {1}, {2}\n-----\n\n", txtString.Text[b],
                    EncodingHelper.GetHex(txtString.Text[b]),
                    EncodingHelper.GetUnicodeName(txtString.Text[b]));
            }
            rtbString.Text += "=====\n";
        }

        private void lnkSiteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(((LinkLabel)sender).Text);
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            int number;
            if (int.TryParse(txtNumber.Text, out number) == false)
            {
                MessageBox.Show("Invalid Number");
                return;
            }

            var stream = PersianNumberRead.ReadPersianNumber(number, string.Empty);
            var player = new System.Media.SoundPlayer(stream);
            player.Play();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
