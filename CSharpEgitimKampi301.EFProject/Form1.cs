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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.tblGuide.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tblGuide guide = new tblGuide();
            guide.GuideName = txtName.Text;
            guide.GuideSurname = txtSurname.Text;
            db.tblGuide.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Yeni rehber eklenmiştir.","Rehber Ekleme",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var removeValue = db.tblGuide.Find(id);
            db.tblGuide.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla silinmiştir.", "Rehber Silme", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updateValue = db.tblGuide.Find(id);
            updateValue.GuideName = txtName.Text;
            updateValue.GuideSurname = txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla güncellenmiştir.", "Rehber Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var values = db.tblGuide.Where(x => x.GuideId == id).ToList();
            //x=> öyleki anlamına gelir.
            dataGridView1.DataSource = values;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
