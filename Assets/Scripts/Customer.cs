using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public int age;
    public string customerName;
    public Preferences preferences;
    public Disabilities disabilities;
    public float socialSatisfaction;

    public void CreateCustomer(int age, string name, Preferences preferences, Disabilities disabilities, float socialSatisfaction)
    {
        this.age = age;
        this.customerName = name;
        this.preferences = preferences;
        this.disabilities = disabilities;
        this.socialSatisfaction = socialSatisfaction;
    }

    public float ServeCustomer(Dish dish)
    {
        float points = 3;
        if (!preferences.likedConsistencies.Contains(dish.protein.consistency)) {
            points -= 1;
        }
        if (!preferences.likedConsistencies.Contains(dish.vegetable.consistency))
        {
            points -= 1;
        }
        if (!preferences.likedConsistencies.Contains(dish.starch.consistency))
        {
            points -= 1;
        }
        return points;
    }
}

public struct Preferences
{
    public List<Consistency> likedConsistencies;
    public List<Consistency> dislikedConsistencies;
}

public enum Disabilities
{
    None,
    CannotSwallow,
    Blind
}