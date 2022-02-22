# CST326 Project 2 - Platformer (Part 1 Done)

A platform game that is definitely not Mario.

## Part 1:

- Level Parser to create levels on start using Prefabs of different blocks.
  - Prefabs each have a material, which each have a texture.
- UI to imitate the original. Keeps track of score, coins, world/level, and time.
  - Timer counts down starting from 300 using Time.fixedTime.
  - Functions exist to add/substract score, coins, and to change each text in UIManager script.
- Use RayCasting to detect if a GameObject was clicked.
  - Destroys bricks if clicked.
  - Adds a coin to the coin counter if a question block is clicked.

#### Additional Notes:

- Font used: https://assetstore.unity.com/packages/2d/fonts/free-pixel-font-thaleah-140059
- UI Coin image made by me since I couldn't find one online.
