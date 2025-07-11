using System.Diagnostics;

namespace Plants.Domain
{
    public class Pot
    {
        public bool IsEmpty => string.IsNullOrEmpty(plantId);
        
        #region Esto es cohesivo, algo del tiempo o yo qué sé
        TimeSpan timeSinceLastWatering;
        public bool IsWet { get; private set; }
        static TimeSpan AssumedTechDebtTimeToNotWet()
            => TimeSpan.FromDays(4);

        #endregion

        #region Esto es cohesivo, creemos que una planta, no queremos sacarlo aún.
        enum PlantStage { Seed, Sprout, Stem, WithLeaves, Flowers }
        
        string plantId;
        PlantStage stage = PlantStage.Seed;
        public bool HasSprout => stage == PlantStage.Sprout;
        public bool HasStem => stage == PlantStage.Stem;
        public bool HasLeaves => stage == PlantStage.WithLeaves;
        public bool HasFlowers => stage == PlantStage.Flowers;
        
        static TimeSpan AssumedTechDebtTimeToSpawnSprout()
            => TimeSpan.FromDays(2);
        static int AssumedTechDebtCyclesToSprout()
            => 3;

        private CountDown _cyclesToSprout;
        #endregion
        
        public void SowSeed(string id)
        {
            Debug.Assert(IsEmpty);
            Debug.Assert(!string.IsNullOrEmpty(id));
            
            plantId = id;
            _cyclesToSprout = CountDown.From(AssumedTechDebtCyclesToSprout());
        }
        
        public void Water()
        {
            Debug.Assert(!IsEmpty);
            Debug.Assert(!IsWet);

            IsWet = true;
            timeSinceLastWatering = TimeSpan.Zero;
        }

        private void PassTime(TimeSpan delta)
        {
            Debug.Assert(delta >= TimeSpan.Zero);
            timeSinceLastWatering += delta;
            
            IsWet = timeSinceLastWatering <= AssumedTechDebtTimeToNotWet();
        }

        public void PassCycles(int howMany)
        {
            Debug.Assert(howMany >= 0);
            for (var i = 0; i < howMany; i++)
                PassOneCycle();
        }
        public void PassOneCycle()
        {
            PassCycle();
            PassTime(TimeSpan.FromDays(1));
        }
        
        public void PassCycle()
        {
            if(!IsWet)
                return;
            _cyclesToSprout.Down();
            if(!_cyclesToSprout.IsDone)
                return;
            stage = PlantStage.Sprout;
        }
    }
}