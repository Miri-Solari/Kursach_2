using System.Collections;
using UnityEngine;

public class ArmorChecker : MonoBehaviour
{
    [SerializeField] Slot helmetSlot;
    [SerializeField] Slot armorSlot;
    [SerializeField] Slot handsSlot;
    [SerializeField] Slot legsSlot;
    [SerializeField] Slot bootsSlot;
    [SerializeField] Player target;

    private void OnEnable()
    {
        if (helmetSlot != null)
        {
            helmetSlot.Equip += EquipHelmet;
            helmetSlot.UnEquip += UnEquipHelmet;
        }
        if (armorSlot != null)
        {
            armorSlot.Equip += EquipArmor;
            armorSlot.UnEquip += UnEquipArmor;
        }
        if (handsSlot != null)
        {
            handsSlot.Equip += EquipHands;
            handsSlot.UnEquip += UnEquipHands;
        }
        if (legsSlot != null)
        {
            legsSlot.Equip += EquipLegs;
            legsSlot.UnEquip += UnEquipLegs;
        }
        if (bootsSlot != null)
        {
            bootsSlot.Equip += UnEquipBoots;
            bootsSlot.UnEquip += UnEquipBoots;
        }
    }

    private void OnDisable()
    {
        if (helmetSlot != null)
        {
            helmetSlot.Equip -= EquipHelmet;
            helmetSlot.UnEquip -= UnEquipHelmet;
        }
        if (armorSlot != null)
        {
            armorSlot.Equip -= EquipArmor;
            armorSlot.UnEquip -= UnEquipArmor;
        }
        if (handsSlot != null)
        {
            handsSlot.Equip -= EquipHands;
            handsSlot.UnEquip -= UnEquipHands;
        }
        if (legsSlot != null)
        {
            legsSlot.Equip -= EquipLegs;
            legsSlot.UnEquip -= UnEquipLegs;
        }
        if (bootsSlot != null)
        {
            bootsSlot.Equip -= UnEquipBoots;
            bootsSlot.UnEquip -= UnEquipBoots;
        }
    }



    private void EquipHelmet() // тут можно было бы использовать классы брони, но это усложнит архитектуру, но облегчит код, ну и в целом надо считать что эффективнее, итак сложность высокая
    {
        if (helmetSlot != null) target.EquipHelmet(helmetSlot.transform.GetComponentInChildren<Armor>());
    }

    private void EquipArmor()
    {
        if (armorSlot != null) target.EquipArmor(armorSlot.transform.GetComponentInChildren<Armor>());
    }
    private void EquipHands()
    {
        if (handsSlot != null) target.EquipHands(handsSlot.transform.GetComponentInChildren<Armor>());
    }
    private void EquipLegs()
    {
        if (legsSlot != null) target.EquipLegs(legsSlot.transform.GetComponentInChildren<Armor>());
    }
    private void EquipBoots()
    {
        if (bootsSlot != null) target.EquipBoots(helmetSlot.transform.GetComponentInChildren<Armor>());
    }



    private void UnEquipHelmet()
    {
        target.UnEquipHelmet();
    }

    private void UnEquipArmor()
    {
        target.UnEquipArmor();
    }
    private void UnEquipHands()
    {
        target.UnEquipHand();
    }
    private void UnEquipLegs()
    {
        target.UnEquipLegs();
    }
    private void UnEquipBoots()
    {
        target.UnEquipBoots();
    }


}
