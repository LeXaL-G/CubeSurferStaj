using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private GameObject winPanel;

    private void Update()
    {
        if (GameManager.instance.startedGame)
            mainPanel.SetActive(false);
        if (GameManager.instance.endGame)
            deathPanel.SetActive(true);
        if (GameManager.instance.wonGame)
            winPanel.SetActive(true);
    }

    public void NextButton()
    {
        GameManager.instance.wonGame = false;
        winPanel.SetActive(false);
        mainPanel.SetActive(true);
        LevelManager.instance.NextLevel();
        GameManager.instance.startedGame = false;
        Time.timeScale = 1;
    }

    public void TryButton()
    {
        GameManager.instance.endGame = false;
        deathPanel.SetActive(false);
        mainPanel.SetActive(true);
        LevelManager.instance.TryAgain();
        GameManager.instance.startedGame = false;
        Time.timeScale = 1;
    }
}
