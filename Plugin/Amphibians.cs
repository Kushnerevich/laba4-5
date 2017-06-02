using System.Collections.Generic;
using Serialization.ClassOfAnimals;
using System;


namespace MyPlugin
{
    [Serializable]
    class Amphibians:Animals
    {
        public string Breath{get;set;}

        public Amphibians(string weight, string growth, string typeOfFood, string colorOfEyes, string breath): base(weight, growth, typeOfFood, colorOfEyes)
        {
            Breath = breath;
        }

        public override List<string> GetInfo()
        {
            List<string> info = new List<string>();
            info.Add(this.Weight);
            info.Add(this.Growth);
            info.Add(this.TypeOfFood);
            info.Add(this.ColorOfEyes);
            info.Add(this.Breath);
            return info;
        }
        public override void Change(List<string> items)
        {
            this.Weight = items[0];
            this.Growth = items[1];
            this.TypeOfFood = items[2];
            this.ColorOfEyes = items[3];
            this.Breath = items[4];
        }
    }
}
