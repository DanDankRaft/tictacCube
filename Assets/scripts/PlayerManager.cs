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

	public Slot[] slots;


	Slot.Type[] slotsType;


	public GameObject gameOverUI;
	public void scoreCalc()
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
							Debug.Log("X has been given a point for a horizontal line");
							xScore++;
							break;
						case Slot.Type.O:
							Debug.Log("O has been given a point for a horizontal line");
							oScore++;
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
						//our conditional makes it impossible for none to be called, at least I think that's what's happening
						case Slot.Type.X:
							Debug.Log("X has been given a point for a vertical line");
							xScore++;
							break;
						case Slot.Type.O:
							Debug.Log("O has been given a point for a vertical line");
							oScore++;
							break;
					}
				}
			}

			//diagonal lines.
			//there are 2 types of diagonals- ones that go from top left to bottom right, and vice versa. Thus the 2 if statements
			if(slotsType[n] == slotsType[n+4] && slotsType[n+4] == slotsType[n+8])
			{
					switch(slotsType[n])
					{
						//our conditional makes it impossible for none to be called, at least I think that's what's happening
						case Slot.Type.X:
							Debug.Log("X has been given a point for a diagonal line");
							xScore++;
							break;
						case Slot.Type.O:
							Debug.Log("O has been given a point for a digonal line");
							oScore++;
							break;
					}
			}

			if(slotsType[n+2] == slotsType[n+4] && slotsType[n+4] == slotsType[n+6])
			{
					switch(slotsType[n+2])
					{
						//our conditional makes it impossible for none to be called, at least I think that's what's happening
						case Slot.Type.X:
							Debug.Log("X has been given a point for a diagonal line");
							xScore++;
							break;
						case Slot.Type.O:
							Debug.Log("O has been given a point for a digonal line");
							oScore++;
							break;
					}
			}
		}

		for(int n = 0; n < 9; n += 1)
		{
			if(slotsType[n] == slotsType[n+9] && slotsType[n+9] == slotsType[n+18])
			{
				switch(slotsType[n])
				{
					case Slot.Type.X:
						xScore++;
						Debug.Log("X has been given a point for a z-horizontal line");
						break;
					case Slot.Type.O:
						oScore++;
						Debug.Log("O has been given a point for a z-horizontal line");
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
				scoreCalc(); //Just in case

				GameObject instantiatedUI = Instantiate(gameOverUI, FindObjectOfType<Canvas>().transform);
				if(xScore > oScore)
				{
					instantiatedUI.transform.GetComponentInChildren<UnityEngine.UI.Text>().text = "X won!";
				}
				else if(oScore > xScore)
				{
					instantiatedUI.transform.GetComponentInChildren<UnityEngine.UI.Text>().text = "O won!";
				}
				else
				{
					instantiatedUI.transform.GetComponentInChildren<UnityEngine.UI.Text>().text = "Draw!";
				}
				isGameOver = true;

				//make sure that all slots are visible. TODO, if we change toggleView's behavior, remember to change this part aswell
				if(!slots[0].GetComponent<MeshRenderer>().enabled) ToggleView();

				FindObjectOfType<CameraMovement>().enabled = false;
				FindObjectOfType<Placement>().enabled = false;
			}
		}
	}

	public void ToggleView()
	{
		for(int i = 0; i < slots.Length; i++)
		{
			if(i != 13)
			{
				slots[i].GetComponent<MeshRenderer>().enabled = !slots[i].GetComponent<MeshRenderer>().enabled;
				slots[i].GetComponent<BoxCollider>().enabled = !slots[i].GetComponent<BoxCollider>().enabled;
			}
		}
	}
}
