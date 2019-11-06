using System;
namespace TSMApp
{
    public class Knoop
    {
        private int x;           //horizontale coordinaat, van links naar rechts
        private int y;           //verticale coordinaat, van boven naar beneden
        private int voorganger;  //tbv bepalen route  indexnummer vorige knoop
        private int opvolger;    //tbv bepalen route  indexnummer volgende knoop

        public Knoop(int xc, int yc)
        {
            this.x = xc;
            this.y = yc;
            this.voorganger = -1;
            this.opvolger = -1;
        }

        public void setX(int xc)
        {
            this.x = xc;
        }

        public void setY(int yc)
        {
            this.y = yc;
        }

        public void setVoorganger(int vg)
        {
            this.voorganger = vg;
        }
        public void setOpvolger(int opv)
        {
            this.opvolger = opv;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public int getOpvolger()
        {
            return this.opvolger;
        }

        public int getVoorganger()
        {
            return this.voorganger;
        }

    }
}