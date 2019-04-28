using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/Systems/PlayerManager")]
public class PlayerManager : ScriptableObject {

    [System.NonSerialized] List<Player> players = new List<Player>();

    public void AddPlayer(Player player) {
        if (!players.Contains(player))
            players.Add(player);
    }

    public void RemovePlayer(Player player) {
        if (players.Contains(player))
            players.Remove(player);
    }

    public bool HasPlayer() {
        return players.Count > 0;
    }

    public Player GetCurrentPlayer() {
        if (players.Count == 0)
            return null;
        return players[0];
    }

    public Tuple<Player, float> GetNearestPlayerInfo(Vector3 position) {
        if (!HasPlayer()) return null;
        float distance = Mathf.Infinity;
        int index = 0;
        for (int i = 0; i < players.Count; ++i) {
            float dist = (players[i].position - position).sqrMagnitude;
            if (dist < distance) {
                distance = dist;
                index = i;
            }
        }
        return new Tuple<Player, float>(players[index], distance);
    }
}
