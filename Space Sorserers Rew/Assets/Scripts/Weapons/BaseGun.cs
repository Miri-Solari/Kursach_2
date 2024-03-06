using Assets.Scripts.Projectile;
using UnityEngine;

public class BaseGun : MonoBehaviour
{
    [SerializeField] protected Transform shootPoint;

    [SerializeField] protected GameObject projectilePrefab;
    protected BaseElem outLayer;
    protected BaseElem midLayer;
    protected BaseElem innLayer;
    protected (Damage, BaseEffect) damageEffectContainer;
    public virtual void Subscription() // стреляет
    {
        Inventory.Instance.SlotsChange += ChangeElem;
    }


    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.timeScale != 0f)
        {
            OpenFire();
        }
            
    }

    protected virtual void OnDisable()
    {
        Inventory.Instance.SlotsChange -= ChangeElem;
    }





    protected virtual void OpenFire()
    {
        GameObject temp = Instantiate(projectilePrefab, shootPoint.transform.position, shootPoint.transform.rotation);
        temp.GetComponent<IProjectile>().ContainEffect = damageEffectContainer.Item2;
        temp.GetComponent<IProjectile>().ContainDamage = damageEffectContainer.Item1;
    }



    public void ChangeElem(Inventory inventory) // ????? может переписать, но пока не знаю как
    {
        ElemType midElemContainer = ElemType.Null;
        ElemType outElemContainer = ElemType.Null;
        ElemContainer temp = inventory.GetSlots();

        outLayer = temp.GetOutLayer();
        midLayer = temp.GetMidLayer();
        innLayer = temp.GetInnLayer();
        if (midLayer != null)
            midElemContainer = midLayer._elemName;
        if (outLayer != null)
            outElemContainer = outLayer._elemName;
        damageEffectContainer = innLayer.InnLayer(midElemContainer, outElemContainer);
        if (midLayer != null) damageEffectContainer.Item1 += midLayer.MidLayer();
        if (outLayer!= null) damageEffectContainer.Item1 += outLayer.OutLayer();
    }


}
