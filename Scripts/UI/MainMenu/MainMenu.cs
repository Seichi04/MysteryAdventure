using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Main;
    public GameObject Star;
    public GameObject MainScene;
    public GameObject PlayScene;
    public GameObject DeleteSlotScene;
    public GameObject SettingScene;
    public GameObject AudioSettingScene;
    public GameObject KeymapScene;


    #region Main Scene
    public void OnClickPlayButton()
    {
        MainScene.SetActive(false);
        PlayScene.SetActive(true);
    }
    public void OnClickSettingButton()
    {
        MainScene.SetActive(false);
        SettingScene.SetActive(true);
    }
    public void OnClickQuitButton()
    {
        Application.Quit();
    }
    #endregion

    #region Play Scene
    public void OnClickSaveSlot1()
    {
        SaveSystem.SaveSaveSlot(1);
        //SceneManager.LoadScene(1);
        Main.SetActive(false);
        Star.SetActive(false);
        SceneLoader.Instance.LoadScene(1);
    }
    public void OnClickSaveSlot2()
    {
        SaveSystem.SaveSaveSlot(2);
        //SceneManager.LoadScene(1);
        Main.SetActive(false);
        Star.SetActive(false);
        SceneLoader.Instance.LoadScene(1);
    }
    public void OnClickDeleteSlot1Button()
    {
        SaveSystem.SaveSaveSlot(1);
        DeleteSlotScene.SetActive(true);
    }
    public void OnClickDeleteSlot2Button()
    {
        SaveSystem.SaveSaveSlot(2);
        DeleteSlotScene.SetActive(true);
    }
    public void OnClickPlayBackButton()
    {
        PlayScene.SetActive(false);
        MainScene.SetActive(true);
    }
        #region Delete Slot Scene
        public void OnClickYesButton()
        {
            Debug.Log("Delete data save slot " + SaveSystem.GetSaveSlot());
            SaveSystem.DeleteData(SaveSystem.GetSaveSlot());
            DeleteSlotScene.SetActive(false);
        }
        public void OnClickNoButton()
        {
            DeleteSlotScene.SetActive(false);

        }

        #endregion

    #endregion

    #region Setting Scene
    public void OnClickAudioButton()
    {
        SettingScene.SetActive(false);
        AudioSettingScene.SetActive(true);
    }
    public void OnClickKeymapButton()
    {
        SettingScene.SetActive(false);
        KeymapScene.SetActive(true);
    }
    public void OnClickSettingBackButton()
    {
        SettingScene.SetActive(false);
        MainScene.SetActive(true);
    }

        #region Audio Setting Scene
        public void OnClickAudioSettingBackButton()
        {
            AudioSettingScene.SetActive(false);
            SettingScene.SetActive(true);
        }

        #endregion

        #region KeymapScene
        public void OnClickKeymapBackButton()
        {
            KeymapScene.SetActive(false);
            SettingScene.SetActive(true);
        }
        #endregion

    #endregion


}
