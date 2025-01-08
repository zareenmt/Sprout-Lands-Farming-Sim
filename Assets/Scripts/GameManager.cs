using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ItemManager itemManager;
    public TileManager tileManager;
    public TimeManager timeManager;
    public UIManager uiManager;

    private void Awake()
    {
        itemManager = GetComponent<ItemManager>();
        tileManager = GetComponent<TileManager>();
        timeManager = GetComponent<TimeManager>();
        uiManager = GetComponent<UIManager>();
        if (instance != null && instance != this)
        {
            Destroy(this.GameObject());
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
