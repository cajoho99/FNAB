using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{

    public GameObject conveyor;
    public GameObject conveyedItem;

    List<GameObject> conveyors = new List<GameObject>();
    List<ConveyorBelt> conveyorBelts = new List<ConveyorBelt>();
    // Start is called before the firsIt frame update
    void Start()
    {
        Spawn();
        Spawn();
        Spawn();
        Spawn();
        Spawn();
        conveyorBelts[conveyors.Count - 1].setDirection(ConveyorBelt.DIRECTION.SOUTH);
        conveyors.Add(Instantiate(conveyor, transform.position, transform.rotation));
        conveyorBelts.Add(conveyors[conveyors.Count - 1].GetComponent<ConveyorBelt>());
        conveyors[conveyors.Count - 1].transform.position += new Vector3(conveyors.Count + 1, -1);
        conveyorBelts[conveyors.Count - 1].setDirection(ConveyorBelt.DIRECTION.SOUTH);
        conveyorBelts[conveyors.Count - 2].setNextConveyor(conveyorBelts[conveyors.Count - 1]);
    }

    void Spawn()
    {
        conveyors.Add(Instantiate(conveyor, transform.position, transform.rotation));
        conveyorBelts.Add(conveyors[conveyors.Count - 1].GetComponent<ConveyorBelt>());
        conveyors[conveyors.Count - 1].transform.position += new Vector3(conveyors.Count +2, 0);
        if (conveyors.Count != 1) {
            conveyorBelts[conveyors.Count - 2].setNextConveyor(conveyorBelts[conveyors.Count - 1]);
        }
        else
        {
            conveyorBelts[conveyors.Count - 1].addConveyedItem(Instantiate(conveyedItem, transform.position, transform.rotation));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
