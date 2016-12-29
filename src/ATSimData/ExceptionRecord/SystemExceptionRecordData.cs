using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSimEntity;
using Dapper;
using System.Data;

namespace ATSimData.ExceptionRecord
{
    public class SystemExceptionRecordData : ISystemExceptionRecordData
    {
        private readonly ISqlCommand command;
        public SystemExceptionRecordData(ISqlCommand sqlCommand)
        {
            command = sqlCommand;
        }
        public void Add(SystemExceptionRecordEntity entity)
        {
            string sql = @"INSERT INTO SystemExceptionRecord(Name,HelpLink,Source,Message,StackTrace,HResult,Data,InnerException,CreateTime)
                           VALUES(?Name,?HelpLink,?Source,?Message,?StackTrace,?HResult,?Data,?InnerException,?CreateTime)";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("?Name", entity.Name, DbType.AnsiString);
            parameter.Add("?HelpLink", entity.HelpLink, DbType.AnsiString);
            parameter.Add("?Source", entity.Source, DbType.AnsiString);
            parameter.Add("?Message", entity.Message, DbType.String);
            parameter.Add("?StackTrace", entity.StackTrace, DbType.String);
            parameter.Add("?HResult", entity.HResult, DbType.Int32);
            parameter.Add("?Data", entity.Data, DbType.String);
            parameter.Add("?InnerException", entity.InnerException, DbType.String);
            parameter.Add("?CreateTime", entity.CreateTime, DbType.DateTime);
            command.Execute(sql, parameter, CommandType.Text);
        }
    }
}
