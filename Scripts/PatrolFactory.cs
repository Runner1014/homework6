/*using UnityEngine;

public class PatrolFactory : System.Object
{
    private static PatrolFactory instance;
    private GameObject PatrolItem;

    private Vector3[] PatrolPosSet = new Vector3[] { new Vector3(-6, 0, 16), new Vector3(-1, 0, 19),
        new Vector3(6, 0, 16), new Vector3(-5, 0, 7), new Vector3(0, 0, 7), new Vector3(6, 0, 7)};

    public static PatrolFactory getInstance()
    {
        if (instance == null)
            instance = new PatrolFactory();
        return instance;
    }

    public void initItem(GameObject _PatrolItem)
    {
        PatrolItem = _PatrolItem;
    }

    public GameObject getPatrol()
    {
        GameObject newPatrol = Camera.Instantiate(PatrolItem);
        return newPatrol;
    }

    public Vector3[] getPosSet()
    {
        return PatrolPosSet;
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolFactory : MonoBehaviour
{
    public GameObject patrol;
    private int min_x = 6;
    private int min_z = 10;
    private int max_x = 86;
    private int max_z = 86;
 
    private int cellLengthX = 30;
    private int cellLengthZ = 29;

    private int col = 3;
    private int row = 3;

    private int patrolNumEveryCell = 2;


    public List<GameObject> getPatrols()
    {
        
        List<GameObject> patrols = new List<GameObject>();
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {

                int rangeMinX = min_x + cellLengthX * i;
                int rangeMinZ = min_z + cellLengthZ * j;
                int rangeMaxX = min_x + cellLengthX * (i + 1);
                int rangeMaxZ = min_z + cellLengthZ * (j + 1);
                for (int k = 0; k < patrolNumEveryCell; k++)
                {

                    System.Random ran = new System.Random(GetRandomSeed());
                    float x = ran.Next(rangeMinX, rangeMaxX);
                    while (x > max_x)
                    {
                        x = ran.Next(rangeMinX, rangeMaxX);
                    }
                    float z = ran.Next(rangeMinZ, rangeMaxZ);
                    while (z > max_z)
                    {
                        z = ran.Next(rangeMinZ, rangeMaxZ);
                    }
                    GameObject newpatrol =  GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Perfabs/Monster"));
                    newpatrol.transform.position = new Vector3(x, 0, z);
                    
                    patrols.Add(newpatrol);
                }
            }
        }
        //patrol.transform.position = new Vector3(4, 1, 0);
        //patrols.Add(patrol);
        return patrols;
    }

    private int GetRandomSeed()
    {
        byte[] bytes = new byte[4];
        System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
        rng.GetBytes(bytes);
        return System.BitConverter.ToInt32(bytes, 0);
    }
}