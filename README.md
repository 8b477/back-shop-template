# 🛒 Online Shopping API Backend

👋 Bienvenue dans le backend de notre application de shopping en ligne!   
*(Cette application a seulement pour but de pratiquer.👀)*

## 📚 Stack
- ASP.NET Core ⚙️
- Minimal API 🛠️
- SQLite 📦
- Entity Framework Core (code first)🗄️
- Data notation 🔑
- Fluent API 🔐
- xUnit Test 🧪
- Pattern repository 📁

## 🚀 Fonctionnalités

- **CRUD Utilisateurs**: Gérez les utilisateurs de votre application de shopping.
- **Tests Unitaires**: Les tests sont réalisés avec xUnit pour garantir la fiabilité de l'API.
- **Base de Données**: Utilisation de SQLite pour une gestion simple et efficace des données.
- **Pattern Repository**: Simplifie les tests et améliore la maintenabilité du code.

## 📂 Structure du Projet

- 🌐 **API_Shop**: Ce projet contient les contrôleurs et gère les endpoints de l'API.
    - 🔗 **Références**: BLL <br>  

- 🧠 **BLL_Shop (Business Logic Layer)**: Contient la logique métier de l'application, elle applique les règles de gestion et les traitements nécessaires.
   - 🔗 **Références**: DAL <br>  

- 📦 **DAL_Shop (Data Access Layer)**: Contient les interfaces et implémentations des repositories pour accéder aux données, elle gère les interactions avec la base de données.
   - 🔗 **Références**: DATABASE <br>  
 
- 💾 **Database_Shop**: Contient le contexte de la base de données et les migrations, elle gère la création et la mise à jour de la base de données.
   - 🔗 **Références**: Aucune <br>  

- 🧪 **TestXUnit_Shop**: Contient les tests unitaires. Ce projet assure la validation du fonctionnement correct de chaque partie de l'application.
   - 🔗 **Références**: API, BLL, DAL


## 💻 Frontend
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
 
- Create validator :
  - Article. 
  - Category.
  - Order.

- Rework Unit test (mockup is not current)
- Add patern Unit of Work
