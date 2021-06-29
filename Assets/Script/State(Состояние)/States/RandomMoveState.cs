using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RandomMoveState : State
{
    public float maxDistance = 5f;

    Vector3 randomPosition;

    public override void Init()
    {
        var randomed = new Vector3(Random.Range(-maxDistance, maxDistance), 0f, Random.Range(-maxDistance, maxDistance));
        randomPosition = character.transform.position + randomed;
    }
    public override void Run()
    {
        var distnace = (randomPosition - character.transform.position).magnitude;

        if (distnace > 10.5f)
            character.MoveTo(randomPosition);
        else
            isFineshed = true;
    }
}
