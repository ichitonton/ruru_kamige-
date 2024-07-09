using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GenerateRadialVertical : GenerateBase
{
    public override void Action(Vector3 position, Vector3 forward)
    {
        if (NumberOf % 2 == 0)
        {
            EvenNumber(position,forward);
        }
        else
        {
            OddNumber(position,forward);
        }
    }

    private void OddNumber(Vector3 position, Vector3 forward)
    {
        int left = (int)(NumberOf * 0.5f);
        int proto = NumberOf - left;

        for (int i = -left; i < proto; ++i)
        {
            Instantiate(generateObject, position, Quaternion.identity).GetComponent<BulletManagar>().SetShotDirection(Quaternion.Euler((Angle * i), 0.0f, (Angle * i)) * forward);
        }
    }

    private void EvenNumber(Vector3 position, Vector3 forward)
    {
        int left = (int)(NumberOf * 0.5f);
        int proto = NumberOf - left;
        int halfAngle = (int)(Angle * 0.5f);

        for (int i = -left; i < proto; ++i)
        {
            Instantiate(generateObject, position, Quaternion.identity).GetComponent<BulletManagar>().SetShotDirection(Quaternion.Euler(((Angle * i) + halfAngle), 0.0f, ((Angle * i) + halfAngle)) * forward);
        }
    }
}
