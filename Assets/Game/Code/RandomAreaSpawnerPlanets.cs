using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAreaSpawnerPlanets : MonoBehaviour
{
    public Transform Planet1;
    public Transform Planet2;
    public Transform Planet3;
    public Transform Planet4;
    public Transform Planet5;
    public Transform Planet6;
    public Transform Planet7;
    public Transform Planet8;
    public Transform Planet9;
    public Transform Planet10;
    public Transform Planet11;
    public Transform Planet12;
    public Transform Planet13;
    public Transform Planet14;
    public Transform Planet15;
    public Transform Planet16;
    public Transform Planet17;
    public Transform Planet18;
    public Transform Planet19;
    public Transform Planet20;

    public Transform Sun;

    public Vector3 shapeModifiers = Vector3.one;
    public int PlanetCount = 50;
    public float range = 1000.0f;
    public bool randomRotation = true;
    public Vector2 scaleRange = new Vector2(1.0f, 3.0f);
    private Transform[] planets = new Transform[20];

    public float velocity = 0.0f;
    public float angularVelocity = 0.0f;
    public bool scaleMass = true;

    void Start()
    {
        planets[0] = Planet1;
        planets[1] = Planet2;
        planets[2] = Planet3;
        planets[3] = Planet4;
        planets[4] = Planet5;
        planets[5] = Planet6;
        planets[6] = Planet7;
        planets[7] = Planet8;
        planets[8] = Planet9;
        planets[9] = Planet10;
        planets[10] = Planet11;
        planets[11] = Planet12;
        planets[12] = Planet13;
        planets[13] = Planet14;
        planets[14] = Planet15;
        planets[15] = Planet16;
        planets[16] = Planet17;
        planets[17] = Planet18;
        planets[18] = Planet19;
        planets[19] = Planet20;
        if (planets != null)
        {
            for (int i = 0; i < PlanetCount; i++)
                CreatePlanet();
        }
        GenerateSun();
    }

    private void CreatePlanet()
    {
        Vector3 spawnPos = Vector3.zero;
        spawnPos.x = Random.Range(-range, range) * shapeModifiers.x;
        spawnPos.y = Random.Range(-range, range) * shapeModifiers.y;
        spawnPos.z = Random.Range(-range, range) * shapeModifiers.z;
        spawnPos += transform.position;
        Quaternion spawnRot = (randomRotation) ? Random.rotation : Quaternion.identity;
        Transform t = Instantiate(planets[Random.Range(0, 20)], spawnPos, spawnRot) as Transform;
        t.SetParent(transform);

        float scale = Random.Range(scaleRange.x, scaleRange.y);
        t.localScale = Vector3.one * scale;

        Rigidbody r = t.GetComponent<Rigidbody>();
        if (r)
        {
            r.mass *= scale * scale * scale;

            r.AddRelativeForce(Random.insideUnitSphere * velocity, ForceMode.VelocityChange);
            r.AddRelativeTorque(Random.insideUnitSphere * angularVelocity * Mathf.Deg2Rad, ForceMode.VelocityChange);
        }
    }

    public void GenerateSun()
    {
        Vector3 spawnPos = Vector3.zero;

        spawnPos.x = Random.Range(-range / 2, range / 2) * shapeModifiers.x;
        spawnPos.y = Random.Range(-range / 2, range / 2) * shapeModifiers.y;
        spawnPos.z = Random.Range(-range / 2, range / 2) * shapeModifiers.z;
        spawnPos += transform.position;

        Quaternion spawnRot = (randomRotation) ? Random.rotation : Quaternion.identity;
        Transform s = Instantiate(Sun, spawnPos, spawnRot) as Transform;
        s.SetParent(transform);

        float scale = Random.Range(scaleRange.x, scaleRange.y);
        s.localScale = Vector3.one * scale;

        Rigidbody sun = s.GetComponent<Rigidbody>();
        if (sun)
        {
            sun.mass *= scale * scale * scale;

            sun.AddRelativeForce(Random.insideUnitSphere * velocity, ForceMode.VelocityChange);
            sun.AddRelativeTorque(Random.insideUnitSphere * angularVelocity * Mathf.Deg2Rad, ForceMode.VelocityChange);
        }
    }

    public void CreateNewPlanet()
    {
        CreatePlanet();
    }
}
