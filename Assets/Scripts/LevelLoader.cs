using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required to load scenes

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 3;
    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        // Whenever this script is called it gets the index of a snece which it was called from
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Start: " + currentSceneIndex);

        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    private IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        Debug.Log("Restart Scene: " + currentSceneIndex);
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        // Resuming if the game was paused
        Time.timeScale = 1;

        // String reference loads a scene with this name.
        // The scene should be added to the 'Build Settings'
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadNextScene()
    {
        // Loading next scene: Current scene index + 1
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadYouLose()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
