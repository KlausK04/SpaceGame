using UnityEngine;



// Used mostly for testing to provide stuff to fly around and into.
public class RandomAreaSpawnerAstroids : MonoBehaviour
{
    public Transform Asteroid1;
    public Transform Asteroid2;
    public Transform Asteroid3;
    public Vector3 shapeModifiers = Vector3.one;
    public int asteroidCount = 250;
    public float range = 1000.0f;
    public bool randomRotation = true;
    public Vector2 scaleRange = new Vector2(1.0f, 3.0f);
    private Transform[] astroids = new Transform[3];

    public float velocity = 0.0f;
    public float angularVelocity = 0.0f;
    public bool scaleMass = true;

    void Start()
    {
        astroids[0] = Asteroid1;
        astroids[1] = Asteroid2;
        astroids[2] = Asteroid3;
        if (astroids != null)
        {
            for (int i = 0; i < asteroidCount; i++)
                CreateAsteroid();
        }
    }

    private void CreateAsteroid()
    {
        Vector3 spawnPos = Vector3.zero;
        spawnPos.x = Random.Range(-range, range) * shapeModifiers.x;
        spawnPos.y = Random.Range(-range, range) * shapeModifiers.y;
        spawnPos.z = Random.Range(-range, range) * shapeModifiers.z;
        spawnPos += transform.position;
        Quaternion spawnRot = (randomRotation) ? Random.rotation : Quaternion.identity;
        Transform t = Instantiate(astroids[Random.Range(0,3)], spawnPos, spawnRot) as Transform;
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

    public void CreateNewAstroid()
    {
        CreateAsteroid();
    }
}
