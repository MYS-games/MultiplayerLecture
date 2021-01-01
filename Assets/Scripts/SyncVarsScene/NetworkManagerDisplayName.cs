using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManagerDisplayName : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);

        PlayerSyncVars myPlayer = conn.identity.GetComponent<PlayerSyncVars>();
        myPlayer.SetName($"Player {numPlayers}");
        myPlayer.SetColor(numPlayers == 1 ? Color.black : Color.white);


    }
}
