
using System;

namespace TSMApp
{
    public class RouteBerekenaar1
    {
        public RouteBerekenaar1()
        {
        }

        public Knoop[] ZoekRoute(Knoop[] knopenGen)
        {
            for (int i = 0; i <= knopenGen.Length - 1; i++)
            {
                knopenGen[i].setVoorganger(-1);
                knopenGen[i].setOpvolger(-1);
            }


            Knoop[] knopenNew = new Knoop[knopenGen.Length];
            //draag invoerwaarde rechtstreeks aan uitvoerwaarde over

            for (int i = 0; i <= knopenGen.Length - 1; i++)
            {
                knopenNew[i] = new Knoop(knopenGen[i].getX(), knopenGen[i].getY());
            }

            //alleen brute force voor alles berekenen bij max 10 punten, daarna te lange rekenduur
            if (knopenGen.Length > 11)
            {
                return knopenNew;
            }

            //bij max 11 knopen brute force: alle mogelijkheden berekenen
            //maak even grote integerarray minus startelement
            int[] permutatieArray = new int[knopenGen.Length-1];
            for (int i=1; i<= knopenGen.Length-1;i++)
            {
                permutatieArray[i-1] = i;
            }
            int minlengte = 32000;
            perm(permutatieArray, knopenGen.Length-1, 0);

            return knopenNew;


            void perm(int[] s, int n, int i)
            {
                int tussen = 0;
                if (i >= n - 1)
                {
                    //klaar met een permutatie, bereken lengte van traject
                    Knoop[] tijdelijk = new Knoop[knopenGen.Length];
                    tijdelijk[0]= new Knoop(knopenGen[0].getX(), knopenGen[0].getY());
                    for (int z=1; z<= s.Length; z++)
                    {
                        tijdelijk[z] = new Knoop(knopenGen[s[z-1]].getX(), knopenGen[s[z-1]].getY());
                    }

                    int actueleLengte= Afstandsberekenaar.BerekenRouteLengte(tijdelijk);
                    if (actueleLengte < minlengte)
                    {
                        minlengte = actueleLengte;
                        for (int q = 0; q <= knopenGen.Length - 1; q++)
                        {
                            knopenNew[q].setX(tijdelijk[q].getX());
                            knopenNew[q].setY(tijdelijk[q].getY());
                        }
                    }
                }
                else
                {
                    perm(s, n, i + 1);
                    for (int j = i + 1; j < n; j++)
                    {
                        tussen = s[i];
                        s[i] = s[j];
                        s[j] = tussen;
                        perm(s, n, i + 1);
                        tussen = s[i];
                        s[i] = s[j];
                        s[j] = tussen;
                    }
                }
            }
        }
    }
}