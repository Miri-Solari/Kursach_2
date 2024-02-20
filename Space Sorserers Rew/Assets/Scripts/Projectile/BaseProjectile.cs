using Assets.Scripts.Projectile;
using System.Collections;
using UnityEngine;

public class BaseProjectile : MonoBehaviour, IProjectile
{
    public Damage ContainDamage { get; set; }
    public BaseEffect ContainEffect { get; set; }

    [SerializeField] protected float speedDecreasing = 1f;
    [SerializeField] protected float speedDecreasingRate = 0.1f;
    [SerializeField] protected float startSpeed = 500f;
    [SerializeField] protected Rigidbody body;
    protected float currentSpeed;
    protected Vector3 velocityVector;

    private IProjectile ProjectileInterface => (IProjectile)this;


    protected virtual void OnCollisionEnter(Collision collision)
    {
        ProjectileInterface.Trigger(collision);
        currentSpeed = 0f;
        Debug.Log(ContainDamage.Types[ElemType.Pyro]) ;

    }

    private void Awake()
    {
        currentSpeed = startSpeed;
        velocityVector = new Vector3(Mathf.Cos(Mathf.Deg2Rad * transform.rotation.eulerAngles.y), 0f, -Mathf.Sin(Mathf.Deg2Rad * transform.rotation.eulerAngles.y));
        body.velocity = velocityVector * currentSpeed;
        StartCoroutine(SpeedDecrease());
    }

    protected IEnumerator SpeedDecrease()
    {
        while (currentSpeed > 0)
        {
            body.velocity = velocityVector * currentSpeed;
            currentSpeed -= speedDecreasing;
            yield return new WaitForSeconds(speedDecreasingRate);
        }
        Destroy(gameObject);
        
        
    }
}
