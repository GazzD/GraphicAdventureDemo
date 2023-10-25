using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventory;
    public static InventoryManager Instance { get; private set; }
    public List<PickableItem> items = new List<PickableItem>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (GameInput.Instance.GetInventoryInputDown())
        {
            print("Inventory input down");
            //this.gameObject.SetActive(!this.gameObject.activeSelf);
            inventory.SetActive(!inventory.activeSelf);
        }
    }

    public void AddItem(PickableItem item)
    {
        items.Add(item);
    }
}
