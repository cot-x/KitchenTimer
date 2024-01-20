using System;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

namespace KitchenTimer
{
    /// <summary>
    /// 指定時間を受け取り、タイマーを起動するフォームです。
    /// </summary>
    public class TimerStarter : NoBorderForm
    {
        private const string FormName = "きっちんたいま～";
        private const double opacity = 0.8;
        private NumericUpDown minuteSelector = new NumericUpDown();
        private Label labelMinute = new Label();
        private Button startButton = new Button();
        private Timer timer;

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="color">フォームの色を指定します。これは、タイマーにも使われます。</param>
        public TimerStarter(Color color)
        {
            this.SuspendLayout();

            this.Text = FormName;
            this.Icon = new Icon(Assembly.GetExecutingAssembly().GetManifestResourceStream("KitchenTimer.Main.ico"));
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.BackColor = color;
            this.Opacity = opacity;

            minuteSelector.Bounds = new Rectangle(6, 5, 34, minuteSelector.PreferredHeight);
            minuteSelector.Minimum = 1;
            minuteSelector.Maximum = 99;
            minuteSelector.Value = 5;
            minuteSelector.KeyDown += new KeyEventHandler(minuteSelector_KeyDown);
            this.Controls.Add(minuteSelector);

            labelMinute.Text = "分 DE";
            labelMinute.Bounds = new Rectangle(minuteSelector.Bounds.Right, minuteSelector.Bounds.Top, labelMinute.PreferredWidth, minuteSelector.Height);
            labelMinute.TextAlign = ContentAlignment.BottomCenter;
            labelMinute.MouseDown += new MouseEventHandler(labelMinute_MouseDown);
            this.Controls.Add(labelMinute);

            startButton.Text = "すた～と";
            startButton.Bounds = new Rectangle(labelMinute.Bounds.Right+5, 4, 64, 20);
            startButton.Click += new EventHandler(startButton_Click);
            this.Controls.Add(startButton);

            this.ClientSize = new Size(startButton.Bounds.Right+6, startButton.Bounds.Height+10);

            this.ResumeLayout();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer = new Timer(this.BackColor);
            timer.SetTimer((uint)minuteSelector.Value, 0);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Closed += new EventHandler(timer_Closed);
            this.Visible = false;
            timer.Visible = true;
            timer.Start();
        }

        private void minuteSelector_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return)
                startButton.PerformClick();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            MessageBox.Show(this, minuteSelector.Value.ToString() + "分経過しました！",
                this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void timer_Closed(object sender, EventArgs e)
        {
            Close();
        }

        private void labelMinute_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);
            point = labelMinute.PointToScreen(point);
            point = this.PointToClient(point);
            this.OnMouseDown(new MouseEventArgs(e.Button, e.Clicks, point.X, point.Y, e.Delta));
        }
    }
}
