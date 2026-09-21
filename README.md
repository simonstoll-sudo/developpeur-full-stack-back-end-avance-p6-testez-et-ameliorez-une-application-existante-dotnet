# Pixel & Pion — Application de gestion

API de gestion de la ludothèque en ligne Pixel & Pion : catalogue de jeux (jeux de société et jeux vidéo), emprunts des abonnés et comptes clients.

## Prérequis

- [SDK .NET 10.0](https://dotnet.microsoft.com/download) (10.0.12 ou supérieur)
- Aucun serveur de base de données : l'application utilise SQLite, le fichier de base est créé automatiquement au premier lancement.

## Installation

```bash
git clone <url-du-depot>
cd <dossier-du-depot>
dotnet restore
```

## Lancement

```bash
dotnet run --project PixelPion.Api
```

Au premier démarrage, l'application crée la base `pixelpion.db` et y insère des données de démarrage (abonnés, jeux, emprunts).

En environnement de développement, la documentation interactive de l'API est disponible sur `/swagger`.

## Stack technique

- C# / .NET 10.0
- ASP.NET Core Web API
- Entity Framework Core 10.0.12 (provider SQLite)
- Swashbuckle (Swagger)

## Structure du projet

```
PixelPion.Api/
├── Controllers/   # Endpoints REST de l'API
├── Services/      # Règles métier : catalogue, emprunts, comptes, connexion
├── Data/          # DbContext EF Core, dépôts, données de démarrage
├── Models/        # Entités (Abonne, Jeu, Emprunt)
├── Program.cs     # Démarrage : injection de dépendances, EF Core, Swagger
└── appsettings.json
starter-kit/       # Documents remis avec le dépôt
```

## Points d'entrée de l'API

| Méthode | Route | Description |
|---|---|---|
| POST | `/api/auth/login` | Connexion d'un abonné (email + mot de passe) |
| POST | `/api/abonnes` | Création d'un compte abonné |
| GET | `/api/abonnes/{id}` | Profil d'un abonné |
| GET | `/api/abonnes/{id}/emprunts` | Historique d'emprunts d'un abonné |
| GET | `/api/jeux?titre=xxx` | Recherche de jeux par titre |
| POST | `/api/jeux` | Ajout d'un jeu au catalogue |
| GET | `/api/jeux/{id}/disponibilite` | Disponibilité d'un jeu |
| POST | `/api/emprunts` | Création d'un emprunt |
| POST | `/api/emprunts/{id}/retour` | Restitution d'un emprunt |

## Scripts utiles

```bash
dotnet build     # Compilation
dotnet run --project PixelPion.Api   # Lancement de l'API
```

## Licence

Projet interne Pixel & Pion. Tous droits réservés.
