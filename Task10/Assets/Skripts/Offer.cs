using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offer : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layerM;
    [SerializeField] private int powerConfigurableJoint;
    [SerializeField] private int powerSpringJoint;
    //—оздаем экземпл€р класса ConfigurableJoint дл€ доступа к нему
    private ConfigurableJoint configurableJoint;
    //—оздаем экземпл€р класса SpringJoint дл€ доступа к нему
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
        //—оздаем экземпл€р класса JointDrive дл€ доступа к нему, так как нельз€ напр€мую изменить YDrive
        JointDrive jointDrive = configurableJoint.yDrive;
        //измен€ем нужное значение
        jointDrive.positionSpring = powerConfigurableJoint;
        // присваиваем (наконец) нужное значение (не на пр€мую)
        configurableJoint.yDrive = jointDrive;
    }
}
