using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    public GenericFood starch;
    public GenericFood vegetable;
    public GenericFood protein;

    public void setStarch(GenericFood gf)
    {
        this.starch = gf;
    }
    public void setVegetable(GenericFood gf)
    {
        this.vegetable = gf;
    }
    public void setProtein(GenericFood gf)
    {
        this.protein = gf;
    }
}
