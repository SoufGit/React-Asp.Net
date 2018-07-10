# React & Asp.Net application

## Prerequis

Visual Studio 2017 

# Exercices

Faire un website C# .net en webapi avec 2 webservices qui acceptent des param�tres et retournent du json :
-    /api/authenticate ( pas besoin d�authentification ). Param�tres du ws � email � et � password �. Retourne � true � ou � false �
-    /api/confidentials ( authentifi� ). Param�tre � email �. Retourne le  � true � ou � false �.
 
Pour le service /api/confidentials impl�menter le m�me mode d�authentification que AWS dont la doc est ici :  http://docs.aws.amazon.com/AmazonS3/latest/dev/RESTAuthentication.html 
 
NOTES :
1/ Pas besoin de faire un projet avec des acc�s en base de donn�es, des donn�es mock�es suffisent
2/ Il n�y a pas de solution id�ale
3/ L��nonc� est volontairement vague

## FRONT

Le front de l'applicatif (page de login) a �t� r�alis� avec REACT JS

## BACK

Le back de l'applicatif a �t� r�alis� en C#

## Installation

# Etape 1

Il vous suffit d'installer le projet en local et executer sur le dossier "Front_End "npm install puis npm start" (ou yarn puis yarn start) 
afin de pouvour lancer l'application front.

# Etape 2
Puis de lancer Visual studio, attention, il se peut que le port g�n�r� par visual studio ne corresponde pas au port renseign� dans le fichier loginContainer.jsx, il faudra donc
le changer pour les variables :
- const authenticateUrl = `http://localhost:62463/api/authenticate/${email}/${password}`;
- const confidentialsUrl = `http://localhost:62463/api/confidentials/${email}/`;
Dans un futur, ce port sera mis dans un fichier de conf.

De plus, dans le web.config, on retouve les cl�s/valeurs pour la bonne saisie du login(email) et mot de passe.
On y trouve aussi des infos (filePath et fileName) permettant de recuperer les infos de connexion et le token issue de AWS.

Dispo pour quelques questions � soufiane.mouffok@gmail.com

## Am�lioration

Bien �videmment cette appli n'est pas finalis�e et on peut y am�liorer pas mal de choses.