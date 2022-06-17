using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreenUI : MonoBehaviour
{
    public TextMeshProUGUI headerText;
    public TextMeshProUGUI bodyText;

    public void SetEndScreen(bool didWin, int roundsSurvived)
    {
        headerText.text = didWin ? "You Win!" : "Game Over!";
        headerText.color = didWin ? Color.green : Color.red;
        bodyText.text = $"You survived {roundsSurvived} rounds.";
    }

    public void OnPlayAgainButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
