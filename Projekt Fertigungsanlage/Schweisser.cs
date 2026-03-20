namespace Fertigungsanlage
{
    public class Schweisser : Werkzeug
    {
        public Schweisser(string art, int verschleiss)
            : base(art, verschleiss)
        {
        }

        public override string Ausgeben()
        {
            return $"Schweisser (Verschleiss {Verschleiss} %).";
        }

        public override void Arbeiten()
        {
            // Schweisser erhoeht den Verschleiss um 2
            ErhoeheVerschleiss(2);
        }
    }
}