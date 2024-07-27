using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter

{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;
    private float spawnPlateTimer;
    [SerializeField]private KitchenObjectSO plateKitchenObjectSO;
    [SerializeField] float spwanPlateTimerMax =4f;
    private int plateSpawnedAmount;
    [SerializeField] private int plateSpawnedMax = 4;
    private void Update()
    {
        spawnPlateTimer += Time.deltaTime;
        if(spawnPlateTimer > spwanPlateTimerMax)
        {
            spawnPlateTimer = 0f;
           if(plateSpawnedAmount < plateSpawnedMax)
            {
                plateSpawnedAmount++;
                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
               
            }
        }
    }
    public override void Interact(Player player)
    {
       if(!player.HasKitchenObjects())
        {
            //Player is EmptyHanded
            if(plateSpawnedAmount >0)
            {
                //There's at least one plate here 
                plateSpawnedAmount--;
                KitchenObjects.SpwanKitchenObject(plateKitchenObjectSO, player);
                OnPlateRemoved?.Invoke(this, EventArgs.Empty);

            }
        }

    }
}
