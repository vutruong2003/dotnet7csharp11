# Add this property to csproj file:

<PropertyGroup>
	<PublishAot>true</PublishAot>
</PropertyGroup>

# Then publish app:

dotnet publish -c release -r win-x64 -o C:\Net7Deployment\ConsoleApp01