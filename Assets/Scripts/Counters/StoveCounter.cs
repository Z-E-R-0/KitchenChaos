using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static CuttingCounter;

public class StoveCounter : BaseCounter, IHasProgress
{
    [SerializeField] private FryingRecipeSO[] fryingRecipeSOArray;
    [SerializeField] private BurningRecipeSO[] burningRecipeSOArray;

    private float fryingtimer;
    private float burningtimer;
    private FryingRecipeSO fryingRecipeSO;
    private BurningRecipeSO burningRecipeSO;
    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;
    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;
    public class OnStateChangedEventArgs : EventArgs
    {
        public States states;
    }
    public enum States
    {
        Idle,
        Frying,
        Fried,
        Burned,
    }

    private States states;


    private void Start()
    {
        states = States.Idle;
    }

    private void Update()
    {

        if (HasKitchenObjects())
        {
            switch (states)
            {
                case States.Idle:

                    break;

                case States.Frying:
                    fryingtimer += Time.deltaTime;
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = fryingtimer / fryingRecipeSO.fryingTimerMax
                    });
                    if (fryingtimer > fryingRecipeSO.fryingTimerMax)
                    {
                        //Fried
                        GetKitchenObject().DestroySelf();
                        KitchenObjects.SpwanKitchenObject(fryingRecipeSO.output, this);
                        states = States.Fried;
                        burningtimer = 0f;
                        burningRecipeSO = GetBurningRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                        {
                            states = states
                        });
                    }
                    break;

                case States.Fried:
                    burningtimer += Time.deltaTime;
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = burningtimer / burningRecipeSO.BurningingTimerMax
                    });
                    if (burningtimer > burningRecipeSO.BurningingTimerMax)
                    {
                        //Fried
                        GetKitchenObject().DestroySelf();
                        KitchenObjects.SpwanKitchenObject(burningRecipeSO.output, this);
                        states = States.Burned;
                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                        {
                            states = states
                        });
                        OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                        {
                            progressNormalized = 0f
                        });
                    }
                    break;

                case States.Burned:

                    break;


            }

        }
    }
    public override void Interact(Player player)
    {
        {
            if (!HasKitchenObjects())
            {
                //there is no kitchen object Here
                if (player.HasKitchenObjects())
                {
                    //Player Carying Someting
                    if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                    {
                        //Player Carrying someting That can be Fried

                        player.GetKitchenObject().SetKitchenObjectParent(this);
                        fryingRecipeSO = GetFryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                        states = States.Frying;
                        fryingtimer = 0f;

                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                        {
                            states = states
                        });

                        OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                        {
                            progressNormalized = fryingtimer / fryingRecipeSO.fryingTimerMax
                        });





                    }
                }
                else
                {
                    //Player Not Carriying Anything 

                }
            }

            else
            {
                //there is a kitchen object Here
                if (player.HasKitchenObjects())
                {

                    //player carrying somting 
                    if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                    {
                        //Player is holding a plate

                        if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                        {
                            GetKitchenObject().DestroySelf();
                            states = States.Idle;
                            OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                            {
                                states = states
                            });
                            OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                            {
                                progressNormalized = 0f
                            });
                        }

                    }
                }
                else
                {
                    //Player is not carrying anything
                    GetKitchenObject().SetKitchenObjectParent(player);
                    states = States.Idle;
                    OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                    {
                        states = states
                    });
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = 0f
                    });
                }



            }
        }
    }
    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO);
        return fryingRecipeSO != null;


    }
    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO);
        if (fryingRecipeSO != null)
        {
            return fryingRecipeSO.output;

        }
        else
        {
            return null;
        }


    }

    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {

        foreach (FryingRecipeSO fryingRecipeSO in fryingRecipeSOArray)
        {
            if (fryingRecipeSO.input == inputKitchenObjectSO)
            {
                return fryingRecipeSO;
            }


        }
        return null;

    }
    private BurningRecipeSO GetBurningRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {

        foreach (BurningRecipeSO BurningingRecipeSO in burningRecipeSOArray)
        {
            if (BurningingRecipeSO.input == inputKitchenObjectSO)
            {
                return BurningingRecipeSO;
            }


        }
        return null;

    }
}
