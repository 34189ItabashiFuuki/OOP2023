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

        private void statasLabelDisp(string msg = "") {
            //MessageBox.Show(msg);
            tsInfoText.Text = msg;
        }
        //追加ボタンがクリックされた時のイベントハンドラー
        private void btAddReport_Click(object sender, EventArgs e) {
            if(cbAuthor.Text.Equals("")) {
                tsInfoText.Text = "記録者を記録してください";
                return;
            }else if(cbCarName.Text.Equals("")) {
                tsInfoText.Text = "車名を入力してください";
                return;
            }
            
            var CarReport = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = getSelectedMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                CarImage = pbCarImage.Image
            };
            CarReports.Add(CarReport);
            dgvCarReports.DataSource = CarReports;
            Clear();
            btModifyReport.Enabled = true;
            btDeleteReport.Enabled = true;
        }
        private CarReport.MakerGroup getSelectedMaker() {
            int tag = 0;
            foreach (var item in gbMaker.Controls) {
                if (((RadioButton)item).Checked) {
                    tag = int.Parse(((RadioButton)item).Tag.ToString());
                    break;
                }
            }
            return (CarReport.MakerGroup)tag;
            #region ほかのやり方
            /*if (rbToyota.Checked) {
                return CarReport.MakerGroup.トヨタ;
            }
            else if (rbNissan.Checked) {
                return CarReport.MakerGroup.日産;
            }
            else if (rbHonda.Checked) {
                return CarReport.MakerGroup.ホンダ;
            }
            else if (rbDaihatsu.Checked) {
                return CarReport.MakerGroup.ダイハツ;
            }
            else if (rbInported.Checked) {
                return CarReport.MakerGroup.輸入車;
            }
            else if (rbOther.Checked) {
                return CarReport.MakerGroup.その他;
            }
            else if (rbSubaru.Checked) {
                return CarReport.MakerGroup.スバル;
            }
            return CarReport.MakerGroup.スズキ;*/
            #endregion
        }
        //指定したメーカーのラジオボタンをセット
        private void setSelectedMaker(CarReport.MakerGroup makerGroup) {
            switch (makerGroup) {
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.スズキ:
                    rbSuzuki.Checked = true;
                    break;
                case CarReport.MakerGroup.ダイハツ:
                    rbDaihatsu.Checked = true;
                    break;
                case CarReport.MakerGroup.輸入車:
                    rbInported.Checked = true;
                    break;
                case CarReport.MakerGroup.その他:
                    rbOther.Checked = true;
                    break;
            }
        }

        private void btImageOpen_Click(object sender, EventArgs e) {
            ofdImageFileOpen.ShowDialog();
            pbCarImage.Image = Image.FromFile(ofdImageFileOpen.FileName);
        }

        private void btDeleteReport_Click(object sender, EventArgs e) {
            CarReports.RemoveAt(dgvCarReports.CurrentRow.Index);

            if (dgvCarReports.Rows.Count == 0)
            {
                btModifyReport.Enabled = false;
                btDeleteReport.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReports.Columns[5].Visible = false; //画像項目非表示

        }

        private void dgvCarReports_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            dtpDate.Value = (DateTime)dgvCarReports.CurrentRow.Cells[0].Value;
            cbAuthor.Text = dgvCarReports.CurrentRow.Cells[1].Value.ToString();
            setSelectedMaker((CarReport.MakerGroup)dgvCarReports.CurrentRow.Cells[2].Value);
            cbCarName.Text = dgvCarReports.CurrentRow.Cells[3].Value.ToString();
            tbReport.Text = dgvCarReports.CurrentRow.Cells[4].Value.ToString();
            pbCarImage.Image = (Image)dgvCarReports.CurrentRow.Cells[5].Value;
        }

        private void btModifyReport_Click(object sender, EventArgs e) {
            if (cbAuthor.Text.Equals("")) {
                tsInfoText.Text = "記録者を記録してください";
                return;
            }
            else if (cbCarName.Text.Equals("")) {
                tsInfoText.Text = "車名を入力してください";
                return;
            }
            if (dgvCarReports.Rows.Count != 0) {
                CarReports[dgvCarReports.CurrentRow.Index].Date = dtpDate.Value;
                CarReports[dgvCarReports.CurrentRow.Index].Author = cbAuthor.Text;
                CarReports[dgvCarReports.CurrentRow.Index].Maker = getSelectedMaker();
                CarReports[dgvCarReports.CurrentRow.Index].CarName = cbCarName.Text;
                CarReports[dgvCarReports.CurrentRow.Index].Report = tbReport.Text;
                dgvCarReports.Refresh();    //一覧更新
            }

        }

        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void Clear() {
            dtpDate.ResetText();
            cbAuthor.ResetText();
            cbCarName.ResetText();
            tbReport.ResetText();
            tbReport.ResetText();
            pbCarImage.Image = null;
            foreach (var item in gbMaker.Controls) {
                if (((RadioButton)item).Checked) {
                    ((RadioButton)item).Checked = false;
                }
            }

        }

        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e) {
            var vf = new VersionForm();
            vf.ShowDialog(); //モーダルダイヤログとして
        }
    }
}

/*private void label2_Click(object sender, EventArgs e) {

}

private void textBox1_TextChanged(object sender, EventArgs e) {

}

private void btImageDelete_Click(object sender, EventArgs e) {

}

private void label7_Click(object sender, EventArgs e) {

}

private void tsInfoText_Click(object sender, EventArgs e) {
            
}

private void button4_Click(object sender, EventArgs e) {

}

private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {

}

private void groupBox1_Enter(object sender, EventArgs e) {

}*/