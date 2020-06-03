using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: NextLevel abstraction like in LevelManager
        if (Input.GetMouseButtonUp(0))
        {
            Color darkGrey;
            ColorUtility.TryParseHtmlString("#404040", out darkGrey);
            Initiate.Fade("Level1", darkGrey, 1);
        }
    }
}
