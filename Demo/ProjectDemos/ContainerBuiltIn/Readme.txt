# create a new project and move to its directory
dotnet new mvc -n my-awesome-container-app
cd my-awesome-container-app

# add a reference to a (temporary) package that creates the container
dotnet add package Microsoft.NET.Build.Containers

# publish your project for linux-x64
# dotnet publish --os linux --arch x64 -c Release -p:PublishProfile=DefaultContainer
dotnet publish -c Release -r linux-x64 -p PublishProfile=DefaultContainer --self-contained

# run your app using the new container
docker run -it --rm -p 5010:80 my-awesome-container-app:1.0.0

# config docker container info
<PropertyGroup>
	<ContainerImageName>my-web-docker-app</ContainerImageName>
	<ContainerImageTag>1.0.1</ContainerImageTag>
</PropertyGroup>

# https://devblogs.microsoft.com/dotnet/announcing-builtin-container-support-for-the-dotnet-sdk/