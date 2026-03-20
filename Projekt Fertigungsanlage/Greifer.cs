namespace Fertigungsanlage
{
    public class Greifer : Werkzeug
    {
        private int greifweite;

        public int Greifweite
        {
            get { return greifweite; }
        }

        public Greifer(string art, int verschleiss, int greifweite)
            : base(art, verschleiss)
        {
            this.greifweite = greifweite;
        }

        public override string Ausgeben()
        {
            return $"Greifer mit Greifweite {greifweite} (Verschleiss {Verschleiss} %).";
        }

        public override void Arbeiten()
        {
            // Greifer erhoeht den Verschleiss um 1
            ErhoeheVerschleiss(1);
        }
    }
}