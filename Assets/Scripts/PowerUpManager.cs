using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Paddle
{
    Right,
    Left
}

public class PowerUpManager : MonoBehaviour
{
    public Transform spawnArea;
    public int maxPowerUpAmount;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;

    public GameObject lPad;
    public GameObject rPad;

    public int spawnInterval;
    public int lifeSpan;
    private float timer;

    public List<GameObject> powerUpTemplateList;
    private List<GameObject> powerUpList;

    

    public float[] durationPaddleLong = { 0, 0 };
    public bool[] activatedPaddleLong = { false, false };

    public float[] durationPaddleFast = { 0, 0 };
    public bool[] activatedPaddleFast = { false, false };

    private void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }
        DurationProcessor();
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    public void GenerateRandomPowerUp(Vector2 position)
    {
        if (powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }

        if (position.x < powerUpAreaMin.x ||
            position.x > powerUpAreaMax.x ||
            position.y < powerUpAreaMin.y ||
            position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);

        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }

    private void DurationProcessor()
    {
        //Debug.Log(durationPaddleLong[(int)Paddle.Right]);
        //Paddle Long
        if (activatedPaddleLong[(int)Paddle.Right])
        {
            durationPaddleLong[(int)Paddle.Right] -= Time.deltaTime;
            //Debug.Log(durationPaddleLong[(int)Paddle.Right]);
            if (durationPaddleLong[(int)Paddle.Right] < 0)
            {
                durationPaddleLong[(int)Paddle.Right] = 0;
                activatedPaddleLong[(int)Paddle.Right] = false;
                rPad.GetComponent<PaddleController>().DeactivatePUPaddleLong();
            }
        }

        if (activatedPaddleLong[(int)Paddle.Left])
        {
            durationPaddleLong[(int)Paddle.Left] -= Time.deltaTime;
            //Debug.Log(durationPaddleLong[(int)Paddle.Left]);
            if (durationPaddleLong[(int)Paddle.Left] < 0)
            {
                durationPaddleLong[(int)Paddle.Left] = 0;
                activatedPaddleLong[(int)Paddle.Left] = false;
                lPad.GetComponent<PaddleController>().DeactivatePUPaddleLong();
            }
        }

        //Paddle Fast
        if (activatedPaddleFast[(int)Paddle.Right])
        {
            durationPaddleFast[(int)Paddle.Right] -= Time.deltaTime;
            if (durationPaddleFast[(int)Paddle.Right] < 0)
            {
                durationPaddleFast[(int)Paddle.Right] = 0;
                activatedPaddleFast[(int)Paddle.Right] = false;
                rPad.GetComponent<PaddleController>().DeactivatePUPaddleFast();
            }
        }

        if (activatedPaddleFast[(int)Paddle.Left])
        {
            durationPaddleFast[(int)Paddle.Left] -= Time.deltaTime;
            if (durationPaddleFast[(int)Paddle.Left] < 0)
            {
                durationPaddleFast[(int)Paddle.Left] = 0;
                activatedPaddleFast[(int)Paddle.Left] = false;
                lPad.GetComponent<PaddleController>().DeactivatePUPaddleFast();
            }
        }
    }

}
