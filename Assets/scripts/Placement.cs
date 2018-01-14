using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour {

	void Update()
	{
		Touch potentialTouch;
		float touchTime = 0;
		float touchDistance = 0;
		if(Input.touchCount > 0)
		{
			potentialTouch = Input.touches[0];
			touchTime += potentialTouch.deltaTime;
			touchDistance += potentialTouch.deltaPosition.magnitude;
			if(Input.GetMouseButtonDown(0) || (touchTime > 0.1f && touchDistance < 0.5f))
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
						FindObjectOfType<PlayerManager>().scoreCalc();
					}
				}

			}
		}
		

	}
}
