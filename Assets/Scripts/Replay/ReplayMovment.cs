using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework.References;
using RocketsAndGamblers.Player;
using System.Threading.Tasks;
using RocketsAndGamblers;

public class ReplayMovment : MonoBehaviour {
    private ShipPhysics physics;
    private ReplayDownload replay;
    private float StartTime;
    // Use this for initialization
    private void Awake()
    {

        physics = GetComponent<ShipPhysics>();
    }

    void Start() {
        StartTime = Time.time;
    }

    // Update is called once per frame
    void Update() {

    }

    private void Burst(Vector2 coords)
    {
        var direction = (coords - physics.Position).normalized;
        physics.AddImpulseForce(direction);
    }

    private float curentTime;

    public async void SetShipOnPoint(Replay replay)
    {
        
        curentTime = Time.time - StartTime;

        Debug.Log("Test pobranej powtorki");
        int count = 0;
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

