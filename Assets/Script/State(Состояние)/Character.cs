using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Init parametrs")]
    public float eat = 1f;
    public float energy = 1f;

    public float moveSpeed;

    public State StartState;
    public State EatState;
    public State EnergyState;
    public State RandomMoveState;

    public Animator animator;

    [Header("Actual state")]
    public State CurrentState;

    public float eatEndTime = 15f;
    public float energyEndTime = 25f;

    void Start()
    {
        SetState(StartState);
    }

    void Update()
    {
        eat -= Time.deltaTime / eatEndTime;
        energy -= Time.deltaTime / energyEndTime;

        if (!CurrentState.isFineshed)
        {
            CurrentState.Run();
        }
        else
        {
            if (eat <= 0.4f)
                SetState(EatState);
            else if (energy <= 0.4f)
                SetState(EnergyState);
            else
                SetState(RandomMoveState);
        }
    }

    public void SetState(State state)
    {
        CurrentState = Instantiate(state);
        CurrentState.character = this;
        CurrentState.Init();
    }

    public void MoveTo(Vector3 position)
    {
        position.y = transform.position.y;

        transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * moveSpeed);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(position - transform.position), Time.deltaTime * 120);
    }
}
