using Xunit;
using Fertigungsanlage;

namespace Fertigungsanlage.Tests
{
    public class WerkzeugTests
    {
        // ------------------------------------------------------------
        // Test-Hilfsklasse
        // ------------------------------------------------------------
        // Da Werkzeug abstrakt ist, erzeugen wir hier eine kleine
        // konkrete Testklasse nur fuer die Unit Tests.
        private class TestWerkzeug : Werkzeug
        {
            public TestWerkzeug(string art, int verschleiss)
                : base(art, verschleiss)
            {
            }

            public void SetzeTestVerschleiss(int wert)
            {
                Verschleiss = wert;
            }

            public void ErhoeheTestVerschleiss(int wert)
            {
                ErhoeheVerschleiss(wert);
            }

            public override string Ausgeben()
            {
                return $"TestWerkzeug (Verschleiss {Verschleiss} %)";
            }

            public override void Arbeiten()
            {
                ErhoeheVerschleiss(1);
            }
        }

        [Fact]
        public void Konstruktor_WirftException_WennVerschleissGenau100Ist()
        {
            Assert.Throws<VerschleissException>(() =>
            {
                TestWerkzeug werkzeug = new TestWerkzeug("Test", 100);
            });
        }

        [Fact]
        public void Konstruktor_WirftException_WennVerschleissUeber100Ist()
        {
            Assert.Throws<VerschleissException>(() =>
            {
                TestWerkzeug werkzeug = new TestWerkzeug("Test", 150);
            });
        }

        [Fact]
        public void Setter_WirftException_WennVerschleissAuf100GesetztWird()
        {
            TestWerkzeug werkzeug = new TestWerkzeug("Test", 50);

            Assert.Throws<VerschleissException>(() =>
            {
                werkzeug.SetzeTestVerschleiss(100);
            });
        }

        [Fact]
        public void Setter_WirftException_WennVerschleissUeber100GesetztWird()
        {
            TestWerkzeug werkzeug = new TestWerkzeug("Test", 50);

            Assert.Throws<VerschleissException>(() =>
            {
                werkzeug.SetzeTestVerschleiss(120);
            });
        }

        [Fact]
        public void Erhoehen_WirftException_WennVerschleissGenau100Erreicht()
        {
            TestWerkzeug werkzeug = new TestWerkzeug("Test", 95);

            Assert.Throws<VerschleissException>(() =>
            {
                werkzeug.ErhoeheTestVerschleiss(5);
            });
        }

        [Fact]
        public void Erhoehen_WirftException_WennVerschleissUeber100Steigt()
        {
            TestWerkzeug werkzeug = new TestWerkzeug("Test", 95);

            Assert.Throws<VerschleissException>(() =>
            {
                werkzeug.ErhoeheTestVerschleiss(10);
            });
        }

        [Fact]
        public void Erhoehen_WirftKeineException_WennVerschleissUnter100Bleibt()
        {
            TestWerkzeug werkzeug = new TestWerkzeug("Test", 95);

            Exception exception = Record.Exception(() =>
            {
                werkzeug.ErhoeheTestVerschleiss(4);
            });

            Assert.Null(exception);
            Assert.Equal(99, werkzeug.Verschleiss);
        }

        [Fact]
        public void Setter_WirftKeineException_WennWertUnter100Ist()
        {
            TestWerkzeug werkzeug = new TestWerkzeug("Test", 10);

            Exception exception = Record.Exception(() =>
            {
                werkzeug.SetzeTestVerschleiss(99);
            });

            Assert.Null(exception);
            Assert.Equal(99, werkzeug.Verschleiss);
        }
    }
}