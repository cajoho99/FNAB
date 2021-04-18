using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : AbstractFactoryObject
{

    public List<GenericFood> containedItems = new List<GenericFood>();

    public int capacity = 10;

    public bool shouldGenerate = false;
    public GenericFood generatorItem;



    public void InsertItem(GenericFood gf)
    {
        containedItems.Add(gf);
    }

    public GenericFood GetOneItem()
    {
        GenericFood ret = containedItems[containedItems.Count - 1];
        containedItems.Remove(ret);
        ret.GetComponent<GameObject>().SetActive(false);
        return ret;
    }

    public List<GenericFood> GetAllItems()
    {
        List<GenericFood> ret = new List<GenericFood>();
        foreach (GenericFood gf in containedItems)
        {
            gf.GetComponent<GameObject>().SetActive(false);
            ret.Add(gf);
        }
        foreach (GenericFood gf in ret)
        {
            containedItems.Remove(gf);
        }
        return ret;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldGenerate && containedItems.Count < capacity)
        {
            containedItems.Add(Instantiate(generatorItem, transform.position, transform.rotation).GetComponent<GenericFood>());
        }
    }
}
