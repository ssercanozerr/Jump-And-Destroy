using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneUIScript : MonoBehaviour
{
    public Text scoreTxt;
    public static float score;

    public void Start()
    {
        GameSceneUIScript.score = 0;
    }
    void Update()
    {
        scoreTxt.text = score.ToString();
    }
}
