using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class Quad : MonoBehaviour
{
    public float size;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshFilter>().mesh = DrawMesh();
    }

    private Mesh DrawMesh()
    {
        var mesh = new Mesh();
        var hSize = size * 0.5f;

        // Quad의 정점 데이터
        var vertices = new Vector3[] {
        new Vector3(-hSize, hSize, 0f), // 0번 정점, quad 왼쪽 위의 위치
        new Vector3( hSize, hSize, 0f), // 1번 정점, quad 오른쪽 위의 위치
        new Vector3( hSize, -hSize, 0f), // 2번 정점, quad 왼쪽 아래의 위치
        new Vector3(-hSize, -hSize, 0f) // 3번 정점, quad 오른쪽 아래의 위치
        };

        // Quad의 uv좌표 데이터
        var uv = new Vector2[] {
        new Vector2(0f, 0f), // 0번 정점의 uv 좌표
        new Vector2(1f, 0f), // 1번 정점의 uv 좌표
        new Vector2(1f, 1f), // 2번 정점의 uv 좌표
        new Vector2(0f, 1f) // 3번 정점의 uv 좌표
        };

        // Quad의 법선 데이터
        var normals = new Vector3[] {
        new Vector3(0f, 0f, -1f), // 0번 정점의 법선
        new Vector3(0f, 0f, -1f), // 1번 정점의 법선
        new Vector3(0f, 0f, -1f), // 2번 정점의 법선
        new Vector3(0f, 0f, -1f) // 3번 정점의 법선
        };

        // Quad의 면 데이터. 네 개의 버텍스로 이루어진 두 삼각형에 필요한 index를 삼각형 순서대로 3개씩 나란히 놓는다
        var triangles = new int[] {
        0, 1, 2, // 첫번째 삼각형
        2, 3, 0 // 두번째 삼각형
        };

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.normals = normals;
        mesh.triangles = triangles;
        // 만들어진 메쉬의 경계 영역(bounds)을 계산한다 (culling에 필요)
        mesh.RecalculateBounds();
        return mesh;
    }
}
