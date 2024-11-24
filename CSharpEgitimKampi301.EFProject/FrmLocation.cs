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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();


        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.tblGuide.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }).ToList() ;
            cmdGuide.DisplayMember = "FullName";
            cmdGuide.ValueMember = "GuideId";
            cmdGuide.DataSource = values;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.tblLocation.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tblLocation location = new tblLocation();
            location.Capacity = byte.Parse(nudCapacity.Value.ToString());
            location.City = txtCity.Text;
            location.Country = txtCountry.Text;
            location.Price = Decimal.Parse(txtPrice.Text);
            location.DayNight = txtDayNight.Text;
            location.GuideId = int.Parse(cmdGuide.SelectedValue.ToString());
            db.tblLocation.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme işlemi başarılı...");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deletedValue = db.tblLocation.Find(id);
            db.tblLocation.Remove(deletedValue);
            db.SaveChanges();
            MessageBox.Show("Silme işlemi başarılı...");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updatedValue = db.tblLocation.Find(id);
            updatedValue.DayNight = txtDayNight.Text;
            updatedValue.Price = int.Parse(txtPrice.Text);
            updatedValue.Capacity = byte.Parse(nudCapacity.Value.ToString());
            updatedValue.City = txtCity.Text;
            updatedValue.Country = txtCountry.Text;
            updatedValue.GuideId = int.Parse(cmdGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme işlemi başarılı...");
        }
    }
}
