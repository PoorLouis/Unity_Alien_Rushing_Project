using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public bool clearSaveData;
    public GameObject creditUi;
    public GameObject levelSelectUI;
    public Button[] levelBtns;
    public int levelPassed = 0;
    public void OnStartBtnClick()
    {
        levelSelectUI.SetActive(true);

        if(clearSaveData)
        {
            PlayerPrefs.DeleteAll();
        }

        if (!PlayerPrefs.HasKey("LevelPassed"))
        {
            PlayerPrefs.SetInt("LevelPassed", 0);
            PlayerPrefs.Save();
        }
        levelPassed = PlayerPrefs.GetInt("LevelPassed");

        for(int i = 0; i < levelBtns.Length; i++)
        {
            if(i <= levelPassed)
            {
                levelBtns[i].interactable = true;
            }
            else
            {
                levelBtns[i].interactable = false;
            }
        }
    }

    public void OnCreditBtnClick()
    {
        creditUi.SetActive(true);
    }
    public void OnExitBtnClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnBackBtnLevelselectClick()
    {
        levelSelectUI.SetActive(false);
    }

    public void OnLevelBtnClick(int level)
    {
        SceneManager.LoadScene(level);
    }
}
