using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseBackground;
    public GameObject cannonUse;
    public GameObject menuButton;

    public void OpenPauseMenu(bool yes)
    {
        pauseBackground.SetActive(yes);
        cannonUse.GetComponent<Movement>().enabled = !yes;
        menuButton.SetActive(!yes);
        Physics.autoSimulation = !yes;
    }

    public void ResumeGame(bool yes)
    {
        menuButton.SetActive(yes);
        cannonUse.GetComponent<Movement>().enabled = yes;
        pauseBackground.SetActive(!yes);
        Physics.autoSimulation = yes;
    }

    public void ReturnToMenuDelay()
    {
        Invoke("ReturnToMenu", .2f);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Start Screen");
        Physics.autoSimulation = true;
    }
}
