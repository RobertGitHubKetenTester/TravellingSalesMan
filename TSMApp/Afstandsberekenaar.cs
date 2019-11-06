namespace TSMApp
{
    public class Afstandsberekenaar
    {
        // BerekenRouteLengte berekent de totale lengte van een route
        // BerekenAfstand2Knopen berekent de lengte van een traject tussen twee knopen
        // als invoer dienen twee of meer knoopunten, in niet-grafische vorm
        public static int BerekenRouteLengte(Knoop[] knopen_calc)
        {
            int totale_afstand = 0;
            int afstandZijde = 0;
            for (int i = 0; i <= knopen_calc.Length - 2; i++)
            {
                //bereken afstand van actuele tot volgende knoop
                afstandZijde = BerekenAfstand2Knopen(knopen_calc[i], knopen_calc[i + 1]);
                totale_afstand = totale_afstand + afstandZijde;
            }
            //en afstand van laatste tot startknoop
            afstandZijde = BerekenAfstand2Knopen(knopen_calc[knopen_calc.Length - 1], knopen_calc[0]);
            totale_afstand = totale_afstand + afstandZijde;

            return totale_afstand;
        }

        public static int BerekenAfstand2Knopen(Knoop knoopVan, Knoop knoopTot)
        {
            int dx = System.Math.Abs(knoopTot.getX() - knoopVan.getX());
            int dy = System.Math.Abs(knoopTot.getY() - knoopVan.getY());
            //voorkom te grote integers
            double wortel = System.Math.Sqrt((dx * dx) + (dy * dy));
            //converteer terug naar int
            return System.Convert.ToInt32(System.Math.Floor(wortel));
        }
    }
}