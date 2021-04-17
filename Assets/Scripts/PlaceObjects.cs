using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PlaceObjects : MonoBehaviour
{
    public Tile highlight;
    public Tilemap highlightMap;

    [SerializeField] private int objectIndex = 0;


    public List<ObjectToPlace> objectsToPlace;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            objectIndex = mod((objectIndex - 1), objectsToPlace.Count);
            Debug.Log("Index of item: " + objectIndex);
        }
        if(Input.GetKeyDown(KeyCode.E)){
            objectIndex = mod((objectIndex + 1), objectsToPlace.Count);
            Debug.Log("Index of item: " + objectIndex);
        }

        if(Input.GetMouseButtonDown(0))
        {
            Vector3Int pos = objectsToPlace[objectIndex].tilemapLayer.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            objectsToPlace[objectIndex].tilemapLayer.SetTile(pos, objectsToPlace[objectIndex].tile);
            
        }

        Vector3Int tilemapPos = objectsToPlace[objectIndex].tilemapLayer.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        HighlightTile(tilemapPos);
    }

    void HighlightTile(Vector3Int tilemapPos)
    {
        highlightMap.ClearAllTiles();
        highlightMap.SetTile(tilemapPos, highlight);
    }

    private int mod(int x, int m) {
        return (x%m + m)%m;
    }
}

[System.Serializable]
public struct ObjectToPlace
{
    [SerializeField] public Tile tile;
    [SerializeField] public Tilemap tilemapLayer;
}