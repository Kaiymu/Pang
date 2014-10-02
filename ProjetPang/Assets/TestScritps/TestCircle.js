#pragma strict
 
var rotationSpeed : float = 10;  
var managerInput : GameObject;

private var minimumZ = -360;
private var maximumZ = 360;
private var rotationZ : float;
 
function Update () {
   
   // rotationZ += Input.GetAxis("Horizontal") * rotationSpeed;
   // rotationZ = ClampAngle(rotationZ, minimumZ, maximumZ);
   
    transform.rotation = Quaternion.AngleAxis (rotationZ, Vector3.forward);
}
 
static function ClampAngle (angle : float, min : float, max : float) {
   if (angle < -360)
      angle += 360;
   if (angle > 360)
      angle -= 360;
   return Mathf.Clamp (angle, min, max);
}