namespace Drawing
{
    public partial class Form1 : Form
    {
        Graphics gr;
        Pen pen;
        bool isPainting;
        Point startPos;
        Point endPos;
        ColorDialog colorDialog;
        public Form1()
        {
            InitializeComponent();
            gr = panel1.CreateGraphics();
            pen = new Pen(Color.Red, 10);
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            colorDialog = new();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isPainting = true;
            startPos = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isPainting = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPainting)
            {
                endPos = new Point(e.X, e.Y);
                gr.DrawLine(pen, startPos, endPos);
                startPos = endPos;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog.Color;
            }
        }
    }
}
