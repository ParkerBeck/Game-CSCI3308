#User Acceptance Tests:

**Test 1:**

- Use Case ID: UC-01
- Use Case Name: Movement Test
- Description: User can move from the left of the screen, jump on top of a static block, and clear the right of the screen.

- Users: Players
- Pre-Conditions: GameObject has movement script, and the environment has all necessary colliders.
- Post-Conditions: The user successfully clears the right of the screen from the top of the block.
- Frequency of Use: Every time the game is played.

*Flow of Events:*
- 1.
  - Actor Action: Actor attempts to move towards the block from bottom left.
  - System Response: Player moves towards the block.
- 2.
  - Actor Action: Actor attemps to jump on top of the block.
  - System Response: Jump not quite high enough, requires two jumps.
- 3.
  - Actor Action: Actor attempts to clear the right of the screen.
  - System Response: Actor clears the right side of the screen.
  
- Test Pass? Yes.
- Additional Notes: Movement would benefit from being less flowy. Making it tighter should be a goal.

**Test 2:**

- Use Case ID: UC-02
- Use Case Name: End of Level Test
- Description: User can enter a trigger, and successfully enter the next level.

- Users: Players
- Pre-Conditions: End of Level script is loaded into an active trigger.
- Post-Conditions: User successfuly enters the next level.
- Frequency of Use: At the end of every game level.

*Flow of Events:*
- 1.
  - Actor Action: Actor moves into the trigger.
  - System Response: No print to the screen, but trigger does detect the player.
- 2.
  - Actor Action: Actor is prompted to press enter.
  - System Response: The next scene loads.

- Test Pass? Yes.
- Additonal Notes: There is a bug that is causing the GUI Text to not print to the screen.

**Test 3:**

- Use Case ID: UC-03
- Use Case Name: Enemy Death Test
- Description: User can collide with enemy and "kill" it only when colliding from the top.

- Users: Players
- Pre-Conditions: All colliders and scripts are in place in both the player and enemy.
- Post-Conditions: User successfuly destroys enemy from the top but not from anywhere else.
- Frequency of Use: Almost every time the game is ran.

*Flow of Events:*
- 1.
  - Actor Action: Actor jumps near enemy.
  - System Response: GameObject moves up predictably.
- 2.
  - Actor Action: Actor targets enemy and lands on top.
  - System Response: Enemy becomes inactive and is affectively "killed".
- 3.
  - Actor Action: Actor hits enemy from side.
  - System Response: Enemy is also affectively "killed".

- Test Pass? No.
- Additional Notes: Need to re-look at code to ensure that hits from the side of an enemy do not kill the enemy.

