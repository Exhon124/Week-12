using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemyOne;
    public GameObject coin;

    public GameObject cloud;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    private Player playerScript;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerInstance = Instantiate(player, transform.position, Quaternion.identity);
        playerScript = playerInstance.GetComponent<Player>();

        InvokeRepeating("CreateEnemyOne", 1f, 3f);
        InvokeRepeating("CreateCoin", 1f, 4f);

        CreateSky();
        score = 0;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + playerScript.lives;
}

    void CreateEnemyOne()
    {
        Instantiate(enemyOne, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.Euler(0, 0, 180));
    }
    void CreateCoin()
    {
        // Randomly choose a negative positive or neither number
        int side = Random.Range(-1, 2);
        // Use the random number to determine if the entity will start on the left or right
        if (side == -1)
        {
            Instantiate(coin, new Vector3(-11, Random.Range(1f, 4f), 0), Quaternion.identity);
        }
        else if (side == 1)
        {
            Instantiate(coin, new Vector3(11, Random.Range(1f, 4f), 0), Quaternion.identity);
        }
    }


    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloud, transform.position, Quaternion.identity);
        }
    }

    public void EarnScore(int newScore)
    {
        score = score + newScore;
        scoreText.text = "Score: " + score;
    }
}
