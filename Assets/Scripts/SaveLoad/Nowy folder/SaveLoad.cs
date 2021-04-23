using UnityEngine;
using System.Collections;

using System; 
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 


public class SaveLoad : MonoBehaviour
{

    private Transform player;


    void Start()
    {
        player = PlayerInstance.instance.GetComponent<Transform>();
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F5))
        {
            save();
        }


        if (Input.GetKeyDown(KeyCode.F10))
        {
            load();
        }
    }


    public void save()
    {
        Debug.Log("SAVE");


        FileStream file = File.Create(Application.persistentDataPath + "/PlayerInfo.data");

        PlayerData data = new PlayerData();
        data.nameScene = SceneManager.GetActiveScene().name; 
        data.health = player.GetComponent<detectHit>().healtbar.value;
        data.position = new Vector3Serialization(player.GetComponent<Transform>().position);
        data.rotate = new QuaternionSerialization(player.GetComponent<Transform>().rotation);
        
    
        BinaryFormatter bf = new BinaryFormatter();

  
        bf.Serialize(file, data);
        file.Close();
    }


    public void load()
    {
        Debug.Log("LOAD");

        if (File.Exists(Application.persistentDataPath + "/playerInfo.data"))
        {


            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.data", FileMode.Open);


            BinaryFormatter bf = new BinaryFormatter();

            
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();          

      
            PlayerInstance.respown = false; 
            SceneManager.LoadScene(data.nameScene);          
            player.GetComponent<detectHit>().healtbar.SetValueWithoutNotify(data.health);
            player.GetComponent<Transform>().position = data.position.getVector();
            player.GetComponent<Transform>().rotation = data.rotate.getQuaternion();
        }
    }

}


[Serializable]
class PlayerData
{
    public string nameScene;
    public float health;
    public Vector3Serialization position;
    public QuaternionSerialization rotate;
}


[Serializable]
class Vector3Serialization
{

    public float x;
    public float y;
    public float z;

    public Vector3Serialization(Vector3 v)
    {
        Vector(v);
    }

  
    public void Vector(Vector3 v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = v.z;
    }


    public Vector3 getVector()
    {
        Vector3 vec = new Vector3();
        vec.x = this.x;
        vec.y = this.y;
        vec.z = this.z;
        return vec;
    }

}


[Serializable]
class QuaternionSerialization
{

    public float x;
    public float y;
    public float z;
    public float w;


    public QuaternionSerialization(Quaternion v)
    {
        Quaternion(v);
    }

    public void Quaternion(Quaternion v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = v.z;
        this.w = v.w;
    }


    public Quaternion getQuaternion()
    {
        Quaternion vec = new Quaternion();
        vec.x = this.x;
        vec.y = this.y;
        vec.z = this.z;
        vec.w = this.w;
        return vec;
    }

}
