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
        public void WateringPot_WetsIt()
        {
            var pot = new Pot();
            pot.Water();
            Assert.That(pot.IsWet, Is.True);
        }
    }
}