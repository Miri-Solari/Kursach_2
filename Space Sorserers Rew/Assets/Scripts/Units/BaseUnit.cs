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
    [SerializeField] protected bool _canAttack = true;
    [SerializeField] protected bool _canMove = true;
    [SerializeField] protected bool _isFirable = true;
    [SerializeField] protected bool _isStunnable = true;
    [SerializeField] protected bool _isFreezable = true;
    [SerializeField] protected bool _isResistDebuffable = true;
    [SerializeField] protected bool _isSlowable = true;
    [SerializeField] protected bool _isWetable = true;
    [Serializable]
    public struct Res // считывание сопротивлений с инспектора
    {
        public ElemType name;
        public float value;
    }
    [SerializeField] Res[] _resistanceArray;

    protected Resistances _resistances = new Resistances(pyro:1);
    protected float _startSpeed;
    protected Resistances _startResist;
    private EffectCollector _collector;
    
    [SerializeField] protected float HP = 100;

    float IDamagable.HP { get => HP; set => HP = value; }
    Resistances IResistable.Resist { get=>_resistances; set => _resistances = value; }
    public float StartSpeed { get => _startSpeed; set => _startSpeed = value; }
    Resistances IResistDebuffable.StartResist { get => _startResist; set => _startResist = value; }


    protected virtual void Awake()
    {
        foreach (var res in _resistanceArray) // Переносим данные с инспектора Unity в структуру сопротивлений
        {
            _resistances.Types[res.name] = res.value;
        }
        _collector = new EffectCollector();
        CanAttack = _canAttack;
        CanMove = _canMove;
        Speed = _speed;
        IsFirable = _isFirable;
        IsFreezable = _isFreezable;
        IsResistDebuffable = _isResistDebuffable;
        IsSlowable = _isSlowable;
        IsStunnable = _isStunnable;
        IsWetable = _isWetable; // что можно делать с юнитом(можно было бы регулировать через интерфейсы от которых наследуется, но в инспекторе менять удобнее)

    }

    private void FixedUpdate()
    {
        if(HP < 0) // убиваем нашего юнита
        {
            Destroy(gameObject);
        }
    }

    public EffectCollector GetEffectCollector()
    {
        return _collector;
    }




}
