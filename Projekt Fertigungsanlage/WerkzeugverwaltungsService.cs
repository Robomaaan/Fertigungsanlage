using Fertigungsanlage;


namespace Fertigung.Application
{
    public class WerkzeugverwaltungsService
    {
        private readonly List<Werkzeug> werkzeuge;

        public WerkzeugverwaltungsService()
        {
            werkzeuge = new List<Werkzeug>();
        }

        public IReadOnlyList<Werkzeug> Werkzeuge
        {
            get { return werkzeuge.AsReadOnly(); }
        }

        public void WerkzeugHinzufuegen(Werkzeug werkzeug)
        {
            if (werkzeug == null)
            {
                throw new ArgumentNullException(nameof(werkzeug));
            }

            werkzeuge.Add(werkzeug);
        }

        public bool WerkzeugEntfernen(Werkzeug werkzeug)
        {
            if (werkzeug == null)
            {
                throw new ArgumentNullException(nameof(werkzeug));
            }

            // Optional laut Aufgabe:
            // Falls ein Werkzeug bereits verschlissen ist, soll eine Exception
            // geworfen werden, bevor es entfernt wird.
            if (werkzeug.Verschleiss >= 100)
            {
                throw new VerschleissException(
                    $"Werkzeug {werkzeug.Bezeichner} kann nicht entfernt werden, da der Verschleiss {werkzeug.Verschleiss} % betraegt."
                );
            }

            return werkzeuge.Remove(werkzeug);
        }
    }
}