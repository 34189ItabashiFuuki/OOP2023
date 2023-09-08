﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CarReportSystem {
    public partial class btConnection : Form {
        //管理用データ
        BindingList<CarReport> CarReports = new BindingList<CarReport>();
        private uint mode;

        //設定情報保存用オブジェクト
        Settings settings = Settings.getInstance();

        public btConnection() {
            InitializeComponent();
            //dgvCarReports.DataSource = CarReports;
        }

        private void statasLabelDisp(string msg = "") {
            //MessageBox.Show(msg);
            tsInfoText.Text = msg;
        }
        //追加ボタンがクリックされた時のイベントハンドラー
        private void btAddReport_Click(object sender, EventArgs e) {
            if (cbAuthor.Text.Equals("")) {
                tsInfoText.Text = "記録者を記録してください";
                return;
            }
            else if (cbCarName.Text.Equals("")) {
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
            setCbAuther(cbAuthor.Text); //記録者コンボボックスの履歴登録処理
            setCbCarName(cbCarName.Text); //車名コンボボックスの履歴登録処理

            CarReports.Add(CarReport);
            Clear(); //項目クリア処理
            btModifyReport.Enabled = true;
            btDeleteReport.Enabled = true;
        }
        //記録者コンボボックスの履歴登録処理
        private void setCbAuther(string auther) {
            if (!cbAuthor.Items.Contains(auther))
                cbAuthor.Items.Add(auther);
        }
        //車名コンボボックスの履歴登録処理
        private void setCbCarName(string carname) {
            if (!cbCarName.Items.Contains(carname))
                cbCarName.Items.Add(carname);
        }
        //項目クリア処理
        private void editItemsClear() {
            cbAuthor.Text = " ";
            setSelectedMaker("トヨタ");
            cbCarName.Text = " ";
            tbReport.Text = " ";
            pbCarImage.Image = null;

            dgvCarReports.ClearSelection();     //選択解除
            btModifyReport.Enabled = false;     //修正ボタン
            btDeleteReport.Enabled = false;     //削除ボタン
        }

        //ラジオボタンで選択されているメーカーを返却
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
        private void setSelectedMaker(string makerGroup) {
            switch (makerGroup) {
                case "トヨタ":
                    rbToyota.Checked = true;
                    break;
                case "日産":
                    rbNissan.Checked = true;
                    break;
                case "ホンダ":
                    rbHonda.Checked = true;
                    break;
                case "スバル":
                    rbSubaru.Checked = true;
                    break;
                case "スズキ":
                    rbSuzuki.Checked = true;
                    break;
                case "ダイハツ":
                    rbDaihatsu.Checked = true;
                    break;
                case "輸入車":
                    rbInported.Checked = true;
                    break;
                case "その他":
                    rbOther.Checked = true;
                    break;
            }
        }

        private void btImageOpen_Click(object sender, EventArgs e) {
            if (ofdImageFileOpen.ShowDialog() == DialogResult.OK)
                pbCarImage.Image = Image.FromFile(ofdImageFileOpen.FileName);
            pbCarImage.Image = Image.FromFile(ofdImageFileOpen.FileName);
        }

        private void btDeleteReport_Click(object sender, EventArgs e) {
            CarReports.RemoveAt(dgvCarReports.CurrentRow.Index);

            if (dgvCarReports.Rows.Count == 0) {
                btModifyReport.Enabled = false;
                btDeleteReport.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e) {


            tsInfoText.Text = ""; //情報表示領域のテキストを初期化
            tstimetext.Text = DateTime.Now.ToString("HH時mm分ss秒");
            timer.Start();

            dgvCarReports.RowsDefaultCellStyle.BackColor = Color.LightGreen;
            dgvCarReports.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite; //奇数行の色を上書き

            dgvCarReports.Columns[5].Visible = false; //画像項目非表示

            try {
                //設定ファイルを逆シリアル化して背景を設定
                using (var reader = XmlReader.Create("settings.xml")) {
                    var serializer = new XmlSerializer(typeof(Settings));
                    settings = serializer.Deserialize(reader) as Settings;
                    BackColor = Color.FromArgb(settings.MainFormColor);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvCarReports_Click(object sender, DataGridViewCellEventArgs e) {
            if (0 != dgvCarReports.RowCount) {
                dtpDate.Value = (DateTime)dgvCarReports.CurrentRow.Cells[1].Value;
                cbAuthor.Text = dgvCarReports.CurrentRow.Cells[2].Value.ToString();
                setSelectedMaker(dgvCarReports.CurrentRow.Cells[3].Value.ToString());
                cbCarName.Text = dgvCarReports.CurrentRow.Cells[4].Value.ToString();
                tbReport.Text = dgvCarReports.CurrentRow.Cells[5].Value.ToString();
                pbCarImage.Image = ByteArrayToImage((Byte[])dgvCarReports.CurrentRow.Cells[6].Value);
            }
        }

        //バイト配列をImageオブジェクトに変換
        public static Image ByteArrayToImage(byte[] b) {
            ImageConverter imgconv = new ImageConverter();
            Image img = (Image)imgconv.ConvertFrom(b);
            return img;
        }

        public static byte[] ImageToByteArray(Image img) {
            ImageConverter imgconv = new ImageConverter();
            byte[] b = (byte[])imgconv.ConvertTo(img, typeof(byte[]));
            return b;
        }

        private void btModifyReport_Click(object sender, EventArgs e) {
            this.Validate();
            this.carReportTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202320DataSet);

            dgvCarReports.CurrentRow.Cells[1].Value = dtpDate.Value;
            dgvCarReports.CurrentRow.Cells[2].Value = cbAuthor.Text;
            dgvCarReports.CurrentRow.Cells[3].Value = getSelectedMaker();
            dgvCarReports.CurrentRow.Cells[4].Value = cbCarName.Text;
            dgvCarReports.CurrentRow.Cells[5].Value = tbReport.Text;
            dgvCarReports.CurrentRow.Cells[6].Value = pbCarImage.Image;

            //if (dgvCarReports.Rows.Count != 0) {

            //    dgvCarReports.Refresh();    //一覧更新
            //}
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
            vf.ShowDialog(); //モーダルダイアログとして
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;
                settings.MainFormColor = cdColor.Color.ToArgb();
            }
        }

        private void btScaleChange_Click(object sender, EventArgs e) {
            mode = mode < 4 ? ((mode == 1) ? 3 : ++mode) : 0; //AutoSize(2)を除外
            pbCarImage.SizeMode = (PictureBoxSizeMode)mode++;
        }

        private void btImageDelete_Click(object sender, EventArgs e) {
            pbCarImage.Image = null;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {

            //設定ファイルのシリアル化
            using (var writer = XmlWriter.Create("settings.xml")) {
                var serializer = new XmlSerializer(settings.GetType());
                serializer.Serialize(writer, settings);

            }
        }

        private void timer_Tick(object sender, EventArgs e) {
            tstimetext.Text = DateTime.Now.ToString("HH時mm分ss秒");
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (sfdCarRepoSave.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル化
                    var bf = new BinaryFormatter();
                    using (FileStream fs = File.Open(sfdCarRepoSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, CarReports);
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
            if (ofdCarRepoOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //逆シリアル化でバイナリ形式を取り込む
                    var bf = new BinaryFormatter();
                    using (FileStream fs = File.Open(ofdCarRepoOpen.FileName, FileMode.Open, FileAccess.Read)) {
                        CarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvCarReports.DataSource = null;
                        dgvCarReports.DataSource = CarReports;

                        editItemsClear();
                        dgvCarReports.Columns[5].Visible = false;   //画像項目非表示
                        foreach (var carReport in CarReports) {
                            setCbAuther(carReport.Author);
                            setCbCarName(carReport.CarName);
                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void carReportTableBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            this.Validate();
            this.carReportTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202320DataSet);

        }
        //接続ボタン
        private void button1_Click(object sender, EventArgs e) {
            // TODO: このコード行はデータを 'infosys202320DataSet.CarReportTable' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.carReportTableTableAdapter.Fill(this.infosys202320DataSet.CarReportTable);
            dgvCarReports.ClearSelection(); //選択解除
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