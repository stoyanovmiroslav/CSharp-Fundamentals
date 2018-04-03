using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;


public class DummyTests
{
    [Test]
    public void DummyLosesHealthAfterAttack()
    {
        Dummy dummy = new Dummy(10, 5);
        dummy.TakeAttack(2);
        Assert.That(dummy.Health, Is.EqualTo(8));
    }

    [Test]
    public void DeadDummyThrowsExceptionAfterAttack()
    {
        Dummy dummy = new Dummy(0, 5);
        Assert.That(() => dummy.TakeAttack(2), Throws.InvalidOperationException);
    }

    [Test]
    public void DeadDummyCanGiveXP()
    {
        Dummy dummy = new Dummy(0, 5);
        Assert.That(() => dummy.GiveExperience(), Is.EqualTo(5));
    }

    [Test]
    public void AliveDummyCantGiveXP()
    {
        Dummy dummy = new Dummy(1, 5);
        Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException);
    }
}