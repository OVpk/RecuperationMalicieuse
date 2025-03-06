using UnityEngine;

public interface IDataPersistence
{
   abstract void LoadData(GameData data);

   void SaveData(ref GameData data);
}
