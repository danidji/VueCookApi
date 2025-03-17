# VueCookApi

## Description

Cette API RESTful développée en **ASP.NET Core** permet la gestion d'un catalogue de recettes de cuisine. Elle offre des fonctionnalités CRUD (Création, Lecture, Mise à jour, Suppression) pour interagir avec une base de données **SQL Server** hébergée sur **Azure**.

L'API est destinée à être consommée par une application **Vue.js**, facilitant la gestion des recettes via une interface utilisateur moderne et réactive.

## Fonctionnalités

- **Créer** une recette avec titre, ingrédients, instructions, etc.
- **Lire** les recettes disponibles (par ID ou liste complète).
- **Mettre à jour** une recette existante.
- **Supprimer** une recette.

## Technologies utilisées

- **Back-end** : ASP.NET Core, Entity Framework Core, SQL Server
- **Cloud** : Azure App Service, Azure Storage, Azure Key Vault
- **Front-end** : Vue.js (consommation de l’API)
