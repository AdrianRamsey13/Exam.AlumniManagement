﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExamWeb.MajorService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MajorDTO", Namespace="http://schemas.datacontract.org/2004/07/ExamWCF.DTOs")]
    [System.SerializableAttribute()]
    public partial class MajorDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Web.Mvc.SelectListItem[] FacultiesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> FacultyIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FacultyNamesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MajorIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MajorNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ModifiedDateField;
        
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
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Web.Mvc.SelectListItem[] Faculties {
            get {
                return this.FacultiesField;
            }
            set {
                if ((object.ReferenceEquals(this.FacultiesField, value) != true)) {
                    this.FacultiesField = value;
                    this.RaisePropertyChanged("Faculties");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> FacultyID {
            get {
                return this.FacultyIDField;
            }
            set {
                if ((this.FacultyIDField.Equals(value) != true)) {
                    this.FacultyIDField = value;
                    this.RaisePropertyChanged("FacultyID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FacultyNames {
            get {
                return this.FacultyNamesField;
            }
            set {
                if ((object.ReferenceEquals(this.FacultyNamesField, value) != true)) {
                    this.FacultyNamesField = value;
                    this.RaisePropertyChanged("FacultyNames");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MajorID {
            get {
                return this.MajorIDField;
            }
            set {
                if ((this.MajorIDField.Equals(value) != true)) {
                    this.MajorIDField = value;
                    this.RaisePropertyChanged("MajorID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MajorName {
            get {
                return this.MajorNameField;
            }
            set {
                if ((object.ReferenceEquals(this.MajorNameField, value) != true)) {
                    this.MajorNameField = value;
                    this.RaisePropertyChanged("MajorName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ModifiedDate {
            get {
                return this.ModifiedDateField;
            }
            set {
                if ((this.ModifiedDateField.Equals(value) != true)) {
                    this.ModifiedDateField = value;
                    this.RaisePropertyChanged("ModifiedDate");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MajorService.IMajorService")]
    public interface IMajorService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMajorService/GetMajors", ReplyAction="http://tempuri.org/IMajorService/GetMajorsResponse")]
        ExamWeb.MajorService.MajorDTO[] GetMajors();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMajorService/GetMajors", ReplyAction="http://tempuri.org/IMajorService/GetMajorsResponse")]
        System.Threading.Tasks.Task<ExamWeb.MajorService.MajorDTO[]> GetMajorsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMajorService/GetMajorsByFacultyID", ReplyAction="http://tempuri.org/IMajorService/GetMajorsByFacultyIDResponse")]
        ExamWeb.MajorService.MajorDTO[] GetMajorsByFacultyID(int facultyID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMajorService/GetMajorsByFacultyID", ReplyAction="http://tempuri.org/IMajorService/GetMajorsByFacultyIDResponse")]
        System.Threading.Tasks.Task<ExamWeb.MajorService.MajorDTO[]> GetMajorsByFacultyIDAsync(int facultyID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMajorService/GetMajorByID", ReplyAction="http://tempuri.org/IMajorService/GetMajorByIDResponse")]
        ExamWeb.MajorService.MajorDTO GetMajorByID(int majorID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMajorService/GetMajorByID", ReplyAction="http://tempuri.org/IMajorService/GetMajorByIDResponse")]
        System.Threading.Tasks.Task<ExamWeb.MajorService.MajorDTO> GetMajorByIDAsync(int majorID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMajorService/InsertMajor", ReplyAction="http://tempuri.org/IMajorService/InsertMajorResponse")]
        void InsertMajor(ExamWeb.MajorService.MajorDTO major);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMajorService/InsertMajor", ReplyAction="http://tempuri.org/IMajorService/InsertMajorResponse")]
        System.Threading.Tasks.Task InsertMajorAsync(ExamWeb.MajorService.MajorDTO major);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMajorService/UpdateMajor", ReplyAction="http://tempuri.org/IMajorService/UpdateMajorResponse")]
        void UpdateMajor(ExamWeb.MajorService.MajorDTO major);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMajorService/UpdateMajor", ReplyAction="http://tempuri.org/IMajorService/UpdateMajorResponse")]
        System.Threading.Tasks.Task UpdateMajorAsync(ExamWeb.MajorService.MajorDTO major);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMajorService/DeleteMajor", ReplyAction="http://tempuri.org/IMajorService/DeleteMajorResponse")]
        void DeleteMajor(int majorID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMajorService/DeleteMajor", ReplyAction="http://tempuri.org/IMajorService/DeleteMajorResponse")]
        System.Threading.Tasks.Task DeleteMajorAsync(int majorID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMajorService/GetFacultyIDByName", ReplyAction="http://tempuri.org/IMajorService/GetFacultyIDByNameResponse")]
        int GetFacultyIDByName(string facultyName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMajorService/GetFacultyIDByName", ReplyAction="http://tempuri.org/IMajorService/GetFacultyIDByNameResponse")]
        System.Threading.Tasks.Task<int> GetFacultyIDByNameAsync(string facultyName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMajorService/GetMajorIDByName", ReplyAction="http://tempuri.org/IMajorService/GetMajorIDByNameResponse")]
        int GetMajorIDByName(string majorName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMajorService/GetMajorIDByName", ReplyAction="http://tempuri.org/IMajorService/GetMajorIDByNameResponse")]
        System.Threading.Tasks.Task<int> GetMajorIDByNameAsync(string majorName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMajorServiceChannel : ExamWeb.MajorService.IMajorService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MajorServiceClient : System.ServiceModel.ClientBase<ExamWeb.MajorService.IMajorService>, ExamWeb.MajorService.IMajorService {
        
        public MajorServiceClient() {
        }
        
        public MajorServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MajorServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MajorServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MajorServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ExamWeb.MajorService.MajorDTO[] GetMajors() {
            return base.Channel.GetMajors();
        }
        
        public System.Threading.Tasks.Task<ExamWeb.MajorService.MajorDTO[]> GetMajorsAsync() {
            return base.Channel.GetMajorsAsync();
        }
        
        public ExamWeb.MajorService.MajorDTO[] GetMajorsByFacultyID(int facultyID) {
            return base.Channel.GetMajorsByFacultyID(facultyID);
        }
        
        public System.Threading.Tasks.Task<ExamWeb.MajorService.MajorDTO[]> GetMajorsByFacultyIDAsync(int facultyID) {
            return base.Channel.GetMajorsByFacultyIDAsync(facultyID);
        }
        
        public ExamWeb.MajorService.MajorDTO GetMajorByID(int majorID) {
            return base.Channel.GetMajorByID(majorID);
        }
        
        public System.Threading.Tasks.Task<ExamWeb.MajorService.MajorDTO> GetMajorByIDAsync(int majorID) {
            return base.Channel.GetMajorByIDAsync(majorID);
        }
        
        public void InsertMajor(ExamWeb.MajorService.MajorDTO major) {
            base.Channel.InsertMajor(major);
        }
        
        public System.Threading.Tasks.Task InsertMajorAsync(ExamWeb.MajorService.MajorDTO major) {
            return base.Channel.InsertMajorAsync(major);
        }
        
        public void UpdateMajor(ExamWeb.MajorService.MajorDTO major) {
            base.Channel.UpdateMajor(major);
        }
        
        public System.Threading.Tasks.Task UpdateMajorAsync(ExamWeb.MajorService.MajorDTO major) {
            return base.Channel.UpdateMajorAsync(major);
        }
        
        public void DeleteMajor(int majorID) {
            base.Channel.DeleteMajor(majorID);
        }
        
        public System.Threading.Tasks.Task DeleteMajorAsync(int majorID) {
            return base.Channel.DeleteMajorAsync(majorID);
        }
        
        public int GetFacultyIDByName(string facultyName) {
            return base.Channel.GetFacultyIDByName(facultyName);
        }
        
        public System.Threading.Tasks.Task<int> GetFacultyIDByNameAsync(string facultyName) {
            return base.Channel.GetFacultyIDByNameAsync(facultyName);
        }
        
        public int GetMajorIDByName(string majorName) {
            return base.Channel.GetMajorIDByName(majorName);
        }
        
        public System.Threading.Tasks.Task<int> GetMajorIDByNameAsync(string majorName) {
            return base.Channel.GetMajorIDByNameAsync(majorName);
        }
    }
}
