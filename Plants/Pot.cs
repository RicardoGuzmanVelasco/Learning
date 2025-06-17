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
        enum PlantStage { None, Sprout, Stem, Flowers }
        
        string plantId;
        PlantStage stage = PlantStage.None;
        public bool HasSprout => stage == PlantStage.Sprout;
        public bool HasStem => stage == PlantStage.Stem;
        public bool HasFlowers => stage == PlantStage.Flowers;
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
                stage = PlantStage.Sprout;
            
            IsWet = timeSinceLastWatering <= AssumedTechDebtTimeToNotWet();
        }

        static TimeSpan AssumedTechDebtTimeToNotWet()
            => TimeSpan.FromDays(1);
        static TimeSpan AssumedTechDebtTimeToSpawnSprout()
            => TimeSpan.FromDays(.75f);
    }
}