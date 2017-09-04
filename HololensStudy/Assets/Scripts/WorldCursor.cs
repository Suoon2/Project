using UnityEngine;

public class WorldCursor : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    void Start()
    {
        this.transform.parent = Camera.main.transform;
        this.transform.localPosition = new Vector3(0, 0, 2);
        this.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
    }

    void Update()
    {
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            float rate = hitInfo.point.z / this.transform.position.z;
            this.transform.position = hitInfo.point;
            this.transform.rotation =
                Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            this.transform.localScale *= rate;
        }
        else
        {
            this.transform.parent = Camera.main.transform;
            this.transform.localPosition = new Vector3(0, 0, 2);
            this.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
            this.transform.localScale = Vector3.one;
        }
    }
}
