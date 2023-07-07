using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //管理用データ
        BindingList<CarReport> CarReports = new BindingList<CarReport>();
      
        public Form1() {
            InitializeComponent();
            dgvCarReports.DataSource = CarReports;
        }
       
        //追加ボタンがクリックされた時のイベントハンドラー
        private void btAddReport_Click(object sender, EventArgs e) {
            var CarReport = new CarReport
            {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = getSelectedMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                CarImage = pbCarImage.Image
            };
            CarReports.Add(CarReport);
            dgvCarReports.DataSource = CarReports;
        }
        private CarReport.MakerGroup getSelectedMaker() {
            if(rbToyota.Checked == )

            return CarReport.MakerGroup.トヨタ;
        }
    }
}

/*private void label2_Click(object sender, EventArgs e) {

}

private void Form1_Load(object sender, EventArgs e) {

}

private void textBox1_TextChanged(object sender, EventArgs e) {

}

private void label7_Click(object sender, EventArgs e) {

}

private void button4_Click(object sender, EventArgs e) {

}

private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {

}

private void groupBox1_Enter(object sender, EventArgs e) {

}*/