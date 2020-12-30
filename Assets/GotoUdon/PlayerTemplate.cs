using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace GotoUdon.Editor
{
    [System.Serializable]
    public class PlayerTemplate
    {
        private static readonly Random _random = new System.Random();

        private static readonly string[] nameGeneratorWords =
        {
            "Ozhy", "GodlyTree", "Siyuuukun", "Tamtam13 ", "iRuz", "Astcape", "Bocun", "Dar", "Prub", "Zellionir", "moebius29", "Senku", "Nywaa", "WibuSquire", "futcut [fy]",
            "Kuze Hibiki", "Schweine", "YuriCrimson-", "Reynald Edwin", "Arjunya", "Liliputzz", "Mr Bin", "Ai-Jello", "Crystalizze", "Steevo", "SacikoSaci", "Gopr0pik", "Konakaburi", "S54B32",
            "Reznya"
        };

        public string playerName;
        public GameObject avatarPrefab;
        public Transform spawnPoint;
        public bool hasVr;
        public bool joinByDefault;
        public int customId;


        public static PlayerTemplate CreateNewPlayer(bool firstOne)
        {
            HashSet<string> usedNamed = new HashSet<string>();
            foreach (PlayerTemplate instancePlayerTemplate in GotoUdonSettings.Instance.playerTemplates)
            {
                usedNamed.Add(instancePlayerTemplate.playerName);
            }

            string newName = GenerateName();
            while (usedNamed.Contains(newName))
            {
                newName += _random.Next(0, 99);
            }

            return new PlayerTemplate
            {
                playerName = newName,
                joinByDefault = firstOne,
                customId = -1
            };
        }

        private static string GenerateName()
        {
            int length = _random.Next(1, 2);
            string name = "";
            for (int i = 0; i < length; i++)
            {
                name += nameGeneratorWords[_random.Next(nameGeneratorWords.Length)];
            }

            return name;
        }
    }
}