/*
In computing, an event log is a file or database used to store events that occur in a system.
These events can include information about errors, warnings, system events, user activities, and more. 
Event logs are commonly used for troubleshooting, monitoring, and auditing purposes.

we can use it once exceptions are thrown in a try-catch block, even if we show the error message to the user,
but we need to log the error for trouleshooting and improvements

To run the Windows Event Viewer, you can follow these steps:

1-Open the Start Menu:
In Windows 10, you can click on the Windows icon in the bottom left corner of your screen.

2-Search for "Event Viewer":
Type "Event Viewer" into the search bar.

3-Open Event Viewer:
Click on the "Event Viewer" app that appears in the search results.

4-Navigate to Event Logs:
In the Event Viewer window, you'll see a left-hand navigation pane. Click on "Windows Logs" to expand it.

5-Choose a Log:
Under "Windows Logs," you'll find several logs like "Application," "Security," "Setup," "System," and more. 
Choose the log you're interested in viewing. For the example provided earlier, you would likely find the log entry in the "Application" log.

6-View Log Entries:
Click on the log you selected, and you'll see a list of log entries in the center pane. Look for the entry created by your C# program.
The logs in the Event Viewer contain information about various events on your system, including system errors, warnings, information events, and more. 
You can filter, sort, and search for specific events within the Event Viewer interface to help you locate the information you need.


After running this program, you can check the Windows Event Viewer to see the log entry. 
Open the Event Viewer, navigate to "Windows Logs," and select "Application" to view the log entries.
 
 */