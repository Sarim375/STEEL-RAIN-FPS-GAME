# 🔫 STEEL RAIN - First-Person Shooter (FPS) Game

![Unity](https://img.shields.io/badge/Engine-Unity%203D-lightgrey.svg)
![Genre](https://img.shields.io/badge/Genre-First--Person%20Shooter-red.svg)
![Platform](https://img.shields.io/badge/Platform-Windows-blue.svg)

Steel Rain is a fully-functional 3D First-Person Shooter game developed for a Game Programming course. It combines custom gameplay scripting, rigid-body physics, pathfinding AI, and visual feedback systems to create a playable action arena.

This repository contains both the **complete Unity project source code** and a **compiled standalone executable build**.

---

## 🎮 Gameplay & Technical Mechanics

The game architecture is split into several modular C# systems:

### 1. Physics-Based First-Person Controller (`PlayerController.cs`)
- Handles player movement relative to the player's coordinate space.
- Utilizes rigid-body physics for movement rather than basic transform translations.
- Incorporates vertical mouse look clamping (clamped vertical rotation from `-90` to `90` degrees) and spacebar jumps.

### 2. Raycast Shooting System (`GunScript.cs`)
- Fires instantaneous bullet streams using 3D raycasting.
- **Scoping Mechanic**: Triggers smooth camera FOV zoom transitions (from `60` down to `45`) and weapon scope animators upon right-click.
- **Ammo System**: Limits max ammo capacity (10 rounds) and automatically executes an async reload coroutine upon depletion.
- **Effects**: Triggers particle muzzle flashes and recoil animations with every shot.

### 3. Intelligent NavMesh Enemy AI (`EnemyAiTutorial.cs` & `Enemy.cs`)
- Integrates Unity's NavMesh pathfinding system for state-driven NPCs.
- **Patrol State**: Searches and wanders towards random localized walkpoints.
- **Chase State**: Aggressively tracks and paths towards the player's real-time position.
- **Attack State**: Spawns rigid-body projectiles and launches them with impulse forces towards the player when in range.

### 4. Health & Audio UI Interfaces (`HealthController.cs` & `SoundManager.cs`)
- Manages player damage tracking, updating a Bootstrap-like slider visual in real time.
- Triggers centralized sound effects for rifle shots and reload triggers.

---

## ⌨️ Control Layout

| Action | Control Key | Description |
| :--- | :--- | :--- |
| **Move Forward / Backward** | `W` / `S` | Moves player along looking direction |
| **Strafe Left / Right** | `A` / `D` | Sidesteps player horizontally |
| **Jump** | `Space` | Applies upward rigid-body impulse force |
| **Shoot Weapon** | `Left Click` (Mouse0) | Fires raycast bullets and applies impact force |
| **Aimed Scope (ADS)** | `Right Click` (Mouse1) | Toggles weapon scoping and zooms camera FOV |
| **Simulate Damage (Test)** | `I` | Inflicts 25 points of test damage on the player |

---

## 📂 Repository Contents

```
STEEL-RAIN-FPS-GAME/
├── Assets/
│   ├── Scripts/                    # Custom C# gameplay files (Player, Gun, Enemy AI, etc.)
│   ├── Animations/                 # Rigging models and reload/scope state machine configurations
│   ├── Prefabs/                    # Configured player, enemy, and bullet game object blueprints
│   ├── Scenes/                     # Main combat scene map assets
│   └── Sound/                      # Audio clips for weapon fire and reload sounds
├── ProjectSettings/                # Unity project input and audio mappings
├── Steel Rain ( FPS ).exe          # Compiled game launcher (Windows)
├── Steel Rain ( FPS )_Data/        # Standalone runtime resources
├── UnityPlayer.dll                 # Compiled Unity engine core runtime library
├── .gitignore                      # Excludes Unity's temporary library cache directories
└── LICENSE                         # MIT License details
```

---

## 🚀 How to Run the Game

### Method 1: Play the Compiled Build (Windows Only)
1. Clone this repository:
   ```bash
   git clone https://github.com/Sarim375/STEEL-RAIN-FPS-GAME.git
   cd STEEL-RAIN-FPS-GAME
   ```
2. Double-click [Steel Rain ( FPS ).exe](file:///c:/Users/Sarim/Desktop/Project%20Development/STEEL-RAIN-FPS-GAME/Steel%20Rain%20(%20FPS%20).exe) to run the game directly.

### Method 2: Open Source in Unity Editor
1. Install **Unity Hub** and the compatible Unity Editor version (specified in `ProjectSettings/ProjectVersion.txt`).
2. Add the `STEEL-RAIN-FPS-GAME` directory as a project in Unity Hub.
3. Open the project and launch the `Main Scene` from the `Assets/Scenes` folder.
4. Press **Play** inside the editor to test, edit, and extend the scripts.

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](file:///c:/Users/Sarim/Desktop/Project%20Development/STEEL-RAIN-FPS-GAME/LICENSE) file for details.
