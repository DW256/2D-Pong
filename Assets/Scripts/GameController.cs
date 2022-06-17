using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MenuController
{
    public GameObject BackPanel;
    public Text[] DurationCountdown;

    public PowerUpManager PUManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DurationCountdown[0].text = System.Math.Round(PUManager.durationPaddleLong[(int)Paddle.Left]).ToString();
        DurationCountdown[1].text = System.Math.Round(PUManager.durationPaddleFast[(int)Paddle.Left]).ToString();
        DurationCountdown[2].text = System.Math.Round(PUManager.durationPaddleLong[(int)Paddle.Right]).ToString();
        DurationCountdown[3].text = System.Math.Round(PUManager.durationPaddleFast[(int)Paddle.Right]).ToString();
    }

    private void pauseGame()
    {
        Time.timeScale = 0;
    }

    private void resumeGame()
    {
        Time.timeScale = 1;
    }

    public void openBackPanel()
    {
        pauseGame();
        BackPanel.SetActive(true);
    }

    public void closeBackPanel()
    {
        resumeGame();
        BackPanel.SetActive(false);
    }

    public override void backToMainMenu()
    {
        resumeGame();
        base.backToMainMenu();
    }


}
