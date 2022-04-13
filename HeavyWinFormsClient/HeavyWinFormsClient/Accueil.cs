namespace HeavyWinFormsClient
{
    public partial class Accueil : Form
    {
        public Accueil()
        {
            InitializeComponent();
        }

        private void ggToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // this.Dispose();
            new StatistiqueForm().ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void hhhToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // this.Dispose();
            new SearchForm().ShowDialog();
        }
    }
}