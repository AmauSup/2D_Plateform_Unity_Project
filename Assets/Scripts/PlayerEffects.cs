using UnityEngine;
using System.Collections;

public class PlayerEffects : MonoBehaviour
{
    public void AddSpeed(int speedGiven, float speedDuration)
    { 
        if((MovePlayer.instance.moveSpeed += speedGiven) > 450)
        {
            MovePlayer.instance.moveSpeed = 450;
        }
        else
        {
            MovePlayer.instance.moveSpeed += speedGiven;
        }
        StartCoroutine(RemoveSpeed(speedGiven, speedDuration));
    }

    private IEnumerator RemoveSpeed(int speedGiven, float speedDuration)
    {
        yield return new WaitForSeconds(speedDuration);
        MovePlayer.instance.moveSpeed -= speedGiven;
    }

    public void AddJump(int jumpGiven, float jumpDuration)
    {
        MovePlayer.instance.jumpForce += jumpGiven;
        StartCoroutine(RemoveJump(jumpGiven, jumpDuration));
    }

    private IEnumerator RemoveJump(int jumpGiven, float jumpDuration)
    {
        yield return new WaitForSeconds(jumpDuration);
        MovePlayer.instance.jumpForce -= jumpGiven;
    }
}