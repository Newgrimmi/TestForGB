using System.Collections;

public interface IWeaknessable 
{
    public void Weakness(float percentInreaseDamage);
    public IEnumerator UnWeakness();

}
