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
    internal sealed partial class SendMailSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static SendMailSettings defaultInstance = ((SendMailSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new SendMailSettings())));
        
        public static SendMailSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SendGridApiKey {
            get {
                return ((string)(this["SendGridApiKey"]));
            }
            set {
                this["SendGridApiKey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SmtpServer {
            get {
                return ((string)(this["SmtpServer"]));
            }
            set {
                this["SmtpServer"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("25")]
        public int SmtpPort {
            get {
                return ((int)(this["SmtpPort"]));
            }
            set {
                this["SmtpPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Test Subject")]
        public string Subject {
            get {
                return ((string)(this["Subject"]));
            }
            set {
                this["Subject"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Test Body")]
        public string Body {
            get {
                return ((string)(this["Body"]));
            }
            set {
                this["Body"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string From {
            get {
                return ((string)(this["From"]));
            }
            set {
                this["From"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("From")]
        public string FromName {
            get {
                return ((string)(this["FromName"]));
            }
            set {
                this["FromName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string To {
            get {
                return ((string)(this["To"]));
            }
            set {
                this["To"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("To")]
        public string ToName {
            get {
                return ((string)(this["ToName"]));
            }
            set {
                this["ToName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Cc {
            get {
                return ((string)(this["Cc"]));
            }
            set {
                this["Cc"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Cc")]
        public string CcName {
            get {
                return ((string)(this["CcName"]));
            }
            set {
                this["CcName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Bcc {
            get {
                return ((string)(this["Bcc"]));
            }
            set {
                this["Bcc"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Bcc")]
        public string BccName {
            get {
                return ((string)(this["BccName"]));
            }
            set {
                this["BccName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("..\\..\\Attachment\\Attachment.txt")]
        public string AttachmentPath_1 {
            get {
                return ((string)(this["AttachmentPath_1"]));
            }
            set {
                this["AttachmentPath_1"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("..\\..\\Attachment\\Attachment.md")]
        public string AttachmentPath_2 {
            get {
                return ((string)(this["AttachmentPath_2"]));
            }
            set {
                this["AttachmentPath_2"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("..\\..\\Attachment\\Attachment.cs")]
        public string AttachmentPath_3 {
            get {
                return ((string)(this["AttachmentPath_3"]));
            }
            set {
                this["AttachmentPath_3"] = value;
            }
        }
    }
}
