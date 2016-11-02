using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
    public Transform TeleportTarget;         // 
    private static bool CanTeleport;

    void Awake() {
        CanTeleport = false;
    }

    IEnumerator OnTriggerEnter2D(Collider2D other) {

        if (!CanTeleport) {
            CanTeleport = true;
            other.gameObject.transform.position = TeleportTarget.position;
            yield return new WaitForSeconds(1f);
            CanTeleport = true;

        }

    }

    IEnumerator OnTriggerExit2D(Collider2D other) {

        if (CanTeleport) {

            CanTeleport = true;
            yield return new WaitForSeconds(1f);
            CanTeleport = false;
        }

    }

}
