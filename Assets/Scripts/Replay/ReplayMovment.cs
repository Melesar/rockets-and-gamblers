using RocketsAndGamblers;
using System.Threading.Tasks;
using UnityEngine;

public class ReplayMovement : MonoBehaviour
{
    private float curentTime;
    private ShipPhysics physics;
    private ShipMovement movement;
    private ReplayDownload replay;

    private float StartTime;

    // Use this for initialization
    private void Awake()
    {
        var shipControl = GetComponent<ShipControls>();
        var initialLaunch = GetComponent<InitialLaunch>();
        shipControl.enabled = false;
        initialLaunch.enabled = false;

        movement = GetComponent<ShipMovement>();
        //physics = GetComponent<ShipPhysics>();
        //physics.Launch();
    }

    private void Start()
    {
        StartTime = Time.time;
    }


    private void Burst(Vector2 coords)
    {
        movement.Launch();
        movement.Burst(coords);
    }

    public async Task SetShipOnPoint(Replay replay)
    {
        curentTime = Time.time - StartTime;

        var count = 0;
        while (count < replay.inputs.Count)
        {
            if (curentTime >= replay.inputs[count].t)
            {
                Burst(replay.inputs[count].cords);
                count++;
            }

            curentTime += Time.deltaTime;
            await new WaitForEndOfFrame();
        }
    }
}