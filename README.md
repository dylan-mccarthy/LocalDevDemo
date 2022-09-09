# Local Microservices Development using Docker and Docker Compose

This demo shows how Docker and Docker compose can be used to help provide a consistant development experience across different IDE's and development platforms.

The repo consists of two branches (MacOS and Windows) with the only real difference being the docker-compose.override.yml file.

## Demo Project Structure

The demo project consists of 3 applications, one front end Blazor application and 2 backend APIs.

The backend APIs both call a database to provide data to the front end application.

Each application has a Dockerfile which is used for both building the application as well as running it.

## Docker Compose
Docker Compose is a tool that allows for multiple containers to be created at the same time. The configuration for this is stored within the docker-compose.yml file.

Each container within the compose file is defined by having the following elements

```yml
application-name:
  image: ${DOCKER_REGISTRY-}application-name
  hostname: application-name
  build:
    context: .
    dockerfile: Application/Dockerfile
  env_file:
  - .env.dev
```

The key parts here are the hostname, the dockerfile and the env_file.

The hostname will determine what DNS name the container is given within the docker network when running. To allow for consistancy within the configuration files this should be set to the expected hostname that application will have when running in a live environment.

The dockerfile links to the Dockerfile within each of the application directories, this will be used to build the images and start up the application.

The env_file is used to store environmental variables like credentials which you want to keep out of source control. This file should be created within the solution base directory and an example of this and another env file will be provided in this documentation. 

Within the docker-compose file for this demo is an extra container, this one is used to set up a local MySQL database and initilise it with some test data for the application. As this is not a part of the solution but instead downloaded from a image repository there is no need to define a dockerfile for it.

## Running the applications with Docker-Compose

How to run the application is dependant on the IDE and environment. 

For Visual Studio 2022 the docker-compose project should be selected as the start up project.

For Rider the following Run/Debug configuration was used
![Screen Shot 2022-09-09 at 4 22 26 pm](https://user-images.githubusercontent.com/61097819/189284824-cce38ec4-89b1-48e8-a232-6eb209c0fa4d.png)

To run using Visual Studio Code or the command line use the following:
docker-compose -f docker-compose.yml -f docker-compose.override.yml up --build

*Note, for debugging with VSCode the Docker Extension is required and can only be attached to a container after it is running.

The docker-compose.override.yml file is used to override elements within the docker-compose.yml file, this is useful when needing to define elements such as OS specific paths. In this example it is used to provide the path to the dotnet dev-certs location so that the applications can be run over HTTPS.

## Environment Files
To run the application two environment files need to be created. These files should not be included within source control as this is where credentials and secure information can defined. The .env file specifies environmental variables to be used in the creation of the container images, where as the .env.dev file is used to define environmental variables inside of the containers.

.env
```
MYSQL_PASSWORD=MYSQLPASS2022!
```

.env.dev
```
DB_PlanetConnection="Server=dbServer;Database=NightSkyDB;Uid=root;Pwd=MYSQLPASS2022!"
DB_GalaxyConnection="Server=dbServer;Database=NightSkyDB;Uid=root;Pwd=MYSQLPASS2022!"
```


The .env file is automatically picked up by default by the docker-compose tool where as the .env.dev file needs to be included in the docker-compose.yml file.
