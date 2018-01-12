using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

	public Material noneMaterial;
	public Material XMaterial;
	public  Material OMaterial;
	public enum Type
	{
		None,
		X,
		O
	}
	
	//TODO see if there is a way to swich this whole thing into a property, once I have internet connection and can figure out how properties work again
	[SerializeField] private Type slotType;

	public void setSlotType(Type input)
	{
		slotType = input;

		switch(input)
		{
			case Type.None:
				Debug.LogWarning("we just set " + transform.name + " to None. that isn't normal...");
				GetComponent<MeshRenderer>().material = noneMaterial;
				break;
			case Type.X:
				Debug.Log("setting " + transform.name + " to X");
				GetComponent<MeshRenderer>().material = XMaterial;
				break;
			case Type.O:
				Debug.Log("setting " + transform.name + " to O");
				GetComponent<MeshRenderer>().material = OMaterial;
				break;
		}
	}

	public Type getSlotType()
	{
		return slotType;
	}
}
