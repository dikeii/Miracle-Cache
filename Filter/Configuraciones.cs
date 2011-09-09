using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PacketMonitor.Filter
{
    public partial class Configuraciones : Form
    {
        public bool filtro1 { set; get; }
        public bool filtro2 { set; get; }
        public bool filtro3 { set; get; }

        public Configuraciones()
        {
            InitializeComponent();            
        }
        public void LoadConfig(bool _filtro1, bool _filtro2, bool _filtro3)
        {
            filtro1 = false;
            filtro2 = false;
            filtro3 = false;
            if (_filtro1)
                radioButton1.Checked = true;

            if (_filtro2)
                radioButton2.Checked = true;

            if (_filtro3)
                radioButton3.Checked = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                filtro1 = true;

            if (radioButton2.Checked)
                filtro2 = true;

            if (radioButton3.Checked)
                filtro3 = true;
        }

    }
}
