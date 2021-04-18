using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericFood : MonoBehaviour
{
    public Ingredient[] ingredients;
    public Consistency consistency;
    public FoodTexture foodTexture;
    public abstract void cook();
}


public enum Consistency
{
    Standard, Pureed
}

public enum FoodTexture
{
    Rough, Bland, 
}

public enum Ingredient 
{
    Fish,
    Potato,
    Beef,
    Pasta,

}