﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CommonTests.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.7.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("{D65231B0-B2F1-4857-A4CE-A8E7C6EA7D27}\\WindowsPowerShell\\v1.0\\powershell.exe")]
        public string NotificationAppID {
            get {
                return ((string)(this["NotificationAppID"]));
            }
            set {
                this["NotificationAppID"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("..\\..\\img\\favicon.ico")]
        public string NotificationIconPath {
            get {
                return ((string)(this["NotificationIconPath"]));
            }
            set {
                this["NotificationIconPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".\\IOTest")]
        public string IODirectoryPath {
            get {
                return ((string)(this["IODirectoryPath"]));
            }
            set {
                this["IODirectoryPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".\\IOTest")]
        public string IOFilePath {
            get {
                return ((string)(this["IOFilePath"]));
            }
            set {
                this["IOFilePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("IOTest.txt")]
        public string IOFileName {
            get {
                return ((string)(this["IOFileName"]));
            }
            set {
                this["IOFileName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".\\IOTest\\")]
        public string IODirectoryPathExt {
            get {
                return ((string)(this["IODirectoryPathExt"]));
            }
            set {
                this["IODirectoryPathExt"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".\\Log")]
        public string LogFilePath {
            get {
                return ((string)(this["LogFilePath"]));
            }
            set {
                this["LogFilePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("LogTest.log")]
        public string LogFileName {
            get {
                return ((string)(this["LogFileName"]));
            }
            set {
                this["LogFileName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".\\ExTest")]
        public string ExFilePath {
            get {
                return ((string)(this["ExFilePath"]));
            }
            set {
                this["ExFilePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ErrorTest.log")]
        public string ExFileName {
            get {
                return ((string)(this["ExFileName"]));
            }
            set {
                this["ExFileName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("(local)\\\\SQL2014")]
        public string AppveyorSqlServerName {
            get {
                return ((string)(this["AppveyorSqlServerName"]));
            }
            set {
                this["AppveyorSqlServerName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("sa")]
        public string AppveyorSqlServerUser {
            get {
                return ((string)(this["AppveyorSqlServerUser"]));
            }
            set {
                this["AppveyorSqlServerUser"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Password12!")]
        public string AppveyorSqlServerPw {
            get {
                return ((string)(this["AppveyorSqlServerPw"]));
            }
            set {
                this["AppveyorSqlServerPw"] = value;
            }
        }
    }
}
