namespace Fertigungsanlage
{
    public class Greifer : Werkzeug
    {
        private int greifweite;

        public int Greifweite
        {
            get { return greifweite; }
        }

        public Greifer(string art = "Greifer", int verschleiss = 0, int greifweite = 0)
            : base(art, verschleiss)
        {
            this.greifweite = greifweite;
        }

        public override string ausgeben()
        {
            return $"Greifer mit Greifweite {greifweite} (Verschleiss {verschleiss} %).";
        }

        public override void arbeiten()
        {
            ErhoeheVerschleiss(1);
        }
    }
}