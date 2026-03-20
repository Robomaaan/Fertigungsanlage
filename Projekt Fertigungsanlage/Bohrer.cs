namespace Fertigungsanlage
{
    public class Bohrer : Werkzeug
    {
        private int groesse;

        public int Groesse
        {
            get { return groesse; }
        }

        public Bohrer(string art, int verschleiss, int groesse)
            : base(art, verschleiss)
        {
            this.groesse = groesse;
        }

        public override string Ausgeben()
        {
            return $"Bohrer mit Groesse {groesse} (Verschleiss {Verschleiss} %).";
        }

        public override void Arbeiten()
        {
            // Bohrer erhoeht den Verschleiss um 5
            ErhoeheVerschleiss(5);
        }
    }
}