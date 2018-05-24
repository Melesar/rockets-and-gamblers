using RocketsAndGamblers;
using UnityEngine;

public class ReplayMovment : MonoBehaviour
{
    private float curentTime;
    private ShipPhysics physics;
    private ReplayDownload replay;

    private float StartTime;

    // Use this for initialization
    private void Awake()
    {
        physics = GetComponent<ShipPhysics>();
    }

    private void Start()
    {
        StartTime = Time.time;
    }

    // Update is called once per frame
    private void Update() { }

    private void Burst(Vector2 coords)
    {
        var direction = (coords - physics.Position).normalized;
        physics.AddImpulseForce(direction);
    }

    public async void SetShipOnPoint(Replay replay)
    {
        curentTime = Time.time - StartTime;

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