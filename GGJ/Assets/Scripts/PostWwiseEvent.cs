using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostWwiseEvent : MonoBehaviour
{
    public AK.Wwise.Event ChosenEvent;

    public void PlaySound() {
        ChosenEvent.Post(gameObject);
    }
}