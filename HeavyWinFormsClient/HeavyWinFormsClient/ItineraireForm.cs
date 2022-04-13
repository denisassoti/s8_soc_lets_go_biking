using Reference;

namespace HeavyWinFormsClient
{
    public partial class ItineraireForm : Form
    {
        private Itineraire itineraire;
        private string depart;
        private string arrivee;

        public ItineraireForm(string depart, string arrivee, Itineraire itineraire)
        {
            this.itineraire = itineraire;
            this.depart = depart;
            this.arrivee = arrivee;

            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ItineraireForm_Load(object sender, EventArgs e)
        {
            ListViewItem listItem = new ListViewItem();
            listItem.Text = this.itineraire.stationDepart;
            ListViewItem listItem2 = new ListViewItem();
            listItem2.Text = this.itineraire.stationArrivee;

            this.departTxt.Text = depart;
            this.arriveeTxt.Text = arrivee;
            this.stationDepartTxt.Text = itineraire.stationDepart;
            this.stationArriveeTxt.Text = itineraire.stationArrivee;

            //this.departStDpListView.Items.Add(listItem);
            //this.departStDpListView.Items.Add(listItem2);

            //list views 
            //depart - station depart 
            foreach (Step step in this.itineraire.depart_stationDepart.features[0].properties.segments[0].steps)
            {
                ListViewItem item = new ListViewItem();
                item.Text = step.instruction;
                item.SubItems.Add(step.name);
                item.SubItems.Add(step.duration+"");
                item.SubItems.Add(step.distance+"");
                this.departStDpListView.Items.Add(item);
            }

            //station depart - station d'arrivee
            foreach (Step step in this.itineraire.stationDepart_stationArrivee.features[0].properties.segments[0].steps)
            {
                ListViewItem item = new ListViewItem();
                item.Text = step.instruction;
                item.SubItems.Add(step.name);
                item.SubItems.Add(step.duration + "");
                item.SubItems.Add(step.distance + "");
                this.sdSaListView.Items.Add(item);
            }

            //station d'arrivee - arrivee
            foreach (Step step in this.itineraire.stationArrivee_arrivee.features[0].properties.segments[0].steps)
            {
                ListViewItem item = new ListViewItem();
                item.Text = step.instruction;
                item.SubItems.Add(step.name);
                item.SubItems.Add(step.duration + "");
                item.SubItems.Add(step.distance + "");
                this.saArriveeListView.Items.Add(item);
            }

        }

       private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
            new MapsForm(this.itineraire).ShowDialog();
        }
    }
}
