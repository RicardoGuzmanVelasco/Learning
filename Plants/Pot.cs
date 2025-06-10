using System;
using System.Diagnostics;

namespace Plants
{
    public class Pot
    {
        string plantId;
        
        public bool IsEmpty => string.IsNullOrEmpty(plantId);
        public bool IsWet { get; private set; }
        
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
        }

        public void PassTime(TimeSpan delta)
        {
            Debug.Assert(delta >= TimeSpan.Zero);
            IsWet = delta.TotalSeconds <= 1;
        }
    }
}