using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serialization.ClassOfAnimals
{
    [Serializable]
    class Fishs:Animals
    {
        public string ColorOfScales { get; set; }

        public Fishs(string weight, string growth, string typeOfFood, string colorOfEyes, string colorOfsScales): base(weight, growth, typeOfFood, colorOfEyes)
        {
            ColorOfScales = colorOfsScales;
        }

        public override List<string> GetInfo()
        {
            List<string> info = new List<string>();
            info.Add(Weight);
            info.Add(Growth);
            info.Add(TypeOfFood);
            info.Add(ColorOfEyes);
            info.Add(ColorOfScales);
            return info;
        }

        public override void Change(List<string> items)
        {
            Weight = items[0];
            Growth = items[1];
            TypeOfFood = items[2];
            ColorOfEyes = items[3];
            ColorOfScales = items[4];
        }
    }
}
