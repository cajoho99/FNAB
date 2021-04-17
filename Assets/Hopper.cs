using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hopper : AbstractFactoryObject

{

        // Start is called before the first frame update
        void Start()
    {
        
    }


    public int itemDispensedDelay = 5;
    public int Counter = 0;

    // Update is called once per frame
    void Update()
    {
        if (nextConveyor == null)
        {
            return;
        }
        else
        {
            Counter++;
        }
        if (conveyedObjects.Count != 0) {
            if (Counter >= itemDispensedDelay * 60)
            {
                Counter = 0;
                nextConveyor.addConveyedItem(conveyedObjects.Dequeue());
            }
        }

    }
}
