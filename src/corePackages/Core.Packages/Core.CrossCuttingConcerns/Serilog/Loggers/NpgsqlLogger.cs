using Core.CrossCuttingConcerns.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Npgsql;
using NpgsqlTypes;
using Serilog;
using Serilog.Sinks.PostgreSQL;

namespace Core.CrossCuttingConcerns.Serilog.Loggers;

public class NpgsqlLogger: LoggerServiceBase
{
    public NpgsqlLogger(IConfiguration configuration)
    {
        PostgreSqlConfiguration logConfiguration =
            configuration.GetSection("SeriLogConfigurations:PostgreSqlConfiguration").Get<PostgreSqlConfiguration>()
            ?? throw new Exception(SerilogMessages.NullOptionsMessage);

        NpgsqlConnectionStringBuilder builder = new(logConfiguration.ConnectionString)
        {
            Pooling = false // Bağlantı havuzu kullanmamak için
        };

        IDictionary<string, ColumnWriterBase> columnWriters = new Dictionary<string, ColumnWriterBase>
        {
            { "MessageTemplate", new MessageTemplateColumnWriter() },
            { "Level", new LevelColumnWriter(true, NpgsqlDbType.Varchar) },
            { "TimeStamp", new TimestampColumnWriter(NpgsqlDbType.Timestamp) },
            { "Exception", new ExceptionColumnWriter(NpgsqlDbType.Text) }
        };

        global::Serilog.Core.Logger seriLogConfig = new LoggerConfiguration()
            .WriteTo.PostgreSQL(builder.ConnectionString, logConfiguration.TableName, columnWriters, needAutoCreateTable: logConfiguration.AutoCreateSqlTable)
            .CreateLogger();

        Logger = seriLogConfig;
    }
}