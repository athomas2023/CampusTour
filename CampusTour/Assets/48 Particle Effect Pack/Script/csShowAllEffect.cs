using UnityEngine;
using System.Collections;
using TMPro; // Import the TextMesh Pro namespace

public class csShowAllEffect : MonoBehaviour
{
    public string[] EffectNames;
    public string[] Effect2Names;
    public Transform[] Effect;
    public TextMeshPro Text1; // Use TextMeshPro instead of TextMeshProUGUI
    int i = 0;
    int a = 0;

    void Start()
    {
        Instantiate(Effect[i], new Vector3(0, 5, 0), Quaternion.identity);
    }

    void Update()
    {
        Text1.text = (i + 1) + ":" + EffectNames[i]; // Fix the parentheses for correct order of operations

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (i <= 0)
                i = 99;
            else
                i--;

            for (a = 0; a < Effect2Names.Length; a++)
            {
                if (EffectNames[i] == Effect2Names[a])
                {
                    Instantiate(Effect[i], new Vector3(0, 0.01f, 0), Quaternion.identity);
                    break;
                }
            }
            if (a == Effect2Names.Length) // Remove unnecessary ++
                Instantiate(Effect[i], new Vector3(0, 5, 0), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (i < 99)
                i++;
            else
                i = 0;

            for (a = 0; a < Effect2Names.Length; a++)
            {
                if (EffectNames[i] == Effect2Names[a])
                {
                    Instantiate(Effect[i], new Vector3(0, 0.01f, 0), Quaternion.identity);
                    break;
                }
            }
            if (a == Effect2Names.Length) // Remove unnecessary ++
                Instantiate(Effect[i], new Vector3(0, 5, 0), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            for (a = 0; a < Effect2Names.Length; a++)
            {
                if (EffectNames[i] == Effect2Names[a])
                {
                    Instantiate(Effect[i], new Vector3(0, 0.01f, 0), Quaternion.identity);
                    break;
                }
            }
            if (a == Effect2Names.Length) // Remove unnecessary ++
                Instantiate(Effect[i], new Vector3(0, 5, 0), Quaternion.identity);
        }
    }
}