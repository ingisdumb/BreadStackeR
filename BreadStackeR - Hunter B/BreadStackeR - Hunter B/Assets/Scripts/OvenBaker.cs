using System.Collections;
using UnityEngine;

public class OvenBaker : MonoBehaviour
{
    public int queuedDough = 0;
    public float bakeTime = 5f;
    private bool isBaking = false;

    public ovenBreadAmount[] safeShelves;

    public void AddDough(int amount)
    {
        queuedDough += amount;

        if (!isBaking)
        {
            StartCoroutine(BakeLoop());
        }
    }

    IEnumerator BakeLoop()
    {
        isBaking = true;

        while (queuedDough > 0)
        {
            yield return new WaitForSeconds(bakeTime);

            bool placed = false;

            foreach (var shelf in safeShelves)
            {
                if (shelf != null && shelf.HasRoom())
                {
                    shelf.AddBread(1);
                    queuedDough--;
                    placed = true;
                    break;
                }
            }

            if (!placed)
            {
                yield return new WaitForSeconds(1f);
            }
        }

        isBaking = false;
    }
}