using Android.Content;
using Android.Graphics;
using Android.Views;

namespace TSMApp
{

    public class PuntenTekenaar : View
    {
        //de gegenereerde knopen, coordinaten
        private Knoop[] knopen;
        public Knoop[] Knopen
        {
            get { return knopen; }
            set { knopen = value; }
        }

        //de gegenereerde knopen, grafisch
        private PointF[] _knopen;
        public PointF[] _Knopen
        {
            get { return _knopen; }
            set { _knopen = value; }
        }


        public PuntenTekenaar(Context context)
            : base(context)
        {
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            //eerst schoonmaken eerdere acties
            SchoonCanvas cc = new SchoonCanvas(canvas);
            cc.doClear();

            _knopen = new PointF[knopen.Length];
            //hevel gegenereerde coordinaten over naar grafische punten
            for (int i = 0; i <= knopen.Length - 1; i++)
            {
                _knopen[i] = (new PointF(knopen[i].getX(), knopen[i].getY()));
            }


            //bepaal kleur en dikte
            Paint mPaint = new Paint();
            mPaint.Color = Color.Red;
            mPaint.SetStyle(Paint.Style.Stroke);
            mPaint.StrokeWidth = 30;

            //eerste punt, rood
            canvas.DrawPoint(_knopen[0].X, _knopen[0].Y, mPaint);

            //teken overige punten
            mPaint.Color = Color.Yellow;
            mPaint.SetStyle(Paint.Style.Stroke);
            mPaint.StrokeWidth = 20;
            for (var i = 1; i < _knopen.Length; i++)
            {
                canvas.DrawPoint(_knopen[i].X, _knopen[i].Y, mPaint);
            }

        }

    }
}