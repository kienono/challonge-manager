﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5485
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChallongeManager.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ladose")]
        public string Challonge_ID {
            get {
                return ((string)(this["Challonge_ID"]));
            }
            set {
                this["Challonge_ID"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Challonge_APIkey {
            get {
                return ((string)(this["Challonge_APIkey"]));
            }
            set {
                this["Challonge_APIkey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2X\r\n3rd Strike/3.3\r\nCvS2/CVS2\r\nSSFIV/SSF4/USF4/USFIV/SF4\r\nGarou\r\nKoF98/KOF 98\r\nKo" +
            "F13/KOF XIII/ KOF 13\r\nKarnov\r\nGGXrd/GG3/XRD\r\nSSBM")]
        public string Challonge_GameList {
            get {
                return ((string)(this["Challonge_GameList"]));
            }
            set {
                this["Challonge_GameList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("LaDOSE.net - Ranking")]
        public string Challonge_SearchTag {
            get {
                return ((string)(this["Challonge_SearchTag"]));
            }
            set {
                this["Challonge_SearchTag"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("[FORFAIT]")]
        public string ForfeitTag {
            get {
                return ((string)(this["ForfeitTag"]));
            }
            set {
                this["ForfeitTag"] = value;
            }
        }
    }
}
