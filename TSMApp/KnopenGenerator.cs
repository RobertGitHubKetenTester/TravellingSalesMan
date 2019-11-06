
namespace TSMApp
{
    public class KnopenGenerator
    {
        //genereer coordinaten van de knopen
        //eerste coordinaat naar rechts, tussen 50 en 1050
        //tweede coordinaat omlaag, tussen 300 en 1650
        public Knoop[] GeneerKnopen(int aantalKnopen)
        {
            Knoop[] knopen_gen = new Knoop[aantalKnopen];

            System.Random rnd = new System.Random();
            for (int i = 0; i <= aantalKnopen - 1; i++)
            {
                knopen_gen[i] = (new Knoop(rnd.Next(50, 1050), rnd.Next(300, 1650)));
            }
            return knopen_gen;
        }
    }
}