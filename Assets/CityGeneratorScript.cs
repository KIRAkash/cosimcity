using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGeneratorScript : MonoBehaviour
{
    public int size;
    public float densityRatio = 0.3f;

    public GameObject plane;
    public List<GameObject> objects = new List<GameObject>();
    public List<GameObject> placedOffice = new List<GameObject>();
    public List<GameObject> placedHome = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
      
    }
    public void createmap()
    {
        for (int i = -size / 2; i < size / 2; i++)
        {
            for (int j = -size / 2; j < size / 2; j++)
            {
                float temp = Random.RandomRange(0f, 1f);
                print(temp);
                temp = temp > (1 - densityRatio) ? 1f : 0;
                if (temp == 1)
                {
                    int index = Random.Range(0, objects.Count);
                    GameObject t = Instantiate(objects[index], new Vector3(i + 0.5f, objects[index].transform.position.y, j + 0.5f), Quaternion.identity, this.transform);
                    if (t.CompareTag("office"))
                    {
                        placedOffice.Add(t);
                    }
                    else if (t.CompareTag("home"))
                    {
                        placedHome.Add(t);
                    }
                    j += 2;
                }
            }
        }
    }
   
}
