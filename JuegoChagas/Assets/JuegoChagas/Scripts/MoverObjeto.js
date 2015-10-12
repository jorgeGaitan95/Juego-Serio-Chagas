var spring = 50.0;
var damper = 5.0;
var drag = 10.0;
var angularDrag = 0.0;
var distance = 0.2;
var pushForce = 0.2;
var attachToCenterOfMass = false;

var highlightMaterial : Material;
private var highlightObject : GameObject;
private var objeto: GameObject;


private var springJoint : SpringJoint;

function Update()
{

if(Input.GetMouseButtonDown(0))
{
	var ray1:Ray= Camera.main.ScreenPointToRay (Input.mousePosition);
	var raycastHit:RaycastHit;
	if (Physics.Raycast (ray1, raycastHit)){
		objeto=raycastHit.collider.gameObject;
		
	}
	
if(Input.GetMouseButton(0))
{
 var ray:Ray=Camera.main.ScreenPointToRay(Input.mousePosition);
 highlightObject = null;
 if( springJoint != null && springJoint.connectedBody != null )
 {
  highlightObject = springJoint.connectedBody.gameObject;
 }
 else
 {
  // We need to actually hit an object
  
  var hitt : RaycastHit;
  if( Physics.Raycast(ray,  hitt) ) {
   if( hitt.rigidbody && !hitt.rigidbody.isKinematic ) {
    highlightObject = hitt.rigidbody.gameObject;
   }
  }
 }

  
 // We need to actually hit an object
 var hit : RaycastHit;
 if (!Physics.Raycast(ray,  hit)) {
 

  return;
  
 }
 // We need to hit a rigidbody that is not kinematic
 if (!hit.rigidbody || hit.rigidbody.isKinematic) {
 {
 
  return;
  }
 }
 
 if (!springJoint)
 {
 
 
  var go = new GameObject("Rigidbody dragger");
  var body = go.AddComponent (Rigidbody);
  springJoint = go.AddComponent (SpringJoint);
  body.isKinematic = true;
 }
 
 springJoint.transform.position = hit.point;
 if (attachToCenterOfMass)
 {
  var anchor = transform.TransformDirection(hit.rigidbody.centerOfMass) + hit.rigidbody.transform.position;
  anchor = springJoint.transform.InverseTransformPoint(anchor);
  springJoint.anchor = anchor;
 }
 else
 {
  springJoint.anchor = Vector3.zero;
 }
 
 springJoint.spring = spring;
 springJoint.damper = damper;
 springJoint.maxDistance = distance;
 springJoint.connectedBody = hit.rigidbody;
 
 DragObject(hit.distance, hit.point, Camera.main.ScreenPointToRay(Input.mousePosition).direction);
}

}
if(Input.GetMouseButtonUp(0))
	this.GetComponent.<Rigidbody>().isKinematic=true;

}



function DragObject (distance : float, hitpoint : Vector3, dir : Vector3)
{

 var startTime = Time.time;
 var mousePos = Input.mousePosition;
 
 
 var oldDrag = springJoint.connectedBody.drag;
 var oldAngularDrag = springJoint.connectedBody.angularDrag;
 springJoint.connectedBody.drag = drag;
 springJoint.connectedBody.angularDrag = angularDrag;
 
 while (Input.GetMouseButton (0))
 {
  var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
  springJoint.transform.position = ray.GetPoint(distance);
  yield;
 }
 
 if (Mathf.Abs(mousePos.x - Input.mousePosition.x) <= 2 && Mathf.Abs(mousePos.y - Input.mousePosition.y) <= 2 && Time.time - startTime < .2 && springJoint.connectedBody)
 {
  dir.y = 0;
  dir.Normalize();
  springJoint.connectedBody.AddForceAtPosition(dir * pushForce, hitpoint, ForceMode.VelocityChange);
  
 } 
 
 
 if (springJoint.connectedBody)
 {
  springJoint.connectedBody.drag = oldDrag;
  springJoint.connectedBody.angularDrag = oldAngularDrag;
  springJoint.connectedBody = null;
 }
}

function OnTriggerStay(col:Collider){

	var i:int;
	for (i = 0;i < objeto.GetComponent.<Renderer>().materials.Length; i++)
	{               
		objeto.GetComponent.<Renderer>().materials[i].color=Color.red;
	}
};

function OnTriggerExit(col:Collider){
	var i:int;
    for (i = 0;i < objeto.GetComponent.<Renderer>().materials.Length; i++)
	{               
		objeto.GetComponent.<Renderer>().materials[i].color=Color.green;
	}
}

