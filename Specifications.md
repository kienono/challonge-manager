# Challonge Manager - Spécifications #

## Introduction ##
Ce document décrit les fonctionnalités de l'application Challonge Manager. Cette application est développée dans le cadre des activités de l'association LaDose, organisatrice d'événements de Versus Fighting sur la region lyonnaise.

## Objectif ##
Challonge Manager a pour but de faciliter l'organisation des tournois de LaDose aussi bien dans leur préparation, le suivi des résultats en cours de tournoi et dans l'agrégation des résultats après les tournois, notamment en vu de réaliser un classement des joueurs.

## Contexte ##
LaDose organise ses tournois en utilisant un outil en ligne de création et de suivi de tournoi nommé Challonge. Cet outil supporte différents types de tournois (arbres à simple ou double élimination, round robin ou poule, tournoi à points). Il est déjà bien pratique et gère notamment automatiquement la construction des arbres en temps réel en fonction des résultats de match. Par contre, il ne permet pas de gérer automatiquement des tournois en plusieurs phases (poules de qualification puis arbre final).

Challonge propose heureusement une API permettant d'accéder à ses fonctionnalités autorisant une couche applicative supérieure plus intelligente à la piloter et à créer de nouvelles fonctionnalités. C'est ce que vise à faire Challonge Manager.

## Contraintes d'utilisation ##
  * toutes les données de tournoi et de joueurs doivent être associées à un même compte Challonge (a priori, celui de LaDose).
  * les tournois doivent être marqués avec un tag dans leur nom afin de faciliter le regroupement de résultats (uniquement les ranking par exemple).
  * un même joueur peut porter plusieurs noms différents mais sous certaines règles. Les seules variations de nom autorisées sont des variation dans la casse et l’ajout d’un nom d’équipe en suffixe ou en préfixe. Dans tous les cas, sera considéré comme nom principal, la variante la plus simple (= la plus courte).
  * L’API Challonge permet de détecter un participant marqué absent lors d'un tournoi (statut inactif) mais ne permet pas de différencier facilement un forfait d'un abandon en court de tournoi. Il sera demandé au gestionnaire des tournoi sous Challonge d'ajouter le tag `[FORFAIT]` au nom des joueurs forfaits dès le début d'un tournoi.

## Fonctionnalités ##
  * Calcul de points d'un participant à un tournoi à partir de règles se basant sur le classement du joueur dans le tournoi considéré, du nombre de participants au tournoi (et du jeu). Dans un premier temps, ces règles de calcul seront intégrées en dur dans l'application à partir des règles déjà en vigueur dans l'association.
  * Le nombre de participants d'un tournoi utilisé dans le calcul des points attribués ne prend pas en compte les forfaits et les abandons en court de tournoi.
  * Agrégation des points d'un joueur donné sur plusieurs tournois. L’outil permettra de faire une première sélection des tournois à considérer (généralement via un tag dans le nom du tournoi et à partir d’un critère de date). Dans cette première sélection, il sera ensuite possible de retirer certains tournois dans le calcul de points.
  * Création d'un rapport de classement des joueurs à partir des résultats d'un ensemble de tournois. Les tournois considérés peuvent être filtrés en fonction d'une période de temps et d’un tag à chercher dans le nom du tournoi. Ce rapport se représentera sous la forme d'un tableau ordonné par nombre de points acquis avec le détail des points acquis par jeu.