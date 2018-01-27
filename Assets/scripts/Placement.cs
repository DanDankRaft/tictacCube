using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour {

	float stationaryTime = 0;
	[SerializeField] bool didEverMove;
	void Update()
	{
		Touch primaryTouch;
		if(Input.touchCount == 1)
		{
			primaryTouch = Input.touches[0];
			if(primaryTouch.phase == TouchPhase.Began)
			{
				didEverMove = false;
			}
			else if(primaryTouch.phase == TouchPhase.Moved)
			{
				didEverMove = true;
			}
			
			if(primaryTouch.phase == TouchPhase.Ended && !didEverMove)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if(Physics.Raycast(ray, out hit) && hit.collider.gameObject.GetComponent<Slot>() != null)
				{
					Slot ourSlot = hit.collider.gameObject.GetComponent<Slot>();
					if(ourSlot.getSlotType() == Slot.Type.None)
					{
						switch(FindObjectOfType<PlayerManager>().currentPlayer)
						{
							case PlayerManager.Player.X:
								ourSlot.setSlotType(Slot.Type.X);
								FindObjectOfType<PlayerManager>().currentPlayer = PlayerManager.Player.O;
								break;
							case PlayerManager.Player.O:
								ourSlot.setSlotType(Slot.Type.O);
								FindObjectOfType<PlayerManager>().currentPlayer = PlayerManager.Player.X;
								break;
						}
						FindObjectOfType<PlayerManager>().calcScore();
					}
				}
			}
		}
		

	}
}
