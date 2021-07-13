using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    [SerializeField] private TextAsset JSONFile;

    public Objects ReadJSON()
    {
        Objects jsonObject = JsonUtility.FromJson<Objects>(JSONFile.text);

        /*print(jsonObject.ObjectPlaced[0].Index);
        print(jsonObject.ObjectPlaced[0].Name);
        foreach(int n in jsonObject.ObjectPlaced[0].Neighbours.TopNeighbours) {
            print(n);
        }
        foreach(int n in jsonObject.ObjectPlaced[0].Neighbours.RightNeighbours) {
            print(n);
        }
        print(jsonObject.ObjectPlaced[0].Replacements[1].Index);
        foreach(int n in jsonObject.ObjectPlaced[0].Replacements[1].Neighbours.RightNeighbours) {
            print(n);
        }*/

        return jsonObject;
    }
}