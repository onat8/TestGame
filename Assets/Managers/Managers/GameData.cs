using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Data/GameData")]
public class GameData : ScriptableObject
{
    [Header("GameStats")]
    [SerializeField] int level_id;

    public int Level_id
    {
        get => PlayerPrefs.GetInt("Level_id", level_id);
        set => PlayerPrefs.SetInt("Level_id", value);
    }
}
