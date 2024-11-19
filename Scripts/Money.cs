using UnityEngine;
using System;

[Serializable]
public struct Money
{
    [SerializeField]
    private int _amount;


    public Money(int amount)
    {
        _amount = amount;
    }

    public Money(int gold, int silver, int copper)
    {
        _amount = gold * 10000 + silver * 100 + copper;
    }

    public (int gold, int silver, int copper) GetCoins()
    {
        int gold = _amount / 10000;
        int silver = _amount % 10000 / 100;
        int copper = _amount % 100;

        return (gold, silver, copper);
    }

    public static bool operator <(Money left, Money right) => left._amount < right._amount;
    public static bool operator >(Money left, Money right) => left._amount > right._amount;
    public static bool operator <=(Money left, Money right) => left._amount <= right._amount;
    public static bool operator >=(Money left, Money right) => left._amount >= right._amount;
    public static bool operator ==(Money left, Money right) => left._amount == right._amount;
    public static bool operator !=(Money left, Money right) => left._amount != right._amount;

    public override bool Equals(object other)
    {
        return other is Money money && money._amount == _amount;
    }

    public override int GetHashCode()
    {
        return _amount.GetHashCode();
    }

    public static Money operator +(Money left, Money right) => new(left._amount + right._amount);
    public static Money operator -(Money left, Money right) => new(left._amount - right._amount);
    public static Money operator *(Money left, float right) => new(Mathf.RoundToInt(left._amount * right));
    public static Money operator *(float left, Money right) => new(Mathf.RoundToInt(left * right._amount));
}
