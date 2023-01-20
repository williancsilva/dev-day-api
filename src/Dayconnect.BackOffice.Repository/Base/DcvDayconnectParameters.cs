using DayFw.DataAccess.Interfaces;

namespace DevSecOps.backoffice.Repository.Base;

public class DcvDayconnectParameters : IConnectionParameters
{
    public bool UseDayFwConfigurationFile => true;
    public string SistemaDaycoval => "DAYSYSTEM_439";
    public string ConnectionName => "DCV_DAYCONNECT";
    public int? TimeOut { get; set; }
}