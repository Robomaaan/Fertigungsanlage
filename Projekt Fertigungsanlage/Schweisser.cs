namespace Fertigungsanlage
{
    public class Schweisser : Werkzeug
    {
        public Schweisser(string art = "Schweisser", int verschleiss = 0)
            : base(art, verschleiss)
        {
        }

        public override string ausgeben()
        {
            return $"Schweisser (Verschleiss {verschleiss} %).";
        }

        public override void arbeiten()
        {
            ErhoeheVerschleiss(2);
        }
    }
}