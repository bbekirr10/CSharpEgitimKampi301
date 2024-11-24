using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.tblLocation.Count().ToString();
            lblTotalCapacity.Text = db.tblLocation.Sum(x=>x.Capacity).ToString();
            lblGuideCount.Text = db.tblGuide.Count().ToString();
            lblAvgCapacity.Text = db.tblLocation.Average(x=>x.Capacity).ToString();
            decimal averageLocationPrice =decimal.Parse(db.tblLocation.Average(x=>x.Price).ToString());
            lblAvgLocationPrice.Text = Math.Round(averageLocationPrice, 2).ToString();

            int lastCountryId = db.tblLocation.Max(x => x.LocationId);
            lblLastCountry.Text = db.tblLocation.Where(x => x.LocationId == lastCountryId).Select(y=>y.Country).FirstOrDefault();

            lblCappadocia.Text = db.tblLocation.Where(x => x.City=="Kapadokya").Select(y=>y.Capacity).FirstOrDefault().ToString();
            lblTurkiyeLocationCapacityAverage.Text = db.tblLocation.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();

            var guideRomeId = db.tblLocation.Where(x => x.City == "Roma Turistlik").Select(y => y.GuideId).FirstOrDefault();
            lblRomeGuide.Text = db.tblGuide.Where(x=>x.GuideId==guideRomeId).Select(y=>y.GuideName+" "+y.GuideSurname).FirstOrDefault();

            var maxCapacityLocation = db.tblLocation.Max(x => x.Capacity);
            lblMaxCapacityLocation.Text = db.tblLocation.Where(x => x.Capacity == maxCapacityLocation).Select(y => y.City).FirstOrDefault();

            var maxPriceLocation = db.tblLocation.Max(x => x.Price);
            lblMaxPriceLocation.Text = db.tblLocation.Where(x => x.Price == maxPriceLocation).Select(y => y.City).FirstOrDefault();

            var guideBeyzaKara = db.tblGuide.Where(x => x.GuideName == "Beyza" && x.GuideSurname == "Kara").Select(y => y.GuideId).FirstOrDefault();
            lblBeyzaKara.Text = db.tblLocation.Where(x => x.GuideId == guideBeyzaKara).Count().ToString();

        }
    }
}
