using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker 
{
    Stack<ICommand> mCommands;

    public Invoker()
    {
        mCommands = new Stack<ICommand>();
    }

    public void Execute(ICommand command)
    {
        if (command != null)
        {
            mCommands.Push(command);
            mCommands.Peek().Execute();
        }
    }

    public void Undo()
    {
        if (mCommands.Count > 0)
        {
            mCommands.Peek().ExecuteUndo();
            mCommands.Pop();
        }
    }

   
}
