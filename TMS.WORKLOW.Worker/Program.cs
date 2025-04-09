using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Temporalio.Client;
using Temporalio.Worker;
using TMS.FLOW.Application.Workflows;
using TMS.FLOW.Workflows;
using TMS.FLOW.Workflows.Activities;


var client = await TemporalClient.ConnectAsync(new("localhost:7233")
{
    LoggerFactory = LoggerFactory.Create(builder =>
        builder.
            AddSimpleConsole(options => options.TimestampFormat = "[HH:mm:ss] ").
            SetMinimumLevel(LogLevel.Information)),
});

using var tokenSource = new CancellationTokenSource();
Console.CancelKeyPress += (_, eventArgs) =>
{
    tokenSource.Cancel();
    eventArgs.Cancel = true;
};

var activities = new InitialActivity();

Console.WriteLine("Running worker");
using var worker = new TemporalWorker(
    client,
    new TemporalWorkerOptions(taskQueue: "my-task-queue").
        AddAllActivities(activities).
        AddWorkflow<InitialWorkflow>());
try
{
    await worker.ExecuteAsync(tokenSource.Token);
}
catch (OperationCanceledException)
{
    Console.WriteLine("Worker cancelled");
}
