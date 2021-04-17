using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineOven : AbstractFactoryObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int SecondsToProcess = 4;


    public int Counter = 0;
    // Update is called once per frame
    void Update()
    {
        if (Counter >= SecondsToProcess * 60)
        {
            if(nextConveyor == null)
            {
                return;
            }
            nextConveyor.addConveyedItem(conveyedObjects[0]);
            conveyedObjects.Remove(conveyedObjects[0]);

        }
    }
}
