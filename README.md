<h1>Shows how to use the standard app.config/web.config connectionString for configuring also Log4Net-Appender.</h1>

<h2>Benefit:</h2>
Only one ConnectionString is easier to configure, to transform (deployment), to document - especially if you have a solution with more than one Host (WebService-Host; Unit-Tests; ...)

<h2>How ToDo:</h2>
Step 1: Create class "CustomLog4NetAdoNetAppender.cs"<br />
Step 2: Change 2 entries in app.config (See <appender name="SQLCEAppender"...> and remarks)<br />
 
You can also diff to commit: "Classic Log4Net Config" (3a10bae1e6e5d7175580093ca2324d270bb427f4) to see the small changes.
