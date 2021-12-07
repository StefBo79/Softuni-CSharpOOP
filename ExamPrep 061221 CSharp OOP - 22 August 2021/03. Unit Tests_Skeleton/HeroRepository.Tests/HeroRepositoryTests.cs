using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private HeroRepository heroRepository;
    [SetUp]
    public void SetUp()
    {
        heroRepository = new HeroRepository();
    }

    [Test]
    public void IfHeroIsNullWhileCreating()
    {
        Assert.IsNotNull(heroRepository.Heroes);
    }

    [Test]
    public void HeroIsAlreadyExist()
    {
        var heroes = new HeroRepository();
        heroes.Create(new Hero("Anakin", 100));
        Assert.Throws<InvalidOperationException>(() => heroes.Create(new Hero("Anakin", 100)));
    }

    [Test]
    public void RemoveWorkProperly()
    {
        var heroes = new HeroRepository();
        heroes.Create(new Hero("Anakin", 100));
        Assert.IsTrue(heroes.Remove("Anakin"));
    }

    [Test]
    public void RemoveShoudThrowExeptionWhenThereisNullOrWhiteSpace()
    {
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(null));
    }

    [Test]
    public void ValidHeroWithHighestLevel()
    {        
        heroRepository.Create(new Hero("Anakin", 100));
        heroRepository.Create(new Hero("ObiOneCanObie", 200));
        var expected = heroRepository.GetHero("ObiOneCanObie");
        Assert.AreEqual(expected, heroRepository.GetHeroWithHighestLevel());
    }


}