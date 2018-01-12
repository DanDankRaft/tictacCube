using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	Vector2 positionDelta;
	public float intensity;
	void Update()
	{
		if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved && !FindObjectOfType<Placement>().wasTouchUsed)
		{
			positionDelta = Input.touches[0].deltaPosition;

			rotate(2, positionDelta.x*intensity);
			rotate(0, positionDelta.y*intensity);
		}
	}


	public Transform cubeParentObject;

	public void rotate(int directionIndex, float intensity)
	{
		Vector3 vectorDirection;

		switch(directionIndex)
		{
			case 0:
				vectorDirection = Vector3.right;
				break;
			case 1:
				vectorDirection = Vector3.left;
				break;
			case 2:
				vectorDirection = Vector3.down;
				break;
			case 3:
				vectorDirection = Vector3.up;
				break;
			default:
				vectorDirection = Vector3.zero;
				break;
		}
		cubeParentObject.Rotate(cubeParentObject.InverseTransformDirection(vectorDirection * intensity));
	}

	//TODO add the touch controls here.
}
