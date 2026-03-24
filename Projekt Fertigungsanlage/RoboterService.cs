namespace Fertigungsanlage
{
    public class RoboterService : IRoboterService
    {
        public string WerkzeugHinzufuegen(Industrieroboter roboter, int index, Werkzeug werkzeug)
        {
            if (roboter == null)
            {
                return "Hinzufuegen nicht moeglich, da kein Roboter uebergeben wurde.";
            }

            if (werkzeug == null)
            {
                return "Hinzufuegen nicht moeglich, da kein Werkzeug uebergeben wurde.";
            }

            bool erfolgreich = roboter.WerkzeugHinzufuegen(index, werkzeug);

            if (erfolgreich)
            {
                return $"Hinzugefuegtes Werkzeug auf Platz {index}: {roboter.GetWerkzeug(index).Ausgeben()}";
            }

            if (index < 0 || index >= 10)
            {
                return $"Hinzufuegen nicht moeglich, da Platz {index} nicht existiert.";
            }

            return $"Hinzufuegen nicht moeglich, da Platz {index} belegt ist.";
        }

        public string WerkzeugEntfernen(Industrieroboter roboter, int index)
        {
            if (roboter == null)
            {
                return "Entfernen nicht moeglich, da kein Roboter uebergeben wurde.";
            }

            Werkzeug vorhandenesWerkzeug = roboter.GetWerkzeug(index);
            bool erfolgreich = roboter.WerkzeugEntfernen(index);

            if (erfolgreich)
            {
                return $"Entferntes Werkzeug auf Platz {index}: {vorhandenesWerkzeug.Ausgeben()}";
            }

            if (index < 0 || index >= 10)
            {
                return $"Entfernen nicht moeglich, da Platz {index} nicht existiert.";
            }

            return $"Entfernen nicht moeglich, da Platz {index} nicht belegt ist.";
        }
    }
}