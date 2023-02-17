using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFreezeable
{
    public void Freezing();
    public IEnumerator UnFreezing();
}
