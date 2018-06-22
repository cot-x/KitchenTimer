using System;
using System.Windows.Forms;
using System.Drawing;

namespace KitchenTimer
{
    /// <summary>
    /// 境界線を持たないフォームです。
    /// </summary>
    /// <remarks>
    /// 左クリックでの移動、右クリックでの終了メニューの表示をサポートします。
    /// </remarks>
    public class NoBorderForm : Form
    {
        public NoBorderForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;

            MenuItem[] menuItems =
                {
                    new MenuItem("終了(&X)", new EventHandler(menu_Exit))
                };
            this.ContextMenu = new ContextMenu(menuItems);
        }

        private void menu_Exit(object sender, EventArgs e)
        {
            Close();
        }

        private bool isLeftButtonDown = false;
        private Point movingPoint;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown (e);
            if(e.Button == MouseButtons.Left)
            {
                Capture = true;
                isLeftButtonDown = true;
                movingPoint = new Point(e.X, e.Y);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp (e);
            if(e.Button == MouseButtons.Left)
            {
                Capture = false;
                isLeftButtonDown = false;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove (e);
            if(isLeftButtonDown)
            {
                Point screenPoint = PointToScreen(new Point(e.X, e.Y));
                this.Location = new Point(screenPoint.X - movingPoint.X, screenPoint.Y - movingPoint.Y);
            }
        }
    }
}
