using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private CommandManager _cmdManager;
    public KeyCode undoKey = KeyCode.U;
    public KeyCode redoKey = KeyCode.R;

    private void Awake()
    {
        _cmdManager = FindObjectOfType<CommandManager>();
    }

    void Update()
    {
        if (_cmdManager == null) return;
        if (Input.GetKeyDown(undoKey)) { _cmdManager.Undo(); }
        if (Input.GetKeyDown(redoKey)) { _cmdManager.Redo(); }
    }
}
