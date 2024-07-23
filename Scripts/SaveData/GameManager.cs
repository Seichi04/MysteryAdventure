using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get;private set;}
    public List<EnemyStatus> EnemyList;
    public List<BuffStatus> BuffList;
    public SaveData SaveData;

    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public Collider2D collider1;
    public Collider2D collider2;
    public Collider2D collider3;
    public Collider2D collider4;
    public Collider2D collider5;

    public Slider MasterSlider;
    public Slider SFXSlider;
    public Slider BGMSlider;

    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
        }
        SaveData = SaveSystem.Load();
        LoadColliderMap();
        LoadAudio();
        LoadStatusEnemy();
        LoadStatusBuff();
    }

    private void Start() {
        LoadColliderMap();
    }


    private void LoadStatusEnemy()
    {
        if(SaveData == null) return;
        for(int i=0;i<EnemyList.Count;i++)
        {
            EnemyList[i].status = SaveData.StatusEnemy[i]=='1';
            if(EnemyList[i].status == false)
            {
                EnemyList[i].Enemy.SetActive(false);
            }
        }
    }

    private void LoadStatusBuff()
    {
        if(SaveData == null) return;
        for(int i=0;i<BuffList.Count;i++)
        {
            BuffList[i].status = SaveData.StatusBuff[i]=='1';
            if(BuffList[i].status == false)
            {
                BuffList[i].Buff.SetActive(false);
            }
        }
    }

    private void LoadAudio()
    {
        if(SaveData == null) return;
        MasterSlider.value = SaveSystem.GetMasterVolumn();
        SFXSlider.value = SaveSystem.GetSFXVolumn();
        BGMSlider.value = SaveSystem.GetBGMVolumn();
        AudioManager.Instance.ChangeMasterVolumn(SaveSystem.GetMasterVolumn());
        AudioManager.Instance.ChangeSFXVolumn(SaveSystem.GetSFXVolumn());
        AudioManager.Instance.ChangeBGMVolumn(SaveSystem.GetBGMVolumn());
    }

    private void LoadColliderMap()
    {
        if(SaveData == null) return;
        if(cinemachineVirtualCamera == null) return;
        cinemachineVirtualCamera.GetComponent<CinemachineConfiner2D>().enabled = false;
        if(SaveData.ColliderMap == 1) cinemachineVirtualCamera.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = collider1;
        else if(SaveData.ColliderMap == 2) cinemachineVirtualCamera.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = collider2;
        else if(SaveData.ColliderMap == 3) cinemachineVirtualCamera.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = collider3;
        else if(SaveData.ColliderMap == 4) cinemachineVirtualCamera.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = collider4;
        else if(SaveData.ColliderMap == 5) cinemachineVirtualCamera.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = collider5;
        cinemachineVirtualCamera.GetComponent<CinemachineConfiner2D>().enabled = true;
    }

    public void SaveMasterVolumn()
    {
        SaveSystem.SaveMasterVolumn(MasterSlider.value);
    }
    public void SaveSFXVolumn()
    {
        SaveSystem.SaveSFXVolumn(SFXSlider.value);
    }
    public void SaveBGMVolumn()
    {
        SaveSystem.SaveBGMVolumn(BGMSlider.value);
    }
}

[Serializable]
public class EnemyStatus
{
    public GameObject Enemy;
    public bool status;
    public EnemyStatus(GameObject enemy, bool status)
    {
        this.Enemy = enemy;
        this.status = status;
    }
}

[Serializable]
public class BuffStatus
{
    public GameObject Buff;
    public bool status;
    public BuffStatus(GameObject buff, bool status)
    {
        this.Buff = buff;
        this.status = status;
    }
}


