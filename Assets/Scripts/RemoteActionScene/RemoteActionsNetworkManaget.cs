using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RemoteActionsNetworkManaget : NetworkManager
{
    [SerializeField] private GameObject changeNameButton = null;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);

        RemoteActionsPlayer myPlayer = conn.identity.GetComponent<RemoteActionsPlayer>();
        myPlayer.SetName($"Player {numPlayers}");
        myPlayer.SetColor(numPlayers == 1 ? Color.black : Color.white);

    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);

        changeNameButton.SetActive(true);
    }
}
