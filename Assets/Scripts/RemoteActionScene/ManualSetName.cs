using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManualSetName : MonoBehaviour
{
    [SerializeField] TMP_InputField selectedName = null;
    
    public void setname()
    {
        string myNewName = selectedName.text;
        RemoteActionsPlayer myPlayer = FindObjectOfType<RemoteActionsPlayer>();

        myPlayer.TrySetNameByClient(myNewName);
    }
}
