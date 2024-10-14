using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class EnemyConfig
{
    public Enemy Prefab;
    [FloatRangeSlider(0.1f, 2f)]
    public FloatRange Scale = new FloatRange(1f);
    [FloatRangeSlider(1f, 20f)]
    public FloatRange Speed = new FloatRange(1f);
    [FloatRangeSlider(1f, 20f)]
    public FloatRange RotationSpeed = new FloatRange(1f);
    [FloatRangeSlider(10f, 1000f)]
    public FloatRange Health = new FloatRange(100f);
    [FloatRangeSlider(1f, 100f)]
    public FloatRange Damage = new FloatRange(5f);

    public EnemyContext ToContext()
    {
        var damage = Damage.RandomValueInRange;
        return new EnemyContext(Scale.RandomValueInRange,
            Speed.RandomValueInRange, RotationSpeed.RandomValueInRange, Health.RandomValueInRange, (int)damage);
    }
}
