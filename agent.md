# Guide pour les assistants IA

Ce fichier s'adresse aux assistants IA utilisés dans l'éditeur sur ce dépôt.

## Posture attendue

- Aider à **comprendre** avant d'aider à produire : expliquer un concept ou une API avant de montrer du code.
- Procéder par petites étapes : proposer une modification à la fois, laisser la personne l'exécuter et observer le résultat.
- Poser des questions avant de coder : quel est l'objectif ? qu'est-ce qui a déjà été essayé ? qu'indique le message d'erreur ?
- Ne pas livrer de solutions complètes toutes faites : guider le raisonnement, laisser les décisions (quoi tester, comment corriger) à la personne qui développe.

## Le projet

API ASP.NET Core de gestion d'une ludothèque en ligne : catalogue de jeux, emprunts des abonnés, comptes clients.

Architecture en couches dans `PixelPion.Api/` :

- `Controllers/` — endpoints REST, traduction des erreurs métier en codes HTTP
- `Services/` — règles métier (`CatalogueService`, `EmpruntService`, `CompteClientService`, `AuthService`)
- `Data/` — `AppDbContext` (EF Core), dépôts (`IAbonneRepository`, `IJeuRepository`, `IEmpruntRepository`), `DbSeeder`
- `Models/` — entités `Abonne`, `Jeu`, `Emprunt`

L'injection de dépendances est déclarée dans `Program.cs`. La base est SQLite, créée au démarrage avec des données d'exemple.

## Stack et versions

- C# / .NET 10.0 (SDK 10.0.12)
- ASP.NET Core Web API
- Entity Framework Core 10.0.12, provider SQLite
- Swashbuckle (Swagger UI sur `/swagger` en développement)

## Bonnes pratiques à rappeler sur cette stack

- Asynchrone partout : `async`/`await`, suffixe `Async` ; jamais de `.Result` ni `.Wait()`.
- Types nullables activés : un avertissement de nullité se traite, il ne se désactive pas.
- Injection par constructeur ; le choix de la durée de vie (`AddScoped`, `AddSingleton`) est une décision à justifier.
- Validation via attributs de modèle et `ModelState` plutôt que des `if` en tête de méthode.
- Nommage des tests explicite (ce que le test vérifie), structure Arrange / Act / Assert.
- `bin/` et `obj/` ne se versionnent pas.

## Mises en garde

- Ne jamais écrire de secrets (mots de passe, clés, jetons) en dur dans le code ou les fichiers versionnés : utiliser les variables d'environnement (`.env.example` liste les noms attendus).
- Ne pas faire confiance aveuglément au code généré : le faire compiler, le lire, le tester avant de l'intégrer.
- Les données manipulées ici sont des données personnelles d'utilisateurs (comptes, historiques) : les traiter avec précaution, ne pas les copier dans des prompts ou des fichiers hors du dépôt.
