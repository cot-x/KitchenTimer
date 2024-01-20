using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace KitchenTimer
{
    /// <summary>
    /// エントリーポイントです。
    /// </summary>
    public class WinMain
    {
        private static readonly Color DefaultColor = Color.White;

        [STAThread]
        public static void Main()
        {
            Color color = DefaultColor;
            try
            {
                StreamReader stream = File.OpenText("color.cfg");
                string colorName = stream.ReadLine();
                switch(colorName.ToUpper())
                {
                    case "BLUE":
                        color = Color.SkyBlue;
                        break;
                    case "BROWN":
                        color = Color.Brown;
                        break;
                    case "GRAY":
                        color = Color.Silver;
                        break;
                    case "GREEN":
                        color = Color.SpringGreen;
                        break;
                    case "ORANGE":
                        color = Color.Orange;
                        break;
                    case "PINK":
                        color = Color.Pink;
                        break;
                    case "RED":
                        color = Color.Red;
                        break;
                    case "WHITE":
                        color = Color.White;
                        break;
                    case "YELLOW":
                        color = Color.Yellow;
                        break;
                }
            }
            catch
            {
            }
            Application.Run(new TimerStarter(color));
        }
    }
}
