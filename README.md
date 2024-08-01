# 🛒 Online Shopping API Backend

👋 Bienvenue dans le backend de notre application de shopping en ligne!   
*(Cette application a seulement pour but de pratiquer.👀)*

## 📚 Stack
- ASP.NET Core ⚙️
- Minimal API 🛠️
- SqLite & SQLServer 📦
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
 
- 💾 **Database_Shop**: Contient les contexte de base de données et les migrations, elle gère la création et la mise à jour de la base de données.
   - 🔗 **Références**: Aucune <br>  

- 🧪 **TestXUnit_Shop**: Contient les tests unitaires. Ce projet assure la validation du fonctionnement correct de chaque partie de l'application.
   - 🔗 **Références**: API, BLL, DAL

## 🐣 Gestion des migrations et update des différentes bases de données

### 🌐 Fournisseurs de bases de données disponibles :
- **SqLite**
- **SQL Server**

### 🚀 Ajout de migrations :

```shell
dotnet ef migrations add initialCreate_SqlLite --context ShopDbContextSqlLite --output-dir Migrations/SqlLite
```


#### 📝 Explications de la commande :
- **`initialCreate_SqlLite`**:
  - *Convention personnelle, ajouter _SqlLite à la fin de chaque migration.*

- **`--context ShopDbContextSqlLite`**:
  - *Cible le contexte approprié.*

- **`--output-dir Migrations/SqlLite`**:
  - *Cible le dossier approprié.*


## 💻 Frontend (pas encore connecter simple ébauche)
Le frontend de cette application est construit avec Angular 17 et Tailwind CSS. L'application frontend interagit avec cette API pour gérer les données utilisateur et les opérations de shopping.

*projet du Frontend*
[🔎](https://github.com/8b477/front-shop-template)

<br> 

## 🗺️ Schema Database

![Ceci est un exemple d’image](https://github.com/8b477/back-shop-template/blob/master/Schema/schema_DB.png)

<br>  

## 🗺️ Schema Database (E-A)  

![Ceci est un exemple d’image](https://github.com/8b477/back-shop-template/blob/master/Schema/schema_DB_EA.png)


------------------- 

------------------- 


## TODO
 
- Utilisation de l'indexation avec fluentAPI pour tout ce qui est recherche récurrente pour opti les perf.
- Rework Unit test (mockup is not current).
- Add pattern Unit of Work.
- Adding Redis for improve performance, optimization with memory caching.
