using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeOrb : MonoBehaviour {

    public float proximity;
    public float collectionTime;
    public PlayerManager playerManager;
    public PlayerData playerData;

    bool collected;

    void Update() {
        if (!collected) {
            var closestPlayerInfo = playerManager.GetNearestPlayerInfo(transform.position);
            if (closestPlayerInfo != null && closestPlayerInfo.Item2 < proximity * proximity)
                StartCoroutine(MoveTowardsPlayer(closestPlayerInfo.Item1));
        }
    }

    IEnumerator MoveTowardsPlayer(Player player) {
        collected = true;
        Vector3 startingPos = transform.position;
        float timer = 0;
        while (timer < collectionTime) {
            yield return new WaitForFixedUpdate();
            if (!player) yield break;
            timer += Time.fixedDeltaTime;
            transform.position = Vector3.Lerp(startingPos, player.position, timer / collectionTime);
        }
        playerData.ReceiveHealth(1);
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, proximity);
    }
}
