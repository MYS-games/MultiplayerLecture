using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManualSetName : MonoBehaviour
{
    
    
    public void setname(TMP_InputField newName)
    {
        RemoteActionsPlayer[] myPlayer = FindObjectsOfType<RemoteActionsPlayer>();
        Debug.Log(myPlayer.Length);

        foreach(RemoteActionsPlayer p in myPlayer)
        {
            p.TrySetNameByClient(newName.text);
        }
       // myPlayer.TrySetNameByClient(newName.text);
    }
}
