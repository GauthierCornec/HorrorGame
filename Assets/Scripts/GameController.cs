using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private int countdownTime;
    [SerializeField] private TextMeshProUGUI countdownDisplay;

    private void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    // Update is called once per frame
    public void BeginGame()
    {
        TimerController.instance.BeginTimer();
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
