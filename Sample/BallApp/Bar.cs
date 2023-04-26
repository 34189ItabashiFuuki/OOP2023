using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class Bar : Obj {
    
        public Bar(double xp, double yp) : base(350,400,@"pic\bar.png") {
            base.MoveX = 70;
            base.MoveY = 0;
        }
        //抽象クラスを継承しているので、不要なメソッドは空にする
        public override void Move(PictureBox pbBar, PictureBox pbBall) {
            ;//空のメソッドにする
        }
        public override void Move( Keys direction ) {
            if(direction == Keys.Right){
                if (PosX < 635){
                    PosX += MoveX;
                }
            }
            if (direction == Keys.Left){
                if (PosX > 0){
                    PosX -= MoveX;
                }
            }
           
        }
        
    }
}
