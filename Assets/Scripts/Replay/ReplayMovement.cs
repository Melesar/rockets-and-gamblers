using RocketsAndGamblers;
using System.Threading.Tasks;
using RocketsAndGamblers.Replay;
using UnityEngine;

public class ReplayMovement : MonoBehaviour
{
    private ShipPhysics physics;
    private ShipMovement movement;
    private ReplayDownload replay;

    private float startTime;

    private void Awake()
    {
        var shipControl = GetComponent<ShipControls>();
        Destroy(shipControl);

        movement = GetComponent<ShipMovement>();
    }

    private void Start()
    {
        startTime = Time.time;
    }

    private void Burst(Vector2 coords)
    {
        movement.Burst(coords);
    }

    public async Task SetShipOnPoint(Replay replay)
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