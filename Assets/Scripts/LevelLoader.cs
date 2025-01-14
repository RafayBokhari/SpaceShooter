using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void NextLevel()
    {
        if(currentIndex>=3)
        {
            currentIndex = 0;
        }
        SceneManager.LoadScene(currentIndex + 1);
    }
  public void Reload()
    {
        SceneManager.LoadScene(currentIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
