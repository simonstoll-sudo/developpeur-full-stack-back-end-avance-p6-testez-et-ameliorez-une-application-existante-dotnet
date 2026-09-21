:::meta
titre: Testez et améliorez une application existante
parcours: Développeur Full-stack back-end avancé
numero_projet: P6
variation_scenario: standard
nb_missions: 1
guidage: entierement_guide
duree_supervisee_h: 55
duree_personnelle_h: 55
certifiant: non
evaluation: session de bilan avec le mentor accompagnateur
prepare: le projet de synthèse P7, où tests et sécurisation s'intègrent dans une mission globale
competence_1: Écrire des tests unitaires [À VALIDER]
competence_2: Écrire des tests d'intégration et e2e [À VALIDER]
competence_3: Sécuriser les données d'une application / Mettre en place l'authentification d'une application [À VALIDER]
:::

# Page d'accueil

## Qu'allez-vous apprendre dans ce projet ?

Vous héritez d'une application qui fonctionne, mais que personne n'ose modifier : aucun test ne protège son comportement. Vous allez apprendre à poser ce filet de sécurité : écrire des **tests unitaires** qui vérifient une règle métier isolément, puis des **tests d'intégration** qui vérifient que les couches de l'application collaborent correctement, jusqu'à un parcours complet de bout en bout.

Vous apprendrez aussi à mesurer ce que vos tests couvrent réellement, grâce à un **rapport de couverture** : un document généré automatiquement qui indique quelles parties du code sont traversées par les tests, et lesquelles ne le sont pas. Lire ce rapport avec discernement est une compétence en soi : du code couvert n'est pas forcément du code correct.

