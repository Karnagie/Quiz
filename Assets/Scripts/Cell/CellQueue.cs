using UnityEngine;

public struct CellQueue<T>
{
    private T[] _objects;
    private int[] _nativeIds;
    private int _id;
    public int Id { get { return _id; } private set { _id = value; } }

    public int GetLength()
    {
        return _objects.Length;
    }

    public CellQueue(T[] objects)
    {
        _objects = objects;
        _nativeIds = new int[objects.Length];
        for (int i = 0; i < _nativeIds.Length; i++)
        {
            _nativeIds[i] = i;
        }
        _id = 0;
    }

    public void Shuffle()
    {
        for (int i = 0; i < _objects.Length * 2; i++)
        {
            int c = i % _objects.Length;
            int k = Random.Range(0, c);
            T v = _objects[c];
            _objects[c] = _objects[k];
            _objects[k] = v;

            int id = _nativeIds[c];
            _nativeIds[c] = _nativeIds[k];
            _nativeIds[k] = id;
        }
    }

    public int GetNativeId()
    {
        return _nativeIds[_id];
    }

    public T GetNext()
    {
        T next = _objects[_id];
        _id++;
        _id %= _objects.Length;
        return next;
    }

    public T[] ToArray()
    {
        return _objects;
    }

}

