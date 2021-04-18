using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericFood : MonoBehaviour
{
    public Consistency consistency = Consistency.STANDARD;
    public Cook cook = Cook.UNCOOCKED;
    public Category category;
    public void SetCook(Cook cook)
    {
        this.cook = cook;
    }
    public void SetConsistency(Consistency consistency)
    {
        this.consistency = consistency;
    }
    public void SetCategory(Category category)
    {
        this.category = category;
    }
}

public enum Category
{
    PROTEIN, STARCH, VEGETABLE
}


public enum Consistency
{
    STANDARD, PUREED
}

public enum Cook
{
    UNCOOCKED, COOKED
}

