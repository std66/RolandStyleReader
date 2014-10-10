using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArrangerDemo {
    public class CustomProgressBar : UserControl {
        public CustomProgressBar() {
            InitializeComponent();
        }

        //private változók
        private int pVal = 50; //Azért 50% a kezdő érték, hogy a designerben lehessen látni a színét is
        private int pMin = 0;
        private int pMax = 100;

        //public változók
        public int Value {
            get {
                return pVal;
            }

            set {
                //Hibát dob, ha az érték nincs a megfelelő értéken belül
                if (value < pMin | value > pMax)
                    throw new Exception("The current value must be between minimum and maximum value.");
                else {
                    pVal = value;
                    Draw(); //Mivel megváltozott az értéke újra kell rajzolni
                }
            }
        }

        public int Minimum {
            get {
                return pMin;
            }

            set {
                if (value >= pMax)
                    throw new Exception("The minimum value can't be lower or equal to the maximum.");
                pMin = value;
            }
        }

        public int Maximum {
            get {
                return pMax;
            }

            set {
                if (value <= pMin)
                    throw new Exception("The maximum value can't be bigger or equal to the minimum.");
                else
                    pMax = value;
            }
        }
        
        //Ennyi a megrajzolás
        private void Draw() {
            Draw(this.CreateGraphics());
        }
        private void Draw(Graphics g) {
            g.FillRectangle(new SolidBrush(this.BackColor), 1, 1, this.Width - 2, this.Height - 2);
            g.FillRectangle(new SolidBrush(this.ForeColor), 2, 2, (int)Math.Floor(((double)this.Width - 4) * (((double)pVal - (double)pMin) / (double)pMax)), this.Height - 4);
        }

        protected override void OnPaint(PaintEventArgs e) {
			if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, this.ClientRectangle);
            Draw(e.Graphics);
        }

        //Automatikusan generált
        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // CustomProgressBar
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ForeColor = System.Drawing.Color.Green;
            this.Name = "CustomProgressBar";
            this.Size = new System.Drawing.Size(200, 20);
            this.ResumeLayout(false);

        }
    }
}
