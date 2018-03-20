using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileStyle
{
    public int Number;
    public Color32 TileColor;
    public Color32 TextColor;
}

public class TileStyleHolder : MonoBehaviour {

    public TileStyle[] TileStyles;
    public static TileStyleHolder Instance;

    private void Awake()
    {
        Instance = this;
    }
}
