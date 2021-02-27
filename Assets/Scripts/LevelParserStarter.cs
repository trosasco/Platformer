using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParserStarter : MonoBehaviour
{
    public string filename;

    public GameObject Rock;

    public GameObject Brick;

    public GameObject QuestionBox;

    public GameObject Stone;

    public GameObject Water;

    public Transform parentTransform;
    // Start is called before the first frame update
    void Start()
    {
        RefreshParse();
    }


    private void FileParser()
    {
        string fileToParse = string.Format("{0}{1}{2}.txt", Application.dataPath, "/Resources/", filename);

        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            int row = 0;
            int column = 0;
            
            while ((line = sr.ReadLine()) != null)
            {
                char[] letters = line.ToCharArray();
                foreach (var letter in letters)
                {
                    row++;
                    Vector3 position = new Vector3(row, column * -1, 0);
                    //Call SpawnPrefab
                    SpawnPrefab(letter, position);
                }

                column++;
                row = 0;

            }

            sr.Close();
        }
    }

    private void SpawnPrefab(char spot, Vector3 positionToSpawn)
    {
        GameObject ToSpawn;

        switch (spot)
        {
            case 'b':
                Debug.Log("Spawn Brick");
                ToSpawn = Brick;
                break;
            case '?': Debug.Log("Spawn QuestionBox");
                ToSpawn = QuestionBox;
                break;
            case 'x': Debug.Log("Spawn Rock");
                ToSpawn = Rock;
                break;
            case 's': Debug.Log("Spawn Stone");
                ToSpawn = Stone;
                break;
            case 'w': Debug.Log("Spawn Water");
                ToSpawn = Water;
                break;
            //default: Debug.Log("Default Entered"); break;
            default: return;
                //ToSpawn = //Brick;       break;
        }

        ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
        ToSpawn.transform.localPosition = positionToSpawn;
    }

    public void RefreshParse()
    {
        GameObject newParent = new GameObject();
        newParent.name = "Environment";
        newParent.transform.position = parentTransform.position;
        newParent.transform.parent = this.transform;
        
        if (parentTransform) Destroy(parentTransform.gameObject);

        parentTransform = newParent.transform;
        FileParser();
    }
}
