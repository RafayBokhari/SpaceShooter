using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject pausedPanel;
    [SerializeField] GameObject pausedButton;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject levelCompletePanel;
    [SerializeField] GameObject endText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        endText.SetActive(false);
        levelCompletePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        pausedPanel.SetActive(false);
        pausedButton.SetActive(true);
    }

   public void PausedGame()
    {
        pausedPanel.SetActive(true);
        pausedButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausedPanel.SetActive(false);
        pausedButton.SetActive(true);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        pausedButton.SetActive(false);
    }

    public IEnumerator levelComplete()

    {
        yield return new WaitForSeconds(2f);
        endText.SetActive(true );
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;
        levelCompletePanel.SetActive(true);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
