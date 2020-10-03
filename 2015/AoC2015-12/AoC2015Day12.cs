using System;
using System.Linq;
using System.Text.Json;

namespace AoC2015_12
{
    class AoC2015Day12
    {
        private readonly JsonDocument _document;
        private bool _checkForRedFlag;

        public AoC2015Day12(JsonDocument document)
        {
            _document = document;
        }

        public int SumAllValues(bool checkForRedFlag)
        {
            _checkForRedFlag = checkForRedFlag;
                
            var root = _document.RootElement;
                
            if(root.ValueKind != JsonValueKind.Array) throw new NotSupportedException("Expected JSON Array");

            return SumArray(root);
        }

        private int SumArray(in JsonElement element)
        {
            var sum = 0;

            foreach (var item in element.EnumerateArray())
            {
                switch (item.ValueKind)
                {
                    case JsonValueKind.Number:
                        sum += item.GetInt32();
                        break;
                    case JsonValueKind.Array:
                        sum += SumArray(item);
                        break;
                    case JsonValueKind.Object:
                        sum += SumObject(item);
                        break;
                    // case JsonValueKind.String:
                    //     break;
                }
            }
                
            return sum;
        }

        private int SumObject(in JsonElement element)
        {
            var sum = 0;
            var containsRedFlag = element.EnumerateObject()
                .Any(i => i.Value.ValueKind == JsonValueKind.String && i.Value.ValueEquals("red"));
            
            if (_checkForRedFlag && containsRedFlag) return 0;

            foreach (var property in element.EnumerateObject())
            {
                sum += SumProperty(property.Value);
            }

            return sum;
        }

        private int SumProperty(JsonElement propertyValue)
        {
            switch (propertyValue.ValueKind)
            {
                case JsonValueKind.Number:
                    return propertyValue.GetInt32();
                case JsonValueKind.Object:
                    return SumObject(propertyValue);
                case JsonValueKind.Array:
                    return SumArray(propertyValue);
                default:
                    return 0;
            }
        }
    }
}