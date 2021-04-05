# Работа с docker-compose
1. Заходим в папку images и командой 
   1. *(docker load -i rabbitmq.tar)*
   2. *(docker load -i postgres.tar)*
   2. *(docker load -i mongo.tar)*
   2. *(docker load -i redis.tar)*
   2. *(docker load -i elasticsearch.tar)*
   2. *(docker load -i logstash.tar)*
   2. *(docker load -i kibana.tar)*
   2. *(docker load -i minio.tar)*
   2. *(docker load -i netije.tar)*
2. После этого начинаем конфигурировать .env файл 
По default можешь нечего не изменять все заработает как надо. Пароль и логин от Kibana Admin Password1!

3. Создай сертификат и измени путь до твоего сертификата и пароль если он есть.
4. Завершающая команда docker-compose -f docker-compose.yml -f docker-compose.override.yml up.
5. Приложение начнет собираться, если хочешь без логов то добавь в конце команду -d тогда он запуститься в background. 