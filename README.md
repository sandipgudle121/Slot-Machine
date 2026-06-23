# 🎰 Unity Slot Machine Game

A polished and playable Slot Machine Game developed in Unity as part of an assignment to demonstrate Unity development skills, OOP principles, UI development, RNG implementation, and clean project architecture.

---

## 📌 Project Overview

This project implements a classic 3-reel slot machine using Unity's UI system (`Canvas`, `Image`, `RectTransform`) rather than world-space sprites.

Players can:

- Select a bet amount
- Spin the slot machine
- Win rewards based on matching symbols
- Manage their balance through gameplay

---

## ✨ Features Implemented

### Core Gameplay
- ✅ 3-Reel Slot Machine
- ✅ Player Balance System
- ✅ Bet Selection (10 / 50 / 100)
- ✅ Spin Button
- ✅ Random Symbol Generation
- ✅ Win/Loss Detection
- ✅ Payout Calculation
- ✅ Dynamic Balance Updates
- ✅ Result Status Display

### Architecture
- ✅ Modular Script Organization
- ✅ Separation of Responsibilities
- ✅ ScriptableObject-Based Symbol Data
- ✅ OOP-Oriented Design

### UI
- ✅ Unity UI-Based Implementation
- ✅ TextMeshPro Integration
- ✅ Responsive Layout Structure

---

## 🎮 Gameplay Flow

```text
Starting Balance: 1000

Select Bet
↓
Press Spin
↓
Bet Amount Deducted
↓
Three Random Symbols Generated
↓
Win Condition Checked
↓
Balance Updated
↓
Result Displayed
```

---

## 🏆 Win Conditions

The player wins when all three visible center symbols match.

Examples:

```text
🍒 🍒 🍒
🔔 🔔 🔔
BAR BAR BAR
7️⃣ 7️⃣ 7️⃣
```

---

## 💰 Payout Table

| Symbol | Multiplier |
|----------|------------|
| Cherry | 2× |
| Bell | 4× |
| BAR | 6× |
| Seven | 10× |

Reward Calculation:

```text
Reward = Bet × Symbol Multiplier
```

Example:

```text
Bet = 50
Seven Match = 50 × 10

Reward = 500
```

---

## 🧠 RNG Implementation

The slot machine uses Unity's random number generator to produce independent reel outcomes.

```csharp
Random.Range(0, symbols.Length);
```

Features:

- Fair outcomes
- Independent reel results
- No predictable patterns

---

## 🏗️ Project Structure

```text
Assets
├── Animations
├── Materials
├── Prefabs
├── Resources
├── ScriptableObjects

├── Scripts
│   ├── Core
│   │   ├── GameManager.cs
│   │   └── SlotMachineController.cs
│   │
│   ├── Data
│   │   ├── SymbolData.cs
│   │   └── PayoutTable.cs
│   │
│   ├── Managers
│   │   ├── AudioManager.cs
│   │   └── CurrencyManager.cs
│   │
│   ├── Reels
│   │   ├── ReelController.cs
│   │   └── SymbolController.cs
│   │
│   ├── UI
│   │   └── UIManager.cs
│   │
│   └── Utilities
│       └── RNGUtility.cs
│
├── Sounds
├── Sprites
└── UI
```

---

## 🧩 Architecture Overview

### GameManager
Responsible for:
- Managing game flow
- Handling bets
- Processing spins
- Checking win conditions

### CurrencyManager
Responsible for:
- Player balance
- Spending currency
- Awarding payouts

### UIManager
Responsible for:
- Updating balance text
- Updating bet text
- Updating result messages

### SlotMachineController
Responsible for:
- Random symbol generation
- Updating visible symbols

### SymbolData
ScriptableObject containing:
- Symbol Name
- Symbol Sprite
- Payout Multiplier

---

## ▶️ How to Run

1. Open the project in Unity.
2. Open the main scene.
3. Press the Play button.
4. Select a bet amount.
5. Press Spin to play.

---

## 🚀 Current Development Status

### Completed
- Balance System
- Bet Selection
- RNG System
- Spin Functionality
- Win Detection
- Payout System
- ScriptableObject Symbol Data

### Planned Enhancements
- Reel Spin Animation
- Sequential Reel Stops
- Lever Animation
- Audio Effects
- Win Particles
- Symbol Highlight Effects
- Screen Shake
- WebGL Build

---

## 🛠️ Technologies Used

- Unity Engine
- C#
- TextMeshPro
- Unity UI System
- ScriptableObjects

---

## 👨‍💻 Development Approach

The project focuses on:

- Clean architecture
- Maintainable code
- Separation of concerns
- Scalable systems
- Professional project organization

The implementation prioritizes readability and extensibility while remaining beginner-friendly.

---

## 📄 License

This project was created for educational and evaluation purposes as part of a Unity development assignment.
