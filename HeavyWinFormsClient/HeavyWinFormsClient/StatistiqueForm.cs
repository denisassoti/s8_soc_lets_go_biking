using Reference;
using IronXL;

namespace HeavyWinFormsClient
{
    public partial class StatistiqueForm : Form
    {

        RoutingServiceClient routingService = new RoutingServiceClient();
        List<Statistique> statistiques = null;

        public StatistiqueForm()
        {
            InitializeComponent();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void StatistiqueForm_Load(object sender, EventArgs e)
        {
            List<string> ville = routingService.GetContracts();
            foreach (string villeItem in ville)
            {
                villeComboBox.Items.Add(villeItem);
            }

            try
            {
                statistiques = routingService.GetStatistiques();
                //get statistiques from RoutingService
                foreach (Statistique statistique in statistiques)
                {
                    this.dataGridView1.Rows.Add(statistique.stationName, statistique.contractName, statistique.date.ToString(), statistique.usage);
                }

            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter("log.log", true))
                {
                    writer.WriteLine(ex.ToString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 2)
            {
                WorkBook workbook = WorkBook.Create(ExcelFileFormat.XLSX);
                var sheet = workbook.CreateWorkSheet("Statistiques");
                //headers
                sheet["A1"].Value = "Stations";
                sheet["B1"].Value = "Ville";
                sheet["C1"].Value = "Date";
                sheet["D1"].Value = "Usage";

                // sizes
                sheet["A1"].Style.Font.Bold = true;
                sheet["B1"].Style.Font.Bold = true;
                sheet["C1"].Style.Font.Bold = true;
                sheet["D1"].Style.Font.Bold = true;


                for (int i = 2; i <= dataGridView1.Rows.Count; i++)
                {
                    sheet["A" + i].Value = dataGridView1.Rows[i - 2].Cells[0].Value;
                    sheet["B" + i].Value = dataGridView1.Rows[i - 2].Cells[1].Value;
                    sheet["C" + i].Value = dataGridView1.Rows[i - 2].Cells[2].Value;
                    sheet["D" + i].Value = dataGridView1.Rows[i - 2].Cells[3].Value;

                }
                // Save Workbook
                workbook.SaveAs("stats_generales.xlsx");

                const string message = "Le fichier Excel a été généré avec succès !";
                const string caption = "Information";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Information);
            }
            else
            {
                const string message = "Le fichier Excel n'a pas pu etre généré !";
                const string caption = "Erreur";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (villeComboBox.SelectedItem != null)
            {
                string ville = villeComboBox.SelectedItem.ToString()!;
                List<Statistique> statistiques = this.statistiques.Where(s => s.contractName == ville).ToList();
                new VilleStatistiquesForm(statistiques, ville).ShowDialog();
            }
            else
            {
                const string message = "Veuillez selectionner la ville";
                const string caption = "Erreur";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Error);
            }
        }
    }
}
