using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AviaMediator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
             g = this.CreateGraphics();
             c = new ConcreteMediator(airplan, helicopter);
        }
        Graphics g;
        Airplane airplan = new Airplane();
        Helicopter helicopter = new Helicopter();
        ConcreteMediator c;
        private void button1_Click(object sender, EventArgs e)
        {
            BaseAircraft.g = g;
            airplan.messageView = textBox2;
            helicopter.messageView = textBox3;
            airplan.Posadka();
        }
    }
}
