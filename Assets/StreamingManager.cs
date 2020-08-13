using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StreamingManager : MonoBehaviour
{
    public Dictionary<string, Texture2D> localisedImages = new Dictionary<string, Texture2D>();

    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator CheckFiles()
    {
        while (isActiveAndEnabled)
        {
            yield return new WaitForSeconds(1f);

        }
        yield break;
    }

    public void LoadLocalisedImages()
    {
        string imagesDirectory = "";

        imagesDirectory = Application.dataPath + "/StreamingAssets/Resources/";


        DirectoryInfo dir = new DirectoryInfo(imagesDirectory);
        FileInfo[] info = dir.GetFiles("*.png");
        foreach (FileInfo fi in info)
        {
            string fileExtension = fi.Extension;
            if (fileExtension != ".meta")
            {
                string imageName = Path.GetFileNameWithoutExtension(fi.Name);
                localisedImages[imageName] = Resources.Load(imageName) as Texture2D;
            }
        }
    }
}
