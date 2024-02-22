using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClickable
{
    public bool IsTaken { get; set; }
    public void Take();
    public void Put();
    public void Remove();
    public void Move();
    public void Double() { }
    public void OnHover() { }
}
