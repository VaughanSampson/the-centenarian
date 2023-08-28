# The Centenarian
##Winner of the "People's Choice" award at the 2023 University of Queensland hackathon.
<br><br>
_The Centenarian_ is a project to create a "virtual cockpit" controller which is satisfying to use in controlling a spaceship in a 2D environment. Built in Unity, this game is designed to take Arduino controls. You play as the captain of a 100 year old ship made of scrap metal, exploring space to find Uranium ores after nuclear war destroyed Earth.

https://github.com/VaughanSampson/the-centenarian/assets/128713660/d676e02b-a5a8-45b5-a503-ee0e4cf1b449

https://github.com/VaughanSampson/the-centenarian/assets/128713660/bfa51174-3985-4f6b-88c0-2e1004cb705f

https://github.com/VaughanSampson/the-centenarian/assets/128713660/131ce5a7-46f5-4b49-b115-0191fc32a93a

<br><br>

## Unity Game
The game is simple, generating an asteroid belt with Poisson disc sampling and Perlin noise. Most asteroids are large and must be avoided but others are small and can be shot at and destroyed for Uranium (score). The scene is dark and the player ship has to utilise the ship's front light to see objects, creating a cool visual and intimidating exploration.
<br><br>

## Arduino Controller
The controller requires an ultrasound range finder, a potentiometer and 2 buttons. The closer something is to the ultrasound detector, the faster acceleration is, so the "virtual cockpit" has an acceleration handle which can slide to and from the ultrasound detector. The potentiometer is used as a steering wheel and in menu selection, so a screw driver extrudes vertically from the "virtual cockpit," attached to the potentiometer. 1 button (the firing button) is fitted under the potentiometer to trigger when the potentiometer is pressed down (the screwdriving is pushed down). Lastly another button is simply used to pause and unpause the game.
<br><br>

## Keyboard Controller
The unity game can also take keyboard input for testing purposes, but this does not function like the Arduino controller. 'E' is shoot. Space-bar is used to accelerate, and the mouse's position is used to affect acceleration speed and turning speed.

