using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActions : MonoBehaviour {

	public Animator cubeAnimator;
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

    [SerializeField] UnityEngine.UI.Button pauseButton;
    [SerializeField] GameObject pauseMenu;
    public void Pause()
    {
        FindObjectOfType<Placement>().enabled = false;
        FindObjectOfType<CameraMovement>().enabled = false;
        //pauseButton.enabled = false;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        FindObjectOfType<Placement>().enabled = true;
        FindObjectOfType<CameraMovement>().enabled = true;
        //pauseButton.enabled = true;
        pauseMenu.SetActive(false);
    }

	public UnityEngine.UI.Text scoreTextObject;

	void Update()
	{
		scoreTextObject.text = scoreText();
	}
}