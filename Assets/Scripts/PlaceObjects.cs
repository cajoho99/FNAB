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
            this.rotation = new Vector3(0, 0, mod((int)rotation.z + 90, 360));
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            this.rotation = new Vector3(0, 0, mod((int)rotation.z - 90, 360));
        }

        if(Input.GetMouseButtonDown(0))
        {
            Vector3 pos = objectMap.CellToWorld(objectMap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
            Vector3 worldPos = new Vector3(pos.x + 0.4f, pos.y + 0.4f, pos.z);
            GameObject go = Instantiate(placeableObjects[objectIndex], worldPos, Quaternion.Euler(rotation));
            AbstractFactoryObject abstractFactoryObject = go.GetComponent<AbstractFactoryObject>();
            if(rotation.z <= 1f)
            {
                abstractFactoryObject.setDirection(AbstractFactoryObject.DIRECTION.SOUTH);
            }
            else if(rotation.z <= 91)
            {
                abstractFactoryObject.setDirection(AbstractFactoryObject.DIRECTION.WEST);
            }
            else if(rotation.z <= 181f)
            {
                abstractFactoryObject.setDirection(AbstractFactoryObject.DIRECTION.NORTH);
            }
            else if(rotation.z <= 241f)
            {
                abstractFactoryObject.setDirection(AbstractFactoryObject.DIRECTION.EAST);
            }
            else 
            {
                Debug.LogError("This should not be happening. If happening consult consultant functional ab");
            }
        }

        Vector3Int tilemapPos = objectMap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        HighlightTile(tilemapPos);
    }

    void HighlightTile(Vector3Int tilemapPos)
    {
        highlightMap.ClearAllTiles();
        highlightMap.SetTile(tilemapPos, highlight);
        highlightMap.SetTransformMatrix(tilemapPos, Matrix4x4.Rotate(Quaternion.Euler(rotation)));
    }

    private int mod(int x, int m) {
        return (x%m + m)%m;
    }
}