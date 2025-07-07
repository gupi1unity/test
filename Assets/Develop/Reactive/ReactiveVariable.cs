using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveVariable<T> where T : IComparable<T>
{
    public event Action<T> Changed;

    private T _value;

    public T Value
    {
        get => _value;

        set
        {
            T oldValue = _value;
            _value = value;

            if (_value.CompareTo(oldValue) != 0)
                Changed?.Invoke(_value);
        }
    }

    public ReactiveVariable()
    {
        Value = default(T);
    }

    public ReactiveVariable(T value)
    {
        Value = value;
    }
}
