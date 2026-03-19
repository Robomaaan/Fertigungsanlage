namespace Fertigungsanlage
{
    public abstract class Werkzeug
    {
        private static int naechsteId = 1;

        private int id;
        private string bezeichner;
        private string art;
        protected int verschleiss;

        public int ID
        {
            get { return id; }
        }

        public string Bezeichner
        {
            get { return bezeichner; }
        }

        public string Art
        {
            get { return art; }
        }

        public int Verschleiss
        {
            get { return verschleiss; }
        }

        public Werkzeug(string art, int verschleiss)
        {
            id = naechsteId++;
            this.art = art;
            bezeichner = art + "_" + id;
            this.verschleiss = BegrenzeVerschleiss(verschleiss);
        }

        protected void ErhoeheVerschleiss(int wert)
        {
            verschleiss = BegrenzeVerschleiss(verschleiss + wert);
        }

        private int BegrenzeVerschleiss(int wert)
        {
            if (wert < 0)
            {
                return 0;
            }

            if (wert > 100)
            {
                return 100;
            }

            return wert;
        }

        public abstract string ausgeben();
        public abstract void arbeiten();
    }
}