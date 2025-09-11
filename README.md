# 🎮 Jeu Unity – Plateforme avec niveaux et boutique

---

## 🧠 Présentation du projet

Ce projet est un jeu développé avec **Unity**, inspiré d’un tutoriel de création de jeu 2D.  
Le joueur progresse à travers plusieurs niveaux, qui se débloquent au fur et à mesure qu’ils sont complétés.  
Une boutique intégrée permet d’acheter des améliorations ou du contenu supplémentaire.

Fonctionnalités principales :

🕹️ Déplacements fluides (clavier)

🔓 Déblocage progressif des niveaux

🛒 Système de boutique accessible en jeu

⭐ Gestion des scores et progression sauvegardée

---

## 📂 Structure du projet

```
├── Assets/ # Scripts, sprites, sons et scènes Unity
├── Builds/ # Dossier contenant les builds exportées (Windows / Web)
├── ProjectSettings/ # Paramètres Unity du projet
├── Packages/ # Dépendances Unity
└── README.md # Documentation du projet
```


---

## 📦 Prérequis

- **Unity Hub** installé  
- **Unity Editor** version 2021.3 LTS ou supérieure  
- Pour jouer directement :  
  - Une **build Windows (.exe)**  
  - Ou une **version WebGL** hébergée  

---

# 🚀 Lancer le jeu

### 1️⃣ Via une build Windows
1. Télécharger le fichier `.zip` de la build.  
2. Extraire le dossier.  
3. Lancer le fichier `.exe` :


```
./Builds/Windows/MonJeu.exe
```
⚠️ Garder le dossier `MonJeu_Data` à côté du `.exe`, sinon le jeu ne se lancera pas.

---

### 2️⃣ Via une build WebGL
- Ouvrir l’URL du projet hébergé (ex. GitHub Pages ou itch.io).  
- Le jeu se lance directement dans le navigateur.  

---

## 🎮 Contrôles

- **Flèches directionnelles** → Déplacement du personnage  
- **Espace** → Saut  
- **B** → Ouvrir / fermer la boutique  
- **Échap** → Pause / retour au menu  

---

## 🎲 Gameplay

- Les niveaux se débloquent **progressivement** après chaque réussite.  
- La boutique permet d’acheter :  
- Améliorations pour le personnage  
- Nouveaux skins / bonus  
- La progression est sauvegardée automatiquement (niveaux et achats).  

---

## 🛠️ Fonctionnement technique

- **Scènes Unity** : chaque niveau correspond à une scène distincte.  
- **Gestion des niveaux** : un script vérifie si le joueur a terminé un niveau pour débloquer le suivant.  
- **Système de boutique** : interface UI reliée à une monnaie en jeu (coins / points).  
- **Sauvegarde** : PlayerPrefs (sauvegarde locale) ou système de fichiers selon configuration.  

---

## 🏗️ Architecture & Design Patterns

Le projet s’appuie sur plusieurs **design patterns** répandus dans le développement de jeux Unity :  

### 🔹 Singleton
- Utilisé pour les **Game Managers** (gestion des niveaux, de la boutique, de l’audio, etc.).  
- Assure qu’il n’existe **qu’une seule instance** accessible globalement.  
- Exemple : `GameManager.Instance` permet d’accéder à l’état du jeu depuis n’importe quel script.

### 🔹 Observer (Events / Delegates)
- Utilisé pour **notifier différents systèmes** (UI, progression, boutique) quand un événement survient.  
- Exemple : quand le joueur gagne des pièces, un **event** met automatiquement à jour l’UI de la monnaie.

### 🔹 State (optionnel selon ton projet)
- Peut être appliqué pour la **gestion des états du jeu** : Menu, En cours, Pause, Game Over.  
- Chaque état définit son comportement, ce qui rend le code plus modulaire et évolutif.

---

## 🚀 Améliorations futures

- 🎨 Amélioration des graphismes et animations  
- 📱 Export mobile (Android / iOS)  
- 🌍 Mode multijoueur en ligne  
- 🏅 Système de succès et leaderboard  

---



