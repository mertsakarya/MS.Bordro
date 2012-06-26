namespace MS.Bordro.Enumerations
{
    public enum Sex : byte { Male = 1, Female = 2, MAX = 2 }
    public enum EmployeeType : byte { Driver = 1, WhiteCollar = 2, BlueCollar = 3, MAX = 3 }
    public enum CalculationType : byte { Hourly = 1, Daily = 2, Monthly = 3, MAX = 3 }
    public enum MembershipCreateStatus : byte { Success = 1, DuplicateUserName, DuplicateEmail, InvalidPassword, InvalidEmail, InvalidAnswer, InvalidQuestion, InvalidUserName, ProviderError, UserRejected }
    public enum PhotoType : byte { Original = 0, Thumbnail = 1, Medium = 2, Large = 3, Icon = 4, MAX = 4 }

    public enum WorkRequestState : byte { Order = 1, OnDeparture = 2, Working = 3, OnReturn = 4, WorkFinished = 5, Accountable = 6, MAX =  6}
    public enum WorkerState : byte { AtWork = 1, MAX =  1 }
    public enum RouteInformationState : byte { OnDeparture = 1, OnReturn = 2, MAX = 2 }
}
