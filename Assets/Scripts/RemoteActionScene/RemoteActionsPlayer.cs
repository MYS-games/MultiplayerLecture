using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RemoteActionsPlayer : NetworkBehaviour
{
    [SerializeField] private TMP_Text nameText = null;
    [SerializeField] private Renderer playerRenderer = null;

    [SyncVar(hook = nameof(HandleTextOnUI))]
    [SerializeField] string playerName = "no one";

    [SyncVar(hook = nameof(HandleColorOnUI))]
    [SerializeField] Color playerColor = Color.gray;

    #region Server

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

    [Command]
    private void CmdSetName(string newName)
    {
        if(newName.Length < 1 || newName.Length > 8) { return; }

        RpcLogToAllClients(newName);

        SetName(newName);
    }

    #endregion

    #region Client

    private void HandleTextOnUI(string _, string newName)
    {
        nameText.text = newName;
    }

    private void HandleColorOnUI(Color _, Color newColor)
    {
        playerRenderer.material.SetColor("_BaseColor", newColor);
    }

    public void TrySetNameByClient(string newName)
    {
        CmdSetName(newName);
    }

    [ClientRpc]
    private void RpcLogToAllClients(string newName)
    {
        Debug.Log($"One of the players changed his name to {newName}");
    }

    #endregion
}
