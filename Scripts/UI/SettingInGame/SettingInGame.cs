using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingInGame : MonoBehaviour
{
    public Player Player;
    public GameObject AudioMenuInGame;
    public GameObject GameSavedNoti;
    public GameObject GameTutorial;
    public GameObject PauseGameScene;
    public PlayerInput PlayerInput;


    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public Collider2D collider1;
    public Collider2D collider2;
    public Collider2D collider3;
    public Collider2D collider4;
    public Collider2D collider5;

    private void Awake() {
        StartCoroutine(GameSavedNotiCoroutine());
    }
    
    //audio
    public void OnClickAudioSettingInGame()
    {
        AudioMenuInGame.SetActive(true);
        DisablePlayerInput();
    }
    public void OnCancelAudioSettingInGame()
    {
        AudioMenuInGame.SetActive(false);
        EnablePlayerInput();
    }

    //game saved
    public void OnClickGameSaveInGame()
    {
        GameSavedNoti.SetActive(true);
        SaveGame();
    }

    //tutorial
    public void OnClickGameTutorialInGame()
    {
        GameTutorial.SetActive(true);
        DisablePlayerInput();
    }
    public void OnCancelGameTutorialInGame()
    {
        GameTutorial.SetActive(false);
        EnablePlayerInput();
    }

    //pause
    public void OnClickPauseGameInGame()
    {
        PauseGameScene.SetActive(true);
        PauseGame();

    }
    public void OnClickHomeInGame()
    {
        SaveGame();
        ResumeGame();
        SceneManager.LoadScene(0);
    }
    public void OnCancelPauseGameInGame()
    {
        PauseGameScene.SetActive(false);
        ResumeGame();
    }



    public void EnablePlayerInput()
    {
        PlayerInput.OnEnable();
    }
    public void DisablePlayerInput()
    {
        PlayerInput.OnDisable();
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    public void SaveGame()
    {
        SaveData saveData = Player.GetDataSave();  // data player

        if(cinemachineVirtualCamera.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D == collider1) saveData.ColliderMap = 1;
        else if(cinemachineVirtualCamera.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D == collider2) saveData.ColliderMap = 2;
        else if(cinemachineVirtualCamera.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D == collider3) saveData.ColliderMap = 3;
        else if(cinemachineVirtualCamera.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D == collider4) saveData.ColliderMap = 4;
        else if(cinemachineVirtualCamera.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D == collider5) saveData.ColliderMap = 5;



    
        char[] statusEnemyString = new char[GameManager.Instance.EnemyList.Count];
        for(int i=0;i<GameManager.Instance.EnemyList.Count;i++)
        {
            GameManager.Instance.EnemyList[i].status = GameManager.Instance.EnemyList[i].Enemy.activeInHierarchy;
            statusEnemyString[i] = GameManager.Instance.EnemyList[i].status? '1' : '0';
        }
        saveData.StatusEnemy = new string(statusEnemyString);
        Debug.Log(saveData.StatusEnemy);

        char[] statusBuffString = new char[GameManager.Instance.BuffList.Count];
        for(int i=0;i<GameManager.Instance.BuffList.Count;i++)
        {
            GameManager.Instance.BuffList[i].status = GameManager.Instance.BuffList[i].Buff.activeInHierarchy;
            statusBuffString[i] = GameManager.Instance.BuffList[i].status? '1' : '0';
        }
        saveData.StatusBuff = new string(statusBuffString);
        Debug.Log(saveData.StatusBuff);




        string json = SaveSystem.ChangeToJson(saveData);
        SaveSystem.Save(json);
    }



    private IEnumerator GameSavedNotiCoroutine()
    {
        while(true)
        {
            if(GameSavedNoti.activeInHierarchy)
            {
                yield return new WaitForSeconds(1);
                GameSavedNoti.SetActive(false);
            }
            yield return null;
        }
    }




    






    


}
