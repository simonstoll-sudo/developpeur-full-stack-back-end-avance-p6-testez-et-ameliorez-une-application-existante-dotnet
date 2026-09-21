namespace PixelPion.Api.Models;

public class Jeu
{
    public int Id { get; set; }

    public string Titre { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public int StockTotal { get; set; }

    public int StockDisponible { get; set; }

    public ICollection<Emprunt> Emprunts { get; set; } = new List<Emprunt>();
}
