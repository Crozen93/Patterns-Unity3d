using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Init parametrs")]
    public float eat = 1f;
    public float energy = 1f;

    public float moveSpeed;
    public bool isGround;

    public State StartState;
    public State EatState;
    public State EnergyState;
    public State JumpState;
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
            else if (energy >= 0.8f)
                SetState(JumpState);
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

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }

    /*
    void OnTriggerStay(Collider col)
    {               //если в тригере что то есть и у обьекта тег "ground"
        if (col.tag == "Ground")
        {
            isGround = true;      //то включаем переменную "на земле"
            Debug.Log("Ground true");
        }
    }
    void OnTriggerExit(Collider col)
    {              //если из триггера что то вышло и у обьекта тег "ground"
        if (col.tag == "Ground")
        {
            isGround = false;     //то вџключаем переменную "на земле"
            Debug.Log("Ground false");
        }
    }
    */

}
