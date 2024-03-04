using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public enum GizmoType { Never, SelectedOnly, Always }

    public Boid prefab1;
    public Boid prefab2;
    public Boid prefab3;
    public float spawnRadius = 1;
    public int spawnCount = 1;
    public GizmoType showSpawnRegion;

    void Awake () {
        for (int i = 0; i < spawnCount; i++) {
            Vector3 pos = transform.position + Random.insideUnitSphere * spawnRadius;
            Boid boid1 = Instantiate (prefab1);
            Boid boid2 = Instantiate(prefab2);
            Boid boid3 = Instantiate(prefab3);
            boid1.transform.position = pos;
            boid1.transform.forward = Random.insideUnitSphere;


            boid2.transform.position = pos;
            boid2.transform.forward = Random.insideUnitSphere;


            boid3.transform.position = pos;
            boid3.transform.forward = Random.insideUnitSphere;

        }
    }

    private void OnDrawGizmos () {
        if (showSpawnRegion == GizmoType.Always) {
            DrawGizmos ();
        }
    }

    void OnDrawGizmosSelected () {
        if (showSpawnRegion == GizmoType.SelectedOnly) {
            DrawGizmos ();
        }
    }

    void DrawGizmos () {


        Gizmos.DrawSphere (transform.position, spawnRadius);
    }

}