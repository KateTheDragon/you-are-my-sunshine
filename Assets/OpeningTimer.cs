using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OpeningTimer : timer
{
    [SerializeField] public float startRunning = 2F;
    [SerializeField] public float runSpeed = .5F;
    [SerializeField] public Sprite runningSprite1;
    [SerializeField] public Sprite runningSprite2;
    [SerializeField] public float teeth = 4F;
    [SerializeField] public float teethClose = 4.4F;
    [SerializeField] public Sprite teethCloseSprite;
    [SerializeField] public float swipe = 4.8F;
    [SerializeField] public Sprite swipeSprite;
    [SerializeField] public float drop = 5.2F;
    [SerializeField] public Sprite dropSprite;
    [SerializeField] public float title = 8f;
    [SerializeField] public GameObject mamaPuppet;
    SpriteRenderer mamaSprite;
    Transform mamaTransform;
    [SerializeField] public GameObject teethPuppet;
    SpriteRenderer teethSprite;
    [SerializeField] public GameObject eggPuppet;
    Transform eggTransform;
    [SerializeField] public GameObject mainCameraObj;
    Camera mainCamera;
    Color darkGrey;
    // Start is called before the first frame update
    void Start()
    {
        mamaPuppet.TryGetComponent<SpriteRenderer>(out mamaSprite);
        teethPuppet.TryGetComponent<SpriteRenderer>(out teethSprite);
        mamaTransform = mamaPuppet.GetComponent<Transform>();
        eggTransform = eggPuppet.GetComponent<Transform>();
        mainCameraObj.TryGetComponent<Camera>(out mainCamera);

        ColorUtility.TryParseHtmlString("#404040", out darkGrey);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        if (currentTime > startRunning && currentTime < teeth)
        {
            mamaTransform.position += new Vector3(1.5f, 0, 0) * Time.deltaTime;
            int frame = (int)((currentTime - startRunning) / runSpeed);
            if (frame % 2 > 0)
            {
                mamaSprite.sprite = runningSprite1;
            } else
            {
                mamaSprite.sprite = runningSprite2;
            }
        } else if (currentTime > teeth && currentTime < teethClose)
        {
            mainCamera.backgroundColor = Color.black;
            mamaPuppet.SetActive(false);
            teethPuppet.SetActive(true);
        } else if (currentTime > teethClose && currentTime < swipe)
        {
            teethSprite.sprite = teethCloseSprite;
        } else if (currentTime > swipe && currentTime < drop)
        {
            teethSprite.sprite = swipeSprite;
        } else if (currentTime > drop && currentTime < title)
        {
            teethPuppet.SetActive(false);
            mamaTransform.position = new Vector3(0, 0, 0);
            mamaPuppet.SetActive(true);
            mainCamera.backgroundColor = darkGrey;
            mamaSprite.sprite = dropSprite;
            eggPuppet.SetActive(true);
            Roll(eggTransform);
        } else if (currentTime > title)
        {
            Initiate.Fade("Title", darkGrey, 1);
        }

    }
    
    void Roll(Transform puppet)
    {
        puppet.position += new Vector3(2, -1, 0) * Time.deltaTime;

        puppet.Rotate(0,0,-Time.deltaTime * 180);
     
    }

}
