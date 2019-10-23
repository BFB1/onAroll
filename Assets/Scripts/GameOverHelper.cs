using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHelper : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Awake()
    {
        // Standard Asset FirstPersonController scriptið læsir músinni, gerir hana ósýnilega
        // og tekur ekki einu sinni til eftir sig! Fuss og svei....
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        scoreText.text = $"you got to wave {ScoreHelper.wave}\nand shot {ScoreHelper.score} rollers";
    }
}