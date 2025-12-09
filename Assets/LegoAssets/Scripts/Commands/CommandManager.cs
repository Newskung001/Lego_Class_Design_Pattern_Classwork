using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    private Stack<ICommand> undoStack = new Stack<ICommand>();
    private Stack<ICommand> redoStack = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        undoStack.Push(command);
        redoStack.Clear(); // เคลียร์ Redo ทุกครั้งที่มีคำสั่งใหม่
    }

    public void Undo()
    {
        if (undoStack.Count > 0)
        {
            ICommand cmd = undoStack.Pop();
            cmd.Undo();
            redoStack.Push(cmd);
            Debug.Log("Undo Command");
        }
    }

    public void Redo()
    {
        if (redoStack.Count > 0)
        {
            ICommand cmd = redoStack.Pop();
            cmd.Execute();
            undoStack.Push(cmd);
            Debug.Log("Redo Command");
        }
    }
}
