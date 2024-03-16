
using Assets.Scripts;

public class Armor : BaseArmor
{
    private void Awake()
    {
        foreach (var res in _resistanceArray) // Переносим данные с инспектора Unity в структуру сопротивлений
        {
            _resistances.Types[res.name] = res.value;
        }
    }
    public override void GiveEffect(IArmorAffectable targetArmor, IResistable targetResist) // применяем эфффект
    {
        _armorEffect.ApplyEffect(targetArmor);
        ApplyResist(targetResist);
    }

    private void ApplyResist(IResistable target)
    {
        target.Resist += _resistances;
    }

}
