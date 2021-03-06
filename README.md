# VanoTD
### Defend Väinölä from evil forces of Pohjola!
VanoTD is single player tower defence where you will defend Väinölä from waves of enemies and even from prime evil!

## Game Design
### Player Experience
Cunning defender of Väinölä, home town of Kalevala folk

### Core Mechanic
Build towers to shoot enemies so that they don't reach your city

### Core Game Loop
Defeat waves of enemies which become stronger every wave!

## Todo
Things to work on

### General gameplay
- [x] Map has Väinölä and Pohjola
- [x] Single type of enemy spawns from Pohjola
- [x] Player has lives
- [x] Enemies spawn in waves
- [x] Player loses lives when enemies reach Väinölä
- [x] Player receives money when they kill enemies
- [x] Player can move the camera (with mouse?)
- [ ] Player has build time between waves

### Towers
- [x] Towers target enemies
- [x] Towers damage enemies with projectiles
- [x] Towers only emit projectile when shooting
- [x] Towers have attack range
- [ ] 

### Building
- [x] Player can build single tower
- [x] Player can destroy single tower
- [x] Player consumes money when building towers
- [ ] Towers take time to build
- [ ] Player can see what they're about to build
- [ ] Player can select from different towers to build
  - [ ] Player can open build menu
  - [ ] Player can see the available towers
  - [ ] Player can see the cost of towers
  - [ ] Player can select tower to be placed
  - [ ] Player can place the selected tower

### Enemies
- [x] Enemies move towards Väinölä via predefined path
- [x] Enemies search their own path from Pohjola to Väinölä
- [ ] Enemies have one waypoint in middle of their path between Pohjola and Väinölä
- [x] Enemies can only move on allowed tiles and area
- [x] Enemies recalculate their path when player builds new tower
- [ ] Enemies health increases for every wave
- [ ] Each wave has own model with their own properties
  - [x] Wave 1: Snowball
  - [x] Wave 2: Mud monster
  - [x] Wave 3: Golem
  - [ ] Wave 4: Spirit of Greed
  - [ ] Wave 5: Daughter of Pohjola
  - [ ] Boss: Louhi

### Models
- [x] Model cannon tower
  - [x] Model projectile
- [ ] Model spear tower
  - [ ] Model projectile
- [ ] Model one enemy
- [ ] Model five enemies
  - [ ] Model snowball
  - [ ] Model mud monster
  - [ ] Model golem
  - [ ] Model spirit of greed
  - [ ] Model daughter of Pohjola
  - [ ] Model Louhi
- [x] Model Väinölä
- [x] Model Pohjola
- [x] Model grass tiles
- [ ] Model two trees
- [ ] Model bush
- [ ] Model water tile

### UI
- [ ] Players start from main menu
- [x] Players can see enemies health
- [x] Players can see their gold
- [x] Players can see their lives
- [ ] Players can see current level
- [ ] Player can see the number and name of the wave

### Tweaks & Fixes
- [ ] Clear object pool after wave