using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParser : MonoBehaviour
{
    public string filename;
    public GameObject rockPrefab;
    public GameObject brickPrefab;
    public GameObject questionPrefab;
    public GameObject stonePrefab;
    public GameObject lavaPrefab;
    public GameObject goalPrefab;
    public Transform levelRoot;

    // --------------------------------------------------------------------------
    void Start()
    {
        LoadLevel();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    // --------------------------------------------------------------------------
    private void LoadLevel()
    {
        string fileToParse = $"{Application.dataPath}{"/Resources/"}{filename}.txt";
        Debug.Log($"Loading level file: {fileToParse}");
        
        Stack<string> levelRows = new Stack<string>();

        // Get each line of text representing blocks in our level
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                levelRows.Push(line);
            }

            sr.Close();
        }

        // Go through the rows from bottom to top
        int row = 0;
        while (levelRows.Count > 0)
        {
            string currentLine = levelRows.Pop();

            int column = 0;
            char[] letters = currentLine.ToCharArray();
            foreach (var letter in letters)
            {
                // Instantiate a new GameObject that matches the type specified by letter
                GameObject newObject = null;

                switch(letter) {
                    case 'b': newObject = Instantiate(brickPrefab); break;
                    case '?': newObject = Instantiate(questionPrefab); break;
                    case 'x': newObject = Instantiate(rockPrefab); break;
                    case 's': newObject = Instantiate(stonePrefab); break;
                    case 'l': newObject = Instantiate(lavaPrefab); break;
                    case 'g': newObject = Instantiate(goalPrefab); break;
                    default: break;
                }

                // Position the new GameObject at the appropriate location by using row and column
                Vector3 pos = new Vector3(column + 0.5f, row + 0.5f, -0.5f);
                if(newObject != null) {
                    newObject.transform.position = pos;

                    // Parent the new GameObject under levelRoot
                    newObject.transform.SetParent(levelRoot);
                }

                column++;
            }
            row++;
        }
    }

    // --------------------------------------------------------------------------
    private void ReloadLevel()
    {
        foreach (Transform child in levelRoot)
        {
           Destroy(child.gameObject);
        }
        LoadLevel();
    }
}
