using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalHit : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject cannonUse;
    public GameObject menuButton;
    public GameObject winParticles;

    private void OnCollisionEnter(Collision collision)      // Displays win screen and freezes game
    {
        if (collision.rigidbody.tag == "Projectile")
        {
            winScreen.SetActive(true);
            cannonUse.GetComponent<Movement>().enabled = false;
            menuButton.SetActive(false);
            Physics.autoSimulation = false;
            Instantiate(winParticles, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
        }
        if (collision.rigidbody.tag == "Aim Projectile")
        {
            Destroy(collision.gameObject);
        }
    }

    public void LoadNextLevelDelay()     // Loads the next level
    {
        Invoke("LoadNextLevel", .1f);
    }

    public void LoadNextLevel()     // Loads the next level
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
        Physics.autoSimulation = true;
    }

    public void ReturnToMenuDelay()      // Returns to main menu
    {
        Invoke("ReturnToMenu", .1f);
    }

    public void ReturnToMenu()      // Returns to main menu
    {
        SceneManager.LoadScene("Start Screen");
        Physics.autoSimulation = true;
    }
}
