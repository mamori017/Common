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
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.1.0.0")]
    internal sealed partial class SQLServerSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static SQLServerSettings defaultInstance = ((SQLServerSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new SQLServerSettings())));
        
        public static SQLServerSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("(local)\\SQL2014")]
        public string SqlServerName {
            get {
                return ((string)(this["SqlServerName"]));
            }
            set {
                this["SqlServerName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("sa")]
        public string SqlServerUser {
            get {
                return ((string)(this["SqlServerUser"]));
            }
            set {
                this["SqlServerUser"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Password12!")]
        public string SqlServerPw {
            get {
                return ((string)(this["SqlServerPw"]));
            }
            set {
                this["SqlServerPw"] = value;
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
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("74.205.54.20,104.197.110.30,104.197.145.181,146.148.85.29,67.225.139.254,67.225.1" +
            "38.82,67.225.139.144")]
        public string AppveyorBuildEnv {
            get {
                return ((string)(this["AppveyorBuildEnv"]));
            }
            set {
                this["AppveyorBuildEnv"] = value;
            }
        }
    }
}
