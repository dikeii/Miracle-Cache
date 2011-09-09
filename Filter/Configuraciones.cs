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

        public bool sinFiltro()
        {
            bool devuelve = radioButton1.Checked;
            return devuelve;
        }

        public bool filtroPorP()
        {
            bool devuelve = radioButton2.Checked;
            return devuelve;
        }

        public bool filtroPorPIP()
        {
            bool devuelve = radioButton3.Checked;
            return devuelve;
        }

        public Configuraciones()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                radioButton1.Checked = true;                       
        }

    }
}
