using UnityEngine;
using System.Collections.Generic;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            // AS01_CountWords();
            // AS02_CountNumber();
            // AS03_CheckValidBrackets();
            // AS04_PrintReverseLinkedList();
            // AS05_FindMiddleElement();
            // AS06_MergeDictionaries();
            // AS07_RemoveDuplicatesFromLinkedList();
            // AS08_TopFrequentNumber();
            // AS09_PlayerInventory();
            // AS10_GameEventQueue();
            // AS11_PlayerStatsTracker();
        }

        #region Assignment

        [Header("AS01 - Count Words")]
        [SerializeField] private string[] as01Words;

        public void AS01_CountWords()
        {
            string[] words = as01Words;
            if (words == null) return;

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }

            foreach (KeyValuePair<string, int> pair in wordCount)
            {
                Debug.Log("word: " + pair.Key + " count: " + pair.Value);
            }
        }

        [Header("AS02 - Count Number")]
        [SerializeField] private int[] as02Numbers;

        public void AS02_CountNumber()
        {
            int[] numbers = as02Numbers;
            if (numbers == null) return;

            Dictionary<int, int> numCount = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int num = numbers[i];
                if (numCount.ContainsKey(num))
                {
                    numCount[num]++;
                }
                else
                {
                    numCount[num] = 1;
                }
            }

            foreach (KeyValuePair<int, int> pair in numCount)
            {
                Debug.Log("number: " + pair.Key + " count: " + pair.Value);
            }
        }

        [Header("AS03 - Check Valid Brackets")]
        [SerializeField] private string as03Input;

        public void AS03_CheckValidBrackets()
        {
            string input = as03Input;
            if (input == null) return;

            Stack<char> stack = new Stack<char>();
            bool isValid = true;

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                // ถ้าเจอวงเล็บเปิด ให้ดันเข้า Stack
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                // ถ้าเจอวงเล็บปิด
                else if (c == ')' || c == '}' || c == ']')
                {
                    // ถ้า Stack ว่าง แสดงว่าไม่มีวงเล็บเปิดมารองรับ -> ไม่ถูกต้อง
                    if (stack.Count == 0)
                    {
                        isValid = false;
                        break;
                    }

                    char top = stack.Pop();
                    // ตรวจสอบว่าวงเล็บปิดตรงกับวงเล็บเปิดล่าสุดหรือไม่
                    if ((c == ')' && top != '(') ||
                        (c == '}' && top != '{') ||
                        (c == ']' && top != '['))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            // ถ้าตรวจจนจบแล้วยังมีวงเล็บเปิดค้างอยู่ใน Stack แสดงว่าปิดไม่ครบ
            if (stack.Count > 0)
            {
                isValid = false;
            }

            Debug.Log("Is Valid: " + isValid);
        }

        [Header("AS04 - Print Reverse Linked List")]
        [SerializeField] private IntLinkedListInput as04List = new IntLinkedListInput();

        public void AS04_PrintReverseLinkedList()
        {
            LinkedList<int> list = as04List.GetLinkedList();
            if (list == null || list.Count == 0) return;

            // เริ่มอ่านจาก Node สุดท้าย (Last)
            LinkedListNode<int> currentNode = list.Last;

            // ถอยหลังไปทีละ Node จนกว่าจะถึงจุดเริ่มต้น (null)
            while (currentNode != null)
            {
                Debug.Log(currentNode.Value);
                currentNode = currentNode.Previous;
            }
        }

        [Header("AS05 - Find Middle Element")]
        [SerializeField] private StringLinkedListInput as05List = new StringLinkedListInput();

        public void AS05_FindMiddleElement()
        {
            LinkedList<string> list = as05List.GetLinkedList();
            if (list == null || list.Count == 0) return;

            LinkedListNode<string> slow = list.First;
            LinkedListNode<string> fast = list.First;

            // เลื่อน fast ไปทีละ 2 ขั้น และ slow ไปทีละ 1 ขั้น
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            if (slow != null)
            {
                Debug.Log("Middle element: " + slow.Value);
            }
        }

        [Header("AS06 - Merge Dictionaries")]
        [SerializeField] private StringIntDictionaryInput as06FirstDictionary = new StringIntDictionaryInput();
        [SerializeField] private StringIntDictionaryInput as06SecondDictionary = new StringIntDictionaryInput();

        public void AS06_MergeDictionaries()
        {
            Dictionary<string, int> dict1 = as06FirstDictionary.GetDictionary();
            Dictionary<string, int> dict2 = as06SecondDictionary.GetDictionary();

            if (dict1 == null || dict2 == null) return;

            // 1. สร้าง Dictionary ใหม่สำหรับเก็บผลลัพธ์ที่รวมแล้ว
            Dictionary<string, int> mergedDict = new Dictionary<string, int>();

            // 2. คัดลอกข้อมูลทั้งหมดจาก dict1 ลงใน mergedDict
            foreach (KeyValuePair<string, int> pair in dict1)
            {
                mergedDict[pair.Key] = pair.Value;
            }

            // 3. วนลูปนำข้อมูลจาก dict2 มารวม
            foreach (KeyValuePair<string, int> pair in dict2)
            {
                if (mergedDict.ContainsKey(pair.Key))
                {
                    // ถ้ามี Key ซ้ำ ให้เอา Value บวกเพิ่มเข้าไป
                    mergedDict[pair.Key] += pair.Value;
                }
                else
                {
                    // ถ้ายังไม่มี Key นี้ ให้ใส่เข้าไปใหม่
                    mergedDict[pair.Key] = pair.Value;
                }
            }

            // 4. แสดงผลข้อมูลหลังจากการ Merge
            foreach (KeyValuePair<string, int> pair in mergedDict)
            {
                Debug.Log("Key: " + pair.Key + ", Value: " + pair.Value);
            }
        }

        [Header("AS07 - Remove Duplicates From Linked List")]
        [SerializeField] private IntLinkedListInput as07List = new IntLinkedListInput();

        public void AS07_RemoveDuplicatesFromLinkedList()
        {
            LinkedList<int> list = as07List.GetLinkedList();
            if (list == null || list.Count == 0) return;

            HashSet<int> seen = new HashSet<int>();
            LinkedListNode<int> current = list.First;

            while (current != null)
            {
                LinkedListNode<int> nextNode = current.Next;

                // ถ้าเคยเจอเลขนี้แล้ว ให้ลบ Node ปัจจุบันออก
                if (seen.Contains(current.Value))
                {
                    list.Remove(current);
                }
                else
                {
                    // ถ้ายังไม่เคยเจอ ให้เพิ่มลงใน HashSet
                    seen.Add(current.Value);
                }

                current = nextNode;
            }

            // แสดงผลข้อมูลที่เหลือใน LinkedList หลังลบตัวซ้ำ
            foreach (int item in list)
            {
                Debug.Log(item);
            }
        }

        [Header("AS08 - Top Frequent Number")]
        [SerializeField] private int[] as08Numbers;

        public void AS08_TopFrequentNumber()
        {
            int[] numbers = as08Numbers;
            if (numbers == null || numbers.Length == 0) return;

            // 1. นับจำนวนครั้งที่แต่ละตัวเลขปรากฏ
            Dictionary<int, int> counts = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                int num = numbers[i];
                if (counts.ContainsKey(num))
                {
                    counts[num]++;
                }
                else
                {
                    counts[num] = 1;
                }
            }

            // 2. ค้นหาตัวเลขที่มีจำนวนครั้งมากที่สุด
            int topNum = 0;
            int maxCount = -1;

            foreach (KeyValuePair<int, int> pair in counts)
            {
                if (pair.Value > maxCount)
                {
                    maxCount = pair.Value;
                    topNum = pair.Key;
                }
            }

            // 3. แสดงผลตัวเลขที่ถี่ที่สุดและจำนวนครั้ง
            Debug.Log("Most frequent number: " + topNum + " (Count: " + maxCount + ")");
        }

        [Header("AS09 - Player Inventory")]
        [SerializeField] private StringIntDictionaryInput as09Inventory = new StringIntDictionaryInput();
        [SerializeField] private string as09ItemName;
        [SerializeField] private int as09Quantity;

        public void AS09_PlayerInventory()
        {
            Dictionary<string, int> inventory = as09Inventory.GetDictionary();
            string itemName = as09ItemName;
            int quantity = as09Quantity;

            if (inventory == null || string.IsNullOrEmpty(itemName)) return;

            // อัปเดตหรือเพิ่มไอเทมในคลัง
            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName] += quantity;
            }
            else
            {
                inventory[itemName] = quantity;
            }

            // แสดงผลไอเทมทั้งหมดในคลัง
            foreach (KeyValuePair<string, int> pair in inventory)
            {
                Debug.Log("Item: " + pair.Key + ", Quantity: " + pair.Value);
            }
        }

        [Header("AS10 - Game Event Queue")]
        [SerializeField] private GameEventLinkedListInput as10EventQueue = new GameEventLinkedListInput();

        public void AS10_GameEventQueue()
        {
            LinkedList<GameEvent> eventQueue = as10EventQueue.GetLinkedList();
            if (eventQueue == null || eventQueue.Count == 0) return;

            // ประมวลผลเหตุการณ์ในคิวจากโหนดแรกไปเรื่อยๆ จนกว่าคิวจะว่าง
            while (eventQueue.Count > 0)
            {
                GameEvent currentEvent = eventQueue.First.Value;

                // แสดงผลข้อมูลเหตุการณ์ (อาจใช้วิธีเรียก Method หรือแสดงชื่อ Event)
                Debug.Log("Processing Event: " + currentEvent.ToString());

                // ลบเหตุการณ์ที่ประมวลผลแล้วออกจากคิว
                eventQueue.RemoveFirst();
            }
        }

        [Header("AS11 - Player Stats Tracker")]
        [SerializeField] private StringIntDictionaryInput as11PlayerStats = new StringIntDictionaryInput();
        [SerializeField] private string as11StatName;
        [SerializeField] private int as11Value;

        public void AS11_PlayerStatsTracker()
        {
            Dictionary<string, int> playerStats = as11PlayerStats.GetDictionary();
            string statName = as11StatName;
            int value = as11Value;

            if (playerStats == null || string.IsNullOrEmpty(statName)) return;

            // อัปเดตค่าเดิม หรือเพิ่ม ค่าสถานะ ใหม่ลงใน Dictionary
            playerStats[statName] = value;

            // แสดงผลค่าสถานะ ทั้งหมดของผู้เล่น
            foreach (KeyValuePair<string, int> stat in playerStats)
            {
                Debug.Log("Stat: " + stat.Key + " = " + stat.Value);
            }
        }

        #endregion
    }
}