using System.IO;
using UnityEngine;
[System.Serializable] // ทำให้สามารถแปลงเป็น JSON ได้
public class ScoreData
{
    public int highScore; // ตัวแปรเก็บคะแนนสูงสุด
}
public class ScoreManager : MonoBehaviour
{
    private string filePath;
    public ScoreData scoreData = new ScoreData(); // สร้างตัวแปรเก็บข้อมูลคะแนน
    void Start()
    {
        filePath = Application.persistentDataPath + "/score.json"; // ตำแหน่งไฟล์
        LoadScore(); // โหลดคะแนนที่เคยบันทึกไว้
    }
    public void SaveScore(int newScore)
    {
        if (newScore > scoreData.highScore) // บันทึกถ้าคะแนนใหม่สูงกว่าเดิม
        {
            scoreData.highScore = newScore;
            string json = JsonUtility.ToJson(scoreData, true); // แปลงเป็น JSON
            File.WriteAllText(filePath, json); // เขียนลงไฟล์
        }
    }
    public void LoadScore()
    {
        if (File.Exists(filePath)) // ถ้ามีไฟล์อยู่แล้ว
        {
            string json = File.ReadAllText(filePath); // อ่านไฟล์
            scoreData = JsonUtility.FromJson<ScoreData>(json); // แปลงกลับเป็น Object
        }
    }
}
