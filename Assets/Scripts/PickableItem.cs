using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    public string itemName;
    public int itemID;
    public Sprite itemIcon;


    public void PickUp()
    {
        InventoryManager.Instance.AddItem(this);
        Debug.Log("Has recogido " + itemName);
        Destroy(this.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        print("Trigger stay");
        if (other.CompareTag("Player"))
        {
            print("Player");
            if (GameInput.Instance.GetActionInputDown())
            {
                print("Action input down");
                PickUp();
            }
        }
    }
}
