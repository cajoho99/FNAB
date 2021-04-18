using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PlaceObjects : MonoBehaviour
{
    public Tile highlight;
    public Tilemap highlightMap;
    public Tilemap objectMap;

    [SerializeField] private int objectIndex = 0;
    
    public Vector3 rotation;

    public List<GameObject> placeableObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DayNightManager.IsNight())
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.R)){
            objectIndex = mod((objectIndex - 1), placeableObjects.Count);
            Debug.Log("Index of item: " + objectIndex);
        }
        if(Input.GetKeyDown(KeyCode.F)){
            objectIndex = mod((objectIndex + 1), placeableObjects.Count);
            Debug.Log("Index of item: " + objectIndex);
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            this.rotation = new Vector3(0, 0, mod((int)rotation.z - 90, 360));
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            this.rotation = new Vector3(0, 0, mod((int)rotation.z + 90, 360));
        }

        if(Input.GetMouseButtonDown(0))
        {
            Vector3Int pos = objectMap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Instantiate(placeableObjects[objectIndex], pos, Quaternion.Euler(rotation));
        }

        Vector3Int tilemapPos = objectMap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
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