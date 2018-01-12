using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour {

	public bool wasTouchUsed = false;
	void Update()
	{
		if(Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit) && hit.collider.gameObject.GetComponent<Slot>() != null)
			{
				wasTouchUsed = true;
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

		if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Stationary)
			wasTouchUsed = false;
	}
}
