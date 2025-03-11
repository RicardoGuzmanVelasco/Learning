using System.Diagnostics;

namespace Plants
{
    public class Pot
    {
        string plantId;
        
        public bool IsEmpty => string.IsNullOrEmpty(plantId);
        public bool IsWet { get; private set; }
        
        public void Water()
        {
            Debug.Assert(!IsEmpty);
            Debug.Assert(!IsWet);
            
            IsWet = true;
        }

        public void ArrancarPlant()
        {
            Debug.Assert(!IsEmpty);
            
            plantId = null;
        }
    }
}