using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private SpawnController spawnController;
    [SerializeField] private PlayerCamera playerCamera;
    [SerializeField] private WeaponController weaponController;
    [SerializeField] private GameObject finishPanel;

    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text bestScoreText;

    public int score;
    public int bestScore;

    public static int gameMode;

    public static float time;
    public float timeSeconds;
    public float timeMinute;

    private bool isSpawenedBad;
    private bool isSpawenedSuper;

    private void Start()
    {
        StartCoroutine(spawnController.SpawnGoodSphere());
    }

    private void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            TimerFinished();
        }

        int minutes;
        int seconds;

        if(time <= 0)
        {
            minutes = 0;
            seconds = 0;
        }
        else
        {
            minutes = Mathf.FloorToInt(time / 60);
            seconds = Mathf.FloorToInt(time % 60);
        }

        timeText.text = $"Время: {minutes:00}:{seconds:00}";
    }

    public void SetSphere()
    {
        if(score > 20 && !isSpawenedBad)
        {
            StartCoroutine(spawnController.SpawnBadSphere());
            isSpawenedBad = true;
        }

        if(score < 20 && isSpawenedBad)
        {
            StopCoroutine(spawnController.SpawnBadSphere());
            isSpawenedBad = false;
        }

        if(score > 40 && !isSpawenedSuper)
        {
            StartCoroutine(spawnController.SpawnBadSphere());
            isSpawenedSuper = true;
        }

        if(score < 40 && isSpawenedSuper)
        {
            StopCoroutine(spawnController.SpawnSuperSphere());
            isSpawenedSuper = false;
        }
    }

    private void TimerFinished()
    {
        if(gameMode == 1)
        {
            if(score >= PlayerPrefs.GetInt("BestScore30", 0))
            {
                PlayerPrefs.SetInt("BestScore30", score);
                Debug.Log("Best Score: " + PlayerPrefs.GetInt("BestScore30", 0));
                scoreText.text = "Результат: " + score;
                bestScoreText.text = "Лучший результат: " + PlayerPrefs.GetInt("BestScore30", 0);

                Yandex.SetToLeaderboard(score);
            }
            else
            {
                scoreText.text = "Результат: " + score;
                bestScoreText.text = "Лучший результат: " + PlayerPrefs.GetInt("BestScore30", 0);
            }
        }

        if(gameMode == 2)
        {
            if(score >= PlayerPrefs.GetInt("BestScore60", 0))
            {
                PlayerPrefs.SetInt("BestScore60", score);
                Debug.Log("Best Score: " + PlayerPrefs.GetInt("BestScore60", 0));
                scoreText.text = "Результат: " + score;
                bestScoreText.text = "Лучший результат: " + PlayerPrefs.GetInt("BestScore60", 0);
            }
            else
            {
                scoreText.text = "Результат: " + score;
                bestScoreText.text = "Лучший результат: " + PlayerPrefs.GetInt("BestScore60", 0);
            }
        }

        if(gameMode == 3)
        {
            if(score >= PlayerPrefs.GetInt("BestScore150", 0))
            {
                PlayerPrefs.SetInt("BestScore150", score);
                Debug.Log("Best Score: " + PlayerPrefs.GetInt("BestScore150", 0));
                scoreText.text = "Результат: " + score;
                bestScoreText.text = "Лучший результат: " + PlayerPrefs.GetInt("BestScore150", 0);
            }
            else
            {
                scoreText.text = "Результат: " + score;
                bestScoreText.text = "Лучший результат: " + PlayerPrefs.GetInt("BestScore150", 0);
            }
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        playerCamera.isPaused = true;
        weaponController.isCanShoot = false;
        finishPanel.SetActive(true);

        Yandex.ShowAdv();
    }
}
