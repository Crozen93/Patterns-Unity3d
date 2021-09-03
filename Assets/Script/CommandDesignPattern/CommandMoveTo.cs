using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandMoveTo : ICommand
{
    GameManagerCommands mGameManager;
    Vector3 mDestination;
    Vector3 mStartPosition;

    public CommandMoveTo(GameManagerCommands manager, Vector3 startPos, Vector3 destPos)
    {
        mGameManager = manager;
        mDestination = destPos;
        mStartPosition = startPos;
    }

    public void Execute()
    {
        mGameManager.MoveTo(mDestination);
    }

    public void ExecuteUndo()
    {
        mGameManager.MoveTo(mStartPosition);
    }
}


