public class Mental : BaseElem // тебя на потом
{
    private void Awake()
    {
        _elemName = ElemType.Mental;
    }

    public override (Damage, BaseEffect) InnLayer(ElemType midLayer, ElemType outLayer) // логика, когда внутренний слой
    {
        Damage dmg = new();
        BaseEffect effect = new();
        return (dmg, effect);
    }

    public override Damage MidLayer() // логика, когда средний слой
    {
        Damage dmg = new();
        return dmg;
    }

    public override Damage OutLayer() // логика, когда внешний слой
    {
        Damage dmg = new();
        return dmg;
    }
}
