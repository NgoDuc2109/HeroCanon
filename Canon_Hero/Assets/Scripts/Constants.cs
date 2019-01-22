using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    public static class Tag
    {
        public const string PLAYER = "Player";
        public const string PLAYERBULLET = "PlayerBullet";
        public const string ENEMYBULLET = "EnemyBullet";
        public const string ENEMY_HEAD = "Enemy_head";
        public const string ENEMY_BODY = "Enemy_body";
        public const string CHECKPOINT = "CheckPoint";
        public const string ENEMY = "Enemy";
        public const string PLATFORM = "Platform";
        public const string GUN = "Gun";
        public const string  SPAWNPOINTBULLET= "SpawnPointBullet";
        public const string GAMECONTROLLER = "GameController";
    }

    public static class Scene
    {
        public const string MAINSCENE = "MainScene";
    }

    public static class ScoreInfo
    {
        public const string TOTALCOINS = "TotalCoins";
        public const string BESTSCORE = "BestScore";
    }

    public static class CharacterInfo
    {
        public const string CURRENTPLAYER = "CurrentPlayer";
        public static string[] LISTPLAYER = new string[4] { "Player1", "Player2", "Player3", "Player4"};
    }

    public static class AudioInfo
    {
        public const string ISBACKGROUND = "IsBackground";
        public const string ISEFFECT = "IsEffect";
    }

    public static class Animation
    {
        public const string ISATTACK = "isAttack";
        public const string PLAYERMOVE = "PlayerMove";
        public const string PLAYERATTACK = "PlayerAttack";
        public const string ISHIDE = "isHide";
        public const string ISSHOOTFLYINGGROUND = "isShootFlyingGround";
        public const string PAUSEFADE = "PauseFade";
    }
}
