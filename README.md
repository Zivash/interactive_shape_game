Here's a GitHub README version for your project:

---

# **Interactive Shape-Based Game**

This project is a Windows Forms application that offers an engaging and interactive game experience by incorporating various geometric shapes. Users can interact with shapes like circles, squares, rectangles, and parallelograms, with dynamic visual effects and gameplay mechanics.

## **Key Features**

### 1. **Object-Oriented Design**  
- Utilizes abstract classes and inheritance to define different geometric shapes.  
- Each shape has properties like position, color, and highlighting, making it easy to extend or modify.

### 2. **Interactive Gameplay**  
- Users can interact with shapes drawn on the canvas, receiving feedback when shapes are clicked.  
- Shapes include circles, squares, parallelograms, and rectangles, each with customized behaviors and properties.

### 3. **Scoring and Leveling System**  
- Dynamic scoring system where players earn points by interacting with specific shapes.  
- As the score increases, players level up, changing the gameplay difficulty and time limits.

### 4. **Sound Effects**  
- Integrated sound effects to enhance user experience during actions like popping shapes, winning, and incorrect interactions.  
- Custom audio files used for actions like “win,” “lose,” and “wrong,” providing immediate feedback.

### 5. **Game Logic Management**  
- A `GameManager` class handles the game's rules, including scoring, level progression, and remaining time.  
- Features a game-over condition with an option to restart the game, ensuring continuous enjoyment for the player.

### 6. **Code Reusability and Extensibility**  
- Designed with modular and reusable code, making it easy to add more shapes or modify the game logic.  
- Emphasis on clean programming practices and separation of concerns, ensuring the codebase is maintainable.




# Figure Pop Game

A fun interactive game where you need to pop figures (circle, square, parallelogram, rectangle) before time runs out. The game involves scoring points by selecting the correct figures, with sound effects for actions and level progression.

## Features
- **Multiple Shapes**: The game includes circles, squares, rectangles, and parallelograms.
- **Levels and Scoring**: Score per figure increases as you level up. Each level unlocks faster gameplay with a shorter time limit.
- **Sound Effects**: Includes sound effects for actions like winning, losing, popping a figure, and making a wrong selection.
- **Game Over and Retry**: When the game ends, a prompt will ask if you want to try again.

## Prerequisites

- .NET Framework 4.7 or higher (for running WinForms applications)
- Visual Studio or any other IDE capable of compiling .NET projects
