using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ItemManager itemManager;
    public TileManager tileManager;

    private void Awake()
    {
        itemManager = GetComponent<ItemManager>();
        tileManager = GetComponent<TileManager>();
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
