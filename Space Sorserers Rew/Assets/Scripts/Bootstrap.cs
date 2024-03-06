using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] BaseGun baseGun;

    private void Awake()
    {
        Invoke(nameof(BaseGunInventoryConnect), 0.1f);
    }

    private void BaseGunInventoryConnect()
    {
        baseGun.Subscription();
        inventory.SlotIsChange();
        
    }
}
