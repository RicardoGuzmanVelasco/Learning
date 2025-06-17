using System;
using System.Diagnostics;

namespace Plants
{
    public class Pot
    {
        string plantId;
        TimeSpan timeSinceLastWatering;
        
        public bool IsEmpty => string.IsNullOrEmpty(plantId);
        public bool IsWet { get; private set; }
        public bool HasSprout { get; private set; }
        
        public void SowSeed(string id)
        {
            Debug.Assert(IsEmpty);
            Debug.Assert(!string.IsNullOrEmpty(id));
            
            plantId = id;
        }
        
        public void Water()
        {
            Debug.Assert(!IsEmpty);
            Debug.Assert(!IsWet);

            IsWet = true;
            timeSinceLastWatering = TimeSpan.Zero;
        }
        
        public void PassTime(TimeSpan delta)
        {
            Debug.Assert(delta >= TimeSpan.Zero);
            timeSinceLastWatering += delta;
            
            if (IsWet && timeSinceLastWatering > AssumedTechDebtTimeToSpawnSprout())
                HasSprout = true;
            
            IsWet = timeSinceLastWatering <= AssumedTechDebtTimeToNotWet();
        }

        static TimeSpan AssumedTechDebtTimeToNotWet()
            => TimeSpan.FromDays(1);
        static TimeSpan AssumedTechDebtTimeToSpawnSprout()
            => TimeSpan.FromDays(.75f);
    }
}