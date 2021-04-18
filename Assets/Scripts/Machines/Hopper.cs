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

    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    private void OnMouseDown()
    {
        Debug.Log("Clicked on hopper!");
        List<GenericFood> inventory = PlayerController.instance.GetInventory();
        PlayerController.instance.ClearInventory();
        foreach (var item in inventory)
        {
            addConveyedItem(item);
        }
    }
}
