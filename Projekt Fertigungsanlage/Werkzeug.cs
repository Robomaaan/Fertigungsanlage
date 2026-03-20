namespace Fertigungsanlage
{
    public abstract class Werkzeug
    {
        private static int naechsteId = 1;

        private int id;
        private string bezeichner;
        private string art;
        private int verschleiss;

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
            protected set
            {
                if (value >= 100)
                {
                    throw new VerschleissException(
                        $"Verschleissgrenze erreicht oder ueberschritten: {value} %. Werkzeug {bezeichner} ist verbraucht."
                    );
                }

                if (value < 0)
                {
                    verschleiss = 0;
                }
                else
                {
                    verschleiss = value;
                }
            }
        }

        public Werkzeug(string art, int startVerschleiss)
        {
            id = naechsteId++;
            this.art = art;
            bezeichner = art + "_" + id;

            // Geht bewusst ueber den Setter, damit die Exception-Pruefung
            // auch bereits beim Setzen im Konstruktor greift.
            Verschleiss = startVerschleiss;
        }

        protected void ErhoeheVerschleiss(int wert)
        {
            // Geht ebenfalls bewusst ueber den Setter,
            // damit bei 100 oder mehr eine Exception ausgeloest wird.
            Verschleiss = Verschleiss + wert;
        }

        public abstract string Ausgeben();
        public abstract void Arbeiten();
    }
}