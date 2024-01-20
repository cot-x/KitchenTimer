using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace KitchenTimer
{
    /// <summary>
    /// 時間をカウントダウンするフォームです。
    /// </summary>
    public class Timer : NoBorderForm
    {
        /// <summary>
        /// カウンタが0になると発生します。
        /// </summary>
        public event EventHandler Tick;

        private readonly FontFamily familyName = new FontFamily("MS UI Gothic");
        private const int fontStyle = (int)FontStyle.Bold;
        private const float emSize = 32;
        private const double opacity = 0.5;

        private uint minute = 0, second = 0;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="color">タイマーの色を指定します。</param>
        public Timer(Color color)
        {
            this.SuspendLayout();
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Opacity = opacity;
            this.BackColor = color;
            this.Size = Graphics.FromImage(new Bitmap(1,1)).MeasureString("00:00", new Font(familyName, emSize, (FontStyle)fontStyle)).ToSize();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Size.Width, Size.Height);
            this.Enabled = false;
            UpdateTimer();
            this.ResumeLayout();

            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        /// <summary>
        /// 時間を設定します。
        /// </summary>
        /// <param name="minute">分を指定します。0～99までの整数を指定できます。</param>
        /// <param name="second">秒を指定します。0～59までの整数を指定できます。</param>
        /// <exception cref="ArgumentException">範囲外の数値が渡された時にスローします。</exception>
        public void SetTimer(uint minute, uint second)
        {
            if(minute > 99 || second > 59)
            {
                throw new ArgumentException();
            }

            this.minute = minute;
            this.second = second;
            UpdateTimer();
        }

        /// <summary>
        /// タイマーをスタートします。
        /// </summary>
        public void Start()
        {
            this.Enabled = true;
        }

        /// <summary>
        /// タイマーをストップします。
        /// </summary>
        public void Stop()
        {
            this.Enabled = false;
        }

        /// <value>
        /// タイマーの色を設定します。
        /// </value>
        public Color Color
        {
            set
            {
                this.BackColor = value;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(this.Enabled)
            {
                if(second > 0)
                {
                    second--;
                }
                else if(minute > 0)
                {
                    minute--;
                    second = 59;
                }
            }
            UpdateTimer();

            if(this.Enabled && minute==0 && second==0)
                Tick(this, new EventArgs());
        }

        private void UpdateTimer()
        {
            this.TopMost = true;    // 常にZレベルを最上位にする。
            GraphicsPath path = new GraphicsPath();
            string time = minute.ToString().PadLeft(2, '0') + ':' + second.ToString().PadLeft(2, '0');
            path.AddString(time, familyName, fontStyle, emSize, new Point(0, 0), StringFormat.GenericDefault);
            this.Region = new Region(path);
        }
    }
}
