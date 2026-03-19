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

        public override string ausgeben()
        {
            return $"Bohrer mit Groesse {groesse} (Verschleiss {verschleiss} %).";
        }

        public override void arbeiten()
        {
            ErhoeheVerschleiss(5);
        }
    }
}