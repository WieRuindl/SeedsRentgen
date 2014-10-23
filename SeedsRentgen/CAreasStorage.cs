using System.Collections.Generic;
using System.Drawing;

namespace SeedsRentgen
{
    /// <summary>
    /// класс хранит все прокликанные на изображении FMainForm области (серые и белые) и предоставляет следующий
    /// функционал для оперирования с ними:
    /// _storage - общий список всех областей, необходим, чтобы была возможность удалять области в обратном порядке
    /// _husksCount, _bodiesCount - количество серых и белых, соответственно, областей
    /// </summary>
    /// 
    class CAreasStorage
    {
        private List<CArea> _storage;

        private int _husksCount;
        private int _bodiesCount;

        public CAreasStorage()
        {
            _storage = new List<CArea>();

            _husksCount = 0;
            _bodiesCount = 0;
        }

        public List<CArea> GetAllAreas()
        {
            return new List<CArea>(_storage);
        }

        public void AddArea(CArea seed)
        {
            _storage.Add(seed);

            if (Color.White.R==seed.Color)
            {
                _bodiesCount++;
            }
            else
            {
                _husksCount++;
            }
        }
        public CArea RemoveLastArea()
        {
            CArea seed = null;

            if (_storage.Count > 0)
            {
                seed = _storage[_storage.Count - 1];
                _storage.Remove(seed);

                if (Color.White.R == seed.Color)
                {
                    _bodiesCount--;
                }
                else
                {
                    _husksCount--;
                }
            }

            return seed;
        }
        public void RemoveAllAreas()
        {
            if (_storage.Count > 0)
            {
                _storage = new List<CArea>();

                _husksCount = 0;
                _bodiesCount = 0;
            }
        }

        public bool IsReadyForSave()
        {
            return (_husksCount >= _bodiesCount) && (_husksCount > 0);
        }
    }
}
