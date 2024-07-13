# 🛒 Online Shopping API Backend

👋 Bienvenue dans le backend de notre application de shopping en ligne!   
*(Cette application a seulement pour but de pratiquer.👀)*

## 📚 Stack
- ASP.NET Core ⚙️
- Minimal API 🛠️
- SQLite 📦
- Entity Framework Core🗄️
- Fluent API 🔗
- xUnit Test 🧪
- Pattern repository 📁

## 🚀 Fonctionnalités

- **CRUD Utilisateurs**: Gérez les utilisateurs de votre application de shopping.
- **Tests Unitaires**: Les tests sont réalisés avec xUnit pour garantir la fiabilité de l'API.
- **Base de Données**: Utilisation de SQLite pour une gestion simple et efficace des données.
- **Pattern Repository**: Simplifie les tests et améliore la maintenabilité du code.

## 📂 Structure du Projet

- **Controllers**: Gère les endpoints de l'API.
- **Repositories**: Contient les interfaces et implémentations des repositories.
- **Services**: Contient la logique métier de l'application.
- **Models**: Contient les entités de la base de données.
- **Data**: Contient le contexte de la base de données.
- **Tests**: Contient les tests unitaires.

## 🌐 Frontend
Le frontend de cette application est construit avec Angular 17 et Tailwind CSS. L'application frontend interagit avec cette API pour gérer les données utilisateur et les opérations de shopping.

*projet du Frontend*
[🔎](https://github.com/8b477/front-shop-template)

<br> 

------------------- 

------------------- 

## Note à moi même !

Utilisation de l'indexation avec fluentAPI pour tout ce qui est recherche récurrente pour opti les perf :
- Email => pour la contrainte unique.
- A venir les propriétés qui me servirons de filtre pour une recherche fluide dans la db (categorie, promo, ..).


## TODO

- Create DTO :
  - Article input BLL output DAL 
  - Category input BLL output DAL 
  - Order input BLL output DAL 
  

- Create validator :
  - Article. 
  - Category.
  - Order.

- Rework Unit test (mockup is not current)