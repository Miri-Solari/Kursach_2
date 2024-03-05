using UnityEngine;
public struct ElemContainer
{
    private BaseElem OutSLot;
    private BaseElem MidSlot;
    private BaseElem InnSlot;
    public ElemContainer(BaseElem[] elem)
    {
        OutSLot = elem[0];
        MidSlot = elem[1];
        InnSlot = elem[2];
    }

    public BaseElem[] Layers()
    {
        BaseElem[] res = new BaseElem[3];
        res[0] = InnSlot;
        res[1] = MidSlot;
        res[2] = OutSLot;
        if (res[0] == null)
        {
            res[0] = res[1];
            res[1] = res[2];
        }
        if (res[1] == null)
        {
            res[1] = res[2];
            res[2] = null;
        }
        return res;
    }

    public BaseElem GetOutLayer()
    {
        return Layers()[2];
    }

    public BaseElem GetMidLayer()
    {
        return Layers()[1];
    }

    public BaseElem GetInnLayer() 
    {
        return Layers()[0];
    }


}

