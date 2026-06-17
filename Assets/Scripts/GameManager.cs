using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text ScoreText;
    public GameObject Gameover;
    public GameObject GetReady;
    public GameObject PlayButton;
    private int Score;

    private void Awake()
    {
        GetReady.SetActive(true);
        Gameover.SetActive(false);
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        Score = 0;
        ScoreText.text = Score.ToString();

        PlayButton.SetActive(false);
        GetReady.SetActive(false);
        Gameover.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for(int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
    public void GameOver()
    {
        Gameover.SetActive(true);
        PlayButton.SetActive(true);
        Pause();
    }
    public void IncreaseScore()
    {
        Score++;
        ScoreText.text = Score.ToString();
    }
}
