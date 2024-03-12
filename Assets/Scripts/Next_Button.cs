using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Next_Button : MonoBehaviour
{
    public BoxCollider2D CloudHitbox;
    public Button nextButton;
    public Button playButton;

    
    public void DropBall()
    {
        CloudHitbox.enabled = false;
    }

    void Start()
    {
        CloudHitbox = GetComponent<BoxCollider2D>();
        playButton.gameObject.SetActive(false);
        nextButton.onClick.AddListener(switchButtons);
    }

    void switchButtons()
    {
        // Disable the button's GameObject
        nextButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
    }
}
