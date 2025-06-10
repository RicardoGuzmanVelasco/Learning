using System;
using NUnit.Framework;

namespace Plants
{
    public class PotTests
    {
        [Test]
        public void NewPotIsEmpty()
        {
            Assert.That(new Pot().IsEmpty, Is.True);
        }

        [Test]
        public void NewPotIsNotWet()
        {
            Assert.That(new Pot().IsWet, Is.False);
        }
        
        [Test]
        public void SowSeed_SoPotIsNotEmpty()
        {
            var pot = new Pot();
            pot.SowSeed("anySeed");
            Assert.That(pot.IsEmpty, Is.False);
        }
        
        [Test]
        public void WateringPot_WetsIt()
        {
            var pot = new Pot();
            pot.SowSeed("anySeed");
            
            pot.Water();
            
            Assert.That(pot.IsWet, Is.True);
        }

        [Test]
        public void WetPot_AfterEnoughTime_IsNotWetAnymore()
        {
            var pot = new Pot();
            pot.SowSeed("anySeed");
            pot.Water();

            pot.PassTime(TimeSpan.MaxValue);
            
            Assert.That(pot.IsWet, Is.False);
        }

        [Test]
        public void WetPot_AfterNotEnoughTime_IsStillWet()
        {
            var pot = new Pot();
            pot.SowSeed("anySeed");
            pot.Water();

            pot.PassTime(TimeSpan.FromSeconds(1));
            
            Assert.That(pot.IsWet, Is.True);
        }
    }
    
    /*
     * la planta crece si está regada y pasa el tiempo.
     * 
     */
}