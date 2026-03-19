using System.Collections.Generic;

namespace Fertigungsanlage
{
    public class Industrieroboter
    {
        private static int naechsteId = 1;
        private static readonly int maxAnzWerkzeuge = 10;

        private int id;
        private string bezeichner;
        private Werkzeug[] werkzeugKasten;

        public int ID
        {
            get { return id; }
        }

        public string Bezeichner
        {
            get { return bezeichner; }
        }

        public Industrieroboter()
        {
            id = naechsteId++;
            bezeichner = "IR_" + id;
            werkzeugKasten = new Werkzeug[maxAnzWerkzeuge];
        }

        public bool werkzeugHinzufuegen(int index, Werkzeug neu)
        {
            if (index < 0 || index >= maxAnzWerkzeuge)
            {
                return false;
            }

            if (neu == null)
            {
                return false;
            }

            if (werkzeugKasten[index] != null)
            {
                return false;
            }

            werkzeugKasten[index] = neu;
            return true;
        }

        public bool werkzeugEntfernen(int index)
        {
            if (index < 0 || index >= maxAnzWerkzeuge)
            {
                return false;
            }

            if (werkzeugKasten[index] == null)
            {
                return false;
            }

            werkzeugKasten[index] = null;
            return true;
        }

        public Werkzeug getWerkzeug(int index)
        {
            if (index < 0 || index >= maxAnzWerkzeuge)
            {
                return null;
            }

            return werkzeugKasten[index];
        }

        public int findeWerkzeug(Werkzeug w)
        {
            if (w == null)
            {
                return -1;
            }

            for (int i = 0; i < werkzeugKasten.Length; i++)
            {
                if (werkzeugKasten[i] == w)
                {
                    return i;
                }
            }

            return -1;
        }

        public List<int> freiePlaetze()
        {
            List<int> freieIndizes = new List<int>();

            for (int i = 0; i < werkzeugKasten.Length; i++)
            {
                if (werkzeugKasten[i] == null)
                {
                    freieIndizes.Add(i);
                }
            }

            return freieIndizes;
        }
    }
}