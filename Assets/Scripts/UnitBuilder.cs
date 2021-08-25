using UnityEngine.UI;
using UnityEngine;

public class UnitBuilder : MonoBehaviour
{
    public float destroyTime = 5f;
    [SerializeField] Image[] uiImages;
    Queue unitQueue;

    [SerializeField]
    Transform spawnPoint;

    float objectBuildTime;

    float timer;
    bool isBuilding;

    Image currentBuildImage;

    // Start is called before the first frame update
    void Start()
    {
        unitQueue = new Queue();
        objectBuildTime = 0.0f;
        timer = 0.0f;
        isBuilding = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < uiImages.Length; ++i)
        {

            if (uiImages[i].GetComponent<ButtonQueueCheck>().isQueued)
            {
                uiImages[i].fillAmount = 0;
            }
            else
            {
                uiImages[i].fillAmount = 1;
            }



        }

        if (!unitQueue.empty() && !isBuilding)
        {
            Debug.Log(unitQueue.front().name + " will start building now.");
            objectBuildTime = unitQueue.front().GetComponent<Unit>().unitBuildTime;
            timer = 0;

            currentBuildImage = uiImages[(int) unitQueue.front().GetComponent<Unit>().unitType];
            currentBuildImage.GetComponent<ButtonQueueCheck>().isBuilding = true;
            currentBuildImage.fillAmount = 0;
            isBuilding = true;
        }
       

        if (isBuilding)
        {

            if (timer < objectBuildTime)
            {
                timer += Time.deltaTime;
                float percent = timer / objectBuildTime;
                //fill the sprite
                currentBuildImage.fillAmount = percent;
            }
            else
            {
                timer = 0.0f;
                isBuilding = false;
                // Spawn Object
                GameObject spawnObject = Instantiate(unitQueue.front(), spawnPoint.position, spawnPoint.rotation);
                // spawnObject.GetComponent<UnitMovement>().shouldMove = true;
                Destroy(spawnObject, destroyTime);
                Debug.Log("Spawn object now.");
                currentBuildImage.GetComponent<ButtonQueueCheck>().isBuilding = false;
                PopFromQueue();
            }
            
        }
       

    }

    public void PushIntoQueue(GameObject unit)
    {
        unitQueue.enqueue(unit);

        uiImages[(int)unit.GetComponent<Unit>().unitType].GetComponent<ButtonQueueCheck>().isQueued = true;
        uiImages[(int)unit.GetComponent<Unit>().unitType].GetComponent<ButtonQueueCheck>().counter++;
    }

    void PopFromQueue()
    {
        uiImages[(int)unitQueue.front().GetComponent<Unit>().unitType].GetComponent<ButtonQueueCheck>().counter--;
        if (uiImages[(int)unitQueue.front().GetComponent<Unit>().unitType].GetComponent<ButtonQueueCheck>().counter <= 0)
            uiImages[(int)unitQueue.front().GetComponent<Unit>().unitType].GetComponent<ButtonQueueCheck>().isQueued = false;
        
        unitQueue.dequeue();
    }
}
