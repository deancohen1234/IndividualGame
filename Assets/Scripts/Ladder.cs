using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    public Transform m_Player;
    public Transform m_TopPosition;
    public Transform m_BottomPosition;


    public void InteractWithLadder()
    {
        bool playerBelowLadder = IsPlayerAtBottom(m_Player.position);

        if (playerBelowLadder)
        {
            m_Player.position = m_TopPosition.position;
        }

        else
        {
            m_Player.position = m_BottomPosition.position;
        }
    }

    //returns true if player is at bottom of ladder
    public bool IsPlayerAtBottom(Vector3 playerLocation)
    {
        bool check = false;

        //transform player location from world to local
        Vector3 localPlayerLocation = transform.parent.InverseTransformPoint(playerLocation);

        Vector3 difference = transform.localPosition - localPlayerLocation;

        //player is above ladder
        //NOTE: using z feels wrong, but it does work
        if (difference.z <= 0)
        {
            check = false;
        }

        //player is below ladder
        else
        {
            check = true;
        }

        return check;
    }
}
