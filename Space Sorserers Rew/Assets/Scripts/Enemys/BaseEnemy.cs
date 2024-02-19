using Assets.Scripts;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IDamagable, IFirable, ISlowable, IResistDebuffable, IStunable, IWetable, IFrozable // ���������� �������� � ��������� ����� � ����
{
    public bool CanAttack { get; set; } = true;
    public bool CanMove { get; set; } = true;
    public float Speed { get; set; }  = 1f;

    [Serializable]
    public struct Res
    {
        public ElemType name;
        public float value;
    }
    [SerializeField] Res[] _resistanceArray;

    private Resistances _resistances = new Resistances(pyro:1);
    private float _startSpeed;
    private Resistances _startResist;
    
    [SerializeField] protected float HP = 100;

    float IDamagable.HP { get => HP; set => HP = value; }
    Resistances IResistable.Resist { get=>_resistances; set => _resistances = value; }
    public float StartSpeed { get => _startSpeed; set => _startSpeed = value; }
    Resistances IResistDebuffable.StartResist { get => _startResist; set => _startResist = value; }

    protected virtual void Awake()
    {
        foreach (var res in _resistanceArray)
        {
            //Debug.Log($"{res.name} {res.value} {_resistances.Types[ElemType.Pyro]}");
            _resistances.Types[res.name] = res.value;
        }
    }

    private void Update()
    {
        if(HP < 0)
        {
            //Destroy(gameObject);
        }
    }




}
