using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerImage : MonoBehaviour {

	public Sprite xSprite;
	public Sprite oSprite;

	void FixedUpdate()
	{
		switch(FindObjectOfType<PlayerManager>().currentPlayer)
		{
			case PlayerManager.Player.X:
				GetComponent<UnityEngine.UI.Image>().sprite = xSprite;
				break;
			case PlayerManager.Player.O:
				GetComponent<UnityEngine.UI.Image>().sprite = oSprite;
				break;
		}
	}
}
