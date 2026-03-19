namespace Fertigungsanlage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Industrieroboter roboter = new Industrieroboter();

            Bohrer bohrer1 = new Bohrer("Bohrer", 0, 10);
            Bohrer bohrer2 = new Bohrer("Bohrer", 0, 10);

            Console.WriteLine("=== Testprogramm gemaess Aufgabenstellung ===");
            Console.WriteLine();

            TesteHinzufuegen(roboter, 5, bohrer1);
            TesteHinzufuegen(roboter, 5, bohrer2);
            TesteHinzufuegen(roboter, 10, bohrer2);
            TesteHinzufuegen(roboter, -1, bohrer2);

            Console.WriteLine();

            TesteEntfernen(roboter, 5);
            TesteEntfernen(roboter, 5);
            TesteEntfernen(roboter, 10);
            TesteEntfernen(roboter, -1);

            Console.WriteLine();
            Console.WriteLine("=== Zusatztests ===");
            Console.WriteLine();

            Greifer greifer = new Greifer("Greifer", 0, 25);
            Schweisser schweisser = new Schweisser("Schweisser", 0);

            roboter.werkzeugHinzufuegen(2, greifer);
            roboter.werkzeugHinzufuegen(7, schweisser);

            Console.WriteLine("Werkzeug auf Platz 2: " + roboter.getWerkzeug(2)?.ausgeben());
            Console.WriteLine("Werkzeug auf Platz 7: " + roboter.getWerkzeug(7)?.ausgeben());
            Console.WriteLine("Werkzeug auf Platz 4: " + (roboter.getWerkzeug(4) == null ? "null" : roboter.getWerkzeug(4).ausgeben()));

            Console.WriteLine();
            Console.WriteLine("Greifer steht auf Index: " + roboter.findeWerkzeug(greifer));
            Console.WriteLine("Schweisser steht auf Index: " + roboter.findeWerkzeug(schweisser));
            Console.WriteLine("Bohrer 1 steht auf Index: " + roboter.findeWerkzeug(bohrer1));
            Console.WriteLine("Bohrer 2 steht auf Index: " + roboter.findeWerkzeug(bohrer2));

            Console.WriteLine();
            Console.WriteLine("Vor dem Arbeiten:");
            Console.WriteLine(greifer.ausgeben());
            Console.WriteLine(schweisser.ausgeben());

            greifer.arbeiten();
            schweisser.arbeiten();

            Console.WriteLine("Nach dem Arbeiten:");
            Console.WriteLine(greifer.ausgeben());
            Console.WriteLine(schweisser.ausgeben());

            Console.WriteLine();
            Console.WriteLine("Freie Plaetze:");
            List<int> frei = roboter.freiePlaetze();
            Console.WriteLine(string.Join(", ", frei));

            Console.WriteLine();
            Console.WriteLine("Programm beendet.");
            Console.ReadKey();
        }

        private static void TesteHinzufuegen(Industrieroboter roboter, int index, Werkzeug werkzeug)
        {
            bool erfolgreich = roboter.werkzeugHinzufuegen(index, werkzeug);

            if (erfolgreich)
            {
                Console.WriteLine($"Hinzugefuegtes Werkzeug auf Platz {index}: {roboter.getWerkzeug(index).ausgeben()}");
            }
            else
            {
                if (index < 0 || index >= 10)
                {
                    Console.WriteLine($"Hinzufuegen nicht moeglich, da Platz {index} nicht existiert.");
                }
                else
                {
                    Console.WriteLine($"Hinzufuegen nicht moeglich, da Platz {index} belegt ist.");
                }
            }
        }

        private static void TesteEntfernen(Industrieroboter roboter, int index)
        {
            Werkzeug vorhandenesWerkzeug = roboter.getWerkzeug(index);
            bool erfolgreich = roboter.werkzeugEntfernen(index);

            if (erfolgreich)
            {
                Console.WriteLine($"Entferntes Werkzeug auf Platz {index}: {vorhandenesWerkzeug.ausgeben()}");
            }
            else
            {
                if (index < 0 || index >= 10)
                {
                    Console.WriteLine($"Entfernen nicht moeglich, da Platz {index} nicht existiert.");
                }
                else
                {
                    Console.WriteLine($"Entfernen nicht moeglich, da Platz {index} nicht belegt ist.");
                }
            }
        }
    }
}