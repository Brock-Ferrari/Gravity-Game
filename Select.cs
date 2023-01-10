using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{

    public GameObject onClick;
    public GameObject offClick;
    public float timeDelay = .2f;

    public void DelayStart()
    {
        Invoke("StartGame", .1f);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LvL 1");
    }

    public void EndGameDelay()
    {
        Invoke("EndGame", .5f);
    }

    public void EndGame()
    {
        Application.Quit();
        Debug.Log("Game has ended.");
    }

    public void RestartGameDelay()
    {
        Invoke("RestartGame", .1f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void OnClick()
    {
        onClick.SetActive(true);
        Invoke("Reset", timeDelay);
    }

    public void OffClick()
    {
        offClick.SetActive(true);
        Invoke("Reset", timeDelay);
    }
    private void Reset()
    {
        onClick.SetActive(false);
        offClick.SetActive(false);
    }
}
