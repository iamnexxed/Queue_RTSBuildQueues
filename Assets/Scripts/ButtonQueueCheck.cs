using UnityEngine.UI;
using UnityEngine;

public class ButtonQueueCheck : MonoBehaviour
{
    public bool isQueued;
    public bool isBuilding;
    public uint counter;
    Image buttonImage;
    // Start is called before the first frame update
    void Start()
    {
        isQueued = false;
        counter = 0;
        buttonImage = GetComponent<Image>();
    }

    private void Update()
    {
       /* if(isQueued)
        {
            buttonImage.fillAmount = 0;
        }
        else
        {
            buttonImage.fillAmount = 1;
        }*/
    }

}
