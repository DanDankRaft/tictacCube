using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	Vector2 positionDelta;
	public float sensetivity;
	void Update()
	{
		//the if statement is just to make sure it's not zoom
		if(Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Moved)
		{
			positionDelta = Input.touches[0].deltaPosition;

			rotate(directionIndex.leftRight, positionDelta.x*sensetivity);
			rotate(directionIndex.upDown, positionDelta.y*sensetivity);
		}
	}

	public void setSensetivity(float newSenstivity)
	{
		PlayerPrefs.SetFloat("cameraSensetivity", newSenstivity);
		sensetivity = newSenstivity;
	}

	void Awake()
	{
		sensetivity = PlayerPrefs.GetFloat("cameraSensetivity", 0.5f);
	}


	public enum directionIndex
	{
		leftRight,
		upDown
	}

	public Transform cubeParentObject;

	public void rotate(directionIndex direction, float intensity)
	{
		Vector3 vectorDirection;

		switch(direction)
		{
			case directionIndex.upDown:
				vectorDirection = Vector3.right;
				break;
			default: //case fallthrough!!!
			case directionIndex.leftRight:
				vectorDirection = Vector3.down;
				break;
		}
		cubeParentObject.Rotate(cubeParentObject.InverseTransformDirection(vectorDirection * intensity));
	}

	//TODO add the touch controls here.
}
