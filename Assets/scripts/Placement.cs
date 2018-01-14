using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour {

	float touchTime = 0;
	float touchDistance = 0;
	void Update()
	{
		Touch primaryTouch;
		if(Input.touchCount == 1)
		{
			primaryTouch = Input.touches[0];
			touchTime += primaryTouch.deltaTime;
			touchDistance += primaryTouch.deltaPosition.magnitude;
			
			if(touchTime > 0.5f && touchDistance < 1f)
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


			if(Input.touches[0].phase == TouchPhase.Ended)
			{
				touchTime = 0;
				touchDistance = 0;
			}
		}
		

	}
}
