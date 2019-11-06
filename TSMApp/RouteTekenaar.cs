namespace TSMApp
{
    using Android.Content;
    using Android.Graphics;
    using Android.Views;
    //eerst coordinaat rechts,min 50 max 1050,  tweede omlaag, min 300 max 100
    public class RouteTekenaar : View
    {
        //gegenereerde coordinaten van knooppunten, nodig om de knopen te hertekenen
        private Knoop[] knopen;
        public Knoop[] Knopen
        {
            get { return knopen; }
            set { knopen = value; }
        }
        //de gegenereerde knopen, grafisch, nodig om knopen te hertekenen
        private PointF[] _knopen;
        public PointF[] _Knopen
        {
            get { return _knopen; }
            set { _knopen = value; }
        }

        //de berekende routeknopen, coordinaten, om de lijnen te tekenen
        private Knoop[] routeknopen;
        public Knoop[] RouteKnopen
        {
            get { return routeknopen; }
            set { routeknopen = value; }
        }

        //de berekende routeknopen grafisch, om de lijnen te tekenen
        private PointF[] _routeknopen;
        public PointF[] _RouteKnopen
        {
            get { return _routeknopen; }
            set { _routeknopen = value; }
        }

        public RouteTekenaar(Context context)
            : base(context)
        {
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            //eerst schoonmaken eerdere acties
            SchoonCanvas sc = new SchoonCanvas(canvas);
            sc.doClear();

            //als eerste tekenen van de gegenereerde knopen
            _knopen = new PointF[knopen.Length];
            //hevel gegenereeerde coordinaten over naar grafische punten
            for (int i = 0; i <= knopen.Length - 1; i++)
            {
                _knopen[i] = (new PointF(knopen[i].getX(), knopen[i].getY()));
            }

            Paint knoopPaint = new Paint();
            knoopPaint.Color = Color.Red;
            knoopPaint.SetStyle(Paint.Style.Stroke);
            knoopPaint.StrokeWidth = 40;

            //teken eerste punt, rood
            canvas.DrawPoint(_knopen[0].X, _knopen[0].Y, knoopPaint);

            //teken overige punten
            knoopPaint.Color = Color.Yellow;
            knoopPaint.SetStyle(Paint.Style.Stroke);
            knoopPaint.StrokeWidth = 30;
            for (var i = 1; i < _knopen.Length; i++)
            {
                canvas.DrawPoint(_knopen[i].X, _knopen[i].Y, knoopPaint);
            }
            //einde tekenen gegenereerde knopen

            //tekenen berekende route
            //overhevelen coordinaten berekende knopen naar grafische knopen
            _routeknopen = new PointF[routeknopen.Length];
            for (int i = 0; i <= routeknopen.Length - 1; i++)
            {
                _routeknopen[i] = (new PointF(routeknopen[i].getX(), routeknopen[i].getY()));
            }

            //teken route, van startknoop tot tweede knoop, in rood
            var pathEerste = new Path();
            pathEerste.MoveTo(_routeknopen[0].X, _routeknopen[0].Y);
            pathEerste.LineTo(_routeknopen[1].X, _routeknopen[1].Y);

            var lijnPaint = new Paint
            {
                Color = Color.Red
            };

            lijnPaint.SetStyle(Paint.Style.Stroke);
            lijnPaint.StrokeWidth = 5;
            canvas.DrawPath(pathEerste, lijnPaint);

            //teken route, de rest vanaf tweede knoop
            var pathOverig = new Path();
            pathOverig.MoveTo(_routeknopen[1].X, _routeknopen[1].Y);
            for (var i = 2; i < _routeknopen.Length; i++)
            {
                pathOverig.LineTo(_routeknopen[i].X, _routeknopen[i].Y);
            }

            lijnPaint.Color = Color.White;
            lijnPaint.SetStyle(Paint.Style.Stroke);
            canvas.DrawPath(pathOverig, lijnPaint);

            //teken route, van laatste tot start knoop 
            var pathLaatste = new Path();
            pathLaatste.MoveTo(_routeknopen[_routeknopen.Length - 1].X, _routeknopen[_routeknopen.Length - 1].Y);
            pathLaatste.LineTo(_routeknopen[0].X, _routeknopen[0].Y);
            canvas.DrawPath(pathLaatste, lijnPaint);

        }

    }

}
