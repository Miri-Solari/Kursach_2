using Assets.Scripts.Projectile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : MonoBehaviour
{
    public Inventory inventar; // ÂÐÅÌÅÍÍÎ
    [SerializeField] protected Transform shootPoint;

    [SerializeField] protected GameObject projectilePrefab;
    protected BaseElem outLayer;
    protected BaseElem midLayer;
    protected BaseElem innLayer;
    protected (Damage, BaseEffect) damageEffectContainer;
    protected virtual void Awake() // ñòðåëÿåò
    {
        ChangeElem(inventar);
    }


    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OpenFire();
        }
            
    }





    protected virtual void OpenFire()
    {
        GameObject temp = Instantiate(projectilePrefab, shootPoint.transform.position, shootPoint.transform.rotation);
        temp.GetComponent<IProjectile>().ContainEffect = damageEffectContainer.Item2;
        temp.GetComponent<IProjectile>().ContainDamage = damageEffectContainer.Item1;
    }

    public void ChangeElem(Inventory inventory)
    {
        GameObject[] temp = inventory.GetSlots();
        outLayer = temp[0].GetComponent<BaseElem>();
        midLayer = temp[1].GetComponent<BaseElem>();
        innLayer = temp[2].GetComponent<BaseElem>();
        damageEffectContainer = innLayer.InnLayer(ElemType.Pyro, ElemType.Pyro);
        damageEffectContainer.Item1 += midLayer.MidLayer();
        damageEffectContainer.Item1 += outLayer.OutLayer();
    }
}
