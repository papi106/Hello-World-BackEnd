#Hello World
Sample Text

#New branch EF change

## How to deploy to heroku
1. Having heroku account (Create account on https://dashboard.heroku.com/apps)
2. Log in to heroku
3. Create an app on heroku 
4. Choose the app where do you want to deploy 
5. Make sure that the deplyoment succeeded

Login to heroku
```
heroku login
```

Create a new Git repository (you need to be in the project folder where you want to build it)
```
git init
heroku git:remote -a first-app-helloworld-patrickp
```

Deploy the app
```
git add .
git commit -am "describe here what have you done"
git push heroku master
```

##How to build and deploy in docker
1. Having docker account (Create account on https://hub.docker.com/)
2. Installing docker hub on your desktop
3. Log in to docker 
4. Open cmd in the project you want to create a dockerfile (for e.g. C:\Projects\SSH_Hello_World\Hello-World-BackEnd\HelloWorldWeb\HelloWorldWeb)
5. Build docker file
6. Make sure the application works locally (go to docker application and open in browser the container that you have built)
7. Deploy docker using heroku
8. Open the app online from heroku apps, after releasing the container

Docker login
```
docker login
```

Docker build
```
docker build -t nameoftheproject .
```

Docker image list
```
docker image ls
```

Docker run
```
docker run -d -p 8081:80 --name nameoftheproject_container nameoftheproject
```

Login to heroku
```
heroku login
heroku container:login
```

Push container
```
heroku container:push -a first-app-helloworld-patrickp web
```

Release the container
```
heroku container:release -a first-app-helloworld-patrickp web
```