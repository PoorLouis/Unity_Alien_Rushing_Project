using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainGameController : MonoBehaviour
{
    public static MainGameController instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    public int gold 
    {
        get { return _gold; }
        set 
        {
            _gold = value;
            goldText.text = "Gold : " + _gold;
        }
    }

    public int life
    {
        get { return _life; }
        set
        {
            _life = value;
            lifeText.text = "Life : " + _life;
            if(life == 0)
            {
                gameOverUi.SetActive(true);
                isEndGame = true;
            }
        }
    }

    public int enemyCount
    {
        get { return _enemyCount; }
        set
        {
            _enemyCount = value;
            if(_enemyCount == 0 && enemySpawner.isWaveEnd)
            {
                winUi.SetActive(true);
                PlayerPrefs.SetInt("LevelPassed", SceneManager.GetActiveScene().buildIndex);
                PlayerPrefs.Save();
                isEndGame = true;
            }
        }
    }

    private int _gold = 250;
    private int _life = 5;

    private int _enemyCount = 0;

    public bool isEndGame = false;

    public TMP_Text goldText;
    public TMP_Text lifeText;
    public GameObject gameOverUi;
    public GameObject winUi;
    public EnemySpawner enemySpawner;
    public NodeUiController nodeUi;

    public void OnRetryBtnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnExitBtnClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnNextLevelBtnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
