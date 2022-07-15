using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    int points = 0;

    bool started = false;
    bool finished = false;
    [Header("Objects")]

    public GameObject player;
    public GameObject spawner;

    [Header("UI")]

    public TMPro.TextMeshProUGUI pointsText;
    public GameObject panelPoints;
    public GameObject panelLogo;
    public GameObject panelGameOver;
    public TMPro.TextMeshProUGUI pointsGameOver;
    void Start()
    {
        if(instance == null)
            instance = this;
    }

    public void Update()
    {
        if (Input.anyKeyDown && !started)
        {
            StartGame();
        }

        if (Input.anyKeyDown && finished)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddPoint()
    {
        points++;
        pointsText.text = points.ToString();
    }

    public void StartGame()
    {
        started = true;
        panelLogo.SetActive(false);
        panelPoints.SetActive(true);
        spawner.GetComponent<Spawner>().StartSpawn();
        player.GetComponent<Player>().SetPlayerState();
    }
    public void GameOver()
    {
        finished = true;
        panelPoints.SetActive(false);
        spawner.GetComponent<Spawner>().StopSpawn();
        panelGameOver.SetActive(true);
        pointsGameOver.text = points.ToString();
    }


}
