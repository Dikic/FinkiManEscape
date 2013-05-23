using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FinkiManEscape
{
    class Kopce:Button
    {
        private Color gradientTop = Color.FromArgb(255, 44, 85, 177);
        private Color gradientBottom = Color.FromArgb(255, 153, 198, 241);
        private Rectangle buttonRect;
        private int highlightAlphaTop = 255;
        private int highlightAlphaBottom;
        private Rectangle highlightRect;
        private Timer animateMouseOverTimer = new Timer();
        private Timer animateResumeNormalTimer = new Timer();
        private bool increasingAlpha;


        public Color GradientTop
        {
            get
            {
                return gradientTop;
            }
            set
            {
                gradientTop = value;
                Invalidate();
            }
        }
        public Color GradientBottom
        {
            get
            {
                return gradientBottom;
            }
            set
            {
                gradientBottom = value;
                Invalidate();
            }
        }

        protected override void OnCreateControl()
        {
            SuspendLayout();
            base.OnCreateControl();
            buttonRect = new Rectangle(ClientRectangle.X, ClientRectangle.Y,
      ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            highlightRect = new Rectangle(ClientRectangle.X, ClientRectangle.Y,
      ClientRectangle.Width - 1, ClientRectangle.Height / 2 - 1);
            animateMouseOverTimer.Interval = 20;
            animateMouseOverTimer.Tick += new EventHandler(animateMouseOverTimer_Tick);
            animateResumeNormalTimer.Interval = 5;
            animateResumeNormalTimer.Tick += new EventHandler(animateResumeNormalTimer_Tick);
            ResumeLayout();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            // Fill the background
            ButtonRenderer.DrawParentBackground(g, ClientRectangle, this);
            // Paint the outer rounded rectangle
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath outerPath = RoundedRectangle(buttonRect, 5, 0))
            {
                using (LinearGradientBrush outerBrush =
        new LinearGradientBrush(buttonRect, gradientTop, gradientBottom, LinearGradientMode.Vertical))
                {
                    g.FillPath(outerBrush, outerPath);
                }
                using (Pen outlinePen = new Pen(gradientTop))
                {
                    g.DrawPath(outlinePen, outerPath);
                }
            }
            // Paint the highlight rounded rectangle
            using (GraphicsPath innerPath = RoundedRectangle(highlightRect, 5, 2))
            {
                using (LinearGradientBrush innerBrush = new LinearGradientBrush(highlightRect,
        Color.FromArgb(highlightAlphaTop, Color.White), Color.FromArgb(highlightAlphaBottom, Color.White),
        LinearGradientMode.Vertical))
                {
                    g.FillPath(innerBrush, innerPath);
                }
            }
            // Paint the text
            TextRenderer.DrawText(g, Text, Font, buttonRect, ForeColor, Color.Transparent,
      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        private static GraphicsPath RoundedRectangle(Rectangle boundingRect, int cornerRadius, int margin)
        {
            GraphicsPath roundedRect = new GraphicsPath();
            roundedRect.AddArc(boundingRect.X + margin, boundingRect.Y + margin,
      cornerRadius * 2, cornerRadius * 2, 180, 90);
            roundedRect.AddArc(boundingRect.X + boundingRect.Width - margin - cornerRadius * 2,
      boundingRect.Y + margin, cornerRadius * 2, cornerRadius * 2, 270, 90);
            roundedRect.AddArc(boundingRect.X + boundingRect.Width - margin - cornerRadius * 2,
      boundingRect.Y + boundingRect.Height - margin - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            roundedRect.AddArc(boundingRect.X + margin, boundingRect.Y + boundingRect.Height -
      margin - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            roundedRect.CloseFigure();
            return roundedRect;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            animateResumeNormalTimer.Stop();
            animateMouseOverTimer.Start();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            animateMouseOverTimer.Stop();
            animateResumeNormalTimer.Start();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            animateMouseOverTimer.Stop();
            animateResumeNormalTimer.Stop();
            highlightRect.Location = new Point(0, ClientRectangle.Height / 2);
            highlightAlphaTop = 0;
            highlightAlphaBottom = 200;
            Invalidate();
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            highlightRect.Location = new Point(0, 0);
            highlightAlphaTop = 255;
            highlightAlphaBottom = 0;
            if (DisplayRectangle.Contains(mevent.Location))
            {
                animateMouseOverTimer.Start();
            }
            base.OnMouseUp(mevent);
        }

        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            if ((mevent.Button & MouseButtons.Left) == MouseButtons.Left &&
      !ClientRectangle.Contains(mevent.Location))
            {
                OnMouseUp(mevent);
            }
            base.OnMouseMove(mevent);
        }

        private void animateMouseOverTimer_Tick(object sender, EventArgs e)
        {
            if (increasingAlpha)
            {
                if (100 <= highlightAlphaBottom)
                {
                    increasingAlpha = false;
                }
                else
                {
                    highlightAlphaBottom += 5;
                }
            }
            else
            {
                if (0 >= highlightAlphaBottom)
                {
                    increasingAlpha = true;
                }
                else
                {
                    highlightAlphaBottom -= 5;
                }
            }
            Invalidate();
        }

        private void animateResumeNormalTimer_Tick(object sender, EventArgs e)
        {
            bool modified = false;
            if (highlightAlphaBottom > 0)
            {
                highlightAlphaBottom -= 5;
                modified = true;
            }
            if (highlightAlphaTop < 255)
            {
                highlightAlphaTop += 5;
                modified = true;
            }
            if (!modified)
            {
                animateResumeNormalTimer.Stop();
            }
            Invalidate();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
