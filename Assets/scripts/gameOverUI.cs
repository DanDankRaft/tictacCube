using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverUI : MonoBehaviour {

	public void PlayAgain()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("thelevel");
	}
}
