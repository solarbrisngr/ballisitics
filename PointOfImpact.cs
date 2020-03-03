using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfImpact
{
    Vector3 POI = new Vector3();
    FiringSolution balistics = new FiringSolution();
    float muzzleV = 10.0f;
    GameObject player;
    GameObject target;

    private void Start()
    {
        player = GameObject.Find("Player");
        target = GameObject.Find("Target");
    }
    
    public void FindPosition()
    {
        Nullable<Vector3> aimVector = balistics.Calculate(player.transform.position, target.transform.position, muzzleV, Physics.gravity);
        Nullable<float> ttt = balistics.GetTimeToTarget(player.transform.position, target.transform.position, muzzleV, Physics.gravity);
        POI.x = player.transform.position.x + (aimVector.Value.x * muzzleV * ttt.Value);
        POI.y = 0;
        POI.z = player.transform.position.z + (aimVector.Value.z * muzzleV * ttt.Value);
        Debug.Log(POI);
        target.transform.position = POI;
        Debug.Log(target.transform.position);
    }
}
