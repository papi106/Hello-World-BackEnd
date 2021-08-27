# Hello World
This is a sample text for test.
This app was made for BackEnd learning.

# Authors
Created by Patrick Păcurar within the Principal33 Solutions S.R.L. Internship.

# CI / CD
This is the workflow of the app.

![example workflow](https://github.com/papi106/Hello-World-BackEnd/actions/workflows/EF_Postgres_dotnet.yml/badge.svg)
# 
### EF_Postgres is actually the main branch.
#
## How to run locally using DockerHub

1. You must have DockerHub Desktop application and account. (Create account: https://hub.docker.com/)
2. Open cmd in the project folder.
3. Build the container image
```
docker build -t  hello-world-backend .
```
4. Start the app. This will create a container with random name.
```
docker run -dp :80 hello-world-backend
```
5. Verify if the app is working.
Open DockerHub, go at Containers/App tab and click on "Open in browser" button on the container that is runnig.
6. Rename the container.
Press the "Stop" button.
Go to the cmd.
```
docker rename <initialname> hello-world-backend-container
```
7. The app should work locally.

## How to deploy and run in heroku with docker

You need to have the application built on DockerHub (see above)

1. Have a heroku account. (Create: https://www.heroku.com/)
2. Install heroku CLI (https://devcenter.heroku.com/articles/heroku-cli)
3. Open cmd in the project folder.
4. Login to heroku.
```
heroku login
heroku container:login
```
4. Create an app in Heroku (skip if you have it already done on the site)
```
heroku create first-app-helloworld-patrickp (or another name if there already exists) --region eu 
```
5. Build the container image and push it.
```
heroku container:push -a first-app-helloworld-patrickp web
```
6. Release the container
```
heroku container:release -a first-app-helloworld-patrickp web
```
7. Go to the heroku website and open the app.
The app should work online.

#
### My heroku app link: https://first-app-helloworld-patrickp.herokuapp.com/