using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;


    public GameObject hudPanel;
    public Text TextScore;
    public Text TextFinalScore;
    public Text TextMaxSpeed;
    public Image Life;
    public int totalScore = 0;

    public static GameController instance;

    void Start()
    {
        instance = this;
        Time.timeScale = 1;
    }

    public void ShowMaxSpeedAlert()
    {
        StartCoroutine(MaxSpeedAlert());
    }

    IEnumerator MaxSpeedAlert()
    {
        TextMaxSpeed.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        TextMaxSpeed.gameObject.SetActive(false);
    }

    public void UpdateLifeBar(float currentLife)
    {
        float lifePercent = currentLife / 10f;
        Life.fillAmount = lifePercent;
    }

    public void UpdateTotalScore(int points)
    {
        totalScore += points;
        TextScore.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
        hudPanel.SetActive(false);
        TextMaxSpeed.gameObject.SetActive(false);

        TextFinalScore.text = "FINAL SCORE: " + totalScore.ToString();

        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }


}
