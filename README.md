# React & Asp.Net application

## Prerequis

- Node
- Yarn ou Npm
- Visual Studio 2017 

# Exercices

Faire un website C# .net en webapi avec 2 webservices qui acceptent des paramètres et retournent du json :
-    /api/authenticate ( pas besoin d’authentification ). Paramètres du ws « email » et « password ». Retourne « true » ou « false »
-    /api/confidentials ( authentifié ). Paramètre « email ». Retourne le  « true » ou « false ».
 
Pour le service /api/confidentials implémentation du mode d’authentification d'AWS dont la doc est ici :  http://docs.aws.amazon.com/AmazonS3/latest/dev/RESTAuthentication.html 
 
## FRONT

Le front de l'applicatif (page de login) a été réalisé avec REACT JS

## BACK

Le back de l'applicatif a été réalisé en C#

## Installation

# Etape 1

Il vous suffit d'installer le projet "ServiceAws" en local et d'executer sur le dossier "Front_End "npm install puis npm start" (ou yarn puis yarn start) afin de pouvour lancer l'application front.

# Etape 2
Lancer Visual studio, attention, il se peut que le port généré par visual studio ne corresponde pas au port renseigné dans le fichier loginContainer.jsx, il faudra donc
le changer pour les variables :
- const authenticateUrl = `http://localhost:62463/api/authenticate/${email}/${password}`;
- const confidentialsUrl = `http://localhost:62463/api/confidentials/${email}/`;
Dans un futur, ce port sera mis dans un fichier de conf.

De plus, dans le web.config, on retouve les clés/valeurs pour la bonne saisie du login (email) et du mot de passe.
On y trouve aussi des infos (filePath et fileName) permettant de recuperer les infos de connexion et le token issue de AWS.

Dispo pour quelques questions à soufiane.mouffok@gmail.com

## Amélioration

Bien évidemment cette appli n'est pas finalisée et on peut y améliorer pas mal de choses.
