using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reference;

namespace HeavyWinFormsClient
{
    public partial class MapsForm : Form
    {
        Itineraire itineraire;
        public MapsForm(Itineraire itineraire)
        {
            this.itineraire = itineraire;
            InitializeComponent();
        }

        private void MapsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
