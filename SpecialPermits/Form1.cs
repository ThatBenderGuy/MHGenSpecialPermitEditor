using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SpecialPermits
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool hasChar1 = false;
        bool hasChar2 = false;
        bool hasChar3 = false;
        byte firstCharOffset = 0x10;
        byte secondCharOffset = 0x14;
        byte thirdCharOffset = 0x14;
        byte[] firstCharLocation;
        byte[] secondCharLocation;
        byte[] thirdCharLocation;
        byte[] firstChar;
        byte[] secondChar;
        byte[] thirdChar;
        byte slot1UsedOffset = 0x4;
        byte slot2UsedOffset = 0x5;
        byte slot3UsedOffset = 0x6;
        int offsetToPermits = 0x01497;
        int loadedChar = 0;
        string path;
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                BinaryReader br = new BinaryReader(File.OpenRead(path));
                br.BaseStream.Position = slot1UsedOffset;
                if (br.ReadByte() == 0x01)
                {
                    hasChar1 = true;
                    loadChar1.Enabled = true;
                    br.BaseStream.Position = 0x10;
                    firstCharLocation = br.ReadBytes(4);
                }
                br.BaseStream.Position = slot2UsedOffset;
                if (br.ReadByte() == 0x01)
                {
                    hasChar2 = true;
                    loadChar2.Enabled = true;
                    br.BaseStream.Position = 0x14;
                    secondCharLocation = br.ReadBytes(4);
                }
                br.BaseStream.Position = slot3UsedOffset;
                if (br.ReadByte() == 0x01)
                {
                    hasChar3 = true;
                    loadChar3.Enabled = true;
                    br.BaseStream.Position = 0x18;
                    thirdCharLocation = br.ReadBytes(4);
                }
                br.Dispose();

                if (hasChar1)
                {
                    maxAllTicketsToolStripMenuItem.Enabled = true;
                    listView1.Enabled = true;
                    loadCharTickets(firstCharLocation);
                    loadedChar = 0;
                }
                if (hasChar2 && !hasChar1)
                {
                    maxAllTicketsToolStripMenuItem.Enabled = true;
                    listView1.Enabled = true;
                    loadCharTickets(secondCharLocation);
                    loadedChar = 1;
                }
                if (hasChar3 && (!hasChar1 && !hasChar2)) 
                {
                    maxAllTicketsToolStripMenuItem.Enabled = true;
                    listView1.Enabled = true;
                    loadCharTickets(thirdCharLocation);
                    loadedChar = 2;
                }
            }
        }

        private void loadCharacter1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadCharTickets(firstCharLocation);
            loadedChar = 0;
        }


        public static string ByteArrayToString(byte[] ba)
        {    
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString().ToUpper();
        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static string CharArrayToString(char[] chars)
        {
            string rString = "";
            foreach (char c in chars)
            {
                rString += c;
            }
            return rString;
        }

        private int getTickets(byte[] loc, BinaryReader br, int offset)
        {
            int ticketLoc = BitConverter.ToInt32(loc, 0);
            br.BaseStream.Position = ticketLoc + offsetToPermits + offset;
            int tickets = br.ReadByte();
            return tickets;
        }

        private void loadCharTickets(byte[] charLoc)
        {
            BinaryReader br = new BinaryReader(File.OpenRead(path));
            br.BaseStream.Position = BitConverter.ToInt32(charLoc, 0);
            char[] charName = br.ReadChars(32);
            label_charName.Text = "Character Name: " + CharArrayToString(charName);
            listView1.Items[00].SubItems[1].Text = getTickets(charLoc, br, 0).ToString();
            listView1.Items[01].SubItems[1].Text = getTickets(charLoc, br, 1).ToString();
            listView1.Items[02].SubItems[1].Text = getTickets(charLoc, br, 2).ToString();
            listView1.Items[03].SubItems[1].Text = getTickets(charLoc, br, 3).ToString();
            listView1.Items[04].SubItems[1].Text = getTickets(charLoc, br, 4).ToString();
            listView1.Items[05].SubItems[1].Text = getTickets(charLoc, br, 5).ToString();
            listView1.Items[06].SubItems[1].Text = getTickets(charLoc, br, 6).ToString();
            listView1.Items[07].SubItems[1].Text = getTickets(charLoc, br, 7).ToString();
            listView1.Items[08].SubItems[1].Text = getTickets(charLoc, br, 8).ToString();
            listView1.Items[09].SubItems[1].Text = getTickets(charLoc, br, 9).ToString();
            listView1.Items[10].SubItems[1].Text = getTickets(charLoc, br, 10).ToString();
            listView1.Items[11].SubItems[1].Text = getTickets(charLoc, br, 11).ToString();
            br.Close();
        }
        private void saveCharTickets(byte[] charLoc)
        {
            BinaryWriter bw = new BinaryWriter(File.OpenWrite(path));
            bw.BaseStream.Position = BitConverter.ToInt32(charLoc, 0);
            int currentTicket = BitConverter.ToInt32(charLoc, 0);
            for(int i = 0; i < 12; i++)
            {
                currentTicket = BitConverter.ToInt32(charLoc, 0) + offsetToPermits + i;
                bw.BaseStream.Position = currentTicket;
                bw.Write(Convert.ToByte(listView1.Items[i].SubItems[1].Text));
            }
            bw.Close();
            MessageBox.Show("Saved Successfully");
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;


        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormEditItem editForm = new FormEditItem();
            editForm.Text = "Editing Tickets For: " + listView1.SelectedItems[0].Text;
            editForm.NameOfMonster = listView1.SelectedItems[0].Text;
            editForm.TicketsForMonster = Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text);
            editForm.StartPosition = FormStartPosition.CenterParent;
            if(editForm.ShowDialog() == DialogResult.OK)
            {
                listView1.SelectedItems[0].SubItems[1].Text = editForm.TicketsForMonster.ToString();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadedChar == 0)
                saveCharTickets(firstCharLocation);
            if (loadedChar == 1)
                saveCharTickets(secondCharLocation);
            if (loadedChar == 2)
                saveCharTickets(thirdCharLocation);
        }

        private void loadChar2_Click(object sender, EventArgs e)
        {
            loadCharTickets(secondCharLocation);
            loadedChar = 1;
        }

        private void loadChar3_Click(object sender, EventArgs e)
        {
            loadCharTickets(thirdCharLocation);
            loadedChar = 2;
        }

        private void maxAllTicketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listView1.Items)
            {
                item.SubItems[1].Text = 99.ToString();
            }
        }
    }
}
