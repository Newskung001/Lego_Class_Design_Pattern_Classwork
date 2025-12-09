using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    private Stack<ICommand> undoStack = new();
    private Stack<ICommand> redoStack = new();
    public void ExecuteCommand(ICommand command)
    {
        if (command == null) return;
        command.Execute(); undoStack.Push(command); redoStack.Clear();
    }
    public void Undo()
    {
        if (undoStack.Count == 0) return;
        ICommand last = undoStack.Pop(); last.Undo(); redoStack.Push(last);
    }
    public void Redo()
    {
        if (redoStack.Count == 0) return;
        ICommand cmd = redoStack.Pop(); undoStack.Push(cmd); cmd.Execute();
    }
}
