using System;
using System.Collections.Generic;
using System.ComponentModel;
using Reference;
using IronXL;
using Syncfusion.Windows.Forms.Chart;
using System.Collections;
using Syncfusion.Drawing;

namespace HeavyWinFormsClient
{
    public partial class VilleStatistiquesForm : Form
    {
        RoutingServiceClient routingService = new RoutingServiceClient();
        List<Statistique> statistiques = null;
        string ville = string.Empty;

        public VilleStatistiquesForm(List<Statistique> s, string ville)
        {
            InitializeComponent();
            this.statistiques = s;
            this.ville = ville;
        }

        private void VilleStatistiquesForm_Load(object sender, EventArgs e)
        {
            this.label1.Text = ville;
            var groupByStation = from s in statistiques
                                 group s by s.stationName into g
                                 select new
                                 {
                                     Station = g.Key,
                                     NbreDepart = g.Count(x => x.usage == "DEPART"),
                                     NbreArrivee = g.Count(x => x.usage == "ARRIVEE")
                                 };

            var groupByDepartArrivee = from s in statistiques
                                       group s by s.usage into g
                                       select new
                                       {
                                           Usage = g.Key,
                                           Nbre = g.Count()
                                       };

            foreach (var item in groupByStation)
            {
                this.dataGridView1.Rows.Add(item.Station, item.NbreDepart, item.NbreArrivee);
            }

            /////CHART
            ArrayList populations = new ArrayList();
            foreach (var population in groupByDepartArrivee)
            {
                populations.Add(new PopulationData(population.Usage, population.Nbre));
                ChartTitle t1 = new ChartTitle();
                t1.Text = population.Nbre + " - " + population.Usage;
                this.chartControl1.Titles.Add(t1);
            }
            //this.chartControl1.Series[1].LegendName = "Arrivée";
            ChartSeries series = new ChartSeries("Populations", ChartSeriesType.Pie);
            ChartDataBindModel dataSeriesModel = new ChartDataBindModel(populations);
            dataSeriesModel.YNames = new string[] { "Population" };
            series.SeriesModel = dataSeriesModel;

            chartControl1.Series.Add(series);

            ChartDataBindAxisLabelModel xAxisLabelModel = new ChartDataBindAxisLabelModel(populations);

            this.chartControl1.Series[0].Style.DisplayText = true;
            this.chartControl1.Series[0].ConfigItems.PieItem.DoughnutCoeficient = 0.5f;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 2)
            {
                WorkBook workbook = WorkBook.Create(ExcelFileFormat.XLSX);
                var sheet = workbook.CreateWorkSheet("stats_" + ville);
                //headers
                sheet["A1"].Value = "Stations";
                sheet["B1"].Value = "Nbre de départs";
                sheet["C1"].Value = "Nbre d'arrivées";

                // sizes
                sheet["A1"].Style.Font.Bold = true;
                sheet["B1"].Style.Font.Bold = true;
                sheet["C1"].Style.Font.Bold = true;

                for (int i = 2; i <= dataGridView1.Rows.Count; i++)
                {
                    sheet["A" + i].Value = dataGridView1.Rows[i - 2].Cells[0].Value;
                    sheet["B" + i].Value = dataGridView1.Rows[i - 2].Cells[1].Value;
                    sheet["C" + i].Value = dataGridView1.Rows[i - 2].Cells[2].Value;
                }
                // Save Workbook
                workbook.SaveAs("stats_" + ville + ".xlsx");

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
    }
}
class PopulationData
{
    private string city;

    public string City
    {
        get { return city; }
        set { city = value; }
    }

    private double population;

    public double Population
    {
        get { return population; }
        set { population = value; }
    }

    public PopulationData(string city, double population)
    {
        this.city = city;
        this.population = population;
    }
}