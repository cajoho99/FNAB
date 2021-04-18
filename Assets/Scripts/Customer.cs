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

    public float ServeCustomer(GenericFood food)
    {
        float score = 0;
        foreach (var ingredient in food.ingredients)
        {
            if(this.preferences.likedIngredients.Contains(ingredient))
            {
                score++;
            }
            else if(this.preferences.dislikedIngredients.Contains(ingredient))
            {
                score--;
            }
        }
        if(disabilities == Disabilities.CannotSwallow && food.consistency == Consistency.Pureed)
        {
            score++;
        }
        else if(disabilities == Disabilities.CannotSwallow && food.consistency == Consistency.Standard)
        {
            score--;
        }
        return score;
    }
}

public struct Preferences
{
    public List<Ingredient> likedIngredients;
    public List<Ingredient> dislikedIngredients;
    public List<Consistency> likedConsistencies;
    public List<Consistency> dislikedConsistencies;
    public List<FoodTexture> likedTextures;
    public List<FoodTexture> dislikedTextures;
}

public enum Disabilities
{
    None,
    CannotSwallow,
    Blind
}