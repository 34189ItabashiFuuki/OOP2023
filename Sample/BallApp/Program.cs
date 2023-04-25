﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class Program :Form{

        private Timer moveTimer; //タイマー用
        private SoccerBall soccerBall;
        private TennisBall tennisBall;
        private PictureBox pb;
        private PictureBox Pb;
        private int count;

        private List<SoccerBall> balls = new List<SoccerBall>(); //ボールインスタンス格納用
        private List<TennisBall> Balls = new List<TennisBall>(); 
        private List<PictureBox> pbs = new List<PictureBox>(); //表示用
        private List<PictureBox> Pbs = new List<PictureBox>(); //表示用

        static void Main(string[] args) {
            Application.Run(new Program());
        }   
           
        public Program() {
            this.Size = new Size(800,600);
            this.BackColor = Color.Green;
            this.Text = "ballgame:";
            this.MouseClick += Program_MouseClick;
            moveTimer = new Timer();
            moveTimer.Interval = 1; //タイマーのインターバル
            moveTimer.Tick += MoveTimer_Tick; //デリゲート登録
        }
        //マウスクリック時のイベントハンドラ
        private void Program_MouseClick(object sender, MouseEventArgs e) {
            //ボールインスタンス生成
            if (e.Button == MouseButtons.Left){
                soccerBall = new SoccerBall(e.X-25,e.Y-25);
                pb = new PictureBox(); //画像を表示をコントロール
                pb.Image = soccerBall.Image;
                pb.Location = new Point((int)soccerBall.PosX, (int)soccerBall.PosY); //画像の位置
                pb.Size = new Size(50, 50); //画像の表示サイズ
                pb.SizeMode = PictureBoxSizeMode.StretchImage; //画像の表示モード
                pb.Parent = this;
                balls.Add(soccerBall);
                pbs.Add(pb);
                moveTimer.Start();　//タイマースタート
            }
            else if(e.Button == MouseButtons.Right) {
                tennisBall = new TennisBall(e.X - 25, e.Y - 25);
                Pb = new PictureBox(); //画像を表示をコントロール
                Pb.Image = tennisBall.Image;
                Pb.Location = new Point((int)tennisBall.PosX, (int)tennisBall.PosY); //画像の位置
                Pb.Size = new Size(25, 25); //画像の表示サイズ
                Pb.SizeMode = PictureBoxSizeMode.StretchImage; //画像の表示モード
                Pb.Parent = this;
                Balls.Add(tennisBall);
                Pbs.Add(Pb);
                moveTimer.Start();　//タイマースタート
            }
            count += 1;
            this.Text = "ballgame:" + count;
        }
       
        //タイマータイムアウト時のイベントハンドラ
        private void MoveTimer_Tick(object sender,EventArgs e) {
            for (int i = 0; i < balls.Count; i++){
                balls[i].Move(); //移動
                pbs[i].Location = new Point((int)balls[i].PosX, (int)balls[i].PosY); //画像の位置
            }
            for (int j = 0; j < Balls.Count; j++){
                Balls[j].Move(); //移動
                Pbs[j].Location = new Point((int)Balls[j].PosX, (int)Balls[j].PosY); //画像の位置
            }
        } 
    }
}
