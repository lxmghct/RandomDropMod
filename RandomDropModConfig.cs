using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace RandomDropMod
{
    public class RandomDropModConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        
        [Label("Chance to drop item")]
        [Slider]
        [SliderColor(255, 255, 50)]
        [Range(0, 100)]
        [Increment(1)]
        [DefaultValue(20)]
        public int DropProbability { get; set; }
    }
}