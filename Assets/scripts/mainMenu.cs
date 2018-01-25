using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour {

	public void newGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("thelevel");
	}

}
