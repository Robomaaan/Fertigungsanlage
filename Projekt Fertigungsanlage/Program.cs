using System;
using System.Collections.Generic;

namespace Fertigungsanlage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== TEST 1: Industrieroboter / Werkzeugkasten ===");
            Console.WriteLine();

            Industrieroboter roboter = new Industrieroboter();

            Bohrer bohrer1 = new Bohrer("Bohrer", 0, 10);
            Bohrer bohrer2 = new Bohrer("Bohrer", 0, 12);

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
            Console.WriteLine("=== TEST 2: Weitere Werkzeugtypen ===");
            Console.WriteLine();

            Greifer greifer = new Greifer("Greifer", 0, 25);
            Schweisser schweisser = new Schweisser("Schweisser", 0);

            roboter.WerkzeugHinzufuegen(2, greifer);
            roboter.WerkzeugHinzufuegen(7, schweisser);

            Console.WriteLine("Werkzeug auf Platz 2: " + roboter.GetWerkzeug(2)?.Ausgeben());
            Console.WriteLine("Werkzeug auf Platz 7: " + roboter.GetWerkzeug(7)?.Ausgeben());
            Console.WriteLine("Werkzeug auf Platz 4: " + (roboter.GetWerkzeug(4) == null ? "null" : roboter.GetWerkzeug(4).Ausgeben()));

            Console.WriteLine();
            Console.WriteLine("Greifer steht auf Index: " + roboter.FindeWerkzeug(greifer));
            Console.WriteLine("Schweisser steht auf Index: " + roboter.FindeWerkzeug(schweisser));
            Console.WriteLine("Bohrer 1 steht auf Index: " + roboter.FindeWerkzeug(bohrer1));
            Console.WriteLine("Bohrer 2 steht auf Index: " + roboter.FindeWerkzeug(bohrer2));

            Console.WriteLine();
            Console.WriteLine("Vor dem Arbeiten:");
            Console.WriteLine(greifer.Ausgeben());
            Console.WriteLine(schweisser.Ausgeben());

            greifer.Arbeiten();
            schweisser.Arbeiten();

            Console.WriteLine("Nach dem Arbeiten:");
            Console.WriteLine(greifer.Ausgeben());
            Console.WriteLine(schweisser.Ausgeben());

            Console.WriteLine();
            Console.WriteLine("Freie Plaetze:");
            List<int> freiePlaetze = roboter.FreiePlaetze();
            Console.WriteLine(string.Join(", ", freiePlaetze));

            Console.WriteLine();
            Console.WriteLine("=== TEST 3: VerschleissException beim Erhoehen ===");
            Console.WriteLine();

            Bohrer bohrerFastKaputt = new Bohrer("Bohrer", 95, 8);

            Console.WriteLine("Startzustand:");
            Console.WriteLine(bohrerFastKaputt.Ausgeben());
            Console.WriteLine();

            try
            {
                Console.WriteLine("Bohrer arbeitet jetzt...");
                bohrerFastKaputt.Arbeiten();   // 95 + 5 = 100 -> Exception
                Console.WriteLine("Nach dem Arbeiten:");
                Console.WriteLine(bohrerFastKaputt.Ausgeben());
            }
            catch (VerschleissException ex)
            {
                Console.WriteLine("Exception abgefangen:");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Zustand nach Exception:");
            Console.WriteLine(bohrerFastKaputt.Ausgeben());

            Console.WriteLine();
            Console.WriteLine("=== TEST 4: VerschleissException beim Setzen im Konstruktor ===");
            Console.WriteLine();

            try
            {
                Schweisser defekt = new Schweisser("Schweisser", 100);
                Console.WriteLine(defekt.Ausgeben());
            }
            catch (VerschleissException ex)
            {
                Console.WriteLine("Exception abgefangen:");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Programm beendet.");
            Console.ReadKey();
        }

        private static void TesteHinzufuegen(Industrieroboter roboter, int index, Werkzeug werkzeug)
        {
            bool erfolgreich = roboter.WerkzeugHinzufuegen(index, werkzeug);

            if (erfolgreich)
            {
                Console.WriteLine($"Hinzugefuegtes Werkzeug auf Platz {index}: {roboter.GetWerkzeug(index).Ausgeben()}");
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
            Werkzeug vorhandenesWerkzeug = roboter.GetWerkzeug(index);
            bool erfolgreich = roboter.WerkzeugEntfernen(index);

            if (erfolgreich)
            {
                Console.WriteLine($"Entferntes Werkzeug auf Platz {index}: {vorhandenesWerkzeug.Ausgeben()}");
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