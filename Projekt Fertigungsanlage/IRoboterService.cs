namespace Fertigungsanlage
{
    public interface IRoboterService
    {
        string WerkzeugHinzufuegen(Industrieroboter roboter, int index, Werkzeug werkzeug);
        string WerkzeugEntfernen(Industrieroboter roboter, int index);
    }
}