Enfin, vous corrigerez les défauts de sécurité de l'application : mots de passe stockés en clair, données clients accessibles sans contrôle. Vous mettrez en place le **hachage** des mots de passe (une transformation irréversible qui rend le mot de passe illisible même en cas de fuite), une **authentification** (vérifier qui est l'utilisateur) et une **autorisation** (vérifier ce qu'il a le droit de faire). Vous documenterez chaque correction pour l'équipe.

## En quoi ces compétences sont-elles importantes pour votre carrière ?

Reprendre du code existant sans tests est le quotidien de la plupart des développeurs back-end : les recruteurs cherchent des profils capables de fiabiliser un existant, pas seulement de créer du neuf. Savoir choisir quoi tester, organiser ses tests et interpréter un échec est ce qui distingue un développeur autonome d'un développeur qui livre à l'aveugle.

La sécurisation des données est devenue une exigence légale autant que technique : une fuite de mots de passe en clair engage la responsabilité de l'entreprise au regard du **RGPD**, le règlement européen sur la protection des données personnelles. Un développeur qui sait expliquer quelles protections il a mises en place, et contre quels risques, est immédiatement crédible en équipe comme en entretien.

## Comment allez-vous procéder ?

- **Mission 1 : Fiabilisez l'application de Pixel & Pion** : vous prendrez en main une application existante, vous écrirez ses tests unitaires puis ses tests d'intégration avec leur rapport de couverture, vous corrigerez ses défauts de sécurité et vous documenterez vos corrections.

Ce projet est **entièrement guidé** : chaque étape vous dit quoi produire et dans quel ordre.

Ce projet n'est pas certifiant : aucune compétence n'y est validée. Il vous prépare au projet de synthèse qui suit, où vous intégrerez ces pratiques dans une mission complète. À l'issue de ce projet, vous présenterez vos livrables à votre **mentor accompagnateur** lors d'une **session de bilan** : le but est de vérifier ensemble que vous êtes prêt pour la suite, et d'identifier ce qu'il vous reste à consolider.

## Prêt à démarrer votre projet ?

Lancez-vous dans la première section « Mission 1 - Fiabilisez l'application de Pixel & Pion ».

:::encadre type=info
**Votre projet démarre : suivez ces quelques recommandations pour être plus efficace !**

- Coupez dès à présent toutes les sources de distraction : téléphone, messagerie, mails, notifications, etc.
- Évitez les situations de multitâches : n'écoutez pas un podcast ou les informations en travaillant.
- Préparez votre environnement de travail : onglets, documents téléchargés, raccourcis, etc.

Vous avez toutes les cartes en main, c'est parti ! Pour plus de conseils, suivez ce chapitre de cours : Mettez en place votre environnement d'apprentissage.
:::

---

# Mission 3 - Fiabilisez l'application de Pixel & Pion (.NET)

:::encadre type=autoeval
Ce projet n'est pas certifiant : il n'y a pas de critères d'évaluation par compétence.
L'étudiant dispose en revanche d'une **fiche d'autoévaluation** dans la dernière étape de son travail.
Elle lui sert de checklist avant la session de bilan, et de base de discussion avec vous.
:::

## Comment allez-vous procéder ?

Cette mission suit un scénario de projet professionnel. Suivez les étapes dans l'ordre : elles construisent le livrable pièce par pièce.

Avant de démarrer, nous vous conseillons de :

- lire toute la mission et ses documents liés ;
- prendre des notes sur ce que vous avez compris ;
- consulter les étapes pour vous guider ;
- préparer une liste de questions pour votre session de mentorat.

:::encadre type=info
**Quelques conseils de méthodologie de travail :**

**Sur la construction du projet :** soyez prêt à détailler votre processus de décision. Exemples : pourquoi avoir testé cette classe en unitaire plutôt qu'en intégration ? Pourquoi ce choix de protection pour cette vulnérabilité ?

**Sur l'usage de l'IA :** si vous utilisez des outils d'intelligence artificielle, vous devez être capable d'expliquer comment vous avez vérifié et adapté le contenu produit. L'IA peut vous aider sur la syntaxe d'un test ; le choix de ce qu'il faut tester et la lecture d'un échec restent les vôtres, et c'est cela qu'on vous demandera d'expliquer.
:::

## Prêt à mener la mission ?

Vous rejoignez lundi Pixel & Pion, une ludothèque en ligne qui loue des jeux de société et des jeux vidéo à ses abonnés. Son application de gestion (catalogue, emprunts, comptes clients) a été livrée par un prestataire pressé : elle tourne, les clients l'utilisent tous les jours, et c'est bien le problème. Personne n'ose y toucher, et les données de ces clients y dorment sans réelle protection.

Le vendredi précédant votre arrivée, Thomas Verdier, le lead developer qui reprend la maintenance, vous écrit pour que vous puissiez démarrer sans l'attendre.

:::artefact canal=email de="Thomas Verdier" fonction="Lead Developer" objet="Avant lundi — l'appli du prestataire"
Bonjour,

Bienvenue chez Pixel & Pion ! Je préfère vous écrire avant votre arrivée : lundi je suis en déplacement, et je ne veux pas que vous perdiez votre première semaine à m'attendre.

Le contexte : on récupère la maintenance de notre application de gestion (catalogue, emprunts, comptes clients), livrée par un prestataire. Elle fonctionne, mais elle nous a été remise sans le moindre test automatisé. Résultat : chaque modification est un saut sans filet, et on a déjà cassé la gestion des emprunts deux fois ce trimestre. Et il y a pire : des choses côté données clients ne me laissent pas dormir, à commencer par les mots de passe.

Votre premier chantier, dans l'ordre :

1. Posez un filet de tests sur les fonctions critiques de l'application, en suivant le plan de tests joint. Il précise les fonctionnalités à couvrir et les cas qui nous ont déjà brûlés.
2. Donnez-moi de quoi voir ce qui est couvert et ce qui ne l'est pas. Je veux pouvoir ouvrir un rapport et savoir où on en est, sans lire tous vos tests.
3. Corrigez les problèmes d'accès et de protection des données décrits dans le second document joint. Les mots de passe en clair, c'est non, et aujourd'hui n'importe quel utilisateur connecté peut consulter les données des autres.
4. Documentez vos corrections pour l'équipe, directement dans le dépôt : quelles vulnérabilités vous avez traitées, et quelles protections vous avez mises en place.

Un point important : vos corrections ne doivent rien casser. C'est justement pour ça que les tests viennent en premier.

Les accès au dépôt suivent dans un autre mail. Bon démarrage, et on fait un point à mon retour.

Thomas Verdier
Lead Developer, Pixel & Pion

**Pièces jointes :** plan_de_tests.pdf, brief_securite.pdf
:::

Cette mission est entièrement guidée. Suivez les étapes ci-dessous, elles vous mènent aux livrables pas à pas.

### Étape 1 - Prenez en main la codebase et le plan de tests

**Prérequis :**

- avoir en tête l'architecture en couches d'une application ASP.NET Core : `Controllers` → `Services` → `Data` → `Models`, vue dans vos projets précédents ;
- avoir reçu les accès au dépôt et les deux documents joints (plan_de_tests.pdf, brief_securite.pdf).

**Résultats attendus :**

- l'application clonée, restaurée et lancée en local avec `dotnet run`, base de données comprise ;
- une cartographie rapide de la codebase : les couches, les entités principales, les endpoints exposés (repérables via le Swagger généré par Swashbuckle) ;
- une reformulation écrite du plan de tests : pour chaque fonctionnalité listée, la classe concernée et les cas à couvrir (nominal et erreur) ;
- une première lecture du brief sécurité, sans rien corriger encore : notez où se trouvent, dans le code, les problèmes qu'il décrit.

**Recommandations :**

- Ouvrez le `.csproj` en premier : il vous dit quelles dépendances de test et de sécurité sont déjà présentes, et lesquelles vous devrez ajouter via NuGet.
- Créez quelques comptes et emprunts de test via Swagger UI : manipuler l'application en utilisateur vous fera comprendre les règles métier plus vite que la lecture du code seul.

**Points de vigilance :**

- N'écrivez aucun test avant de savoir lancer l'application et exécuter `dotnet test` (même vide) : un environnement mal configuré découvert à l'étape 2 vous coûtera bien plus cher qu'ici.

### Étape 2 - Écrivez les tests unitaires

**Prérequis :**

- avoir reformulé le plan de tests (étape 1) ;
- savoir ce qu'est une **doublure** (mock) : un objet factice qui remplace une dépendance réelle pour isoler la classe testée.

**Résultats attendus :**

- une suite de tests unitaires xUnit sur les classes de la couche `Services` ciblées par le plan de tests, passant au vert avec `dotnet test` ;
- des dépendances isolées avec Moq : vos tests unitaires ne touchent ni la base de données, ni le réseau, ni le pipeline de démarrage de l'application ;
- pour chaque fonctionnalité du plan de tests, au moins un cas nominal et un cas d'erreur (entrée invalide, ressource absente, règle métier violée) ;
- un premier **rapport de couverture** généré avec Coverlet, versionné ou exporté dans le dépôt.

**Recommandations :**

- L'injection par constructeur est votre alliée : elle permet d'instancier un service dans un test en lui passant des mocks Moq, sans démarrer le moindre hôte applicatif. Si une classe de la codebase résout ses dépendances autrement et résiste au test, c'est un premier défaut à corriger.
- Structurez chaque test en trois temps, Arrange / Act / Assert : préparer les données et les mocks, exécuter la méthode, vérifier le résultat. Un nom de test doit dire ce qu'il vérifie, par exemple `Emprunt_Refuse_Si_Quota_Atteint`.
- Vous vous demandez peut-être pourquoi tester des cas d'erreur alors que « ça marche » : ce sont précisément les régressions que Pixel & Pion a subies deux fois ce trimestre. Les cas d'erreur sont le filet, pas le décor.

**Points de vigilance :**

- Un mock Moq isolé et un test qui démarre toute l'application via `WebApplicationFactory` ne sont pas interchangeables : un test qui démarre tout le pipeline applicatif pour vérifier une règle de calcul est un test lent pour rien. À cette étape, restez sur des mocks isolés.
- Ne visez pas 100 % de couverture en testant des propriétés triviales : le plan de tests définit ce qui est critique. Vérifiez que ce périmètre est couvert avant d'élargir.

### Étape 3 - Écrivez les tests d'intégration

**Prérequis :**

- disposer de la suite unitaire verte de l'étape 2 ;
- avoir compris la différence entre test unitaire (une classe isolée) et test d'intégration (plusieurs couches réelles qui collaborent).

**Résultats attendus :**

- des tests d'intégration avec `WebApplicationFactory` sur les endpoints listés dans le plan de tests, vérifiant les codes HTTP, le corps des réponses et les cas d'erreur ;
- au moins un test de bout en bout traversant toutes les couches : une requête HTTP réelle qui déclenche la logique métier et vérifie l'état persisté en base ;
- une suite exécutable avec `dotnet test`, sans configuration manuelle non documentée dans le README ;
- le rapport de couverture Coverlet consolidé (unitaires + intégration), présent dans le dépôt.

**Recommandations :**

- Pour la base de données de test, une base éphémère lancée par Testcontainers vous rapproche des conditions réelles ; une base fournie par le provider EF Core en mémoire reste acceptable si vous savez expliquer ce que ce choix ne détecte pas.
- C'est ici que le remplacement de services via `WebApplicationFactory` devient légitime : pour neutraliser une dépendance externe (envoi d'e-mail, service tiers) tout en gardant le reste du pipeline réel.
- Comparez le rapport consolidé au rapport de l'étape 2 : les zones qui ne deviennent couvertes qu'en intégration (contrôleurs, mapping des erreurs) vous disent où passe la frontière entre vos deux familles de tests.

