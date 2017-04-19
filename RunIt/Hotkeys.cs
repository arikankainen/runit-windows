using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunIt
{
    public static class Hotkeys
    {
        public static int GetGlobalHotkeyModNumber(string keyname)
        {
            int i = 0;
            if (keyname.IndexOf("Alt") != -1) i += 1;
            if (keyname.IndexOf("Ctrl") != -1) i += 2;
            if (keyname.IndexOf("Control") != -1) i += 2;
            if (keyname.IndexOf("Shift") != -1) i += 4;
            if (keyname.IndexOf("Win") != -1) i += 8;
            return i;
        }

        public static string GetSendkeyModChars(string keyname)
        {
            string i = null;
            if (keyname.IndexOf("Alt") != -1) i += "%";
            if (keyname.IndexOf("Ctrl") != -1) i += "^";
            if (keyname.IndexOf("Control") != -1) i += "^";
            if (keyname.IndexOf("Shift") != -1) i += "+";
            return i;
        }

        public static string GetSendkeyChar(string i)
        {
            if (i == "D1") i = "1";
            if (i == "D2") i = "2";
            if (i == "D3") i = "3";
            if (i == "D4") i = "4";
            if (i == "D5") i = "5";
            if (i == "D6") i = "6";
            if (i == "D7") i = "7";
            if (i == "D8") i = "8";
            if (i == "D9") i = "9";
            if (i == "D0") i = "0";
            return i.ToLower();
        }

        public static string GetHotkeyModifiers(string keys)
        {
            string mod = null;
            bool first = true;

            if (keys.IndexOf("Shift") != -1)
            {
                if (!first) mod += ", ";
                mod += "Shift";
                first = false;
            }

            if (keys.IndexOf("Ctrl") != -1)
            {
                if (!first) mod += ", ";
                mod += "Control";
                first = false;
            }

            if (keys.IndexOf("Alt") != -1)
            {
                if (!first) mod += ", ";
                mod += "Alt";
                first = false;
            }

            return mod;
        }

        public static string GetHotkeyModifiersGlobal(string keys)
        {
            string mod = null;
            bool first = true;

            if (keys.IndexOf("Alt") != -1)
            {
                if (!first) mod += ", ";
                mod += "Alt";
                first = false;
            }

            if (keys.IndexOf("Ctrl") != -1)
            {
                if (!first) mod += ", ";
                mod += "Control";
                first = false;
            }

            if (keys.IndexOf("Shift") != -1)
            {
                if (!first) mod += ", ";
                mod += "Shift";
                first = false;
            }

            return mod;
        }

        public static string GetHotkeyKey(string keys)
        {
            return keys.Replace("Shift", "").Replace("Ctrl", "").Replace("Alt", "").Replace("+", "");
        }

        public static string ValueListToKeyList(string value)
        {
            if (value != "")
            {
                List<string> hotkeyList = value.Split('|').ToList<string>();
                bool first = true;
                string hotkey = "";

                foreach (string key in hotkeyList)
                {
                    if (first)
                    {
                        hotkey = Hotkeys.GetKeyName(key);
                        first = false;
                    }
                    else hotkey += "+" + Hotkeys.GetKeyName(key);
                }

                return hotkey;
            }
            return "";

        }

        public static string KeyListToValueList(string value)
        {
            if (value != "")
            {
                List<string> hotkeyList = value.Split('+').ToList<string>();
                bool first = true;
                string hotkey = "";

                foreach (string key in hotkeyList)
                {
                    if (first)
                    {
                        hotkey = Hotkeys.GetValue(key);
                        first = false;
                    }
                    else hotkey += "|" + Hotkeys.GetValue(key);
                }

                return hotkey;
            }
            return "";

        }

        public static string GetKeyName(string keyValue)
        {
            string keyString = ((Keys)Enum.Parse(typeof(Keys), keyValue)).ToString();

            switch (keyValue)
            {
                case "16":
                    keyString = "Shift";
                    break;
                case "17":
                    keyString = "Ctrl";
                    break;
                case "18":
                    keyString = "Alt";
                    break;
            }

            return keyString;
        }

        public static string GetValue(string keyString)
        {
            string keyValue = "";

            switch (keyString)
            {
                case "Shift":
                    keyValue = "16";
                    break;
                case "Ctrl":
                    keyValue = "17";
                    break;
                case "Alt":
                    keyValue = "18";
                    break;
                default:
                    keyValue = ((int)Enum.Parse(typeof(Keys), keyString, true)).ToString();
                    break;
            }

            return keyValue;
        }

    }
}
