using System;
using System.Collections.Generic;
using UnityEngine;

public enum Ingredient
{
    Crepe,
    Chocolate,
    Strawberry,
    Cream
}

[Serializable]
public class Dish
{
    [SerializeField] private List<Ingredient> _dish = null;

    public Dish()
    {
        _dish = new();
    }

    public List<Ingredient> GetDish()
    {
        return _dish;
    }

    public void CatchCrepe()
    {
        _dish.Add(Ingredient.Crepe);
    }

    public void AddIngredient(Ingredient ingredient)
    {
        if (_dish.Contains(Ingredient.Crepe))
        {
            if (!_dish.Contains(ingredient))
            {
                _dish.Add(ingredient);
                Debug.Log($"{ingredient} added...");
            }
            else
            {
                Debug.Log($"Can't add {ingredient}, the crepe already has it...");
            }
        }
        else
        {
            Debug.Log($"Need a crepe first in order to add {ingredient}...");
        }
    }

    public void DishToTrash()
    {
        _dish.Clear();
    }
}
