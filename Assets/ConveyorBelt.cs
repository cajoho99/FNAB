using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt :  AbstractFactoryObject
{
    // In which directions the conveyor can move items.
    public enum DIRECTION { NORTH, EAST, SOUTH, WEST }

    // In which direction the conveyor currently moves items.
    public DIRECTION currentDirection = DIRECTION.EAST;

    public void setDirection(DIRECTION dir) {
        currentDirection = dir;
    }

    // Which objects the conveyor currently 'owns'
    public List<GameObject> conveyedObjects = new List<GameObject>();

    // Objects on the floor in front of the conveyor
    List<GameObject> idleObjects = new List<GameObject>();
    

    public void addConveyedItem(GameObject go)
    {
        conveyedObjects.Add(go);
        go.transform.position = new Vector3(transform.position.x, transform.position.y);

    }

    // Which the next conveyor is
    public ConveyorBelt nextConveyor = null;
    public void setNextConveyor(ConveyorBelt conveyor)
    {
        this.nextConveyor = conveyor;
        foreach (GameObject idleObj in idleObjects)
        {
            conveyor.addConveyedItem(idleObj);
        }
    }

    // ScalableSpeed for the conveyor
    public float conveyorSpeed = 1;

  
    // Start is called before the first frame update
    void Start()
    {
       



    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> toBeRemoved = new List<GameObject>();
        foreach(GameObject obj in conveyedObjects)
        {
            if(currentDirection == DIRECTION.NORTH)
            {
                
                obj.transform.position += new Vector3(0, 0.005f) * conveyorSpeed;
            }
            if (currentDirection == DIRECTION.EAST)
            {
                obj.transform.position += new Vector3(0.005f, 0) * conveyorSpeed;
            }
            if (currentDirection == DIRECTION.SOUTH)
            {
                obj.transform.position += new Vector3(0, -0.005f) * conveyorSpeed;
            }
            if (currentDirection == DIRECTION.WEST)
            {
                obj.transform.position += new Vector3(-0.005f, 0) * conveyorSpeed;
                
            }







            if (Mathf.Abs(obj.transform.position.x) - Mathf.Abs(transform.position.x) > Mathf.Abs(this.gameObject.GetComponent<BoxCollider2D>().bounds.size.x) || Mathf.Abs(obj.transform.position.y) - Mathf.Abs(transform.position.y) > Mathf.Abs(this.gameObject.GetComponent<BoxCollider2D>().bounds.size.y))
            {
                if (nextConveyor == null)
                {
                    toBeRemoved.Add(obj);
                    idleObjects.Add(obj);
                }
                else
                {
                    nextConveyor.addConveyedItem(obj);
                    toBeRemoved.Add(obj);
                }
            }
        }

        foreach (GameObject obj in toBeRemoved)
        {
            conveyedObjects.Remove(obj);
        }
    }
}
