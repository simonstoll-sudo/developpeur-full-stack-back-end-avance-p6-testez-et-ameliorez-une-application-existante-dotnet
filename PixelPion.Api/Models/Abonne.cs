namespace PixelPion.Api.Models;

public class Abonne
{
    public int Id { get; set; }

    public string Nom { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string MotDePasse { get; set; } = string.Empty;

    public DateTime DateInscription { get; set; }

    public ICollection<Emprunt> Emprunts { get; set; } = new List<Emprunt>();
}
