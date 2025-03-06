using UnityEngine;
using System;
using System.IO;
using Unity.VisualScripting;

public class FileDataHandler
{
    private string dirPath = "";
    private string fileName = "";

    public GameData Load()
    {
        return null;
    }

    public void Save(GameData data)
    {
        string fullPath = Path.Combine(dirPath, fileName);
        try
        {
            Directory.CreateDirectory(Path.Combine(fullPath));

            string dataToSave = JsonUtility.ToJson(data, true);

            using (FileStream stream = new FileStream(fullPath,FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToSave);
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log("Error when trying to save data file with the following error : " + e);
        }
    }

    public FileDataHandler(string dirpath, string filename)
    {
        this.dirPath = dirpath;
        this.fileName = filename;
    }

}