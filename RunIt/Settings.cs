using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace RunIt
{
    class Settings
    {
        private string appDir = Path.GetDirectoryName(Application.ExecutablePath);
        private string customPath;

        private ExeConfigurationFileMap configFileMap2;
        private Configuration configFile2;
        private KeyValueConfigurationCollection settings2;

        public Settings()
        {
            customPath = Path.Combine(appDir, "settings.cfg");
        }

        public string CfgFile
        {
            set
            {
                if (value != null)
                {
                    try
                    {
                        string dir = Path.GetDirectoryName(value);
                        string file = Path.GetFileName(value);

                        if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                        customPath = Path.Combine(dir, file);
                    }

                    catch { }
                }
            }

            get
            {
                return customPath;
            }

        }

        public void OpenSettings()
        {
            try
            {
                configFileMap2 = new ExeConfigurationFileMap();
                configFileMap2.ExeConfigFilename = customPath;

                configFile2 = ConfigurationManager.OpenMappedExeConfiguration(configFileMap2, ConfigurationUserLevel.None);
                settings2 = configFile2.AppSettings.Settings;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void WriteSettings()
        {
            try
            {
                configFile2.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile2.AppSettings.SectionInformation.Name);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public string GetSetting(string key)
        {
            return GetSetting(key, "string", "");
        }

        public dynamic GetSetting(string key, string type, string def)
        {
            string result;

            try { result = settings2[key].Value ?? null; }
            catch { result = null; }

            if (type == "int")
            {
                if (result == null) return Convert.ToInt32(def);
                else return Convert.ToInt32(result);
            }

            if (type == "dec")
            {
                if (result == null) return Convert.ToDecimal(def);
                else return Convert.ToDecimal(result);
            }

            if (type == "timespan")
            {
                if (result == null) return TimeSpan.Parse(def);
                else return TimeSpan.Parse(result);
            }

            if (type == "float")
            {
                if (result == null) return float.Parse(def);
                else return float.Parse(result);
            }

            if (type == "double")
            {
                if (result == null) return double.Parse(def, CultureInfo.InvariantCulture);
                else return double.Parse(result, CultureInfo.InvariantCulture);
            }

            if (type == "bool")
            {
                if (result == null) return Convert.ToBoolean(def);
                else return Convert.ToBoolean(result);
            }

            if (type == "string")
            {
                if (result == null) return def;
                else return result;
            }

            else return result;
        }

        public void SetSetting(string key, string value)
        {
            try
            {
                if (settings2[key] == null)
                {
                    settings2.Add(key, value);
                }
                else
                {
                    settings2[key].Value = value;
                }
            }

            catch { }
        }

        public void EraseSetting(string key)
        {
            try
            {
                if (settings2[key] != null) settings2.Remove(key);
            }

            catch { }
        }

        public string LoadSetting(string key)
        {
            return LoadSetting(key, "string", "");
        }

        public dynamic LoadSetting(string key, string type, string def)
        {
            string result;

            try
            {
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = customPath;

                Configuration configFile = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                KeyValueConfigurationCollection settings = configFile.AppSettings.Settings;

                try { result = settings[key].Value ?? null; }
                catch { result = null; }
            }

            catch { result = null; }

            if (type == "int")
            {
                if (result == null) return Convert.ToInt32(def);
                else return Convert.ToInt32(result);
            }

            if (type == "dec")
            {
                if (result == null) return Convert.ToDecimal(def);
                else return Convert.ToDecimal(result);
            }

            if (type == "timespan")
            {
                if (result == null) return TimeSpan.Parse(def);
                else return TimeSpan.Parse(result);
            }

            if (type == "float")
            {
                if (result == null) return float.Parse(def);
                else return float.Parse(result);
            }

            if (type == "double")
            {
                if (result == null) return double.Parse(def, CultureInfo.InvariantCulture);
                else return double.Parse(result, CultureInfo.InvariantCulture);
            }

            if (type == "bool")
            {
                if (result == null) return Convert.ToBoolean(def);
                else return Convert.ToBoolean(result);
            }

            if (type == "string")
            {
                if (result == null) return def;
                else return result;
            }

            else return result;
        }

        public void SaveSetting(string key, string value)
        {
            try
            {
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = customPath;

                var configFile = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }

            catch { }
        }

        public void EraseSetting2(string key)
        {
            try
            {
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = customPath;

                var configFile = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                if (settings[key] != null)
                {
                    settings.Remove(key);
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }

            catch { }
        }


    }
}
