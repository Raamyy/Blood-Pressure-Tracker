using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Diet_Plan_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DietPlan" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DietPlan.svc or DietPlan.svc.cs at the Solution Explorer and start debugging.
    public class DietPlan : IDietPlan
    {
        /// <summary>
        /// Generate preferred diet plan for high pressure.
        /// </summary>
        /// <returns>Dictionary(string, string)Diet paln</returns>
        public Dictionary<string, string> GenerateHighPressureDiet()
        {
            Dictionary<string, string> diet = new Dictionary<string, string>();
            diet.Add("Leafy greens", "Potassium helps your kidneys get rid of more sodium through your urine. "
                + "This in turn lowers your blood pressure.");
            diet.Add("Berries", "Berries, especially blueberries, are rich in natural compounds called flavonoids. One "
                + "study found that consuming these compounds might prevent hypertension and help lower blood pressure.");
            diet.Add("Skim milk", "Skim milk is an excellent source of calcium and is low in fat. These are both important "
                + "elements of a diet for lowering blood pressure. You can also opt for yogurt if you don’t like milk.");
            diet.Add("Bananas", "Eating foods that are rich in potassium is better than taking supplements. Slice "
                + "a banana into your cereal or oatmeal for a potassium-rich addition.");
            diet.Add("Fish", "Fish are a great source of lean protein. Fatty fish like mackerel and salmon are high in "
                + "omega-3 fatty acids, which can lower blood pressure, reduce inflammation, and lower triglycerides.");
            diet.Add("Dark chocolate", "Dark chocolate contains more than 60 percent cocoa solids and has less sugar than "
                + "regular chocolate. You can add dark chocolate to yogurt or eat it with fruits.");

            return diet;
        }

        /// <summary>
        /// Generate preferred diet plan for low pressure.
        /// </summary>
        /// <returns>Dictionary(string, string)Diet paln</returns>
        public Dictionary<string, string> GenerateLowPressureDiet()
        {
            Dictionary<string, string> diet = new Dictionary<string, string>();
            diet.Add("More fluids", "Dehydration decreases blood volume, causing blood pressure to drop. "
                + "Staying hydrated is especially important when exercising.");
            diet.Add("Foods high in vitamin B-12", "Too little vitamin B-12 can lead to anemia, which can cause low blood "
                + "pressure. Foods high in B-12 include eggs, fortified cereals, and beef.");
            diet.Add("Foods high in folate", "Too little folate can have the same effect as too little vitamin B-12. Examples "
                + "of folate-rich foods include asparagus, garbanzo beans, and liver.");
            diet.Add("Salt", "Salty foods can increase blood pressure. Try eating canned soup, smoked fish, "
                + "cottage cheese, and olives.");
            diet.Add("Licorice tea", "Licorice may reduce the effect of aldosterone, the hormone that helps regulate the impact "
                + "of salt on the body. Drinking licorice tea can help increase blood pressure rates.");
            diet.Add("Caffeine", "Coffee and caffeinated tea may temporarily spike blood pressure by stimulating the "
                + "cardiovascular system and boosting your heart rate.");

            return diet;
        }

        /// <summary>
        /// Generate preferred diet plan for normal pressure.
        /// </summary>
        /// <returns>Dictionary(string, string)Diet paln</returns>
        public Dictionary<string, string> GenerateNormalPressureDiet()
        {
            Dictionary<string, string> diet = new Dictionary<string, string>();
            diet.Add("Eat a balanced salt", "For many people, eating a low-sodium diet can help "
                + "keep blood pressure normal.");
            diet.Add("Limit the alcohol", "Drinking too much alcohol can lead to high blood pressure. "
                + "For women, that means no more than one drink a day, and for men, no more than two.");
            diet.Add("Eat a balanced diet", "Eating healthful foods can help keep your blood pressure under control");
            diet.Add("Drink water", "Drinking more water can help increase blood volume, which can aleviate "
                + "one of the potential causes of low blood pressure.");
            diet.Add("Eat small meals frequently", "Eating smaller, more frequent meals throughout the day may help "
                + "with low blood pressure.");

            return diet;
        }

        /// <summary>
        /// Get the type of blood pressure.
        /// </summary>
        /// <param name="systolic">High number of blood pressure</param>
        /// <param name="diastolic">Low number of blood pressure</param>
        /// <returns>(string)Pressure type</returns>
        public string GetBloodPressureType(uint systolic, uint diastolic)
        {
            if (systolic >= 70 && diastolic >= 40)
            {
                if (systolic <= 90 && diastolic <= 60)
                    return "low";
                else if (systolic <= 130 && diastolic <= 85)
                    return "normal";
                else if (systolic < 200 && diastolic < 100)
                    return "high";
                else
                    return "invalid";
            }

            return "invalid";
        }

        /// <summary>
        /// Get preferred diet plan based on the type of blood pressure measurement.
        /// </summary>
        /// <param name="systolic">High number of blood pressure</param>
        /// <param name="diastolic">Low number of blood pressure</param>
        /// <returns>Dictionary(string, string)Diet paln</returns>
        public Dictionary<string, string> GetPreferDietPlan(uint systolic, uint diastolic)
        {
            string pressureType = GetBloodPressureType(systolic, diastolic);
            if (pressureType == "low")
                return GenerateLowPressureDiet();
            else if (pressureType == "normal")
                return GenerateNormalPressureDiet();
            else if (pressureType == "high")
                return GenerateHighPressureDiet();
            else
                throw new ArgumentException("Invalid blood pressure measurement.");
        }
    }
}
