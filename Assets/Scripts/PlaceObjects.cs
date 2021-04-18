using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PlaceObjects : MonoBehaviour
{
    public const int worldWidth = 18;
    public const int worldHeight = 8;
    public Tile highlight;
    public Tilemap highlightMap;
    public Tilemap objectMap;

    public AbstractFactoryObject[,] abstractFactories = new AbstractFactoryObject[18, 8];
    [SerializeField] private int objectIndex = 0;
    
    public int rotation;

    public List<GameObject> placeableObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public List<TileInstance> currentTiles = new List<TileInstance>();

    // Update is called once per frame
    void Update()
    {
        if(DayNightManager.IsDay())
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
            rotation = mod(rotation + 90, 360);
            Debug.Log("Rotation increased: " + rotation);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            rotation = mod(rotation - 90, 360);
            Debug.Log("Rotation decreased: " + rotation);
        }

        if(Input.GetMouseButtonDown(1))
        {
            Vector3Int negativePos = objectMap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Vector3Int intPos = new Vector3Int(negativePos.x + worldWidth / 2, negativePos.y + worldHeight / 2, 0);
            if(abstractFactories[intPos.x, intPos.y] != null)
            {
                Destroy(abstractFactories[intPos.x, intPos.y].gameObject);
                abstractFactories[intPos.x, intPos.y] = null;
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            Vector3Int negativePos = objectMap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Vector3Int intPos = new Vector3Int(negativePos.x + worldWidth / 2, negativePos.y + worldHeight / 2, 0);
            if(abstractFactories[intPos.x, intPos.y] == null)
            {
                Vector3 pos = objectMap.CellToWorld(negativePos);
                Vector3 worldPos = new Vector3(pos.x + 0.4f, pos.y + 0.4f, pos.z);
                GameObject go = Instantiate(placeableObjects[objectIndex], worldPos, Quaternion.Euler(new Vector3(0, 0, 0)));
                AbstractFactoryObject abstractFactoryObject = go.GetComponent<AbstractFactoryObject>();
                Debug.Log("Position: " + intPos.x + " " + intPos.y);
                abstractFactories[intPos.x, intPos.y] = abstractFactoryObject;
                if(rotation == 0)
                {
                    abstractFactoryObject.setDirection(AbstractFactoryObject.DIRECTION.SOUTH);
                }
                else if(rotation == 90)
                {
                    abstractFactoryObject.setDirection(AbstractFactoryObject.DIRECTION.WEST);
                }
                else if(rotation == 180)
                {
                    abstractFactoryObject.setDirection(AbstractFactoryObject.DIRECTION.NORTH);
                }
                else if(rotation == 270)
                {
                    abstractFactoryObject.setDirection(AbstractFactoryObject.DIRECTION.EAST);
                }
                else 
                {
                    Debug.LogError("This should not be happening. If happening consult consultant functional ab");
                }
                if(intPos.x > 0 && intPos.x < worldWidth)
                {
        
                    if(abstractFactories[intPos.x - 1, intPos.y] != null && abstractFactories[intPos.x - 1, intPos.y].currentDirection == AbstractFactoryObject.DIRECTION.EAST){
                        abstractFactories[intPos.x - 1, intPos.y].nextConveyor = abstractFactoryObject;
                        Debug.Log("nextConveyour set!");
                    }
                    if(abstractFactories[intPos.x + 1, intPos.y] != null && abstractFactories[intPos.x + 1, intPos.y].currentDirection == AbstractFactoryObject.DIRECTION.WEST){
                        abstractFactories[intPos.x + 1, intPos.y].nextConveyor = abstractFactoryObject;
                        Debug.Log("nextConveyour set!");
                    }

                }
                if(intPos.y > 0 && intPos.y < worldHeight)
                {
                    if(abstractFactories[intPos.x, intPos.y + 1] != null && abstractFactories[intPos.x, intPos.y + 1].currentDirection == AbstractFactoryObject.DIRECTION.SOUTH){
                            abstractFactories[intPos.x, intPos.y + 1].nextConveyor = abstractFactoryObject;
                            Debug.Log("nextConveyour set!");    
                    }
                    if(abstractFactories[intPos.x, intPos.y - 1] != null && abstractFactories[intPos.x, intPos.y - 1].currentDirection == AbstractFactoryObject.DIRECTION.NORTH){
                            abstractFactories[intPos.x, intPos.y - 1].nextConveyor = abstractFactoryObject;
                            Debug.Log("nextConveyour set!");
                    }
                }
            }
        }

        Vector3Int tilemapPos = objectMap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        HighlightTile(tilemapPos);
    }

    void HighlightTile(Vector3Int tilemapPos)
    {
        highlightMap.ClearAllTiles();
        highlightMap.SetTile(tilemapPos, highlight);
        highlightMap.SetTransformMatrix(tilemapPos, Matrix4x4.Rotate(Quaternion.Euler(new Vector3(0, 0, rotation))));
    }

    private int mod(int x, int m) {
        return (x%m + m)%m;
    }
}