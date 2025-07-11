using System.Diagnostics;

namespace Plants.Domain
{
    public class Pot
    {
        public bool IsEmpty => string.IsNullOrEmpty(plantId);
        
        #region Esto es cohesivo, algo del tiempo o yo qué sé
        public bool IsWet { get; private set; }
        static int AssumedTechDebtCyclesToDry()
            => 4;
        private CountDown _cyclesToDry = CountDown.From(0);
        #endregion

        #region Esto es cohesivo, creemos que una planta, no queremos sacarlo aún.
        enum PlantStage { Seed, Sprout, Stem, WithLeaves, Flowers }
        
        string plantId;
        PlantStage stage = PlantStage.Seed;
        public bool HasSprout => stage == PlantStage.Sprout;
        public bool HasStem => stage == PlantStage.Stem;
        public bool HasLeaves => stage == PlantStage.WithLeaves;
        public bool HasFlowers => stage == PlantStage.Flowers;
        
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
            _cyclesToDry = CountDown.From(AssumedTechDebtCyclesToDry());
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
        }

        private void PassCycle()
        {
            if(!IsWet)
                return;
            _cyclesToDry.Down();
            if (_cyclesToDry.IsDone)
            {
                IsWet = false;
            }
            _cyclesToSprout.Down();
            if(!_cyclesToSprout.IsDone)
                return;
            stage = PlantStage.Sprout;
        }
    }
}