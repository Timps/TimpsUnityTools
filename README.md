## TimpsUnityTools
Some quick simple utility tools to make scene nav and level design easier in Unity 3d

# Instructions
Just import the folder in your Unity assets (/Assets/TimpsTools/ is the default)
You can now see and use the tools via the Tools > Timps > Show Dockable menu item.

1. Tools > Timps > Remove Parents
This removes the connection between a child and a parent object.
You can select multiple objects, then select the menu item and return them to the root of the heirachy.
2. Tools > Timps > Show Dockable
This shows the dockable window with the tools in it.
![Image of Timps Tools Dockable window](https://i.imgur.com/eMpjRPT.png)

## Dockable tools
There are eight tools in the dockable window in four categories.

1.Parenting
Use this tool to parent one object to another. It doesn't change the positions or rotations, only attaches them together in the heirachy.
Simply select the object you want to parent to another, and press the button.
Then select the object you want to parent it to and press the second.
You can also drag an object into the selector to choose it.
NB: it works only on single objects. But works with the heirachy or scene views.

2. De Parent
Use this tool to send any/all selected objects back to the root of the heirachy and remove all parent/child relationships.
It works on multiple objects and does not affect position or rotation. A child object will retain it's inherited position from the parent.

3. Heirachy Changes - move to Top
Use this tool to move the selected object to the top of the heirachy window.
It works on root objects only, child objects won't move or take their parent to the top.

4.Clear Console
This button clears the console window, Useful to clear the console window from elsewhere if streaming etc

5. Transform - Copy/Paste position
Use this tool to copy and paste the position of an object onto another. 
It does not work on multiple objects.

6. Transform - Copy/Paste Rotation
Use this tool to copy and paste the rotation of an object onto another.
It does not work on multiple objects.

7. Transform Copy/Paste All
Use this tool to copy and paste the rotation and position of an object onto another.
It does not work on multiple objects.

These tools were built to quickly move objects around a scene when designing a level. You can parent things to get them into the right place in the heirachy and then copy and paste positions.

EG select the street lamp you need from the other side of the level and duplicate it (CTRL+D). Then parent it to an object where you want it. Copy/paste the transform of it. Then de parent and you've now got a new streetlight on the other side of the level in the right place both heirachy and position wise.
