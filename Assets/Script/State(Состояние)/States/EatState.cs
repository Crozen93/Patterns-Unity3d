using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EatState : State
{
    public float restoreEat = 0.6f;
    public State noApplesState;

    Transform targetApple;


    public override void Init()
    {
        var apples = GameObject.FindGameObjectsWithTag("Apple");

        if (apples.Length == 0)
        {
            character.SetState(noApplesState);
            return;
        }

        targetApple = apples[Random.Range(0, apples.Length)].transform;
    }


    public override void Run()
    {
        if (isFineshed)
            return;

        MoveToApple();
    }

    void MoveToApple()
    {
        var distance = (targetApple.position - character.transform.position).magnitude;

        if (distance > 20f)
        {
            character.MoveTo(targetApple.position);
        }
        else
        {
            Destroy(targetApple.gameObject);
            character.eat += restoreEat;
            isFineshed = true;
        }
    }
}
