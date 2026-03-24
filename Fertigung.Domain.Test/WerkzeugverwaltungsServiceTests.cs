using Fertigungsanlage;
using System.Reflection;
using Xunit;

namespace Fertigung.Application.Tests
{
    public class WerkzeugverwaltungsServiceTests
    {
        [Fact]
        public void WerkzeugEntfernen_EntferntVorhandenesWerkzeugAusListe()
        {
            // Arrange
            WerkzeugverwaltungsService service = new WerkzeugverwaltungsService();
            Bohrer bohrer = new Bohrer("Bohrer", 0, 10);

            service.WerkzeugHinzufuegen(bohrer);

            // Act
            bool entfernt = service.WerkzeugEntfernen(bohrer);

            // Assert
            Assert.True(entfernt);
            Assert.Empty(service.Werkzeuge);
        }

        [Fact]
        public void WerkzeugEntfernen_GibtFalseZurueck_WennWerkzeugNichtInListeIst()
        {
            // Arrange
            WerkzeugverwaltungsService service = new WerkzeugverwaltungsService();
            Bohrer bohrer = new Bohrer("Bohrer", 0, 10);

            // Act
            bool entfernt = service.WerkzeugEntfernen(bohrer);

            // Assert
            Assert.False(entfernt);
            Assert.Empty(service.Werkzeuge);
        }

        [Fact]
        public void WerkzeugEntfernen_WirftArgumentNullException_WennNullUebergebenWird()
        {
            // Arrange
            WerkzeugverwaltungsService service = new WerkzeugverwaltungsService();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => service.WerkzeugEntfernen(null));
        }

        [Fact]
        public void WerkzeugEntfernen_WirftVerschleissException_WennWerkzeugBereitsVerschlissenIst()
        {
            // Arrange
            WerkzeugverwaltungsService service = new WerkzeugverwaltungsService();
            Bohrer bohrer = new Bohrer("Bohrer", 99, 10);

            service.WerkzeugHinzufuegen(bohrer);

            // Da dein Domänenmodell >= 100 normalerweise direkt verhindert,
            // simulieren wir hier für den Optional-Test einen inkonsistenten Zustand
            // per Reflection.
            FieldInfo verschleissFeld = typeof(Werkzeug).GetField(
                "verschleiss",
                BindingFlags.Instance | BindingFlags.NonPublic);

            verschleissFeld.SetValue(bohrer, 100);

            // Act & Assert
            Assert.Throws<VerschleissException>(() => service.WerkzeugEntfernen(bohrer));

            // Das Werkzeug darf dabei nicht entfernt worden sein
            Assert.Single(service.Werkzeuge);
        }
    }
}