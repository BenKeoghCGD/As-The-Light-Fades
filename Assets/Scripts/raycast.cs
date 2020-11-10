using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ObjCardPair : System.Object
{
    public GameObject key;
    public raycast.KeyCards value;
}

public class raycast : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject raycastObj;

    [Header("Values")]
    public static bool interact;
    public float reachDistance;

    [Header("parts")]
    public int PartNumber;

    public GameObject part1;
    public GameObject part2;
    public GameObject part3;

    public bool repaired1;
    public bool repaired2;
    public bool repaired3;

    [Header("machineState")]
    public bool machineOpen;
    public Animator machineAnimator;

    [Header("Canvases")]
    public Canvas interaction;
    public Text interaction_text;

    [Header("KeyCards")]
    public IDictionary<GameObject, KeyCards> cards = new Dictionary<GameObject, KeyCards>();

    public List<ObjCardPair> objCardPairs = new List<ObjCardPair>();

    public enum KeyCards
    {
        BLUE, RED, YELLOW, GREEN, PURPLE
    };
    public List<KeyCards> obtainedKeycards = new List<KeyCards>();

    public KeyCode[] combo;
    public int currentIndex = 0;

    bool inter = false;

    // the parts that are going to be repaired 
    void Start()
    {
        // setting collected parts to 0, parts repaired to non and the machine closed
        PartNumber = 0;
        repaired1 = false;
        repaired2 = false;
        repaired3 = false;

        machineOpen = false;
        interaction.enabled = false;
        interaction_text.text = "PRESS 'E' TO INTERACT";

        foreach (ObjCardPair pair in objCardPairs)
        {
            cards.Add(pair.key, pair.value);
        }
    }

    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,out hit, reachDistance))
        {
            raycastObj = hit.collider.gameObject;
            if (hit.collider.tag == "EasterEgg")
            {
                if (currentIndex < combo.Length)
                {
                    if (Input.GetKeyDown(combo[currentIndex]))
                    {
                        currentIndex++;
                    }
                }
                else
                {
                    currentIndex = 0;
                    StartCoroutine(hit.collider.GetComponent<VideoScript>().playEE());
                }
            }
            else currentIndex = 0;

            if(cards.ContainsKey(hit.collider.gameObject))
            {
                inter = true;
                interaction.enabled = true;
                interaction_text.text = "PRESS 'E' TO PICK UP";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.SetActive(false);
                    KeyCards card;
                    cards.TryGetValue(hit.collider.gameObject, out card);
                    obtainedKeycards.Add(card);
                }
            }

            if (hit.collider.name == "ElevatorButton")
            {
                inter = true;
                interaction.enabled = true;
                ElevatorHandler eh = hit.collider.GetComponent<ElevatorHandler>();
                switch(eh.Elevator_Function)
                {
                    case ElevatorHandler.doorFunction.FLOOR1:
                        interaction_text.text = "PRESS 'E' FOR FLOOR 1";
                        break;
                    case ElevatorHandler.doorFunction.FLOOR2:
                        interaction_text.text = "PRESS 'E' FOR FLOOR 2";
                        break;
                    case ElevatorHandler.doorFunction.HUB:
                        interaction_text.text = "PRESS 'E' FOR HUB";
                        break;
                    case ElevatorHandler.doorFunction.OPENDOOR:
                        interaction_text.text = "PRESS 'E' TO OPEN ELEVATOR";
                        break;
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.gameObject.GetComponent<ElevatorHandler>().runFunction();
                }
            }

            if (hit.collider.name.StartsWith("LevelButton"))
            {
                inter = true;
                interaction.enabled = true;
                interaction_text.text = "PRESS 'E' TO INTERACT";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    int lev = 0;
                    int.TryParse(hit.collider.name.Remove("LevelButton".Length), out lev);
                    transform.parent.GetComponent<playerHandler>().levelLoader.changeLevel(lev);
                }
            }

            if (hit.collider.name == "door")
            {
                inter = true;
                interaction.enabled = true;
                interaction_text.text = "PRESS 'E' TO OPEN DOOR";
                doorScript ds = raycastObj.GetComponent<doorScript>();
                if(Input.GetKeyDown(KeyCode.E)) ds.isLooking(obtainedKeycards);
            }

            if (hit.collider.name == "partMain")
            {
                inter = true;
                interaction.enabled = true;
                interaction_text.text = "PRESS 'E' TO PICK UP";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(hit.collider.gameObject);
                    PartNumber += 1;
                    //Debug.Log("this is a part");
                }
            }

            if (hit.collider.name == "repairInteract")
            {
                inter = true;
                interaction.enabled = true;
                interaction_text.text = "PRESS 'E' TO PLACE PARTS";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (PartNumber == 1)
                    {
                        repaired1 = true;
                        part1.SetActive(true);
                    }
                    else if (PartNumber == 2)
                    {
                        repaired1 = true;
                        part1.SetActive(true);
                        repaired2 = true;
                        part2.SetActive(true);
                    }
                    else if (PartNumber == 3)
                    {
                        repaired1 = true;
                        part1.SetActive(true);
                        repaired2 = true;
                        part2.SetActive(true);
                        repaired3 = true;
                        part3.SetActive(true);
                    }
                }
            }

            if (hit.collider.name == "openMachine")
            {
                inter = true;
                interaction.enabled = true;
                interaction_text.text = "PRESS 'E' TO INTERACT";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (repaired3 == true)
                    {
                        machineAnimator.SetBool("machineButtonPress", true);

                    }
                    if (repaired3 = !true)
                    {
                        Debug.Log("find more parts!");
                    }

                }
            }

            if (hit.collider.name == "End")
            {
                inter = true;
                interaction.enabled = true;
                interaction_text.text = "PRESS 'E' TO INTERACT";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("insert cuscene or ending screen here");
                }
            }
            
            if(!inter)
            {
                interaction.enabled = false;
                interaction_text.text = "PRESS 'E' TO INTERACT";
                Debug.DrawRay(transform.position, transform.forward * reachDistance, Color.red);
            }
            inter = false;
        }
        else
        {
            interaction.enabled = false;
            interaction_text.text = "PRESS 'E' TO INTERACT";
        }
    }
}
