using Fertigung.Domain;
using Fertigungsanlage;
using Xunit;

namespace Fertigung.Domain.Test;

public class BohrerTests
{
    [Fact]
    public void TestBohrer()
    {
        // Arrange
        Bohrer bohrer = new Bohrer("Bohrer", 1, 1);

        // Act
        string ergebnis = bohrer.Ausgeben();

        // Assert
        Assert.StartsWith("Bohrer", ergebnis);
    }

    [Fact]
    public void TestBohrerVerschleiss()
    {
        // Arrange
        Bohrer bohrer = new Bohrer("Bohrer", 1, 1);
        // Act
        bohrer.Arbeiten();
        int verschleissNachArbeiten = bohrer.Verschleiss;
        // Assert
        Assert.Equal(6, verschleissNachArbeiten);
    }
}
public class GreiferTests
{
    [Fact]
    public void TestGreifer()
    {
        // Arrange
        Greifer greifer = new Greifer("Greifer", 1, 10);
        // Act
        string ergebnis = greifer.Ausgeben();
        // Assert
        Assert.StartsWith("Greifer", ergebnis);
    }
    [Fact]
    public void TestGreiferVerschleiss()
    {
        // Arrange
        Greifer greifer = new Greifer("Greifer", 1, 10);
        // Act
        greifer.Arbeiten();
        int verschleissNachArbeiten = greifer.Verschleiss;
        // Assert
        Assert.Equal(2, verschleissNachArbeiten);
    }
}
public class SchweisserTests
{
    [Fact]
    public void TestSchweisser()
    {
        // Arrange
        Schweisser schweisser = new Schweisser("Schweisser", 1);
        // Act
        string ergebnis = schweisser.Ausgeben();
        // Assert
        Assert.StartsWith("Schweisser", ergebnis);
    }
    [Fact]
    public void TestSchweisserVerschleiss()
    {
        // Arrange
        Schweisser schweisser = new Schweisser("Schweisser", 1);
        // Act
        schweisser.Arbeiten();
        int verschleissNachArbeiten = schweisser.Verschleiss;
        // Assert
        Assert.Equal(3, verschleissNachArbeiten);
    }
}
public class IndustrieroboterTests
{
    [Fact]
    public void TestIndustrieroboterHinzufuegen()
    {
        // Arrange
        Industrieroboter roboter = new Industrieroboter();
        Bohrer bohrer = new Bohrer("Bohrer", 0, 10);
        // Act
        roboter.WerkzeugHinzufuegen(0, bohrer);
        Werkzeug? ergebnis = roboter.GetWerkzeug(0);
        // Assert
        Assert.NotNull(ergebnis);
        Assert.IsType<Bohrer>(ergebnis);
    }
}
