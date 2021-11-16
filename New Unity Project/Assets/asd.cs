using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class asd : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [Tooltip("������ ���")]
    [SerializeField]
    private Transform Target;

    [Tooltip("�������� ������ ��ƽ")]
    [SerializeField]
    private RectTransform Stick;

    [Tooltip("��ƽ�� �� ���")]
    [SerializeField]
    private RectTransform BackBoard;

    // ** ��ƽ �� ����� ������
    private float Radius = 0.0f;

    // ** �Է� Ȯ��
    private bool TouchCheck = false;

    // ** �̵� �ӵ�
    private float Speed = 0.0f;

    // ** ���� ��.
    private Vector2 Direction;

    // ** �̵� ��.
    private Vector3 Movement;

    void Start()
    {
        // ** BackBoard�� �������� ����.
        Radius = (BackBoard.rect.width / 2.0f);
        Speed = 5.0f;
    }

    void Update()
    {
        if (TouchCheck)
            Target.position += Movement;
    }

    private void GetMovement(Vector2 _Point)
    {
        Stick.localPosition = new Vector2(
            _Point.x - BackBoard.position.x,
            _Point.y - BackBoard.position.y);

        Stick.localPosition = Vector2.ClampMagnitude(
            Stick.localPosition, Radius);

        // ** ���� ����
        float Ratio = (BackBoard.position - Stick.position).sqrMagnitude / (Radius * Radius);

        // ** ������ ����ȭ ����
        Direction = Stick.localPosition.normalized;

        Movement = new Vector3(
            Direction.x * Speed * Ratio * Time.deltaTime,
            0,
            Direction.y * Speed * Ratio * Time.deltaTime);
    }

    public void OnDrag(PointerEventData eventData)
    {
        GetMovement(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Stick.localPosition = Vector3.zero;
        TouchCheck = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GetMovement(eventData.position);
        TouchCheck = true;
    }
}
