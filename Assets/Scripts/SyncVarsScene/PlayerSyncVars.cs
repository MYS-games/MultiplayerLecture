using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerSyncVars : NetworkBehaviour
{
    [SerializeField] private TMP_Text nameText = null;
    [SerializeField] private Renderer playerRenderer = null;

    [SyncVar(hook = nameof(HandleTextOnUI))]
    [SerializeField] string playerName = "no one";

    [SyncVar(hook = nameof(HandleColorOnUI))]
    [SerializeField] Color playerColor = Color.gray;

    [Server]
    public void SetName(string newName)
    {
        playerName = newName;
    }

    [Server]
    public void SetColor(Color newColor)
    {
        playerColor = newColor;
    }

    private void HandleTextOnUI(string _, string newName)
    {
        nameText.text = newName;
    }

    private void HandleColorOnUI(Color _, Color newColor)
    {
        playerRenderer.material.SetColor("_BaseColor", newColor);
    }

}
