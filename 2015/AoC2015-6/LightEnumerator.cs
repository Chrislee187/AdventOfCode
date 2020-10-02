using System;
using System.Collections;
using System.Collections.Generic;

namespace AoC2015_6
{
    public class LightEnumerator : IEnumerator<Light>
    {
        private readonly int[,] _lightGrid;
        private int _currentX;
        private int _currentY;
        private readonly int _maxX;
        private readonly int _maxY;

        public LightEnumerator(int[,] lightGrid)
        {
            _lightGrid = lightGrid;
            _currentX = 0;
            _currentY = 0;

            _maxX = lightGrid.GetUpperBound(0);
            _maxY = lightGrid.GetUpperBound(1);
        }
        public bool MoveNext()
        {
            _currentX++;
            if (_currentX > _maxX)
            {
                _currentY++;
                _currentX = 0;
            }

            var index = Math.Max(_maxX * (_currentY - 1), 0) + _currentX;
            var maxIndex = _maxX * _maxY - 1;
            return index <= maxIndex;
        }

        public void Reset()
        {
            _currentX = 0;
            _currentY = 0;
        }

        public Light Current => new Light
        {
            X = _currentX,
            Y = _currentY,
            Brightness = _lightGrid[_currentX, _currentY]
        };

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            //
        }
    }
}