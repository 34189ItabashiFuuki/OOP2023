using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    class TennisBall : Obj {
        private static int count;
        Random random = new Random(); //乱数インスタンス
        
        //コンストラクタ
        public TennisBall (double xp, double yp) : base(xp, yp, @"pic\tennis_ball.png") { 
            int rndX = random.Next(-25, 25);
            MoveX = (rndX != 0 ? rndX : 1);
            int rndY = random.Next(-25, 25);
            MoveY = (rndY != 0 ? rndY : 1);
            count++;
        }
        //メソッド
        public override void Move() {
            PosX += MoveX;
            PosY += MoveY;
            if (PosX > 730 || PosX < 0) { MoveX *= -1; }
            if (PosY > 500 || PosY < 0) { MoveY *= -1; }
        }
    }
}
