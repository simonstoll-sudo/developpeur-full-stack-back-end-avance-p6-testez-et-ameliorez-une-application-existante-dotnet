namespace PixelPion.Api.Models;

public class Emprunt
{
    public int Id { get; set; }

    public int AbonneId { get; set; }

    public Abonne? Abonne { get; set; }

    public int JeuId { get; set; }

    public Jeu? Jeu { get; set; }

    public DateTime DateEmprunt { get; set; }

    public DateTime? DateRetour { get; set; }
}
