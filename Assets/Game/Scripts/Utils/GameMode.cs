using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMode : MonoBehaviour
{
    public void SetGameMode(int type)
    {
        type = Mathf.Clamp(type, 0, 2);
        GameModeSettings.gameMode = (GameModeType) type;
    }
}