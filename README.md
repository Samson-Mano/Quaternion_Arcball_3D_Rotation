# Quaternion Arcball 3D Rotation
Implementation of  Arcball which tackles the problem that the mouse is in 2D and the object is in 3D by picturing a sphere behind the screen that when clicked pinches the sphere and by dragging, the sphere is rotated around its center with all its associated objects

## Step 0: Defining the mouse events
Before starting the 3D rotation, lets define the mouse events associated with carrying out the rotation. 
1. left mouse down -> Left mouse down signals the start of the rotation event
2. left mouse down + mouse move -> left mouse click and drag actively performs the rotation
3. left mouse up -> Rotation event is ended

