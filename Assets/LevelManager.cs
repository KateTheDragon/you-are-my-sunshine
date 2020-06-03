using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour, IMessaging
{
    [SerializeField] public string nextLevel;

    public void GoalReached()
    {
        Color lightGrey;
        ColorUtility.TryParseHtmlString("#BFBFBF", out lightGrey);
        Initiate.Fade(nextLevel, lightGrey, .1f);
    }

    public void Lost()
    {
        Color darkGrey;
        ColorUtility.TryParseHtmlString("#404040", out darkGrey);
        Initiate.Fade("Lose", darkGrey, .5f);
    }
}
