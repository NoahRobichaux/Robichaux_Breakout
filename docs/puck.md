# Puck

> ## Contents
> - **Jump To** [**Info**](https://noahrobichaux.github.io/Robichaux_Breakout/docs/mainmenu#info)
> - **Jump To** [**Other Documentation Pages**](https://noahrobichaux.github.io/Robichaux_Breakout/docs/mainmenu#other-documentation-pages)

***

> ## Info
> 
> The puck is a Unity game object that is controlled by the [_Puck Script_](https://github.com/NoahRobichaux/Robichaux_Breakout/blob/master/Assets/Scripts/Puck.cs).
> 
> At the start of Level One being loaded, the puck is frozen and the gravity scale of the puck is set to zero. 
> Then, if the player presses the spacebar, the game starts and the puck goes up in a random _x_ direction (between -10f and 10f, where f declares that it is a float). 
> 
> Once the puck comes in contact with a bar, the bar is destroyed, a sound effect is played and the puck is sent downward in a random _x_ direction (between -10f and 10f). Game play repeats from here.
>
> When the puck has broken four bars, the puck speed increases by one quarter of it's original speed. The puck's speed increases by that same amount after twelve hits, and when it has broken through the orange and red rows, respectively.
>
>Once the puck has hit the back wall, the [_Back Wall Script_](https://github.com/NoahRobichaux/Robichaux_Breakout/blob/master/Assets/Scripts/WinWall.cs) sets the Player game object's x transform (in the Game Manager Script) to half of it's original width.

***

> ## Other Documentation Pages
> - [**Main Menu**](https://noahrobichaux.github.io/Robichaux_Breakout/docs/mainmenu)
> - [**Player Controller**](https://noahrobichaux.github.io/Robichaux_Breakout/docs/player)

***

> [**Return To Home Page**](https://noahrobichaux.github.io/Robichaux_Breakout/)
