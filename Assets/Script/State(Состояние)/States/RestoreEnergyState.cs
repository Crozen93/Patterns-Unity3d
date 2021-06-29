using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RestoreEnergyState : State
{
    public Transform targetBed;

    public Vector3 lastCharPos;

    public bool isSleepStarted;
    public float sleapTimeleft = 7f;

    public override void Init()
    {
        targetBed = GameObject.FindGameObjectWithTag("Bed").transform;
    }

    public override void Run()
    {
        if (isFineshed)
            return;
        if (!isSleepStarted)
            MoveToBed();
        else
            DoSleep();
    }

    void MoveToBed()
    {
        var distance = (targetBed.position - character.transform.position).magnitude;
        Debug.Log(distance);
        if (distance > 50)
        {
            character.MoveTo(targetBed.position);
        }
        else
        {
            lastCharPos = character.transform.position;
            character.transform.position = targetBed.position;

            //Animator
            isSleepStarted = true;
        }
    }

    void DoSleep()
    {
        sleapTimeleft -= Time.deltaTime;

        if (sleapTimeleft > 0)
            return;

        //animator character.Animator.Play("AnimationName");
        character.transform.position = lastCharPos;
        Debug.Log("I am Sleep");
        character.energy = 1f;
        isFineshed = true;


    }

}
