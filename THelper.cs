using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class THelper : MonoBehaviour
{
    public Material msh;
    public int triCount;
    public float radius;

    private Coroutine cor;
    // Start is called before the first frame update
    void Start()
    {
        // VTest();
        // CreateCircle();
        Debug.Log("开始1");
        //StartCoroutine(CorTest());
        cor = StartCoroutine(CorTest());
        Debug.Log("开始2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VTest()
    {
        VertexHelper vh = new VertexHelper();
        vh.Clear();

        vh.AddVert(new Vector3(0, 0, 0), Color.red, new Vector2(0, 0));
        vh.AddVert(new Vector3(1, 0, 0), Color.blue, new Vector2(1, 0));
        vh.AddVert(new Vector3(1, 1, 0), Color.yellow, new Vector2(1, 1));
        vh.AddVert(new Vector3(0, 1, 0), Color.cyan, new Vector2(0, 1));

        vh.AddTriangle(0, 1, 2);
        vh.AddTriangle(2, 3, 0);

        MeshFilter meshFilter = gameObject.GetOrAddComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        mesh.name = "Quad";
        vh.FillMesh(mesh);
        meshFilter.mesh = mesh;

        MeshRenderer meshRenderer = gameObject.GetOrAddComponent<MeshRenderer>();
        meshRenderer.material = msh;
        meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        meshRenderer.receiveShadows = false;
    }

    private void CreateCircle()
    {
        VertexHelper vh = new VertexHelper();
        vh.Clear();
        vh.AddVert(new Vector3(0, 0, 0), Color.white, new Vector2(0.5f, 0.5f));
        float theta = 2 * Mathf.PI / triCount;
        for (int i = 0; i < triCount; i++)
        {
            Color color = Color.Lerp(Color.blue, Color.red, (float)i / (triCount - 1));
            //计算每个顶点的位置
            float X = Mathf.Sin(2 * Mathf.PI - i * theta);
            float Y = Mathf.Cos(2 * Mathf.PI - i * theta);
            //radius为半径
            vh.AddVert(new Vector3(X * radius, Y * radius, 0), color, new Vector2(X, Y));
        }
        //添加三角形
        for (int i = 1; i < triCount; i++)
        {
            vh.AddTriangle(0, i, i + 1);
        }
        vh.AddTriangle(0, triCount, 1);
        MeshFilter meshFilter = gameObject.GetOrAddComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        vh.FillMesh(mesh);
        meshFilter.mesh = mesh;

        MeshRenderer meshRenderer = gameObject.GetOrAddComponent<MeshRenderer>();
        meshRenderer.material = msh;
    }



    IEnumerator CorTest()
    {
        Debug.Log("协程1");
        yield return new WaitForSeconds(1);
        Debug.Log("协程2");
    }
}
