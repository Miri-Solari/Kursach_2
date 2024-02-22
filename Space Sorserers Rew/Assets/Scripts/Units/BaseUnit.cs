using Assets.Scripts;
using System;
using UnityEngine;


public class BaseUnit : MonoBehaviour, IDamagable, IFirable, ISlowable, IResistDebuffable, IStunnable, IWetable, IFreezable // восприятие эффектов и получение урона в лицо
{
    public bool CanAttack { get; set; }
    public bool CanMove { get; set; }
    public float Speed { get; set; }
    public bool IsFirable {  get; set; }
    public bool IsStunnable { get; set;}
    public bool IsFreezable { get;set;}
    public bool IsResistDebuffable { get; set; }
    public bool IsSlowable {  get; set; }
    public bool IsWetable {  get; set; }

    [SerializeField] protected float _speed = 1f;
    [SerializeField] private bool _canAttack = true;
    [SerializeField] private bool _canMove = true;
    [SerializeField] private bool _isFirable = true;
    [SerializeField] private bool _isStunnable = true;
    [SerializeField] private bool _isFreezable = true;
    [SerializeField] private bool _isResistDebuffable = true;
    [SerializeField] private bool _isSlowable = true;
    [SerializeField] private bool _isWetable = true;
    [Serializable]
    public struct Res
    {
        public ElemType name;
        public float value;
    }
    [SerializeField] Res[] _resistanceArray;

    protected Resistances _resistances = new Resistances(pyro:1);
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
        CanAttack = _canAttack;
        CanMove = _canMove;
        Speed = _speed;
        IsFirable = _isFirable;
        IsFreezable = _isFreezable;
        IsResistDebuffable = _isResistDebuffable;
        IsSlowable = _isSlowable;
        IsStunnable = _isStunnable;
        IsWetable = _isWetable;

    }

    private void FixedUpdate()
    {
        if(HP < 0)
        {
            Destroy(gameObject);
        }
    }




}
