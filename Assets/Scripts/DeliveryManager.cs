using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;
    public event EventHandler OnRecipeSuccess;
    public event EventHandler OnRecipeFail;
    public static DeliveryManager Instance {  get; private set; }
    [SerializeField] private RecipeListSO recipeListSO;
    List<RecipeSO> waitingRecipeSOList;
    private float spawnRecipeTimer;
    private float spawnRecipeTimerMax = 4;
    private int watingRecipeMax = 4;
    private void Awake()
    {
        Instance = this;
        waitingRecipeSOList = new List<RecipeSO>();
    }

    private void Update()
    {
        spawnRecipeTimer -= Time.deltaTime;
        if (spawnRecipeTimer <= 0f)
        {
            spawnRecipeTimer = spawnRecipeTimerMax;
            if (waitingRecipeSOList.Count < watingRecipeMax)
            {
                RecipeSO waitingRecipeSO = recipeListSO.recipesSOList[UnityEngine.Random.Range(0, recipeListSO.recipesSOList.Count)];
                Debug.Log(waitingRecipeSO.recipeName);
                waitingRecipeSOList.Add(waitingRecipeSO);
                OnRecipeSpawned?.Invoke(this,EventArgs.Empty);
            }
        }

    }
    public void DeliverRecipe(PlateKitchenObject plateKitchenObject)
    {

        for (int i = 0; i < waitingRecipeSOList.Count; ++i)
        {
            RecipeSO waitingRecipeSO = waitingRecipeSOList[i];

            if (waitingRecipeSO.kitchenObjectSOList.Count == plateKitchenObject.GetKitchenObjectSOList().Count)
            {

                // Has Same number of Ingredients
                bool plateContentMatchesRecipe = true;
                foreach (KitchenObjectSO recipeKitchenObjectSO in waitingRecipeSO.kitchenObjectSOList)
                {
                    //Cycling through all ingredients in recipe
                    bool ingredientsFound = false;
                    foreach (KitchenObjectSO plateKItchenObjectSO in plateKitchenObject.GetKitchenObjectSOList())
                    {
                        //Cycling through all ingredients in PLate
                        if (plateKItchenObjectSO == recipeKitchenObjectSO)
                        {
                            //Ingredients Matches!
                            ingredientsFound = true;
                            break;

                        }



                    }
                    if (!ingredientsFound)
                    {
                        // This Recipe ingredient not found on the Plate 
                        plateContentMatchesRecipe = false;
                    }
                }
                if (plateContentMatchesRecipe)
                {
                    //Player Delivered Correct Recipe
                  
                    waitingRecipeSOList.RemoveAt(i);

                    OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
                    OnRecipeSuccess?.Invoke(this, EventArgs.Empty);
                    return;


                }

            }

        }
        //No matches Found
        //Player Did not delivered a correct recipe 
        OnRecipeFail?.Invoke(this, EventArgs.Empty);



    }
    public List<RecipeSO> GetWaitingRecipeSOList()
    {
        return waitingRecipeSOList;

    }
}
