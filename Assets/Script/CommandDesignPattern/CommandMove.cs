using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandMove : ICommand
{
    GameObject mGameObject;
    Vector3 mDirection;

    public CommandMove(GameObject obj, Vector3 direction)
    {
        mGameObject = obj;
        mDirection = direction;
    }

    public void Execute()
    {
        mGameObject.transform.position += mDirection;
    }

    public void ExecuteUndo()
    {
        mGameObject.transform.position -= mDirection;
    }

    
}
