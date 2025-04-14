# DaDataAddressApiFinal
 перевод кучи данных в удобный формат, отсеяв все ненужное
 
**DaDataAddressApiFinal** — это ASP.NET Core Web API, предназначенный для стандартизации и очистки адресов с использованием сервиса [DaData.ru](https://dadata.ru/).  
Проект подключает внешний API, принимает адрес в произвольном виде и возвращает очищенные, структурированные данные.

## Функционал:

Очистка и нормализация адресов
Внедрение зависимостей (DI)
AutoMapper 
Обработка исключений с помощью Middleware
Логирование с помощью Serilog
Стандартная CORS политика
Подключенный Swagger

## Использование
Для использования исправьте appsettings.json:

"DaData": {
  "Token": "ВАШ_ТОКЕН",
  "Secret": "ВАШ_СЕКРЕТ",
  "BaseUri": "https://cleaner.dadata.ru/api/v1/clean/address"
}

## Пример запроса:
https://localhost:7216/api/address?query=Воронеж, ул. Кольцовская, 6
### Результат:
{
  "source": "Воронеж, ул. Кольцовская, 6",
  "result": "г Воронеж, ул Кольцовская, д 6",
  "postal_code": "394036",
  "country": "Россия",
  "region": "Воронежская",
  "city": "Воронеж",
  "settlement": null,
  "street": "Кольцовская",
  "house": "6",
  "flat": null
}

Либо
https://localhost:7216/swagger/index.html (На Swagger)

## Изменения ответа
Чтобы поменять результат запроса, удалите или добавьте поля в классы AddressResponse и AddressResponse

**Всем спасибо!)**

