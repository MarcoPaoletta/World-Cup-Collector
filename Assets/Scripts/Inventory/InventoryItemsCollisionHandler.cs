using UnityEngine;

public class InventoryItemsCollisionHandler : MonoBehaviour
{   
    [SerializeField] private AudioClip inventoryItemSFX;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            InventoryManager.inventory[gameObject.tag] = true;
            SaveManager.SaveInventoryManagerData();
            AudioManager.instance.PlaySFX(inventoryItemSFX);
            Destroy(gameObject);
        }     
    }
}