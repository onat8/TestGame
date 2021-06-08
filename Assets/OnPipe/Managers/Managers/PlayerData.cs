using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerData",menuName ="Data/PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("PlayerStats")]
    [SerializeField] int level;
    [SerializeField] int highScore;
    [SerializeField] int coin;
    [SerializeField] string nickName;


  
    public int Level
    {
        get=>PlayerPrefs.GetInt("Level",level);
        set=>PlayerPrefs.SetInt("Level",value);
    }
    
   
  
}
