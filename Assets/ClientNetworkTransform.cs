using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode.Components;
using UnityEngine.Networking;

//Allow for client movement in server
[DisallowMultipleComponent]
[System.Obsolete]
public class ClientNetworkTransform : NetworkTransform
{
    protected override bool OnIsServerAuthoritative()
    {
        return false;
    }

}

