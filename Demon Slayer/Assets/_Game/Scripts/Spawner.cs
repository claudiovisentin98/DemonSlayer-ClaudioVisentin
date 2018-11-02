using UnityEngine;

public class Spawner : MonoBehaviour {
    public float spawntime;
    public float time;
    public Transform [] spawnpoints;
    public GameObject zombie;


	void Update () {
        time += 1*Time.deltaTime;
		if (time > spawntime)
        {
            for (int i = 0; i < spawnpoints.Length; i++)
            {
                Quaternion rotation = spawnpoints [i].transform.rotation;
                Instantiate(zombie, spawnpoints[i].transform.position, rotation);
            }
            time = 0;
        }
	}
}
