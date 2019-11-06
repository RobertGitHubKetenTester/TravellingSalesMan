using Android.App;
using Android.Widget;
using Android.OS;

namespace TSMApp
{
    [Activity(Label = "Travelling Salesman", MainLauncher = true, Icon = "@drawable/Salesman")]
    public class MainActivity : Activity
    {
        private int aantalKnopen = 6;  //aantal bij starten app
        Button _route1Button;          //standaard route, gebaseerd op volgorde van plaatsen punten
        Button _route2Button;          //route gebaseerd op steeds kortste afstand zoeken
        Button _minButton;             //verminderen aantal betrokken knopen
        Button _plusButton;            //verhogen aantal betrokken knopen
        TextView _aantalTextveld;      //tonen aantal betrokken knopen
        TextView _lengteTextveld;      //tonen totale lengte van een route

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            Knoop[] knopen_gen; //  coordinaten, random gegenereerd

            _aantalTextveld = FindViewById<TextView>(Resource.Id.nknopen);
            //toon de startwaarde 6
            _aantalTextveld.Text = aantalKnopen.ToString();

            //totale lengte van de route
            _lengteTextveld = FindViewById<TextView>(Resource.Id.lengte);

            _minButton = FindViewById<Button>(Resource.Id.minButton);
            if (aantalKnopen == 6)
            {
                _minButton.Enabled = false;
            }

            _minButton.Click += (sender, e) =>
            {
                if (aantalKnopen ==11)
                {
                    aantalKnopen = aantalKnopen - 3;
                }
                else
                {
                    aantalKnopen = aantalKnopen - 2;
                }
                _aantalTextveld.Text = aantalKnopen.ToString();
                if (aantalKnopen == 6)
                {
                    _minButton.Enabled = false;
                }
                if (aantalKnopen < 25)
                {
                    _plusButton.Enabled = true;
                }

                knopen_gen = GenereerKnopen(aantalKnopen);
                TekenKnopen(knopen_gen);
                _lengteTextveld.Text = "";
            };

            _plusButton = FindViewById<Button>(Resource.Id.plusButton);
            _plusButton.Click += (sender, e) =>
            {
                if (aantalKnopen==8)
                {
                    aantalKnopen = aantalKnopen + 3;
                }
                else
                {
                    aantalKnopen = aantalKnopen + 2;
                }
                _aantalTextveld.Text = aantalKnopen.ToString();
                if (aantalKnopen > 6)
                {
                    _minButton.Enabled = true;
                }
                if (aantalKnopen == 25)
                {
                    _plusButton.Enabled = false;
                }

                knopen_gen = GenereerKnopen(aantalKnopen);
                TekenKnopen(knopen_gen);
                _lengteTextveld.Text = "";
            };


            _route1Button = FindViewById<Button>(Resource.Id.route1Button);
            _route2Button = FindViewById<Button>(Resource.Id.route2Button);
            _lengteTextveld = FindViewById<TextView>(Resource.Id.lengte);

            //genereren en tekenen punten bij opstarten app, alle schermelementen zijn gevonden
            knopen_gen = GenereerKnopen(aantalKnopen);
            TekenKnopen(knopen_gen);
            _lengteTextveld.Text = ""; //schoonmaken na eventuele vorige routeronde

            //einde initiele acties bij opstarten app

            //bereken en teken de gevonden route
            _route1Button.Click += (sender, e) => {
                Knoop[] knopen_calc = new Knoop[aantalKnopen];
                knopen_calc = BerekenRoute1(knopen_gen);
                TekenRoute(knopen_gen, knopen_calc);

                //toon de lengte van de route
                _lengteTextveld.Text = GeefTotaleAfstand(knopen_calc).ToString();
            };

            //bereken en teken de gevonden route volgens slimmer algoritme
            _route2Button.Click += (sender, e) => {
                Knoop[] knopen_calc = new Knoop[aantalKnopen];
                knopen_calc = BerekenRoute2(knopen_gen);
                TekenRoute(knopen_gen, knopen_calc);

                //toon de lengte van de route
                _lengteTextveld.Text = GeefTotaleAfstand(knopen_calc).ToString();
            };
        }

        Knoop[] GenereerKnopen(int aantalKnopen)
        {
            Knoop[] knopen = new Knoop[aantalKnopen];
            KnopenGenerator KG = new KnopenGenerator();
            knopen = KG.GeneerKnopen(aantalKnopen);
            return knopen;
        }
        void TekenKnopen(Knoop[] knopen_gen)
        {
            //teken de gegenereerde knopen
            var puntenKaart = new PuntenTekenaar(this);
            puntenKaart.Knopen = knopen_gen;
            LinearLayout anotherLayout = new LinearLayout(this);
            LinearLayout.LayoutParams linearLayoutParams =
            new LinearLayout.LayoutParams(
               LinearLayout.LayoutParams.WrapContent,
                LinearLayout.LayoutParams.WrapContent);
            AddContentView(puntenKaart, linearLayoutParams);
        }

        void TekenRoute(Knoop[] knopen_gen, Knoop[] knopen_calc)
        {
            var routeKaart = new RouteTekenaar(this);
            routeKaart.Knopen = knopen_gen; //tbv opnieuw tekenen knopen

            //gebruik de knopen uit een routeberekening om de grafische punten te bepalen
            routeKaart.RouteKnopen = knopen_calc; //tbv tekenen route
            LinearLayout anotherLayout = new LinearLayout(this);
            LinearLayout.LayoutParams linearLayoutParams =
             new LinearLayout.LayoutParams(
             LinearLayout.LayoutParams.WrapContent,
               LinearLayout.LayoutParams.WrapContent);
            AddContentView(routeKaart, linearLayoutParams);
        }

        Knoop[] BerekenRoute1(Knoop[] knopen_gen)
        {
            RouteBerekenaar1 RB1 = new RouteBerekenaar1();
            Knoop[] knopen_calc = RB1.ZoekRoute(knopen_gen);  //knopen_calc wordt gebruikt in TekenRoute
            return knopen_calc;
        }

        Knoop[] BerekenRoute2(Knoop[] knopen_gen)
        {
            RouteBerekenaar2 RB2 = new RouteBerekenaar2();
            Knoop[] knopen_calc = RB2.ZoekRoute(knopen_gen);
            return knopen_calc;
        }

        int GeefTotaleAfstand(Knoop[] knopen_calc)
        {
            return Afstandsberekenaar.BerekenRouteLengte(knopen_calc);
        }
    }
}

