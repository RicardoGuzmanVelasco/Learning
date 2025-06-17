using System;
using System.Diagnostics;

namespace Plants
{
    public class Pot
    {
        public bool IsEmpty => string.IsNullOrEmpty(plantId);
        
        TimeSpan timeSinceLastWatering;
        public bool IsWet { get; private set; }

        #region Esto es cohesivo, creemos que una planta, no queremos sacarlo aún.
        string plantId;
        public bool HasSprout { get; private set; }
        public bool HasStem { get; private set; }
        public bool HasFlowers { get; private set; }
        #endregion
        
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