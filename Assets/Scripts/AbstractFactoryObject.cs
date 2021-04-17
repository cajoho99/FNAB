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

    // Which objects the conveyor currently 'owns'
    public List<GenericFood> conveyedObjects = new List<GenericFood>();

    // Objects on the floor in front of the conveyor
    public List<GenericFood> idleObjects = new List<GenericFood>();


    public void addConveyedItem(GenericFood go)
    {
        conveyedObjects.Add(go);
        go.transform.position = new Vector3(transform.position.x, transform.position.y);

    }

    // Which the next conveyor is
    public ConveyorBelt nextConveyor = null;
    public void setNextConveyor(ConveyorBelt conveyor)
    {
        this.nextConveyor = conveyor;
        foreach (GenericFood idleObj in idleObjects)
        {
            conveyor.addConveyedItem(idleObj);
        }
    }
}
