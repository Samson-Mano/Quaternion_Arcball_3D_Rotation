# Quaternion Arcball 3D Rotation
Implementation of  Arcball which tackles the problem that the mouse is in 2D and the object is in 3D by picturing a sphere behind the screen that when clicked pinches the sphere and by dragging, the sphere is rotated around its center with all its associated objects

## Step 0: Defining the mouse events
Before starting the 3D rotation, lets define the mouse events associated with carrying out the rotation. 
1. left mouse down -> Left mouse down signals the start of the rotation event
2. left mouse down + mouse move -> left mouse click and drag actively performs the rotation
3. left mouse up -> Rotation event is ended

Other initialization to consider before the start of the rotation are Transformations (Stored as Matrix4f) and Arcball class.\
-> ArcBall stores the information about the virtual sphere (initialized with the Width and Height of painting area)\
-> Transformation variable stores the rotation details as both Rotation matrix and Quaternion.

## Step 1: Map to sphere
ArcBall stores the information about the virtual unit sphere. The screen co-ordinates are scaled down to the boundary of unit sphere. Important thing is to note is the sphere is actually an ellipsoid where the screen points are normalized in both x & y.

Event 1:- Rotation starts (when the left mouse button is pressed down)\
Start vector (3D vector) is calculated from the mouse point (Mx,My). If the mouse point lies outside the sphere its assumed to be lies on the edge of the sphere with z=0.

![](/Images/virtual_sphere1.png)

Event 2:- Rotation in progress (when the left mouse button is still pressed down and dragged)\
End Vector (3D vector) is calculated based on the current mouse point when dragged.

## Step 2: Calculating Rotation Quaternions
A (normalized) quaternion in the axis-angle interpretation is a directional vector and the rotation angle around this vector. The perpendicular vector P which is the cross product of start and end vectors and the rotation angle which is the dot product of start and end vectors forms the Rotation quaternion. This rotation quaternion is multiplied and normailized with further rotation transformations.

![](/Images/virtual_sphere2.png)

## Conclusion
3Blue1Brown explaination of Quaternions is very elegant and dives much deeper into quaternions. In case of implementation in 3D rotation the main things to note are using quaternions to store the tranformation, multiplication of quaternions instead of rotation matrix and no gimbal lock which happens with Euler angles.

# My Implementation
-> GUI loads objects and allows rotation be performed with left mouse click and drag.\
-> Menu Load allows different objects be loaded (Cube, Sphere, Cylinder, Donut, Klein Bottle)\
-> Menu object allows features of visualizatioin be switched on and off.\
-> Status Menu view allows user to change the view to a pre-set view (Front view, Side view, Top view etc.)

![](/Images/do_nut.png)

![](/Images/Klein_bottle.png)

![](/Images/cylinder.png)

Other exercises are\
-> Implementation of primitive shading using the z-paint order.\
-> Animating the rotation to a pre-set view (By quaternion multiplication)

Things to improve are\
-> Improving the speed of rendering. This program is not efficient in handling bigger model. More tweaks and research are needed.\
-> Improving the shading technique & providing a camera angle\
-> Pan and zoom is not implemented (Although I have previously implemented these features, this program only deals with Rotation)\
-> Other GUI options (Like adjusting transperency, loading a custom objects etc.)

## References
1. ARCBALL: A User Interface for Specifying Three-Dimensional Orientation Using a Mouse
Ken Shoemake, Computer Graphics Laboratory, University of Pennsylvania, Philadelphia, PA 19104
2. https://eater.net/quaternions && https://www.3blue1brown.com/topics/geometry (YouTube: 3Blue1Brown)
3. https://www.3dgep.com/understanding-quaternions/
4. https://www.gamedeveloper.com/programming/rotating-objects-using-quaternions
