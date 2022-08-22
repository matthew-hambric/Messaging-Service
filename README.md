# Messaging-Service

bash```
cd src
docker build -f ./host/Dynamics.MessagingService.WebApi/Dockerfile . -t messaging-service

cd ..
docker compose up
```

http://localhost:9001/api/..
http://localhost:9002/api/..