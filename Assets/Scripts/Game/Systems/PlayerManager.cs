using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/Systems/PlayerManager")]
public class PlayerManager : ScriptableObject {

    List<Player> players = new List<Player>();

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
}
