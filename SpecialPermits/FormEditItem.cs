using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecialPermits
{
    public partial class FormEditItem : Form
    {
        public FormEditItem()
        {
            InitializeComponent();
        }

        public int TicketsForMonster
        {
            get { return (int)numericTickets.Value; }
            set { numericTickets.Value = value;     }
        }

        public string NameOfMonster
        {
            set { labelMonster.Text = value; }
        }

        private void FormEditItem_Load(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
