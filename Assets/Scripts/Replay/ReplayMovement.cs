using RocketsAndGamblers;
using System.Threading.Tasks;
using RocketsAndGamblers.Replay;
using UnityEngine;

public class ReplayMovement : MonoBehaviour
{
    private ShipMovement movement;

    private void Awake()
    {
        var shipControl = GetComponent<ShipControls>();
        Destroy(shipControl);

        movement = GetComponent<ShipMovement>();
    }

    private void Burst(Vector2 coords)
    {
        movement.Burst(coords);
    }

    public async Task Lauch(Replay replay)
    {
        var curentTime = 0f;

        var count = 0;
        while (count < replay.inputs.Count) {
            if (curentTime >= replay.inputs[count].t) {
                Burst(replay.inputs[count].cords);
                count++;
            }

            curentTime += Time.deltaTime;
            await new WaitForEndOfFrame();
        }
    }
}