**Points de vigilance :**

- Si un test d'intégration échoue à cause d'un accès à une navigation property EF Core non chargée hors contexte, ne contournez pas au hasard : c'est un chargement paresseux qui explose hors de son `DbContext`, et l'expliquer fait partie du travail. Notez le diagnostic dans le dépôt.
- Si vos tests d'API révèlent qu'une entité EF Core traverse le contrôleur au lieu d'un DTO, notez-le : le modèle de base est exposé dans l'API, et vous retrouverez ce point à l'étape 4 côté fuite de données.

### Étape 4 - Sécurisez les données et l'authentification

**Prérequis :**

- disposer d'une suite de tests verte (`dotnet test`) : c'est elle qui garantit que vos corrections ne cassent rien ;
- avoir relu le brief sécurité et localisé chaque problème dans le code (étape 1).

**Résultats attendus :**

- les mots de passe hachés via ASP.NET Core Identity : plus aucun stockage ni comparaison en clair, y compris dans les données d'exemple ;
- une authentification en place via ASP.NET Core Identity : les endpoints sensibles exigent un utilisateur identifié ;
- une autorisation cohérente : un utilisateur ne peut consulter et modifier que ses propres données (comptes, emprunts), conformément au brief sécurité ;
- les vulnérabilités listées dans brief_securite.pdf corrigées : [À COMPLÉTER : liste exacte des vulnérabilités présentes dans la codebase .NET fournie] ;
- la suite de tests complète toujours verte après sécurisation, adaptée là où le comportement attendu a légitimement changé (par exemple un `401 Unauthorized` sur un endpoint désormais protégé).

