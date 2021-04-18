using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractFactoryObject : MonoBehaviour
{
    public string name;
    public Vector2Int Position;
    public int width;
    public int height;

    public AbstractFactoryObject input;
    public AbstractFactoryObject output;

    // In which directions the conveyor can move items.
    public enum DIRECTION { NORTH, EAST, SOUTH, WEST }

    // In which direction the conveyor currently moves items.
    public DIRECTION currentDirection = DIRECTION.EAST;

    public void setDirection(DIRECTION dir)
    {
        currentDirection = dir;
    }

    public void setDirection(float dir) 
    {
        if(dir <= 1f)
        {
            currentDirection = DIRECTION.NORTH;
        }
        else if(dir <= 91)
        {
            currentDirection = DIRECTION.EAST;
        }
        else if(dir <= 181f)
        {
            currentDirection = DIRECTION.SOUTH;
        }
        else if(dir <= 241f)
        {
            currentDirection = DIRECTION.WEST;
        }
        else 
        {
            Debug.LogError("This should not be happening. If happening consult consultant functional ab");
        }
    }
    // Which objects the conveyor currently 'owns'
    public Queue<GenericFood> conveyedObjects = new Queue<GenericFood>();

    // Objects on the floor in front of the conveyor
    public List<GenericFood> idleObjects = new List<GenericFood>();


    public void addConveyedItem(GenericFood go)
    {
        conveyedObjects.Enqueue(go);
        go.transform.position = new Vector3(transform.position.x, transform.position.y);

    }

    // Which the next conveyor is
    public AbstractFactoryObject nextConveyor = null;
    public void setNextConveyor(AbstractFactoryObject conveyor)
    {
        this.nextConveyor = conveyor;
        foreach (GenericFood idleObj in idleObjects)
        {
            conveyor.addConveyedItem(idleObj);
        }
    }

 
}
