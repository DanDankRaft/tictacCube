using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

	public enum Player
	{
		X,
		O
	}

	public Player currentPlayer;
	public float xScore;
	public float oScore;

	[UnityEngine.SerializeField] GameObject gameOverUI;
	public Slot[] slots;


	Slot.Type[] slotsType;


	void givePoint(Player player, string message=" misc. reason")
	{
		switch(player)
		{
			case Player.X:
				Debug.Log("X got a point for " + message);
				xScore++;
				break;
			case Player.O:
				Debug.Log("O got a point for " + message);
				oScore++;
				break;
		}
	}
	public void calcScore()
	{
		xScore = 0;
		oScore = 0;

		//kees slotsType[] up to date
		slotsType = new Slot.Type[27];
		for(int i = 0; i < slots.Length; i++)
			slotsType[i] = slots[i].getSlotType();

		//the extra loop uses the indexer as an addition factor (is that how you call those?) that will apply the logic of the front 9 cubes to the back 18
		for(int n = 0; n < 27; n += 9)
		{
			//horizontal lines.
			for(int i = 0; i < 9; i += 3)
			{
				if(slotsType[i+n] == slotsType[i+n+1] && slotsType[i+n+1] == slotsType[i+n+2])
				{
					switch(slotsType[i+n])
					{
						//our conditional makes it impossible for none to be called, at least I think that's what's happening
						case Slot.Type.X:
							givePoint(Player.X, "a horizontal line");
							break;
						case Slot.Type.O:
							givePoint(Player.O, "a horizontal line");
							break;
					}
				}
			}

			//vertical lines.
			for(int i = 0; i < 3; i++)
			{
				if(slotsType[i+n] == slotsType[i+n+3] && slotsType[i+n+3] == slotsType[i+n+6])
				{
					switch(slotsType[i+n])
					{
						case Slot.Type.X:
							givePoint(Player.X, "a vertical line");
							break;
						case Slot.Type.O:
							givePoint(Player.O, "a vertical line");
							break;
					}
				}
			}

			//diagonal lines.
			//First type of diagonal
			if(slotsType[n] == slotsType[n+4] && slotsType[n+4] == slotsType[n+8])
			{
					switch(slotsType[n])
					{
						case Slot.Type.X:
							givePoint(Player.X, "a diagonal line");
							break;
						case Slot.Type.O:
							givePoint(Player.O, "a diagonal line");
							break;
					}
			}

			//second type of diagonal
			if(slotsType[n+2] == slotsType[n+4] && slotsType[n+4] == slotsType[n+6])
			{
					switch(slotsType[n+2])
					{
						case Slot.Type.X:
							givePoint(Player.X, "a diagonal line");
							break;
						case Slot.Type.O:
							givePoint(Player.O, "a diagonal line");
							break;
					}
			}
		}

		//z-horizontal lines
		for(int n = 0; n < 9; n += 1)
		{
			if(slotsType[n] == slotsType[n+9] && slotsType[n+9] == slotsType[n+18])
			{
				switch(slotsType[n])
				{
					case Slot.Type.X:
							givePoint(Player.X, "a z-horizontal line");
						break;
					case Slot.Type.O:
							givePoint(Player.O, "a z-horizontal line");
						break;
				}
			}
		}
	}

	bool isGameOver;
	void Update()
	{
		if(!isGameOver)
		{
			//when the game is over
			bool areAllSlotsFull = true;
			foreach(Slot slot in slots)
			{
				if(slot.getSlotType() == Slot.Type.None)
					areAllSlotsFull = false;
			}

			if(areAllSlotsFull)
			{
				calcScore(); //Just in case

				gameOverUI.SetActive(true);
				if(xScore > oScore)
					gameOverUI.transform.GetComponentInChildren<UnityEngine.UI.Text>().text = "X won!";
				else if(oScore > xScore)
					gameOverUI.transform.GetComponentInChildren<UnityEngine.UI.Text>().text = "O won!";
				else
					gameOverUI.transform.GetComponentInChildren<UnityEngine.UI.Text>().text = "Draw!";
				isGameOver = true;

				//make sure that all slots are visible. TODO, if we change toggleView's behavior, remember to change this part aswell
				if(!slots[0].GetComponent<MeshRenderer>().enabled) FindObjectOfType<UIActions>().ToggleView();

				FindObjectOfType<CameraMovement>().enabled = false;
				FindObjectOfType<Placement>().enabled = false;
			}
		}
	}


}
