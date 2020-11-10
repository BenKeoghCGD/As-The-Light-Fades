using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorHandler : MonoBehaviour
{

    [Header("Elevator")]
    public GameObject Elevator;
    public Animator Elevator_Animator;
    public doorFunction Elevator_Function;
    public GameObject Player;

    public enum doorFunction
    {
        OPENDOOR, FLOOR1, FLOOR2, HUB
    };

    void Start()
    {
        Elevator_Animator.SetBool("Open", false);
    }

    public void runFunction()
    {
        switch(Elevator_Function)
        {
            case doorFunction.OPENDOOR:
                Elevator_Animator.SetBool("Open", true);
                StartCoroutine(delayDoor(2));
                break;

            case doorFunction.HUB:
                StartCoroutine(Player.GetComponent<levelLoader>().changeLevel(0));
                break;

            case doorFunction.FLOOR1:
                StartCoroutine(Player.GetComponent<levelLoader>().changeLevel(1));
                break;

            case doorFunction.FLOOR2:
                StartCoroutine(Player.GetComponent<levelLoader>().changeLevel(2));
                break;
        }
    }

    private IEnumerator delayDoor(float time)
    {
        yield return new WaitForSeconds(time);
        Elevator_Animator.SetBool("Open", false);
    }

    public void openDoor()
    {
        Elevator_Animator.SetBool("Open", true);
        StartCoroutine(delayDoor(2));
    }
}
