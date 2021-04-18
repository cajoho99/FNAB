using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{

    public GameObject conveyor;
    public GameObject conveyedItem;
    public GameObject ovenItem;
    public GameObject hopper;

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
        
        MachineOven oven = Instantiate(ovenItem, transform.position, transform.rotation).GetComponent<MachineOven>();
        conveyorBelts[conveyors.Count - 1].setNextConveyor(oven);
        ConveyorBelt lastBelt = Instantiate(conveyor, transform.position, transform.rotation).GetComponent<ConveyorBelt>();


        oven.transform.position += new Vector3(conveyors.Count + 1, -2);
        oven.setDirection(MachineOven.DIRECTION.SOUTH);
        lastBelt.transform.position += new Vector3(conveyors.Count + 1, - 3);
        oven.setNextConveyor(lastBelt);

        Hopper ohopper = Instantiate(hopper, transform.position, transform.rotation).GetComponent<Hopper>();

        ohopper.transform.position += new Vector3(2, 0);
        ohopper.setNextConveyor(conveyorBelts[0]);

        for(int i = 0; i < 10; i++)
        {
            ohopper.addConveyedItem(Instantiate(conveyedItem, transform.position + new Vector3(2, 0), transform.rotation).GetComponent<GenericFood>());
        }
        
        
       

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
            conveyorBelts[conveyors.Count - 1].addConveyedItem(Instantiate(conveyedItem, transform.position, transform.rotation).GetComponent<GenericFood>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
