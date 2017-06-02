using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serialization.ClassOfAnimals
{
    [Serializable]
    class Insects:Animals
    {
        public string GroupOfInsects { get; set; }

        public Insects(string weight, string growth, string typeOfFood, string colorOfEyes, string groupOfInsects)
            : base(weight, growth, typeOfFood, colorOfEyes)
        {
            GroupOfInsects = groupOfInsects;
        }

        public override List<string> GetInfo()
        {
            List<string> info = new List<string>();
            info.Add(Weight);
            info.Add(Growth);
            info.Add(TypeOfFood);
            info.Add(ColorOfEyes);
            info.Add(GroupOfInsects);
            return info;
        }

        public override void Change(List<string> items)
        {
            Weight = items[0];
            Growth = items[1];
            TypeOfFood = items[2];
            ColorOfEyes = items[3];
            GroupOfInsects = items[4];
        }
    }
}
