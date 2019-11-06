using Android.Graphics;

namespace TSMApp
{
    public class SchoonCanvas
    {
        private Canvas canvas;
        public SchoonCanvas(Canvas Canvas)
        {
            this.canvas = Canvas;
        }

        public void doClear()
        {
            var path = new Path();
            path.MoveTo(35, 285);
            path.LineTo(35, 1660);
            path.LineTo(1060, 1670);
            path.LineTo(1060, 285);
            path.LineTo(35, 285);
            var paint2 = new Paint
            {
                Color = Color.Black
            };

            paint2.SetStyle(Paint.Style.Fill);
            canvas.DrawPath(path, paint2);
        }
    }
}