using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public static class SaveSystem
{
    //Save Slot
    public static void SaveSaveSlot(int SaveSlot)
    {
        PlayerPrefs.SetInt("SaveSlot",SaveSlot);
    }
    public static int GetSaveSlot()
    {
        return PlayerPrefs.GetInt("SaveSlot");
    }

    //Save volumn
    public static void SaveMasterVolumn(float volumn)
    {
        PlayerPrefs.SetFloat("MasterVolumn",volumn);
    }
    public static void SaveSFXVolumn(float volumn)
    {
        PlayerPrefs.SetFloat("SFXVolumn",volumn);
    }
    public static void SaveBGMVolumn(float volumn)
    {
        PlayerPrefs.SetFloat("BGMVolumn",volumn);
    }

    public static float GetMasterVolumn()
    {
        return PlayerPrefs.GetFloat("MasterVolumn");
    }
    public static float GetSFXVolumn()
    {
        return PlayerPrefs.GetFloat("SFXVolumn");
    }
    public static float GetBGMVolumn()
    {
        return PlayerPrefs.GetFloat("BGMVolumn");
    }


    //Save Data
    public static void Save(string JsonString)
    {
        int saveSlot = GetSaveSlot();
        if(saveSlot ==1)
        {
            File.WriteAllText(Application.dataPath + "/SaveFile1.json",JsonString);
            Debug.Log("Slot1_Saved!");
        }
        else
        {
            File.WriteAllText(Application.dataPath + "/SaveFile2.json",JsonString);
            Debug.Log("Slot2_Saved!");
        }
        //Debug.Log(JsonString);
    }
    public static string ChangeToJson(SaveData saveData)
    {
        return JsonUtility.ToJson(saveData,true);
    }

    public static SaveData Load()
    {
        int saveSlot = GetSaveSlot();
        if(saveSlot ==1)
        {
            if(File.Exists(Application.dataPath + "/SaveFile1.json"))
            {
                string JsonString = File.ReadAllText(Application.dataPath + "/SaveFile1.json");
                return JsonUtility.FromJson<SaveData>(JsonString);
            }
        }
        else
        {
            if(File.Exists(Application.dataPath + "/SaveFile2.json"))
            {
                string JsonString = File.ReadAllText(Application.dataPath + "/SaveFile2.json");
                return JsonUtility.FromJson<SaveData>(JsonString);
            }
        }
        
        return null;
    }

    public static void DeleteData(int SaveSlot)
    {
        if(SaveSlot ==1)
        {
            if(File.Exists(Application.dataPath + "/SaveFile1.json"))
            {
                File.Delete(Application.dataPath + "/SaveFile1.json");
                File.Delete(Application.dataPath + "/SaveFile1.json.meta");
            }
        }
            
        if(SaveSlot ==2)
        {
            if(File.Exists(Application.dataPath + "/SaveFile2.json"))
            {
                File.Delete(Application.dataPath + "/SaveFile2.json");
                File.Delete(Application.dataPath + "/SaveFile2.json.meta");
            }
        }
    }



}
