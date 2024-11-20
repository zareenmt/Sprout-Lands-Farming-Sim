using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap _interactableMap;
    [SerializeField] private Tile interactedTile;
    void Start()
    {
    }

    public bool IsInteractable(Vector3Int position)
    {
        TileBase tile = _interactableMap.GetTile(position);
        if (tile)
        {
            if (tile.name == "Interactable")
            {
                return true;
            }
        }

        return false;
    }

    public void SetInteracted(Vector3Int position)
    {
        _interactableMap.SetTile(position,interactedTile);
    }
}