**Recommandations :**

- Hachage n'est pas chiffrement : un hachage est irréversible par construction, et c'est exactement ce qu'on veut pour un mot de passe. Sachez le dire avec vos mots, la question viendra en session de bilan.
- Procédez vulnérabilité par vulnérabilité, en relançant `dotnet test` après chaque correction : si un test casse, vous savez immédiatement laquelle de vos modifications est en cause.
- Appuyez-vous sur les attributs de validation (`[Required]`, `[StringLength]`) et la vérification de `ModelState` pour la vérification des entrées plutôt que sur des `if` en tête de méthode, et laissez un middleware de gestion des exceptions traduire les erreurs en réponses HTTP : renvoyer un code d'erreur depuis un service est une faute de couche.

**Points de vigilance :**

- Vérifiez que rien de sensible ne transite par les journaux d'application : hacher les mots de passe en base ne sert à rien s'ils apparaissent en clair dans les logs à chaque connexion.
- Distinguez bien authentification (qui est l'utilisateur) et autorisation (à quoi a-t-il droit) : protéger la connexion sans restreindre l'accès aux données des autres laisse le problème principal du brief sécurité intact.

### Étape 5 - Documentez vos corrections et préparez la session de bilan

**Prérequis :**

- avoir terminé la sécurisation (étape 4), suite de tests verte à l'appui.

**Résultats attendus :**

- dans le README du dépôt, une **note de sécurisation** courte : les vulnérabilités traitées, les protections mises en place, et pour chacune le risque qu'elle écarte ;
- dans le même README, les commandes pour exécuter la suite de tests et générer le rapport de couverture (`dotnet test`, chemin du rapport Coverlet) ;
- un dépôt propre : historique de commits lisible, pas de fichiers générés versionnés inutilement (dossiers `bin/` et `obj/` exclus), rapport de couverture final accessible ;
- votre démonstration préparée : `dotnet test` qui passe au vert devant témoin, le rapport Coverlet ouvert et commenté, un endpoint protégé appelé depuis Swagger UI avec et sans authentification.

**Vérifications finales :**

- Complétez votre fiche d'autoévaluation pour identifier d'éventuels oublis avant l'échange avec votre mentor.
- Relisez votre note de sécurisation en vous mettant à la place d'un collègue qui découvre le dépôt : peut-il comprendre ce qui a changé sans vous appeler ?
- Notez ce sur quoi vous vous sentez encore fragile : c'est le meilleur point de départ de la session de bilan.

Ce que vous livrez là, c'est ce qui manquait à Pixel & Pion depuis la livraison du prestataire : une application qu'on peut modifier sans trembler, et des données clients qu'on peut regarder en face. La prochaine personne qui touchera à ce code travaillera sur vos fondations.

# Renforcez vos connaissances

Dans ce projet, vous avez appris à écrire des tests unitaires et d'intégration, à interpréter un rapport de couverture, et à sécuriser les données et l'authentification d'une application existante.

La reformulation fait partie des techniques d'apprentissage qui fonctionnent et qui permettent de renforcer vos connaissances et compétences.

Nous vous proposons donc un outil qui vous permet de travailler cette reformulation et ainsi ancrer votre apprentissage plus profondément.

Pour cela, vous allez pouvoir utiliser l'outil Companion, qui a été spécialement entraîné pour vous permettre de reformuler et d'affiner votre pensée. Cet engagement cognitif plus fort vous permettra de renforcer vos connaissances et d'être plus à l'aise lors de votre session de bilan.

Quand vous serez parvenu à une formulation claire et satisfaisante des notions que vous souhaitez retravailler (par exemple : la différence entre test unitaire et test d'intégration, ce que mesure et ne mesure pas la couverture, la différence entre hachage et chiffrement), faites une capture d'écran de la fin de la conversation et intégrez-la dans vos livrables.

Si des notions du projet vous semblent suffisamment claires pour ne pas nécessiter d'échange d'approfondissement, cela signifie que vous vous sentez suffisamment solide pour présenter votre travail.

Cliquez sur le bouton ci-dessous et commencez à échanger avec Companion.

:::encadre type=info
Mettre ici le lien vers le custom Companion
:::

---

# Livrables et session de bilan

## Livrables

1. **Dépôt GitHub de l'application fiabilisée** (lien vers le dépôt), contenant : le code des tests unitaires et des tests d'intégration, les corrections de sécurité (mots de passe hachés, authentification et autorisation en place), et dans le README une courte note expliquant les vulnérabilités traitées et les protections mises en place, ainsi que les commandes pour exécuter les tests.
2. **Rapport de couverture de tests**, exporté depuis le dépôt (ou accessible dans celui-ci à un chemin indiqué dans le README), couvrant la suite complète.
3. **Capture(s) d'écran de vos échanges avec Companion** montrant votre compréhension des notions du projet que vous aviez besoin de retravailler.

:::encadre type=info
Déposez sur la plateforme, dans un dossier zip nommé **Titre_du_projet_nom_prénom**, tous les livrables du projet comme suit : **Nom_Prénom_n° du livrable_nom du livrable_date de démarrage du projet**.

Cela donnera :

- Nom_Prénom_1_depot_application_mmaaaa
- Nom_Prénom_2_rapport_couverture_mmaaaa
- Nom_Prénom_3_captures_companion_mmaaaa

Par exemple, le premier livrable peut être nommé comme suit : Dupont_Jean_1_depot_application_012026.
:::

## Session de bilan

Ce projet ne fait pas l'objet d'une soutenance. Vous présentez votre travail à votre mentor accompagnateur, qui vous connaît et qui vous suit depuis le début du projet.

**Ce que vous montrez**

- Votre suite de tests, exécutée en direct devant votre mentor, du lancement de la commande au résultat au vert.
- Votre rapport de couverture, ouvert et commenté : ce qui est couvert, ce qui ne l'est pas, et pourquoi.
- Un endpoint protégé, appelé en direct avec puis sans authentification, pour montrer vos protections à l'œuvre.

**Ce dont vous parlez**

- Vos choix de découpage : ce que vous avez testé en unitaire, ce que vous avez testé en intégration, et ce qui a guidé la frontière.
- Un échec de test que vous avez rencontré : ce qu'il révélait, et comment vous avez tranché entre corriger le code et corriger le test.
- Vos corrections de sécurité : pour chacune, le risque concret qu'elle écarte pour les clients de l'entreprise.
- Ce sur quoi vous vous sentez encore fragile. Le dire ne vous pénalise pas : c'est même ce qui rend la session utile.

**Ce que vous en retirez**

Votre mentor vous dira où vous en êtes par rapport au projet de synthèse qui suit, et ce qu'il vous conseille de consolider avant de l'aborder.

:::encadre type=info
Comptez une trentaine de minutes. Cette session n'a pas de format imposé et ne se prépare pas comme une soutenance : venez avec votre dépôt ouvert, votre environnement prêt pour la démonstration, et vos questions.
:::

---
