using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistDebuff : BaseEffect
{
    [SerializeField] private float resistDuration;
    private IResistDebuffable _target;


    protected override void Awake()
    {
        base.Awake();
        _target = target.GetComponent<IResistDebuffable>();
        Resistances temp = new();
        foreach (var item in temp.Types)
        {
            temp.Types[item.Key] = resistDuration;
        }
        _target.ResistDebuff(temp.Types);
        temp.Types.Clear();
        StartCoroutine(ResDebEnd());
    }


    private IEnumerator ResDebEnd()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(_time);
        _target.ResistDebuffEnd();
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    public void ResistDurationMulti(float multi)
    {
        resistDuration *= multi;
    }


}
