using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunIt
{
    public partial class FormSettings
    {
        private void loadSettings()
        {
            try
            {
                string appName = "ak_start";
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (rk.GetValue(appName, "").ToString() != "") checkRunAutomatically.Checked = true;
                else checkRunAutomatically.Checked = false;
            }

            catch { }

            settings.OpenSettings();
            txtShortcutFolder.Text = settings.GetSetting("ShortcutFolder");

            txtHotkey.Text = settings.GetSetting("Hotkey");
            checkHotkeyAlt.Checked = settings.GetSetting("HotkeyAlt", "bool", "false");
            checkHotkeyCtrl.Checked = settings.GetSetting("HotkeyCtrl", "bool", "false");
            checkHotkeyShift.Checked = settings.GetSetting("HotkeyShift", "bool", "false");

            numericWaitingTime.Value = settings.GetSetting("MouseWaitingTime", "int", "200");
            numericLeftRight.Value = settings.GetSetting("MouseLeftRightEdge", "int", "10");
            numericTopBottom.Value = settings.GetSetting("MouseTopBottomEdge", "int", "10");

            checkTop.Checked = settings.GetSetting("MouseTop", "bool", "false");
            checkBottom.Checked = settings.GetSetting("MouseBottom", "bool", "false");
            checkLeft.Checked = settings.GetSetting("MouseLeft", "bool", "false");
            checkRight.Checked = settings.GetSetting("MouseRight", "bool", "false");

            checkTopLeft.Checked = settings.GetSetting("MouseTopLeft", "bool", "false");
            checkTopRight.Checked = settings.GetSetting("MouseTopRight", "bool", "false");
            checkBottomLeft.Checked = settings.GetSetting("MouseBottomLeft", "bool", "false");
            checkBottomRight.Checked = settings.GetSetting("MouseBottomRight", "bool", "false");


            numericEdgeMargin.Value = settings.GetSetting("EdgeMargin", "int", "10");

            radioTop.Checked = settings.GetSetting("LocationTop", "bool", "false");
            radioBottom.Checked = settings.GetSetting("LocationBottom", "bool", "false");
            radioLeft.Checked = settings.GetSetting("LocationLeft", "bool", "false");
            radioRight.Checked = settings.GetSetting("LocationRight", "bool", "false");

            radioTopLeft.Checked = settings.GetSetting("LocationTopLeft", "bool", "false");
            radioTopRight.Checked = settings.GetSetting("LocationTopRight", "bool", "false");
            radioBottomLeft.Checked = settings.GetSetting("LocationBottomLeft", "bool", "false");
            radioBottomRight.Checked = settings.GetSetting("LocationBottomRight", "bool", "false");

            radioMousePosition.Checked = settings.GetSetting("LocationMousePosition", "bool", "false");
            radioCustomPosition.Checked = settings.GetSetting("LocationCustomPosition", "bool", "false");
            radioCenter.Checked = settings.GetSetting("LocationCenter", "bool", "true");


            txtColorBackground.Text = settings.GetSetting("ColorBackground", "string", "#1F1F1F");
            txtColorGroupBackground.Text = settings.GetSetting("ColorGroupBackground", "string", "#161616");
            txtColorShortcutBackground.Text = settings.GetSetting("ColorShortcutBackground", "string", "#333333");
            txtColorShortcutBackgroundHover.Text = settings.GetSetting("ColorShortcutBackgroundHover", "string", "#3F3F3F");
            txtColorTooltipBackground.Text = settings.GetSetting("ColorToolTipBackground", "string", "#3F3F3F");

            txtColorGroupFont.Text = settings.GetSetting("ColorGroupFont", "string", "#ADADAD");
            txtColorShortcutFont.Text = settings.GetSetting("ColorShortcutFont", "string", "#DADADA");
            txtColorTooltipFont.Text = settings.GetSetting("ColorShortcutFont", "string", "#DADADA");


            if (txtColorBackground.Text == "") txtColorBackground.Text = "#1F1F1F";
            if (txtColorGroupBackground.Text == "") txtColorGroupBackground.Text = "#161616";
            if (txtColorShortcutBackground.Text == "") txtColorShortcutBackground.Text = "#333333";
            if (txtColorShortcutBackgroundHover.Text == "") txtColorShortcutBackgroundHover.Text = "#3F3F3F";
            if (txtColorTooltipBackground.Text == "") txtColorTooltipBackground.Text = "#3F3F3F";
            if (txtColorGroupFont.Text == "") txtColorGroupFont.Text = "#ADADAD";
            if (txtColorShortcutFont.Text == "") txtColorShortcutFont.Text = "#DADADA";
            if (txtColorTooltipFont.Text == "") txtColorTooltipFont.Text = "#DADADA";

            comboFontGroup.Text = settings.GetSetting("FontGroup", "string", "Segoe UI");
            numericFontGroupSize.Value = settings.GetSetting("FontGroupSize", "int", "12");
            checkFontGroupBold.Checked = settings.GetSetting("FontGroupBold", "bool", "false");
            checkFontGroupItalic.Checked = settings.GetSetting("FontGroupItalic", "bool", "false");

            comboFontShortcut.Text = settings.GetSetting("FontShortcut", "string", "Microsoft Sans Serif");
            numericFontShortcutSize.Value = settings.GetSetting("FontShortcutSize", "int", "8");
            checkFontShortcutBold.Checked = settings.GetSetting("FontShortcutBold", "bool", "false");
            checkFontShortcutItalic.Checked = settings.GetSetting("FontShortcutItalic", "bool", "false");


            numericOuterMargin.Value = settings.GetSetting("OuterMargin", "int", "0");

            numericGroupMargin.Value = settings.GetSetting("GroupMargin", "int", "10");
            numericGroupLabel.Value = settings.GetSetting("GroupLabelHeight", "int", "23");

            numericShortcutMargin.Value = settings.GetSetting("ShortcutMargin", "int", "10");
            numericShortcutLabelHeight.Value = settings.GetSetting("ShortcutLabelHeight", "int", "26");
            numericShortcutBoxSize.Value = settings.GetSetting("ShortcutBoxSize", "int", "80");
            numericShortcutIconSize.Value = settings.GetSetting("ShortcutIconSize", "int", "32");

            numericToolTipMarginTop.Value = settings.GetSetting("ToolTipMarginTop", "int", "2");
            numericToolTipPaddingWidth.Value = settings.GetSetting("ToolTipPaddingWidth", "int", "0");
            numericToolTipPaddingHeight.Value = settings.GetSetting("ToolTipPaddingHeight", "int", "0");

            numericHorizontal.Value = settings.GetSetting("HorizontalShortcuts", "int", "4");

            checkShowShortcutLabels.Checked = settings.GetSetting("ShowShortcutLabels", "bool", "true");
            checkShowShortcutTooltips.Checked = settings.GetSetting("ShowShortcutTooltips", "bool", "false");

            comboGroupTopicAlign.Text = settings.GetSetting("GroupTopicAlign", "string", "Left");
            comboShortcutTextAlign.Text = settings.GetSetting("ShortcutTextAlign", "string", "Middle");

            numericOpacity.Value = trackOpacity.Value = (int)(100 * settings.GetSetting("Opacity", "dec", "0,96"));
            checkFade.Checked = settings.GetSetting("Fade", "bool", "true");
            numericFadeSpeed.Value = trackFadeSpeed.Value = settings.GetSetting("FadeSpeed", "int", "15");
        }

        private void saveSettings()
        {
            try
            {
                string appName = "ak_start";
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (checkRunAutomatically.Checked) rk.SetValue(appName, "\"" + Application.ExecutablePath.ToString().Replace("/", "\\") + "\"");
                else rk.DeleteValue(appName, false);
            }

            catch { }

            settings.SetSetting("ShortcutFolder", txtShortcutFolder.Text);

            settings.SetSetting("HotKey", txtHotkey.Text);
            settings.SetSetting("HotKeyAlt", checkHotkeyAlt.Checked.ToString());
            settings.SetSetting("HotKeyCtrl", checkHotkeyCtrl.Checked.ToString());
            settings.SetSetting("HotKeyShift", checkHotkeyShift.Checked.ToString());

            settings.SetSetting("MouseWaitingTime", numericWaitingTime.Value.ToString());
            settings.SetSetting("MouseLeftRightEdge", numericLeftRight.Value.ToString());
            settings.SetSetting("MouseTopBottomEdge", numericTopBottom.Value.ToString());

            settings.SetSetting("MouseTop", checkTop.Checked.ToString());
            settings.SetSetting("MouseBottom", checkBottom.Checked.ToString());
            settings.SetSetting("MouseLeft", checkLeft.Checked.ToString());
            settings.SetSetting("MouseRight", checkRight.Checked.ToString());

            settings.SetSetting("MouseTopLeft", checkTopLeft.Checked.ToString());
            settings.SetSetting("MouseTopRight", checkTopRight.Checked.ToString());
            settings.SetSetting("MouseBottomLeft", checkBottomLeft.Checked.ToString());
            settings.SetSetting("MouseBottomRight", checkBottomRight.Checked.ToString());


            settings.SetSetting("EdgeMargin", numericEdgeMargin.Value.ToString());

            settings.SetSetting("LocationTop", radioTop.Checked.ToString());
            settings.SetSetting("LocationBottom", radioBottom.Checked.ToString());
            settings.SetSetting("LocationLeft", radioLeft.Checked.ToString());
            settings.SetSetting("LocationRight", radioRight.Checked.ToString());

            settings.SetSetting("LocationTopLeft", radioTopLeft.Checked.ToString());
            settings.SetSetting("LocationTopRight", radioTopRight.Checked.ToString());
            settings.SetSetting("LocationBottomLeft", radioBottomLeft.Checked.ToString());
            settings.SetSetting("LocationBottomRight", radioBottomRight.Checked.ToString());

            settings.SetSetting("LocationMousePosition", radioMousePosition.Checked.ToString());
            settings.SetSetting("LocationCustomPosition", radioCustomPosition.Checked.ToString());
            settings.SetSetting("LocationCenter", radioCenter.Checked.ToString());


            if (validColor(txtColorBackground.Text)) settings.SetSetting("ColorBackground", txtColorBackground.Text);
            else settings.EraseSetting("ColorBackground");

            if (validColor(txtColorGroupBackground.Text)) settings.SetSetting("ColorGroupBackground", txtColorGroupBackground.Text);
            else settings.EraseSetting("ColorGroupBackground");

            if (validColor(txtColorShortcutBackground.Text)) settings.SetSetting("ColorShortcutBackground", txtColorShortcutBackground.Text);
            else settings.EraseSetting("ColorShortcutBackground");

            if (validColor(txtColorShortcutBackgroundHover.Text)) settings.SetSetting("ColorShortcutBackgroundHover", txtColorShortcutBackgroundHover.Text);
            else settings.EraseSetting("ColorShortcutBackgroundHover");

            if (validColor(txtColorTooltipBackground.Text)) settings.SetSetting("ColorToolTipBackground", txtColorTooltipBackground.Text);
            else settings.EraseSetting("ColorToolTipBackground");


            if (validColor(txtColorGroupFont.Text)) settings.SetSetting("ColorGroupFont", txtColorGroupFont.Text);
            else settings.EraseSetting("ColorGroupFont");

            if (validColor(txtColorShortcutFont.Text)) settings.SetSetting("ColorShortcutFont", txtColorShortcutFont.Text);
            else settings.EraseSetting("ColorShortcutFont");

            if (validColor(txtColorTooltipFont.Text)) settings.SetSetting("ColorToolTipFont", txtColorTooltipFont.Text);
            else settings.EraseSetting("ColorToolTipFont");


            if (validFont(comboFontGroup.Text, (float)numericFontGroupSize.Value, checkFontGroupBold.Checked, checkFontGroupItalic.Checked))
            {
                settings.SetSetting("FontGroup", comboFontGroup.Text);
                settings.SetSetting("FontGroupSize", numericFontGroupSize.Value.ToString());
                settings.SetSetting("FontGroupBold", checkFontGroupBold.Checked.ToString());
                settings.SetSetting("FontGroupItalic", checkFontGroupItalic.Checked.ToString());
            }

            else
            {
                settings.EraseSetting("FontGroup");
                settings.EraseSetting("FontGroupSize");
                settings.EraseSetting("FontGroupBold");
                settings.EraseSetting("FontGroupItalic");
            }


            if (validFont(comboFontShortcut.Text, (float)numericFontShortcutSize.Value, checkFontShortcutBold.Checked, checkFontShortcutItalic.Checked))
            {
                settings.SetSetting("FontShortcut", comboFontShortcut.Text);
                settings.SetSetting("FontShortcutSize", numericFontShortcutSize.Value.ToString());
                settings.SetSetting("FontShortcutBold", checkFontShortcutBold.Checked.ToString());
                settings.SetSetting("FontShortcutItalic", checkFontShortcutItalic.Checked.ToString());
            }

            else
            {
                settings.EraseSetting("FontShortcut");
                settings.EraseSetting("FontShortcutSize");
                settings.EraseSetting("FontShortcutBold");
                settings.EraseSetting("FontShortcutItalic");
            }


            settings.SetSetting("OuterMargin", numericOuterMargin.Value.ToString());

            settings.SetSetting("GroupMargin", numericGroupMargin.Value.ToString());
            settings.SetSetting("GroupLabelHeight", numericGroupLabel.Value.ToString());

            settings.SetSetting("ShortcutMargin", numericShortcutMargin.Value.ToString());
            settings.SetSetting("ShortcutLabelHeight", numericShortcutLabelHeight.Value.ToString());
            settings.SetSetting("ShortcutBoxSize", numericShortcutBoxSize.Value.ToString());
            settings.SetSetting("ShortcutIconSize", numericShortcutIconSize.Value.ToString());

            settings.SetSetting("ToolTipMarginTop", numericToolTipMarginTop.Value.ToString());
            settings.SetSetting("ToolTipPaddingWidth", numericToolTipPaddingWidth.Value.ToString());
            settings.SetSetting("ToolTipPaddingHeight", numericToolTipPaddingHeight.Value.ToString());

            settings.SetSetting("HorizontalShortcuts", numericHorizontal.Value.ToString());

            settings.SetSetting("ShowShortcutLabels", checkShowShortcutLabels.Checked.ToString());
            settings.SetSetting("ShowShortcutTooltips", checkShowShortcutTooltips.Checked.ToString());

            settings.SetSetting("GroupTopicAlign", comboGroupTopicAlign.Text);
            settings.SetSetting("ShortcutTextAlign", comboShortcutTextAlign.Text);

            settings.SetSetting("Opacity", (numericOpacity.Value / 100).ToString());
            settings.SetSetting("Fade", checkFade.Checked.ToString());
            settings.SetSetting("FadeSpeed", numericFadeSpeed.Value.ToString());


            settings.WriteSettings();
        }



    }
}
