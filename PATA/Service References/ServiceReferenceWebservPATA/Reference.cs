﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PATA.ServiceReferenceWebservPATA {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DadosWEB", Namespace="http://schemas.datacontract.org/2004/07/WCFPata")]
    [System.SerializableAttribute()]
    public partial class DadosWEB : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PATA.ServiceReferenceWebservPATA.DiagnosticoWEB[] listaDiagnosticosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PATA.ServiceReferenceWebservPATA.SintomaWEB[] listaSintomasField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PATA.ServiceReferenceWebservPATA.DiagnosticoWEB[] listaDiagnosticos {
            get {
                return this.listaDiagnosticosField;
            }
            set {
                if ((object.ReferenceEquals(this.listaDiagnosticosField, value) != true)) {
                    this.listaDiagnosticosField = value;
                    this.RaisePropertyChanged("listaDiagnosticos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PATA.ServiceReferenceWebservPATA.SintomaWEB[] listaSintomas {
            get {
                return this.listaSintomasField;
            }
            set {
                if ((object.ReferenceEquals(this.listaSintomasField, value) != true)) {
                    this.listaSintomasField = value;
                    this.RaisePropertyChanged("listaSintomas");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DiagnosticoWEB", Namespace="http://schemas.datacontract.org/2004/07/WCFPata")]
    [System.SerializableAttribute()]
    public partial class DiagnosticoWEB : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PATA.ServiceReferenceWebservPATA.SintomaWEB[] listaSintomasField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nomeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string orgaoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string tratamentoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PATA.ServiceReferenceWebservPATA.SintomaWEB[] listaSintomas {
            get {
                return this.listaSintomasField;
            }
            set {
                if ((object.ReferenceEquals(this.listaSintomasField, value) != true)) {
                    this.listaSintomasField = value;
                    this.RaisePropertyChanged("listaSintomas");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nome {
            get {
                return this.nomeField;
            }
            set {
                if ((object.ReferenceEquals(this.nomeField, value) != true)) {
                    this.nomeField = value;
                    this.RaisePropertyChanged("nome");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string orgao {
            get {
                return this.orgaoField;
            }
            set {
                if ((object.ReferenceEquals(this.orgaoField, value) != true)) {
                    this.orgaoField = value;
                    this.RaisePropertyChanged("orgao");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string tratamento {
            get {
                return this.tratamentoField;
            }
            set {
                if ((object.ReferenceEquals(this.tratamentoField, value) != true)) {
                    this.tratamentoField = value;
                    this.RaisePropertyChanged("tratamento");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SintomaWEB", Namespace="http://schemas.datacontract.org/2004/07/WCFPata")]
    [System.SerializableAttribute()]
    public partial class SintomaWEB : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nomeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nome {
            get {
                return this.nomeField;
            }
            set {
                if ((object.ReferenceEquals(this.nomeField, value) != true)) {
                    this.nomeField = value;
                    this.RaisePropertyChanged("nome");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceWebservPATA.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/logIn", ReplyAction="http://tempuri.org/IService1/logInResponse")]
        string logIn(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/logIn", ReplyAction="http://tempuri.org/IService1/logInResponse")]
        System.Threading.Tasks.Task<string> logInAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/logOut", ReplyAction="http://tempuri.org/IService1/logOutResponse")]
        void logOut(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/logOut", ReplyAction="http://tempuri.org/IService1/logOutResponse")]
        System.Threading.Tasks.Task logOutAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/isAdmin", ReplyAction="http://tempuri.org/IService1/isAdminResponse")]
        bool isAdmin(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/isAdmin", ReplyAction="http://tempuri.org/IService1/isAdminResponse")]
        System.Threading.Tasks.Task<bool> isAdminAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/isLoggedIn", ReplyAction="http://tempuri.org/IService1/isLoggedInResponse")]
        bool isLoggedIn(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/isLoggedIn", ReplyAction="http://tempuri.org/IService1/isLoggedInResponse")]
        System.Threading.Tasks.Task<bool> isLoggedInAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/carregaXml", ReplyAction="http://tempuri.org/IService1/carregaXmlResponse")]
        bool carregaXml(string token, PATA.ServiceReferenceWebservPATA.DadosWEB dados);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/carregaXml", ReplyAction="http://tempuri.org/IService1/carregaXmlResponse")]
        System.Threading.Tasks.Task<bool> carregaXmlAsync(string token, PATA.ServiceReferenceWebservPATA.DadosWEB dados);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/lerSintomasXML", ReplyAction="http://tempuri.org/IService1/lerSintomasXMLResponse")]
        PATA.ServiceReferenceWebservPATA.SintomaWEB[] lerSintomasXML(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/lerSintomasXML", ReplyAction="http://tempuri.org/IService1/lerSintomasXMLResponse")]
        System.Threading.Tasks.Task<PATA.ServiceReferenceWebservPATA.SintomaWEB[]> lerSintomasXMLAsync(string token);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : PATA.ServiceReferenceWebservPATA.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<PATA.ServiceReferenceWebservPATA.IService1>, PATA.ServiceReferenceWebservPATA.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string logIn(string username, string password) {
            return base.Channel.logIn(username, password);
        }
        
        public System.Threading.Tasks.Task<string> logInAsync(string username, string password) {
            return base.Channel.logInAsync(username, password);
        }
        
        public void logOut(string token) {
            base.Channel.logOut(token);
        }
        
        public System.Threading.Tasks.Task logOutAsync(string token) {
            return base.Channel.logOutAsync(token);
        }
        
        public bool isAdmin(string token) {
            return base.Channel.isAdmin(token);
        }
        
        public System.Threading.Tasks.Task<bool> isAdminAsync(string token) {
            return base.Channel.isAdminAsync(token);
        }
        
        public bool isLoggedIn(string token) {
            return base.Channel.isLoggedIn(token);
        }
        
        public System.Threading.Tasks.Task<bool> isLoggedInAsync(string token) {
            return base.Channel.isLoggedInAsync(token);
        }
        
        public bool carregaXml(string token, PATA.ServiceReferenceWebservPATA.DadosWEB dados) {
            return base.Channel.carregaXml(token, dados);
        }
        
        public System.Threading.Tasks.Task<bool> carregaXmlAsync(string token, PATA.ServiceReferenceWebservPATA.DadosWEB dados) {
            return base.Channel.carregaXmlAsync(token, dados);
        }
        
        public PATA.ServiceReferenceWebservPATA.SintomaWEB[] lerSintomasXML(string token) {
            return base.Channel.lerSintomasXML(token);
        }
        
        public System.Threading.Tasks.Task<PATA.ServiceReferenceWebservPATA.SintomaWEB[]> lerSintomasXMLAsync(string token) {
            return base.Channel.lerSintomasXMLAsync(token);
        }
    }
}
