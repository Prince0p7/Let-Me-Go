public static class ClearData
{
    public static void clearData()
    {
        System.IO.File.Delete(UnityEngine.Application.persistentDataPath + "/player.save");
        UnityEngine.Debug.Log("Data Deleted");
    }
}