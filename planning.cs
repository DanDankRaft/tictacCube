public class planning
{
    [Serialize] UnityEngine.UI.Button button;
    [Serlalize] gameObject pauseMenu;
    public void Pause()
    {
        FindObjectOfType<Placement>().enabled = false;
        FindObjectOfType<CameraMovement>().enabled = false;
        Button.enabled = false;
        pauseMenu.activated = true;
    }

    public void Resume()
    {
        FindObjectOfType<Placement>().enabled = true;
        FindObjectOfType<CameraMovement>().enabled = true;
        Button.enabled = true;
        pauseMenu.activated = false;
    }
}