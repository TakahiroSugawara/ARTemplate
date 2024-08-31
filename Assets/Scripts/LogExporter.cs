using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine;
using System.IO;

public class LogExporter : MonoBehaviour
{
    private string logFilePath;
    private float deltaTime = 0.0f;

    void Start()
    {
        // Persistent Pathにログファイルのパスを設定
        logFilePath = Path.Combine(Application.persistentDataPath, "fps_log.txt");
        Debug.Log(logFilePath);

        // ログファイルの初期化
        File.WriteAllText(logFilePath, "FPS Log\n\n");

    }

    void Update()
    {
        // FPSの計算
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;

        // ログにFPSを追加
        File.AppendAllText(logFilePath, "FPS: " + fps.ToString("F2") + "\n");

        Debug.Log(IsLogFileExists());
    }

    // ログファイルが存在するか確認するメソッド
    public bool IsLogFileExists()
    {
        return File.Exists(logFilePath);
    }

}