using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] private int countdownTime;
    [SerializeField] private TextMeshProUGUI countdownDisplay;

    public GameOverScreen GameOverScreen;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(CountdownToStart());
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void GameOver()
    {
        GameOverScreen.Setup();
    }

    // Update is called once per frame
    public void BeginGame()
    {
        TimerController.instance.BeginTimer();
        EnemyFollow.instance.SetAgent();
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownDisplay.text = "RUN...";

        yield return new WaitForSeconds(1f);

        BeginGame();

        countdownDisplay.gameObject.SetActive(false);
    }
}
