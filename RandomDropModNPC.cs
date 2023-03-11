using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace RandomDropMod
{
    public class RandomDropModNPC : GlobalNPC
    {
        private static Random random = new Random();
        public override bool PreKill(NPC npc)
        {
            if (Main.rand.NextDouble() < 0.8)
            {
                return base.PreKill(npc);
            }
            // 随机生成物品
            int itemId = random.Next(ItemLoader.ItemCount);
            Item item = new Item();
            item.SetDefaults(itemId);
            // 随机生成物品的数量
            int maxStack = item.maxStack;
            /*
                最大堆叠, 生成数量
                1, 1
                2~10, 1~(maxStack-1)
                11~30, 5~(maxStack-5)
                31~100, 15~(maxStack-15)
                >100, 30~60
            */
            int count = 1;
            if (maxStack > 1)
            {
                if (maxStack < 10)
                {
                    count = random.Next(maxStack - 1) + 1;
                }
                else if (maxStack < 30)
                {
                    count = random.Next(maxStack - 5) + 5;
                }
                else if (maxStack < 100)
                {
                    count = random.Next(maxStack - 15) + 15;
                }
                else
                {
                    count = random.Next(30) + 30;
                }
            }
            // 生成物品
            Item.NewItem(null, npc.position, itemId, count);
            return base.PreKill(npc);
        }
    }
}