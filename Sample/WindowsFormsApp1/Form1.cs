﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btButton_Click(object sender, EventArgs e) {
            //int ans = int.Parse(tbNum1.Text) + int.Parse(tbNum2.Text);
            //tbAns.Text = ans.ToString();

            int num1 = int.Parse(tbNum1.Text);
            int num2 = int.Parse(tbNum2.Text);
            int sum = num1 + num2;
            tbAns.Text = sum.ToString();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void tbNum1_TextChanged(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }
        //イベントハンドラ
        private void btPow_Click(object sender, EventArgs e) {
            //int num1 = Decimal.ToInt32(mudX.Value);
            //int num2 = Decimal.ToInt32(mudY.Value);
            //int power = num1;
            //for (int i = 0; i < num2 - 1; i++)
            //{
            //    power = power * num1;
            //}
            //tbResult.Text = power.ToString();

            tbResult.Text = (Math.Pow((double)mudX.Value, (double)mudY.Value)).ToString();
           
        }
    }
}
