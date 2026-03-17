using UnityEngine;
using UnityEngine.UIElements;

public class SomeItemMover : MonoBehaviour
{
    public GameObject target;
    
    public VisualElement ui;
    
    Button left, right, up, down;

    void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
    }

    void OnEnable()
    {
        left = ui.Q<Button>("left");
        right = ui.Q<Button>("right");
        up = ui.Q<Button>("up");
        down = ui.Q<Button>("down");

        left.clicked += () => MoveObject(-transform.right);
        right.clicked += () => MoveObject(transform.right);
        up.clicked += () => MoveObject(transform.up);
        down.clicked += () => MoveObject(-transform.up);
    }

    void MoveObject(Vector3 kuda)
    {
        var a =target.GetComponent<Rigidbody>();
        if (a == null) {
            a = target.AddComponent<Rigidbody>();
            a.useGravity = false;
        }

        a.AddForce(kuda * 10);
    }
}
