using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt :  AbstractFactoryObject
{
    

    // ScalableSpeed for the conveyor
    public float conveyorSpeed = 1;

  
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        bool dequeue = false;
        foreach(GenericFood obj in conveyedObjects)
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
                    idleObjects.Add(obj);
                    dequeue = true;
                }
                else
                {
                    nextConveyor.addConveyedItem(obj);
                    dequeue = true;
                }
            }
        }

        if (dequeue)
        {
            conveyedObjects.Dequeue();
        }


    }
}
