using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractAdaptor : MonoBehaviour
{
    public UnityEvent<PlayerInteractor> OnInvoked;
    public void Interact(PlayerInteractor interactor)
    {
        OnInvoked?.Invoke(interactor);
    }
}
