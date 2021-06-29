using UnityEngine;

public abstract class State : ScriptableObject
{
    //gameplay parametrs 
    public bool isFineshed { get; protected set;}
    [HideInInspector] public Character character;

    public virtual void Init() { }
    public abstract void Run();
 
}
