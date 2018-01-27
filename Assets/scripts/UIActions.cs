using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActions : MonoBehaviour {

    [SerializeField] UnityEngine.UI.Button pauseButton;
	public Animator cubeAnimator;
	bool isPaused = false;
    [SerializeField] GameObject pauseMenu;
	public void Restart()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("thelevel");
	}

	public void ToggleView()
	{
		if(cubeAnimator.GetCurrentAnimatorStateInfo(0).IsName("default"))
			cubeAnimator.Play("cubeOpening");
		else if(cubeAnimator.GetCurrentAnimatorStateInfo(0).IsName("cubeOpening"))
			cubeAnimator.SetTrigger("switchToClosing");
		
	}

	public string scoreText()
	{
		PlayerManager manager = FindObjectOfType<PlayerManager>();
		return "X score: " + manager.xScore + "\nO score: " + manager.oScore;
	}

    public void Pause()
    {
		GameObject.Find("toggleView button").GetComponent<UnityEngine.UI.Button>().enabled = false;
		FindObjectOfType<Placement>().enabled = false;
		FindObjectOfType<CameraMovement>().enabled = false;
		pauseMenu.SetActive(true);
    }

    public void Resume()
    {
		GameObject.Find("toggleView button").GetComponent<UnityEngine.UI.Button>().enabled = true;
		//GameObject.Find("gameStart UI").SetActive(false);
        FindObjectOfType<Placement>().enabled = true;
        FindObjectOfType<CameraMovement>().enabled = true;
        pauseMenu.SetActive(false);
    }

	public UnityEngine.UI.Text scoreTextObject;

	void Update()
	{
		scoreTextObject.text = scoreText();
	}

	public void togglePausing()
	{
		if(isPaused)
			Resume();
		else
			Pause();
		isPaused = !isPaused;
	}

	public void gotIt()
    {
		GameObject.Find("toggleView button").GetComponent<UnityEngine.UI.Button>().enabled = true;
		GameObject.Find("gameStart UI").SetActive(false);
        FindObjectOfType<Placement>().enabled = true;
        FindObjectOfType<CameraMovement>().enabled = true;
        pauseMenu.SetActive(false);
    }
}