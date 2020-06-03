using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public interface IMessaging : IEventSystemHandler
{
    // functions that can be called via the messaging system
    void GoalReached();
    void Lost();
}
