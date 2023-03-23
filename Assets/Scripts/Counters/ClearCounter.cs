using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
        
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //there is no kitchen object here

            if (player.HasKitchenObject())
            {
                //player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //player is not carrying anything

            }
        }
        else
        {
            //there is kitchen object
            if (player.HasKitchenObject())
            {
                //player is carying somehting
                if(player.GetKitchenObject() is PlateKitchenObject)
                {
                    //Player is holding a plate
                    PlateKitchenObject plateKitchenObject = player.GetKitchenObject() as PlateKitchenObject;
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                    
                }
            }
            else
            {
                //player is not carying antygin
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }

    }

}
