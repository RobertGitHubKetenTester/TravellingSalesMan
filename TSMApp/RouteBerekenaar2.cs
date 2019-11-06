using System;

namespace TSMApp
{
    public class RouteBerekenaar2
    {

        //The Nearest Neighbor Algorithm is probably the most intuitive of all TSP algorithms.
        //First, one chooses a node to start from.
        //one goes to the node being the closest to the current node. 
        //Naturally, one must always head at nodes, which have not been visited throughout the tour.
        //This step is repeated until no more node is available.
        //Afterwards, one returns to the starting node. 

        public RouteBerekenaar2()
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

            //eerst vanuit startpunt verbinding leggen naar dichtsbijzijnde punt
            int afstandZijde = 0;
            int minlengte = 32000; //bewust zeer hoge waarde
            int index_kandidaatOpvolger = 0;

            for (int i = 1; i <= knopenGen.Length - 1; i++)
            {
                afstandZijde = Afstandsberekenaar.BerekenAfstand2Knopen(knopenGen[0], knopenGen[i]);
                if (afstandZijde < minlengte)
                {
                    minlengte = afstandZijde;
                    index_kandidaatOpvolger = i;
                }
            }
            knopenGen[0].setOpvolger(index_kandidaatOpvolger);
            knopenGen[index_kandidaatOpvolger].setVoorganger(0);
            //eerste verbinding gelegd

            knopenGen[0].setVoorganger(999); //tijdelijk blokkeren startknoop voor koppeling in volgende stuk

            knopenNew[0] = new Knoop(knopenGen[0].getX(), knopenGen[0].getY());
            knopenNew[1] = new Knoop(knopenGen[index_kandidaatOpvolger].getX(), knopenGen[index_kandidaatOpvolger].getY());
            int newindex = 1;

            int actueel = index_kandidaatOpvolger;
            index_kandidaatOpvolger = 0;
            int aantalIncompleet = 0;
            int indexIncompleet = 0;
            bool ketenincompleet = true;
            while (ketenincompleet)
            {

                minlengte = 32000;
                bool kandidaat_gevonden = false;
                for (int i = 1; i <= knopenGen.Length - 1; i++)
                {
                    if (i != actueel)
                    {
                        if (knopenGen[i].getVoorganger() == -1)
                        {
                            afstandZijde = Afstandsberekenaar.BerekenAfstand2Knopen(knopenGen[i], knopenGen[actueel]);
                            if (afstandZijde < minlengte)
                            {

                                minlengte = afstandZijde;
                                index_kandidaatOpvolger = i;
                                kandidaat_gevonden = true;
                            }
                        }
                    }

                }
                if (kandidaat_gevonden)
                {
                    knopenGen[actueel].setOpvolger(index_kandidaatOpvolger);
                    knopenGen[index_kandidaatOpvolger].setVoorganger(actueel);
                    actueel = index_kandidaatOpvolger;

                    //bouw geleidelijk de uitvoerarray verder op
                    newindex = newindex + 1;
                    knopenNew[newindex] = new Knoop(knopenGen[index_kandidaatOpvolger].getX(), knopenGen[index_kandidaatOpvolger].getY());
                }
                //check of alles een opvolger heeft
                ketenincompleet = false;
                aantalIncompleet = 0;
                for (int j = 1; j <= knopenGen.Length - 1; j++)
                {
                    if (knopenGen[j].getOpvolger() == -1)
                    {
                        ketenincompleet = true;
                        indexIncompleet = j;
                        aantalIncompleet = aantalIncompleet + 1;
                    }
                }
                //voorkom loopen als er nog maar 1 knoop over is, die moet naar 0
                if (aantalIncompleet == 1)
                {
                    //laatste knoop knopen aan starpunt
                    knopenGen[indexIncompleet].setOpvolger(0);
                    knopenGen[0].setVoorganger(indexIncompleet);
                    ketenincompleet = false;
                    //geen element meer aan knopennew toevoegen                   
                }
            }

            return knopenNew;
        }

       
    }
}