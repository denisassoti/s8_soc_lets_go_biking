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
    public partial class SearchForm : Form
    {

        RoutingServiceClient routingService = new RoutingServiceClient();

        public SearchForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string depart = this.departTxt.Text;
            string arrivee = this.arriveeTxt.Text;
            if (depart != arrivee)
            {
                Itineraire it = routingService.GetItineraire(depart, arrivee);
                if (it == null)
                {
                    const string message = "Aucun itinéraire n'a été trouvé. \n Assurez-vous que les adresses renseignées se trouvent dans des villes disposants de vélos JcDecaux";
                    const string caption = "Information";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Information);
                }
                else
                {
                    new ItineraireForm(depart, arrivee, it).ShowDialog();
                }
            }
            else
            {
                const string message = "Les adresses renseignées sont identiques";
                const string caption = "Erreur";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Error);
            }

        }

        private void SearchForm_Load(object sender, EventArgs e)
        {

        }
    }
}
