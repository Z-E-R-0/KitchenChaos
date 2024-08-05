using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManagerUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform recipeTemplate;
    // Start is called before the first frame update
    [SerializeField]
    private void Awake()
    {
        recipeTemplate.gameObject.SetActive(false);

    }
    private void Start()
    {
        DeliveryManager.Instance.OnRecipeCompleted += DeliveryManager_OnRecipeCompleted;
        DeliveryManager.Instance.OnRecipeSpawned += DeliveryManager_OnRecipeSpawned;
        UpdateVisual();
    }

    private void DeliveryManager_OnRecipeSpawned(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void DeliveryManager_OnRecipeCompleted(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    // Update is called once per frame
    void UpdateVisual()
    {
        foreach (Transform child in container)
        {
            if (child == recipeTemplate) continue;
            Destroy(child.gameObject);
        }
         foreach(RecipeSO recipeSO in  DeliveryManager.Instance.GetWaitingRecipeSOList())
        {
            Transform recipeTransform = Instantiate(recipeTemplate,container);
            recipeTransform.gameObject.SetActive(true); 
            recipeTransform.GetComponent<DeliveryManagerSingleUI>().SetRecipeSO(recipeSO);


        }

    }
}
