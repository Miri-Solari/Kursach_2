public class Mental : BaseElem // ���� �� �����
{
    private void Awake()
    {
        _elemName = ElemType.Mental;
    }

    public override (Damage, BaseEffect) InnLayer(ElemType midLayer, ElemType outLayer) // ������, ����� ���������� ����
    {
        Damage dmg = new();
        BaseEffect effect = new();
        return (dmg, effect);
    }

    public override Damage MidLayer() // ������, ����� ������� ����
    {
        Damage dmg = new();
        return dmg;
    }

    public override Damage OutLayer() // ������, ����� ������� ����
    {
        Damage dmg = new();
        return dmg;
    }
}
