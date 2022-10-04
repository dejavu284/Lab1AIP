using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1AIP
{
    public partial class Form1 : Form
    {
        int[] Xs = new int[10000];
        int[] Ys = new int[10000];
        int i = 0;
        bool flag = false;

        int playerX = 100;
        int Y1 = 0;

        int h1 = 50;
        int w1 = 50;
        


        int X2 = 0;
        int Y2 = 0;

        int h2 = 25*20;
        int w2 = 25*10;

        bool bottom = true;
        bool up_block = true;
        int speed = 50;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Создание объекта, на котором будем рисовать
            Graphics g = e.Graphics;

            //Создание маркера, который рисует
            Pen pen1 = new Pen(Color.Black, 3);
            Pen pen2 = new Pen(Color.Green, 3);

            if (!bottom || !up_block)
            {
                Xs[i] = playerX;
                Ys[i] = Y1;
                Y1 = 13;
                playerX = 100;
                i++;
                flag = true;
            }
            g.DrawRectangle(pen1, playerX, Y1, w1, h1);
            if (flag) for (int j = 0; j < i; j++)
            {
                g.DrawRectangle(pen1, Xs[j], Ys[j], w1, h1);
            }
            g.DrawRectangle(pen2, X2, Y2, w2, h2);//обводка
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int key = e.KeyChar;
            if (37 != key && 39 != key) timer1.Enabled = !timer1.Enabled;

        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int key = e.KeyValue;
            if (key == 37)
            {
                if (playerX - X2 > speed) playerX -= speed;
                else playerX -= (playerX - X2);
            }

            if (key == 39)
            {
                if ((X2 + w2) - (playerX + w1) > speed) playerX += speed;
                else playerX += ((X2 + w2) - (playerX + w1));
            }

            if (key == 40)
            {
                if ((Y2 + h2) - (Y1 + h1) < speed) Y1 += ((Y2 + h2) - (Y1 + h1));
                else Y1 += speed;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Ys[0] != 0)
            {
                for (int f = i - 1; f >= 0; f--)
                {
                    if (playerX + w1 > Xs[f] && playerX < Xs[f] + w1)
                    {
                        if (Y1 + h1 >= Ys[f])
                        {
                            up_block = false;
                            Y1 = Ys[f] - h1;
                            break;
                        }
                        else up_block = true;
                    }
                    else up_block = true;
                } 
            }
            if (Y1 + h1 >= Y2 + h2) bottom = false;
            else bottom = true;
            if (bottom && up_block)
            {
                if ((Y2 + h2) - (Y1 + h1) < speed) Y1 += ((Y2 + h2) - (Y1 + h1));
                else Y1 += speed;
            }
            else if (!bottom) Y1 = Y2 + h2 - h1;
            if (Y1 <= Y2)
            {
                label1.Visible = true;
            }
            this.Invalidate();




























            //this.Invalidate();
            ////          Удар о правый край окна
            //if (X1 + wight1 >= this.ClientSize.Width) right = false;

            ////          Удар о левый край препядствия
            //if (X1 + wight1 == X2 && (Y1 + height1 >= Y2 && Y1 <= Y2 + heightstat)) right = false;
            //if (X1 + wight1 == X3 && (Y1 + height1 >= Y3 && Y1 <= Y3 + heightstat)) right = false;
            //if (X1 + wight1 == X4 && (Y1 + height1 >= Y4 && Y1 <= Y4 + heightstat)) right = false;
            //if (X1 + wight1 == X5 && (Y1 + height1 >= Y5 && Y1 <= Y5 + heightstat)) right = false;
            //if (X1 + wight1 == X6 && (Y1 + height1 >= Y6 && Y1 <= Y6 + heightstat)) right = false;

            ////          Удар о правый край препядствия
            //if (X1 == X2 + wightstat && (Y1 + height1 >= Y2 && Y1 <= Y2 + heightstat)) right = true;
            //if (X1 == X3 + wightstat && (Y1 + height1 >= Y3 && Y1 <= Y3 + heightstat)) right = true;
            //if (X1 == X4 + wightstat && (Y1 + height1 >= Y4 && Y1 <= Y4 + heightstat)) right = true;
            //if (X1 == X5 + wightstat && (Y1 + height1 >= Y5 && Y1 <= Y5 + heightstat)) right = true;
            //if (X1 == X6 + wightstat && (Y1 + height1 >= Y6 && Y1 <= Y6 + heightstat)) right = true;

            ////          Удар о левый край окна
            //if (X1 <= 0) right = true;

            //if (right) X1 += speed; else X1 -= speed;

            //this.Invalidate();

            ////          Удар о нижний край окна
            //if (Y1 + height1 >= this.ClientSize.Height) bottom = false;

            ////          Удар о левый край препядствия
            //if (Y1 + height1 == Y2 && (X1 + wight1 >= X2 && X1 <= X2 + wightstat)) bottom = false;
            //if (Y1 + height1 == Y3 && (X1 + wight1 >= X3 && X1 <= X3 + wightstat)) bottom = false;
            //if (Y1 + height1 == Y4 && (X1 + wight1 >= X4 && X1 <= X4 + wightstat)) bottom = false;
            //if (Y1 + height1 == Y5 && (X1 + wight1 >= X5 && X1 <= X5 + wightstat)) bottom = false;
            //if (Y1 + height1 == Y6 && (X1 + wight1 >= X6 && X1 <= X6 + wightstat)) bottom = false;

            ////          Удар о правый край препядствия
            //if (Y1 == Y2 + wightstat && (X1 + wight1 >= X2 && X1 <= X2 + wightstat)) bottom = true;
            //if (Y1 == Y3 + wightstat && (X1 + wight1 >= X3 && X1 <= X3 + wightstat)) bottom = true;
            //if (Y1 == Y4 + wightstat && (X1 + wight1 >= X4 && X1 <= X4 + wightstat)) bottom = true;
            //if (Y1 == Y5 + wightstat && (X1 + wight1 >= X5 && X1 <= X5 + wightstat)) bottom = true;
            //if (Y1 == Y6 + wightstat && (X1 + wight1 >= X6 && X1 <= X6 + wightstat)) bottom = true;

            ////          Удар о верхний край окна
            //if (Y1 <= 0) bottom = true;

            //if (bottom) Y1 += speed; else Y1 -= speed;

            //this.Invalidate();

            //if (X1 + wight1 >= this.ClientSize.Width) right = false;
            //if ((X1 + wight1 >= X2 && X1 <= X2 + wight2) && (Y1 + height1 >= Y2 && Y1 <= Y2 + height2)) right = false;
            //if ((X1 <= X2 + wight2 && X1 >= X2) && (Y1 + height1 >= Y2 && Y1 <= Y2 + height2)) right = true;
            //if (X1 <= 0) right = true;
            //if (right) X1++; else X1--;
            //this.Invalidate();

            //if (Y1 + height1 >= this.ClientSize.Height) bottom = false;
            //if ((Y1 + height1 >= Y2 && Y1 <= Y2 + height2) && (X1 + wight1 >= X2 && X1 <= X2 + wight2)) bottom = false;
            //if ((Y1 <= Y2 + wight2 && Y1 >= Y2) && (X1 + wight1 >= X2 && X1 <= X2 + wight2)) bottom = true;
            //if (Y1 <= 0) bottom = true;
            //if (bottom) Y1++; else Y1--;
            //this.Invalidate();
        }
    }
}
