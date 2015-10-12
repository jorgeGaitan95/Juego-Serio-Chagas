using UnityEngine;
using System.Collections;

public class TouchCamaraControl : MonoBehaviour {

	public float moveSensitivityX = 1.0f;
	public float moveSensitivityY = 1.0f;
	public bool updateZoomSensitivity = true;
	public float orthoZoomSpeed = 0.05f;
	public float minZoom = 100.0f;
	public float maxZoom = 200.0f;
	public bool invertMoveX = false;
	public bool invertMoveY = false;
	public float mapWidth = 700.0f;
	public float mapHeight = 400.0f;
	
	public float inertiaDuration = 1.0f;
	
	private Camera _camera;
	
	private float minX, maxX, minY, maxY;
	private float horizontalExtent, verticalExtent;
	
	private float scrollVelocity = 0.0f;
	private float timeTouchPhaseEnded;
	private Vector2 scrollDirection = Vector2.zero;
	
	void Start () 
	{
		_camera = Camera.main;
		
		maxZoom = 0.5f * (mapWidth / _camera.aspect);
		
		if (mapWidth > mapHeight)
			maxZoom = 0.5f * mapHeight;
		
		if (_camera.orthographicSize > maxZoom)
			_camera.orthographicSize = maxZoom;
		
	
	}
	
	void Update () 
	{
		if (updateZoomSensitivity)
		{
			moveSensitivityX = _camera.orthographicSize / 4.0f;
			moveSensitivityY = _camera.orthographicSize / 5.0f;
		}
		
		Touch[] touches = Input.touches;
		
		if (touches.Length < 1)
		{
			//if the camera is currently scrolling
			if (scrollVelocity != 0.0f)
			{
				//slow down over time
				float t = (Time.time - timeTouchPhaseEnded) / inertiaDuration;
				float frameVelocity = Mathf.Lerp (scrollVelocity, 0.0f, t);
				_camera.transform.position += -(Vector3)scrollDirection.normalized * (frameVelocity * 0.05f) * Time.deltaTime;
				
				if (t >= 1.0f)
					scrollVelocity = 0.0f;
			}
		}
		
		if (touches.Length > 0)
		{
			//Single touch (move)
			if (touches.Length == 1)
			{
				if (touches[0].phase == TouchPhase.Began)
				{
					scrollVelocity = 0.0f;
				}
				else if (touches[0].phase == TouchPhase.Moved)
				{
					Vector3 delta = touches[0].deltaPosition;
					
					float positionX = delta.x * moveSensitivityX * Time.deltaTime;
					positionX = invertMoveX ? positionX : positionX * -1;
					
					float positionY = delta.y * moveSensitivityY * Time.deltaTime;
					positionY = invertMoveY ? positionY : positionY * -1;



					_camera.transform.position += new Vector3 (positionX,positionY,delta.z);
					
					scrollDirection = touches[0].deltaPosition.normalized;
					scrollVelocity = touches[0].deltaPosition.magnitude / touches[0].deltaTime;
					
					
					if (scrollVelocity <= 100)
						scrollVelocity = 0;
				}
				else if (touches[0].phase == TouchPhase.Ended)
				{
					timeTouchPhaseEnded = Time.time;
				}
			}
		}
	}

	
	void LateUpdate ()
	{
		Vector3 limitedCameraPosition = _camera.transform.position;
		limitedCameraPosition.x = Mathf.Clamp (limitedCameraPosition.x, -260,-50);
		limitedCameraPosition.y = Mathf.Clamp (limitedCameraPosition.y, 300,400);
		limitedCameraPosition.z = Mathf.Clamp (limitedCameraPosition.z, 0, 10);

		_camera.transform.position = limitedCameraPosition;
	}
	
	void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube (Vector3.zero, new Vector3 (mapWidth, mapHeight, 0));
	}
}
