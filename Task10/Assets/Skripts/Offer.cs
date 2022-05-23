using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offer : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layerM;
    [SerializeField] private int powerConfigurableJoint;
    [SerializeField] private int powerSpringJoint;
    //������� ��������� ������ ConfigurableJoint ��� ������� � ����
    private ConfigurableJoint configurableJoint;
    //������� ��������� ������ SpringJoint ��� ������� � ����
    private SpringJoint springJoint;

    private void Update()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, radius, layerM);
        foreach (Collider col in colls)
        {
            if (col.gameObject.GetComponent<ConfigurableJoint>())
            {
                configurableJoint = col.gameObject.GetComponent<ConfigurableJoint>();
                ChangeConfigurableJoint();
            }
            if (col.gameObject.GetComponent<SpringJoint>())
            {
               springJoint = col.gameObject.GetComponent<SpringJoint>();
               springJoint.spring = powerSpringJoint;
            }
        }
    }

    private void ChangeConfigurableJoint()
    {
        //������� ��������� ������ JointDrive ��� ������� � ����, ��� ��� ������ �������� �������� YDrive
        JointDrive jointDrive = configurableJoint.yDrive;
        //�������� ������ ��������
        jointDrive.positionSpring = powerConfigurableJoint;
        // ����������� (�������) ������ �������� (�� �� ������)
        configurableJoint.yDrive = jointDrive;
    }
}
