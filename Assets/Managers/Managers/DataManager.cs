using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class DataManager : MonoSingleton<DataManager>
{
   

    public PlayerData playerData;
    public GameData gameData;

   
    public static PlayerData PlayerData
    {
        get
        {
            return Instance.playerData;
        }
       
       
       
    }

    public static GameData GameData
    {
        get
        {
            return Instance.gameData;
        }
    }

 
}
