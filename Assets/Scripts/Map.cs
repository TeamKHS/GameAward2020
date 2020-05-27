using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    public GameObject obj;

    public int m_MapX;
    public int m_MapY;

    private int[] m_Map;  
    public int[] MapData
    {
        get { return m_Map; }
    }

    private Vector3 m_StartPosition;
    public Vector3 StartPosition
    {
        get { return m_StartPosition; }
    }

    public enum MapType
    {
        Non = 0,
        Hole,
        Floor,
        Wall,
        Note,           //ノーツ
        Barrage,        //連打
        Arrow,          //方向転換
        Start,
        Goal,
        Max
    }
    int[,] num;

    // m_Map配列の添え字を返す
    public int GetMapIndex(Vector2 Position)
    {
        int index = m_MapX * (int)-Position.y + (int)Position.x;
        
        return index;
    }
    public int GetMapIndex(Vector3 Position)
    {
        int index = m_MapX * (int)-Position.y + (int)Position.x;

        return index;
    }
    public int GetMapIndex(GameObject obj)
    {
        return GetMapIndex(obj.transform.position);
    }
    public int GetMapIndex(Player obj)
    {
        return GetMapIndex(obj.transform.position);
    }

    // 添え字から位置を返す
    private Vector3 OffsetPosition(Vector3 pos)
    {
        pos.x += 0.5f;
        pos.y -= 0.5f;
        return pos;
    }
    public Vector3 GetMapPosition(int index)
    {
        Vector3 pos = new Vector3();
        pos.x = (float)(index % m_MapX);
        pos.y = (float)(index / m_MapX) * -1.0f;
        pos.z = 0.0f;
        return OffsetPosition(pos);
    }

    // 位置から乗っているタイルタイプを返す
    public MapType GetMapType(Vector3 pos)
    {
        return (MapType)m_Map[GetMapIndex(pos)];
    }
    public MapType GetMapType(GameObject obj)
    {
        return GetMapType(obj.transform.position);
    }
    public MapType GetMapType(Player player)
    {
        return (MapType)m_Map[GetMapIndex(player)];
    }

    // 今いるタイルにどれくらい乗っているか（1.0が真ん中）
    public float GetTilePosition(GameObject obj)
    {
        float f = 0.0f;
        Vector3 pos = GetMapPosition(GetMapIndex(obj));

        // 縦移動中
        if (obj.transform.position.x == pos.x)
        {
            f = Mathf.Max(obj.transform.position.y, pos.y) -
                Mathf.Min(obj.transform.position.y, pos.y);
        }

        // 横移動中
        if (obj.transform.position.y == pos.y)
        {
            f = Mathf.Max(obj.transform.position.x, pos.x) -
                Mathf.Min(obj.transform.position.x, pos.x);
        }

        return (1.0f - f);
    }
    public float GetTilePosition(Player player)
    {
        float f = 0.0f;
        Vector3 pos = GetMapPosition(GetMapIndex(player));

        // 縦移動中
        if (player.transform.position.x == pos.x)
        {
            f = Mathf.Max(player.transform.position.y, pos.y) -
                Mathf.Min(player.transform.position.y, pos.y);
        }

        // 横移動中
        if (player.transform.position.y == pos.y)
        {
            f = Mathf.Max(player.transform.position.x, pos.x) -
                Mathf.Min(player.transform.position.x, pos.x);
        }

        return (1.0f - f);
    }

    public void Initialize()
    {
        // 配列サイズ
        int mapNum = m_MapX * m_MapY;

        // マップ初期化
        m_Map = new int[mapNum];
        for (int i = 0; i < mapNum; i++)
            m_Map[i] = (int)MapType.Non;


        // タイルの取得
        Tilemap tileMap = GameObject.FindObjectOfType<Tilemap>();

        // タイル情報の一時保存先
        List<string> nameList = new List<string>();
        List<Vector3> positionList = new List<Vector3>();

        var bound = tileMap.cellBounds;

        // マップチップからのデータを取得
        for (int y = bound.max.y - 1; y >= bound.min.y; --y) 
        {
            for (int x = bound.min.x; x < bound.max.x; ++x)
            {
                // タイル情報
                TileBase tileBase = tileMap.GetTile<TileBase>(new Vector3Int(x, y, 0));

                // 座標
                Vector3Int localPlace = (new Vector3Int(x, y, (int)tileMap.transform.position.y));
                Vector3 place = tileMap.CellToWorld(localPlace);

                if(tileBase != null && tileMap.HasTile(localPlace))
                {
                    nameList.Add(tileBase.name.ToString());
                    place.y++;  // 調整
                    positionList.Add(place);
                }
            }
        }

        // データの書き込み
        for (int i = 0; i < nameList.Count; i++)
        {
            // マップ範囲外だったら次のループへ
            if (GetMapIndex(positionList[i]) < 0 || mapNum - 1 < GetMapIndex(positionList[i]))
            {
                continue;
            }
            
            if (nameList[i].StartsWith("Oil")){
                m_Map[GetMapIndex(positionList[i])] = 0;
                continue;
            }

            switch (nameList[i])
            {
                case "block_147":
                    m_Map[GetMapIndex(positionList[i])] = (int)MapType.Wall;
                    break;

                case "block_460":
                    m_Map[GetMapIndex(positionList[i])] = (int)MapType.Hole;
                    break;

                case "block_43":
                    m_Map[GetMapIndex(positionList[i])] = (int)MapType.Floor;
                    break;

                case "block_459":
                    m_Map[GetMapIndex(positionList[i])] = (int)MapType.Goal;
                    break;

                case "block_211":
                    m_Map[GetMapIndex(positionList[i])] = (int)MapType.Arrow;
                    break;

                case "block_315":
                    m_Map[GetMapIndex(positionList[i])] = (int)MapType.Note;
                    break;

                case "Konishi":
                    m_Map[GetMapIndex(positionList[i])] = (int)MapType.Arrow;
                    m_StartPosition = OffsetPosition(positionList[i]);
                    break;
            }
        }

    
        //// ゴールの取得
        //{
        //    GameObject goal = GameObject.FindGameObjectWithTag("Goal");

        //    m_Map[GetMapIndex((Vector2)goal.transform.position)] = (int)MapType.Goal;
        //}

        // 壁の取得
        {
            GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");

            foreach (GameObject i in walls)
            {
                // 仮。１は壁とする。
                m_Map[GetMapIndex((Vector2)i.transform.position)] = (int)MapType.Wall ;
            }
        }

    }
}
