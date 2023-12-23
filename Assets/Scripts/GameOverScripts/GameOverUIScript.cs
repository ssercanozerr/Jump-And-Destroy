using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIScript : MonoBehaviour
{
    public Text scoreTxt;

    private void Start()
    {
        scoreTxt.text = GameSceneUIScript.score.ToString();
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
