using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class InfoManager 
{
    public static readonly InfoManager Instance = new InfoManager();

    //저장 경로

    public string playerPath = string.Format("{0}/playerInfo.json", Application.persistentDataPath);
    public string heightPath = string.Format("{0}/heightInfo.json", Application.persistentDataPath);

    public PlayerInfo PlayerInfo { get; set; }
    public HeightInfo HeightInfo { get; set; }

    private InfoManager() { }

    //뉴비 판별
    public bool IsNewbie()
    {
        bool existFile = File.Exists(this.playerPath);
        Debug.LogFormat("exist: {0}", existFile);
        return !existFile;
    }

    //초기화
    //플레이어 인포
    public void PlayerInfoInit()
    {
        Debug.Log("<color=white>PlyerInfo Init</color>");
        this.PlayerInfo = new PlayerInfo();
        this.PlayerInfo.nowCharacterId = 0;
        this.PlayerInfo.nowClothesColorIndex = 0;
        this.SavePlayerInfo();
    }
    //키 인포
    public void HeightInfoInit()
    {
        Debug.Log("<color=white>heightInfo Init</color>");
        this.HeightInfo = new HeightInfo();
        this.HeightInfo.height = 0;
        this.SaveHeightInfo();
    }

    //인포 로드
    //플레이어
    public void LoadPlayerInfo()
    {
        //역직렬화
        var json = File.ReadAllText(this.playerPath);
        this.PlayerInfo = JsonConvert.DeserializeObject<PlayerInfo>(json);
        Debug.Log("<color=red>[load success] playerInfo.json</color>");
    }
    //키
    public void LoadHeightInfo()
    {
        //역직렬화
        var json = File.ReadAllText(this.heightPath);
        this.HeightInfo = JsonConvert.DeserializeObject<HeightInfo>(json);
        Debug.Log("<color=red>[load success] heightInfo.json</color>");
    }

    //인포 저장
    //플레이어
    public void SavePlayerInfo()
    {
        //직렬화
        var json = JsonConvert.SerializeObject(this.PlayerInfo);
        File.WriteAllText(playerPath, json);
        Debug.Log("<color=red>[save success] playerInfo.json</color>");
    }
    //키
    public void SaveHeightInfo()
    {
        //직렬화
        var json = JsonConvert.SerializeObject(HeightInfo);
        File.WriteAllText(heightPath, json);
        Debug.Log("<color=red>[save success] heightInfo.json</color>");
    }

    //인포 추가/변동 필요 시


    //인포 가져오기(배열로 된 경우) 필요 시
    public void EditPlayerInfo(int characterId, int colorIndex)
    {
        this.PlayerInfo.nowCharacterId = characterId;
        this.PlayerInfo.nowClothesColorIndex= colorIndex;
        SavePlayerInfo();
    }
}
