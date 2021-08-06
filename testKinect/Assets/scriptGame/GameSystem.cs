using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    //setup
    public int startingHp;
    public float startingSpeed, startingCooldown;
    public Text hpText, scoreText, highscoreText, scoreEnd, highscoreEnd;
    public GameObject playingScreen, gameOverScreen;

    //variable universal yang bakal dipake sama script lain
    public static int hp, score, highscore;
    public static float bulletSpeed, bulletCooldown;
    public static bool isPlaying;

    void Start()
    {
        hp = startingHp;
        score = 0;
        highscore = PlayerPrefs.GetInt("highscore");
        bulletSpeed = startingSpeed;
        bulletCooldown = startingCooldown;
        isPlaying = true;
        gameOverScreen.SetActive(false);
    }
    
    void Update()
    {
        //update text
        hpText.text = hp.ToString();
        scoreText.text = score.ToString();
        highscoreText.text = highscore.ToString();

        //tambah kesulitan
        bulletSpeed += Time.deltaTime / 50;
        if (bulletCooldown > 1f) //cooldown minimal, gak boleh 0, kecepetan
            bulletCooldown -= Time.deltaTime / 50;
        Debug.Log("Speed = " + bulletSpeed + ", Cooldown = " + bulletCooldown);

        //jika mati, game over
        if (isPlaying && hp <= 0)
        {
            GameOver();
        }
    }

    public static void AddScore(int value)
    {
        score += value;
        if (score > highscore)
        {
            highscore = score;
        }
    }

    public static void Damage(int value)
    {
        hp -= value;
    }

    public void GameOver()
    {
        //delete semua bullet
        GameObject[] allBullet = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in allBullet)
        {
            Destroy(bullet);
        }

        scoreEnd.text += score.ToString();
        highscoreEnd.text += highscore.ToString();

        //update highscore
        if (highscore > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", highscore);
            highscoreEnd.text += " (NEW!)";
        }

        isPlaying = false;
        playingScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }
}
