using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class JumpState : State
{
    public float jumpForce;


    public override void Init()
    {
       // isGround = true;
    }

    public override void Run()
    {

        if (character.isGround == true)
            character.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        else
            isFineshed = true;
    }

   

}
