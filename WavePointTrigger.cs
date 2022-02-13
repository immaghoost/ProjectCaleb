using UnityEngine;

public class WavePointTrigger : MonoBehaviour
{
    public NpcMovementManager npcMovementManager;
    private void OnTriggerEnter2D(Collider2D col)
    {
        npcMovementManager.isResting = true;
    }
}
